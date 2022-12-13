using PortfolioManagement.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Domain.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        ICoinRepository Coins { get; }
        IPortfolioRepository Portfolios { get; }
        ITransactionRepository Transactions { get; }
        IUserRepository Users { get; }
        IWalletRepository Wallets { get; }
        ICoinWalletRepository CoinWallets { get; }
        Task<int> SaveAsync();
    }
}
