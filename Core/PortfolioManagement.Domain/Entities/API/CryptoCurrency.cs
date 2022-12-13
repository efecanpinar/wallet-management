using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PortfolioManagement.Domain.Entities.API
{
    [Serializable]
    public class CryptoCurrency
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("openPrice")]
        public string OpenPrice { get; set; }

        [JsonPropertyName("prevClosePrice")]
        public string PrevClosePrice { get; set; } 

        [JsonPropertyName("avarageBuyPrice")]
        public string AvarageBuyPrice { get; set; }

        [JsonPropertyName("weightedAvgPrice")]
        public string WeightedAvgPrice { get; set; } 
    }
}
