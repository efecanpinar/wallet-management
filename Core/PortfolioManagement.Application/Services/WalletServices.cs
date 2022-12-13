using PortfolioManagement.Application.Abstractions;
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
    public class WalletServices : IWalletService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WalletServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> InitialWalletCreate(int portfolioId) 
        {
            Wallet wallet = new Wallet
            {
                IsActive = true,
                IsDeleted = false,
                TotalWealth = "0",
                PortfolioId = portfolioId

            };
            await _unitOfWork.Wallets.AddAsync(wallet);
            await _unitOfWork.SaveAsync();
            return wallet.Id;
        }

        public async Task<int> GetCreatedWalletId(int portfolioId)
        {
            var wallet = await _unitOfWork.Wallets.GetAsync(x => x.PortfolioId == portfolioId);
            return wallet.Id;
        }
    }
}
