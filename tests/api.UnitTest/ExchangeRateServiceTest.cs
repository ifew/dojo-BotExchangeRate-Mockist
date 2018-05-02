using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using api.Services;
using Moq;
using Moq.Protected;
using Xunit;

namespace api.UnitTest
{
    public class ExchangeRateServiceTest
    {
        ExchangeRateService _exchangeRate;

        public ExchangeRateServiceTest()
        {
            Uri requestUri = new Uri("https://iapi.bot.or.th/Stat/Stat-ExchangeRate/DAILY_AVG_EXG_RATE_V1/?start_period=2018-02-01&end_period=2018-02-01&currency=USD");
            string expectedResponse = "{\"result\":{\"success\":\"true\",\"api\":\"Daily Weighted-average Interbank Exchange Rate - THB / USD\",\"timestamp\":\"2018-03-07 19:04:04\",\"data\":{\"data_header\":{\"report_name_eng\":\"Rates of Exchange of Commercial Banks in Bangkok Metropolis (2002-present)\",\"report_name_th\":\"\u0E2D\u0E31\u0E15\u0E23\u0E32\u0E41\u0E25\u0E01\u0E40\u0E1B\u0E25\u0E35\u0E48\u0E22\u0E19\u0E40\u0E09\u0E25\u0E35\u0E48\u0E22\u0E02\u0E2D\u0E07\u0E18\u0E19\u0E32\u0E04\u0E32\u0E23\u0E1E\u0E32\u0E13\u0E34\u0E0A\u0E22\u0E4C\u0E43\u0E19\u0E01\u0E23\u0E38\u0E07\u0E40\u0E17\u0E1E\u0E21\u0E2B\u0E32\u0E19\u0E04\u0E23 (2545-\u0E1B\u0E31\u0E08\u0E08\u0E38\u0E1A\u0E31\u0E19)\",\"report_uoq_name_eng\":\"(Unit : Baht / 1 Unit of Foreign Currency)\",\"report_uoq_name_th\":\"(\u0E2B\u0E19\u0E48\u0E27\u0E22 : \u0E1A\u0E32\u0E17 \u0E15\u0E48\u0E2D 1 \u0E2B\u0E19\u0E48\u0E27\u0E22\u0E40\u0E07\u0E34\u0E19\u0E15\u0E23\u0E32\u0E15\u0E48\u0E32\u0E07\u0E1B\u0E23\u0E30\u0E40\u0E17\u0E28)\",\"report_source_of_data\":[{\"source_of_data_eng\":\"Bank of Thailand\",\"source_of_data_th\":\"\u0E18\u0E19\u0E32\u0E04\u0E32\u0E23\u0E41\u0E2B\u0E48\u0E07\u0E1B\u0E23\u0E30\u0E40\u0E17\u0E28\u0E44\u0E17\u0E22\"}],\"report_remark\":[{\"report_remark_eng\":\"Since Nov 16, 2015 the data regarding Buying Transfer Rate of PKR has been changed to Buying Rate using Foreign Exchange Rates (THOMSON REUTERS) with Bangkok Market Crossing.\",\"report_remark_th\":\"\u0E15\u0E31\u0E49\u0E07\u0E41\u0E15\u0E48\u0E27\u0E31\u0E19\u0E17\u0E35\u0E48 16 \u0E1E.\u0E22. 2558 \u0E02\u0E49\u0E2D\u0E21\u0E39\u0E25\u0E43\u0E19\u0E2D\u0E31\u0E15\u0E23\u0E32\u0E0B\u0E37\u0E49\u0E2D\u0E40\u0E07\u0E34\u0E19\u0E42\u0E2D\u0E19\u0E02\u0E2D\u0E07\u0E2A\u0E01\u0E38\u0E25 PKR \u0E44\u0E14\u0E49\u0E40\u0E1B\u0E25\u0E35\u0E48\u0E22\u0E19\u0E40\u0E1B\u0E47\u0E19\u0E2D\u0E31\u0E15\u0E23\u0E32\u0E0B\u0E37\u0E49\u0E2D\u0E17\u0E35\u0E48\u0E43\u0E0A\u0E49\u0E2D\u0E31\u0E15\u0E23\u0E32\u0E43\u0E19\u0E15\u0E25\u0E32\u0E14\u0E15\u0E48\u0E32\u0E07\u0E1B\u0E23\u0E30\u0E40\u0E17\u0E28 (\u0E17\u0E2D\u0E21\u0E2A\u0E31\u0E19\u0E23\u0E2D\u0E22\u0E40\u0E15\u0E2D\u0E23\u0E4C) \u0E04\u0E33\u0E19\u0E27\u0E13\u0E1C\u0E48\u0E32\u0E19\u0E2D\u0E31\u0E15\u0E23\u0E32\u0E0B\u0E37\u0E49\u0E2D\u0E02\u0E32\u0E22\u0E40\u0E07\u0E34\u0E19\u0E14\u0E2D\u0E25\u0E25\u0E32\u0E23\u0E4C \u0E2A\u0E23\u0E2D. \u0E43\u0E19\u0E15\u0E25\u0E32\u0E14\u0E01\u0E23\u0E38\u0E07\u0E40\u0E17\u0E1E\u0E2F\"}],\"last_updated\":\"2018-03-07\"},\"data_detail\":[{\"period\":\"2018-02-01\",\"currency_id\":\"USD\",\"currency_name_th\":\"\u0E2A\u0E2B\u0E23\u0E31\u0E10\u0E2D\u0E40\u0E21\u0E23\u0E34\u0E01\u0E32 : \u0E14\u0E2D\u0E25\u0E25\u0E32\u0E23\u0E4C (USD)\",\"currency_name_eng\":\"USA : DOLLAR (USD) \",\"buying_sight\":\"31.0936000\",\"buying_transfer\":\"31.1806000\",\"selling\":\"31.5408000\",\"mid_rate\":\"31.3607000\"}]}}}";
 
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(expectedResponse) };
            var mockHandler = new Mock<HttpClientHandler>();
            mockHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(mockResponse));

