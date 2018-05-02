using System;
using System.Net.Http;
using System.Threading.Tasks;
using api.Models;
using Newtonsoft.Json;

namespace api.Services
{
    public class BotService
    {
        private static HttpClient _client;
 
        public BotService(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public double GetSellingAverageDay(string date)
        {
            string currency = "USD";
            string url = "https://iapi.bot.or.th/Stat/Stat-ExchangeRate/DAILY_AVG_EXG_RATE_V1/?start_period="+date+"&end_period="+date+"&currency="+currency;

            RootObject result = CallGet(url).Result;

            return Double.Parse(result.result.data.data_detail[0].selling);
        }

        public async Task<RootObject> CallGet(string url)
        {
            _client.DefaultRequestHeaders.Add("api-key", "U9G1L457H6DCugT7VmBaEacbHV9RX0PySO05cYaGsm");
            var response = await _client.GetStringAsync(url);
            var repositories = JsonConvert.DeserializeObject<RootObject>(response);

            return repositories;
        }
    }
}
