using PortfolioManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Application.Abstractions
{
    public interface ICoinWalletService
    {
        Task AddCoinWallet(int coinId, int walletId);
        Task<IEnumerable<CoinWalletJoin>> GetUnifiedCoinWallet(int coinId, int walletId);
        Task<List<CoinWalletJoin>> GetUserWallet(int portfolioId);
    }
}
