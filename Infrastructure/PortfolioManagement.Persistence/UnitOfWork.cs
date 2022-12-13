using PortfolioManagement.Domain.Interfaces;
using PortfolioManagement.Domain.Interfaces.Repository;
using PortfolioManagement.Persistence.Contexts;
using PortfolioManagement.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PortfolioManagementDbContext _context;
        private CoinRepository _conCoinRepository;
        private PortfolioRepository _portfolioRepository;
        private TransactionRepository _transactionRepository;
        private UserRepository _userRepository;
        private WalletRepository _walletRepository;
        private CoinWalletRepository _coinWalletRepository;

        public UnitOfWork(PortfolioManagementDbContext context)
        {
            _context = context;
        }


        public ICoinRepository Coins => _conCoinRepository ?? new CoinRepository(_context);
        public IPortfolioRepository Portfolios => _portfolioRepository ?? new PortfolioRepository(_context);
        public ITransactionRepository Transactions => _transactionRepository ?? new TransactionRepository(_context);
        public IUserRepository Users => _userRepository ?? new UserRepository(_context);
        public IWalletRepository Wallets => _walletRepository ?? new WalletRepository(_context);
        public ICoinWalletRepository CoinWallets => _coinWalletRepository ?? new CoinWalletRepository(_context);
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

    }
}
