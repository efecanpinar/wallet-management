using PortfolioManagement.Domain.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Domain.Entities
{
    public class Transaction : EntityBase, IEntity
    {
        public string Amount { get; set; }
        public string TransactionPrice { get; set; }
        public string TotalPrice { get; set; }
        public string CoinName { get; set; }
        public string TransactionType { get; set; }
        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
    }
}
