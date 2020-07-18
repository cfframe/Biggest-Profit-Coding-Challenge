using Repository;
using System;

namespace ProfitConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dataSourceChoice = ProfitConsoleAppHelper.DataSourceChoice.Unassigned;
            var helper = new ProfitConsoleAppHelper();

            string input = string.Empty;
            IRepository repository = null;

            while (dataSourceChoice != ProfitConsoleAppHelper.DataSourceChoice.Exit)
            {
                dataSourceChoice = helper.DataSourceChoiceFromDisplayMenu();
                
                switch (dataSourceChoice)
                {
                    case ProfitConsoleAppHelper.DataSourceChoice.Exit:
                        Environment.Exit(0);
                        break;
                    case ProfitConsoleAppHelper.DataSourceChoice.Text:
                        Console.WriteLine("Enter raw data at line below and press Enter:");
                        repository = new StringRepository();
                        break;
                    case ProfitConsoleAppHelper.DataSourceChoice.File:
                        Console.WriteLine("Enter full file path and press Enter:");
                        repository = new FileRepository();
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }

                try
                {
                    input = Console.ReadLine();

                    var extractor = new DataExtraction.PricesDataFromSource(repository);

                    var calculator = new Calculator.ProfitCalculator();

                    var priceData = extractor.GetPriceDataFromDataSource(input);

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

                Console.WriteLine("\n");
            }

            Console.WriteLine("Press any key to end.");
            Console.ReadKey(false);

        }
    }
}