            var _client = new HttpClient(mockHandler.Object);

            _exchangeRate = new ExchangeRateService(_client);
        }

        [Theory]
        [InlineData(1, 32.33)]
        [InlineData(100, 3232.94)]
        [InlineData(101, 3254.12)]
        [InlineData(499, 16077.25)]
        [InlineData(500, 16109.47)]
        [InlineData(501, 16117.98)]
        [InlineData(1000, 32171.62)]
        public void When_Exchange_Rate_As_Of_1Feb2018_And_Plus_Fee(double inputAmountUSD, double expectedAmountTHB)
        {
            double actualResult = _exchangeRate.ExchangeRate(inputAmountUSD, "2018-02-01");

            Assert.Equal(expectedAmountTHB, actualResult);
        }

        [Fact]
        public void When_Exchange_Rate_0USD_Should_Be_0THB()
        {
            double actualResult = _exchangeRate.ExchangeRate(0.00, "2018-02-01");

            Assert.Equal(0, actualResult);
        }

        [Fact]
        public void When_Exchange_Rate_0_1USD_Should_Be_0THB()
        {
            double actualResult = _exchangeRate.ExchangeRate(0.10, "2018-02-01");

            Assert.Equal(0, actualResult);
        }

        [Theory]
        [InlineData(1, 0.0250)]
        [InlineData(100, 0.0250)]
        [InlineData(101, 0.0215)]
        [InlineData(499, 0.0215)]
        [InlineData(500, 0.0215)]
        [InlineData(501, 0.0200)]
        [InlineData(1000, 0.0200)]
        public void When_Input_Amount_And_Get_Fee(double inputAmountUSD, double expectedAmountTHB)
        {
            double actualResult = _exchangeRate._GetFee(inputAmountUSD);

            Assert.Equal(expectedAmountTHB, actualResult);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(1.014, 1.02)]
        [InlineData(1.015, 1.02)]
        [InlineData(1.016, 1.02)]
        [InlineData(1.004, 1.01)]
        [InlineData(1.005, 1.01)]
        [InlineData(1.006, 1.01)]
        public void When_Input_Number3Digit_And_Get_Number2Digit(double inputNumber2Digit, double expectedNumber2Digit)
        {
            double actualResult = _exchangeRate._RoundCeiling2Digit(inputNumber2Digit);

            Assert.Equal(expectedNumber2Digit, actualResult);
        }
        
        [Theory]
        [InlineData(10, 0.0250, 10.25)]
        [InlineData(10.01, 0.0250, 10.27)]
        [InlineData(10.001, 0.0250, 10.26)]
        public void When_Input_AmountWithFee_And_Get_Number2Digit(double inputAmount, double inputFee, double expectedNumber2Digit)
        {
            double actualResult = _exchangeRate.CalculateAmountWithFee(inputAmount, inputFee);

            Assert.Equal(expectedNumber2Digit, actualResult);
        }
    }
}
