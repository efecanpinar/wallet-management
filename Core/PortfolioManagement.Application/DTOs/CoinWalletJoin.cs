using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Application.DTOs
{
    public class CoinWalletJoin
    {
        public int CoinWalletId { get; set; }
        public string TotalWelthOfCoin { get; set; }
        public int WalletId { get; set; }
        public int CoinId { get; set; }
        public int PortfolioId { get; set; }
        public string CoinPrice { get; set; }
        public string TotalWelthOfWallet { get; set; }  
        public string AmountOfCoin { get; set; } 
        public string AvarageBuyPrice { get; set; } 
        public string CoinName { get; set; }
    }
}
