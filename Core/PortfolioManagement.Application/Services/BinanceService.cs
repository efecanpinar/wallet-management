using PortfolioManagement.BinanceOutbound;
using PortfolioManagement.Domain.Entities.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagement.Application.Services
{
    public class BinanceService
    {
        BinanceApi binance = new BinanceApi();
        public async Task<IEnumerable<CryptoCurrency>> GetCryptoCurrenciesAsync()
        {
            return await binance.GetCryptoCurrencies();
        }
    }
}
