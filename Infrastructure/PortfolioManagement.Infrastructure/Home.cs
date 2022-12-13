using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using PortfolioManagement.Domain.Entities.API;

namespace PortfolioManagement.Infrastructure
{
    public class Home
    {
        [HttpPost]
        [Route("/Home")]
        public static List<CryptoCurrency> HomeIndex()
        {
            var client = new RestClient("https://api.binance.com/api/v3/ticker/24hr");
            var request = new RestRequest();

            RestResponse response = client.Execute(request);
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;

            var myJson = JsonConvert.DeserializeObject(response.Content, settings);
            JArray jsonArray = JArray.Parse(response.Content);


            List<string> childTokens = new List<string>();

            foreach (var childToken in jsonArray.Children())
            {
                childTokens.Add(childToken.ToString());
            }

            List<CryptoCurrency> _24HourExchangeList = new List<CryptoCurrency>();

            foreach (var x in childTokens)
            {
                _24HourExchangeList.Add(JsonConvert.DeserializeObject<CryptoCurrency>(x));
            }

            return _24HourExchangeList;
        }
    }
}
