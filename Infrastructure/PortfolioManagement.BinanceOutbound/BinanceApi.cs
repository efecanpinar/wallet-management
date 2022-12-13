using PortfolioManagement.Domain.Entities.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PortfolioManagement.BinanceOutbound
{
    public class BinanceApi
    {
        static readonly HttpClient client = new HttpClient();
        private IEnumerable<CryptoCurrency> binanceApiCoins = Array.Empty<CryptoCurrency>();

        public async Task<IEnumerable<CryptoCurrency>> GetCryptoCurrencies()
        {
            HttpResponseMessage response = await client.GetAsync("https://api.binance.com/api/v3/ticker/24hr");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                IEnumerable<CryptoCurrency>? test = JsonSerializer.Deserialize<IEnumerable<CryptoCurrency>>(responseBody);
                if (test?.Count() > 0)
                    return test;
            }
            throw new HttpRequestException();
        }

    }
}
