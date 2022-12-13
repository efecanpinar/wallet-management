using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Application.Abstractions
{
    public interface IWalletService
    {
        Task<int> InitialWalletCreate(int portfolioId);
        Task<int> GetCreatedWalletId(int portfolioId);
    }
}
