using Repository;
using System;

namespace ProfitConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool keepOnTrying = true;

            while (keepOnTrying)
            {
                try
                {
                    Console.WriteLine("Enter data text:");

                    string input = Console.ReadLine();

                    var extractor = new DataExtraction.PricesDataFromSource(new StringRepository());

                    var calculator = new Calculator.ProfitCalculator();

                    var priceData = extractor.GetPriceDataFromCsvString(input);

                    var result = calculator.CalculateBiggestProfitFromPriceData(priceData);

                    Console.WriteLine("Output below:");
                    Console.WriteLine(result);

                }
                catch (ApplicationException ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                }
                catch (Exception ex)
                {
                    string message = string.Concat("UNEXPECTED ERROR: \n", ex.Message);
                    Console.WriteLine(message);
                }

                Console.WriteLine("Keep on trying? (Y to continue)");

                var answer = Console.ReadKey(false);
                keepOnTrying = (answer.Key == ConsoleKey.Y);
                
                Console.WriteLine("\n");
            }

            Console.WriteLine("Press any key to end.");
            Console.ReadKey(false);
            Environment.Exit(0);

        }
    }
}
