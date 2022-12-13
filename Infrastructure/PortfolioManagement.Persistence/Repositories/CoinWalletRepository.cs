using Microsoft.EntityFrameworkCore;
using PortfolioManagement.Domain.Entities;
using PortfolioManagement.Domain.Interfaces.Repository;
using PortfolioManagement.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Persistence.Repositories
{
    public class CoinWalletRepository : GenericRepository<CoinWallet>, ICoinWalletRepository
    {
        public CoinWalletRepository(DbContext context) : base(context)
        {
        }
    }
}
