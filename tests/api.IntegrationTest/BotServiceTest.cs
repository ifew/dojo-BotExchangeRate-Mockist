using System;
using Xunit;
using api.Services;
using System.Net.Http;

namespace api.IntegrationTest
{
    public class BotServiceTest
    {
        [Fact]
        public void When_Selling_Amount_As_Of_1Feb2018_Should_Be_31_5408000THB()
        {
            HttpClient _client = new HttpClient();
            BotService botService = new BotService(_client);
            double actualSelling = botService.GetSellingAverageDay("2018-02-01");

            Assert.Equal(31.5408000, actualSelling);
        }
    }
}
