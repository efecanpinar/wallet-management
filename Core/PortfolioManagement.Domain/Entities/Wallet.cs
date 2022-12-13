using PortfolioManagement.Domain.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Domain.Entities
{
    public class Wallet : EntityBase, IEntity
    {

        public string TotalWealth { get; set; }
        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }

        public ICollection<Coin> Coins { get; set; }
    }
}
