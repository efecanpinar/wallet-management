using PortfolioManagement.Domain.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Domain.Entities
{
    public class Portfolio : EntityBase, IEntity
    {
        public string PortfolioName { get; set; }
        public int UserId { get; set; }    
        public User User { get; set; }
        public int WalletId { get; set; }
        public Wallet Wallet { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
