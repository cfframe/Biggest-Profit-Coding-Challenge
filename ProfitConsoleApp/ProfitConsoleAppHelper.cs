using System;
using System.IO;

namespace ProfitConsoleApp
{
    public class ProfitConsoleAppHelper
    {
        public enum DataSourceChoice 
        {
            Unassigned = 0,
            Exit = 1,
            Text = 2,
            File = 3
        }

        public DataSourceChoice DataSourceChoiceFromDisplayMenu()
        {
            ConsoleKey choiceKey;
            DataSourceChoice endChoice = DataSourceChoice.Unassigned;

            do
            {
                Console.WriteLine("Choose desired option from the following :");
                Console.WriteLine("1. Exit");
                Console.WriteLine("2. Enter raw prices data line at the command prompt");
                Console.WriteLine("3. Enter full path to file containing prices data");
                Console.Write("Choice: ");
                choiceKey = Console.ReadKey().Key;

                switch (choiceKey)
                {
                    case ConsoleKey.Escape:
                    case ConsoleKey.NumPad1:
                        choiceKey = ConsoleKey.D1;
                        break;
                    case ConsoleKey.NumPad2:
                        choiceKey = ConsoleKey.D2;
                        break;
                    case ConsoleKey.NumPad3:
                        choiceKey = ConsoleKey.D3;
                        break;
                }

                Console.WriteLine("\n");
            }
            while
            (
                choiceKey != ConsoleKey.D1
                && choiceKey != ConsoleKey.D2
                && choiceKey != ConsoleKey.D3
            );

            switch (choiceKey)
            {
                case ConsoleKey.D1:
                    endChoice = DataSourceChoice.Exit;
                    break;
                case ConsoleKey.D2:
                    endChoice = DataSourceChoice.Text;
                    break;
                case ConsoleKey.D3:
                    endChoice = DataSourceChoice.File;
                    break;
            }

            return endChoice;
        }
    }
}
