using PortfolioManagement.Application.Abstractions;
using PortfolioManagement.Application.DTOs;
using PortfolioManagement.Domain.Entities;
using PortfolioManagement.Domain.Interfaces;
using PortfolioManagement.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Application.Services
{
    public class CoinServices : ICoinService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoinServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> AddCoin(CreateTransactionDto addCoinDto)
        {
            var isExist = await _unitOfWork.Coins.AnyAsync(x => x.CoinName == addCoinDto.CoinName);

            if (isExist)
            {
                var coin = await _unitOfWork.Coins.GetAllAsync(x => x.CoinName == addCoinDto.CoinName);
                var coinId = coin.Select(x => x.Id).FirstOrDefault();
                return coinId;
            }
            else
            {
                Coin addCoin = new Coin
                {
                    CoinName = addCoinDto.CoinName,
                    CoinPrice = addCoinDto.CoinPrice
                };
                await _unitOfWork.Coins.AddAsync(addCoin);
                await _unitOfWork.SaveAsync();
                return addCoin.Id; 
            }

        }
    }
}
