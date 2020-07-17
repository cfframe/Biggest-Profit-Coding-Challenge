using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DataExtraction
{
    public class PricesDataFromSource
    {
        private IRepository Repository;

        public PricesDataFromSource(IRepository repository)
        {
            this.Repository = repository;
        }

        public string PricesStringFromSource(string dataSource)
        {
            string rawData = Repository.GetPricesStringFromSource(dataSource);

            return rawData;
        }

        public Dictionary<int, double?> GetPriceDataFromCsvString(string dataLine)
        {
            var priceData = new Dictionary<int, double?>();

            try
            {
                if (IsStringValidNumericCsv(dataLine))
                {
                    string[] dataArray = dataLine.Split(",");

                    for (int i = 1; i <= dataArray.Count(); i++)
                    {
                        try
                        {
                            priceData.Add(i, double.Parse(dataArray[i - 1]));
                        }
                        catch
                        {
                            throw new ApplicationException(string.Concat("Invalid data '" + dataArray[i - 1] + "' found at listed number position ", i.ToString(), "."));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return priceData;
        }

        public bool IsDictionaryValid(Dictionary<int, double?> itemToValidate)
        {

            return false;
        }

        public bool IsStringValidNumericCsv(string itemToValidate)
        {
            // TODO: to implement number comma pattern validation
            // Regex here seems to behave contrary to other regex conventions - doesn't accept \d or \.

            if (itemToValidate.Length == 0)
            {
                throw new ApplicationException("No data in supplied text.");
            }

            // Look for unwanted characters
            Regex invalidCharacterRegex = new Regex("[^0-9.,]");
            if (invalidCharacterRegex.IsMatch(itemToValidate))
            {
                throw new ApplicationException("Invalid data in supplied text.");
            }

            // TODO: regex for CSV pattern.
            //Regex r = new Regex("^([0-9]*.[0-9]{0-2},)*([0-9]*.[0-9]{0-2})$");
            //if (!r.IsMatch(itemToValidate))
            //{
            //    throw new ApplicationException("Invalid data in supplied text.");
            //}

            return true;
        }
    }
}
