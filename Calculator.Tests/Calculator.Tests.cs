using NUnit.Framework;
using System.Collections.Generic;

namespace Calculator.Tests
{
    public class Tests
    {
        [OneTimeSetUp]
        public void Setup()
        {
            Calculator = new ProfitCalculator();
        }

        private ProfitCalculator Calculator;
        
        [Test]
        public void CalculateBiggestProfit_WhenOneValidBuySellPairExists_ReturnsExpectedResult()
        {
            var priceData = new Dictionary<int, double?> {
                { 1, 10.1 } ,
                { 2, 20.02 } ,
                { 3, 30.02 } ,
                { 4, 10.1 }
            };

            string expectedResult = "1(10.1),3(30.02)";

            string actualResult = Calculator.CalculateBiggestProfitFromPriceData(priceData);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CalculateBiggestProfit_WhenGoodSellDayNotExists_ReturnsMessage()
        {
            var testDataWithProfit = new Dictionary<int, double?> {
                { 1, 40.1 } ,
                { 2, 30.00 } ,
                { 3, 20.02 } ,
                { 4, 10.00 }
            };

            string expectedResult = @"No profit available";
            string actualResult = Calculator.CalculateBiggestProfitFromPriceData(testDataWithProfit);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}