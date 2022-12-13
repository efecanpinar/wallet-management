using PortfolioManagement.Application.Abstractions;
using PortfolioManagement.Application.DTOs;
using PortfolioManagement.Domain.Entities;
using PortfolioManagement.Domain.Interfaces;
using PortfolioManagement.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Application.Services
{
    public class TransactionServices : ITransactionService
    {
        public enum Side
        {
            Buy = 1,
            Sell = 2
        }
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICoinService _coinService;
        private readonly IWalletService _walletService;
        private readonly ICoinWalletService _coinWalletService;
        public TransactionServices(IUnitOfWork unitOfWork, ICoinService coinService, IWalletService walletService, ICoinWalletService coinWalletService)
        {
            _unitOfWork = unitOfWork;
            _coinService = coinService;
            _walletService = walletService;
            _coinWalletService = coinWalletService;
        }
        public async Task<bool> ManageTransaction(CreateTransactionDto addTransactionDto, int instancePortfolioId)
        {
            var addedCoin = await _coinService.AddCoin(addTransactionDto);
            var addedWallet = await _walletService.GetCreatedWalletId(instancePortfolioId);

            await _coinWalletService.AddCoinWallet(addedCoin, addedWallet);
            await AddTransaction(addTransactionDto, instancePortfolioId);
            var unifiedWalletCoin = await _coinWalletService.GetUnifiedCoinWallet(addedCoin, addedWallet);

            var coin = await _unitOfWork.Coins.GetAllAsync(x => x.CoinName == addTransactionDto.CoinName);
            var coin2 = await _unitOfWork.CoinWallets.GetAllAsync(x => x.Coin == coin[0]);
            var x = coin2.Select(x => x.AmountOfCoin);
            if (addTransactionDto.TransactionType == "Sell" && Int32.Parse(addTransactionDto.CoinAmount) <= Int32.Parse(x.ToArray()[0]))
            {
                addTransactionDto.IsSuccess = true;
                await DoWalletTransaction(addTransactionDto, unifiedWalletCoin);
                return true;
            }
            else if (addTransactionDto.TransactionType != "Sell")
            {
                addTransactionDto.IsSuccess = true;
                await DoWalletTransaction(addTransactionDto, unifiedWalletCoin);
                return true;
            }
            else
            {

                addTransactionDto.IsSuccess = false;
                return false;
            }
        }

        public async Task AddTransaction(CreateTransactionDto addTransactionDto, int instancePortfolioId)
        {
            Transaction transaction = new Transaction
            {
                CoinName = addTransactionDto.CoinName,
                TotalPrice = addTransactionDto.CoinPrice,
                Amount = addTransactionDto.CoinAmount,
                PortfolioId = instancePortfolioId,
                TransactionPrice = addTransactionDto.TotalAmount,
                IsActive = true,
                IsDeleted = false,
                TransactionType = addTransactionDto.TransactionType.ToString()
            };
            await _unitOfWork.Transactions.AddAsync(transaction);
            await _unitOfWork.SaveAsync();
        }
        public async Task DoWalletTransaction(CreateTransactionDto createTransactionDto, IEnumerable<CoinWalletJoin> joinedCoinWallet)
        {

            if (createTransactionDto.TransactionType == "Buy")
            {
                await ManageProccess(createTransactionDto, joinedCoinWallet, Side.Buy);
            }
            else if (createTransactionDto.TransactionType == "Sell")
            {
                await ManageProccess(createTransactionDto, joinedCoinWallet, Side.Sell);
            }
        }
        public async Task ManageProccess(CreateTransactionDto createTransactionDto, IEnumerable<CoinWalletJoin> joinedCoinWallets, Side side)
        {
            var df = double.Parse(createTransactionDto.TotalAmount, CultureInfo.InvariantCulture);
            Wallet wallet = new Wallet();
            CoinWallet coinWallet = new CoinWallet();

            _unitOfWork.Wallets.DetachEntity();
            _unitOfWork.CoinWallets.DetachEntity();
            foreach (var joinedCoinWallet in joinedCoinWallets)
            {
                var totalWelthOfWallet = double.Parse(joinedCoinWallet.TotalWelthOfWallet, CultureInfo.InvariantCulture); 
                totalWelthOfWallet = totalWelthOfWallet + (side == Side.Buy ? 1 : -1) * double.Parse(createTransactionDto.TotalAmount, CultureInfo.InvariantCulture);
                wallet.TotalWealth = totalWelthOfWallet.ToString(CultureInfo.InvariantCulture);
         
                var amountOfCoin = double.Parse(joinedCoinWallet.AmountOfCoin, CultureInfo.InvariantCulture);
                amountOfCoin = amountOfCoin + (side == Side.Buy ? 1 : -1) * double.Parse(createTransactionDto.CoinAmount, CultureInfo.InvariantCulture);
                coinWallet.AmountOfCoin = amountOfCoin.ToString(CultureInfo.InvariantCulture);


                var totalWelthOfCoin = double.Parse(joinedCoinWallet.TotalWelthOfCoin, CultureInfo.InvariantCulture);
                totalWelthOfCoin = totalWelthOfCoin + (side == Side.Buy ? 1 : -1) * double.Parse(createTransactionDto.TotalAmount, CultureInfo.InvariantCulture);
                coinWallet.TotalWelthOfCoin = totalWelthOfCoin.ToString(CultureInfo.InvariantCulture);


                var avarage = totalWelthOfCoin / amountOfCoin;
                coinWallet.AvarageBuyPrice = avarage.ToString(CultureInfo.InvariantCulture);

                wallet.PortfolioId = joinedCoinWallet.PortfolioId;
                wallet.Id = joinedCoinWallet.WalletId;
                coinWallet.CoinId = joinedCoinWallet.CoinId;
                coinWallet.WalletId = joinedCoinWallet.WalletId;
                coinWallet.Id = joinedCoinWallet.CoinWalletId;
            }
            wallet.IsDeleted = false;
            wallet.IsActive = true;
            coinWallet.IsActive = true;
            coinWallet.IsDeleted = false;

            await _unitOfWork.CoinWallets.UpdateAsync(coinWallet);
            await _unitOfWork.Wallets.UpdateAsync(wallet); 
            await _unitOfWork.SaveAsync();
        }
    }
}
