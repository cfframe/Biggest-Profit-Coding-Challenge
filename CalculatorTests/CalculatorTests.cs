using Calculator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tests
{
    public class CalculatorTests
    {
        [SetUp]
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

            Assert.AreEqual(expectedResult, actualResult);
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

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}