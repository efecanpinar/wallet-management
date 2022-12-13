using Azure;
using Azure.Core;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PortfolioManagement.Domain.Entities.API;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PortfolioManagement.Infrastructure.ExternalServices
{
    public class BinanceApiService
    {
        //public static List<CryptoCurrency> ListCurrencies()
        //{
        //    List<CryptoCurrency> cryptoCurrencies = new List<CryptoCurrency>();
        //    var client = new RestClient("https://api.binance.com/api/v3/ticker/24hr");
        //    var request = new RestRequest(client, Method.Get);
        //    RestResponse response = client.Execute(request);
        //    JsonSerializerSettings settings = new JsonSerializerSettings();
        //    settings.NullValueHandling = NullValueHandling.Ignore;

        //    var myJson = JsonConvert.DeserializeObject(response.Content, settings);
        //    JArray jsonArray = JArray.Parse(response.Content);

        //    return cryptoCurrencies;
        //}

    }
}
