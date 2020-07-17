using Repository;
using System;

namespace ProfitConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter data line:");

                string input = Console.ReadLine();

                var extractor = new DataExtraction.DataFromString();

                var calculator = new Calculator.ProfitCalculator();

                var priceData = extractor.GetPriceDataFromCsvString(input);

                var result = calculator.CalculateBiggestProfitFromPriceData(priceData);

                Console.WriteLine("Output below:");
                Console.WriteLine(result);
            } 
            catch (Exception ex)
            {
                string message = string.Concat("Exception occurred with message: \n", ex.Message);
                Console.WriteLine(message);
            }

            Console.WriteLine("Press Return to end.");
            Console.ReadLine();
            Environment.Exit(0);

        }
    }
}
