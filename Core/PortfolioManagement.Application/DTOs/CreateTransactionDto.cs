using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Application.DTOs
{
    public class CreateTransactionDto
    {
        public string CoinName { get; set; }
        public string CoinPrice { get; set; }
        public string CoinAmount { get; set; }
        public string TotalAmount { get; set; }
        public string TransactionType { get; set; }
        public bool IsSuccess { get; set; }
    }
}
