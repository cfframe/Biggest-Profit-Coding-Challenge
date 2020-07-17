using System;
using System.Collections.Generic;
using System.Linq;


namespace Calculator
{
    public class ProfitCalculator
    {
        public string CalculateBiggestProfitFromPriceData(Dictionary<int, double?> priceData)
        {
            var maxProfitOptions = (from buy in priceData
                                    from sell in priceData
                                    where buy.Key < sell.Key && buy.Value < sell.Value
                                    select new
                                    {
                                        BuyDay = buy.Key,
                                        SellDay = sell.Key,
                                        BuyValue = buy.Value,
                                        SellValue = sell.Value,
                                        Profit = sell.Value - buy.Value
                                    }).OrderByDescending(po => po.Profit).FirstOrDefault();


            string result =
                (maxProfitOptions != null)
                ? string.Concat
                (
                    maxProfitOptions.BuyDay.ToString(),
                    "(", maxProfitOptions.BuyValue.ToString(), "),",
                    maxProfitOptions.SellDay.ToString(),
                    "(", maxProfitOptions.SellValue.ToString(), ")"
                )
                : "No profit available";


            return result;
        }
    }
}
