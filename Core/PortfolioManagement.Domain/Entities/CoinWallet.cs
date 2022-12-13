using PortfolioManagement.Domain.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Domain.Entities
{
    public class CoinWallet : EntityBase, IEntity
    {
        public int CoinId { get; set; }
        public string AvarageBuyPrice { get; set; }
        public string AmountOfCoin { get; set; }
        public string TotalWelthOfCoin { get; set; }
        public Coin Coin { get; set; }
        public int WalletId { get; set; }
        public Wallet Wallet { get; set; }
    }
}
