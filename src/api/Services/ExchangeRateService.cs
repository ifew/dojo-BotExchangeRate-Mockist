using System;
using System.Net.Http;

namespace api.Services
{
    public class ExchangeRateService
    {
        private static HttpClient _client;

        public ExchangeRateService(HttpClient httpClient)
        {
            _client = httpClient;
        }
        
        double sellingPriceBOT = 0;
        public void GetSellingPrice(string date) {
            BotService botService = new BotService(_client);
            sellingPriceBOT = botService.GetSellingAverageDay(date);
        }

        public double ExchangeRate(double inputAmountUSD, string date)
        {
            GetSellingPrice(date);

            if (inputAmountUSD >= 1)
            {
                double inputAmount = inputAmountUSD * sellingPriceBOT;
                double fee = _GetFee(inputAmountUSD);
                return CalculateAmountWithFee(inputAmount, fee);
            }
            else
            {
                return 0;
            }
        }
        public double CalculateAmountWithFee(double inputAmount, double fee)
        {
            double amountWithFee = inputAmount + (inputAmount * fee);

            return _RoundCeiling2Digit(amountWithFee);
        }

        public double _GetFee(double inputAmount)
        {
            if (inputAmount <= 100)
            {
                return 0.0250;
            }
            else if (inputAmount > 100 && inputAmount <= 500)
            {
                return 0.0215;
            }
            else
            {
                return 0.0200;
            }
        }

        public double _RoundCeiling2Digit(double number)
        {
            double result = Math.Round(Math.Ceiling(number * 100) / 100, 2, MidpointRounding.AwayFromZero);

            return result;
        }
    }
}
