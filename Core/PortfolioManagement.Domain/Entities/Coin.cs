using PortfolioManagement.Domain.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Domain.Entities
{
    public class Coin : EntityBase, IEntity
    {
        public string CoinName { get; set; }
        public string CoinPrice { get; set; }
        public ICollection<Wallet> Wallets { get; set; } 
    }
}
