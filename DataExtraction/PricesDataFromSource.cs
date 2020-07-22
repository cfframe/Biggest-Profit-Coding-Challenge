using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

[assembly: InternalsVisibleTo("DataExtraction.Tests")]

namespace DataExtraction
{
    public class PricesDataFromSource
    {
        private IRepository Repository;

        public PricesDataFromSource(IRepository repository)
        {
            this.Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Dictionary<int, double?> GetPriceDataFromDataSource(string dataSource)
        {
            string dataLine = Repository.GetPricesStringFromSource(dataSource);

            Dictionary<int, double?> result = null;

            if (IsStringValidNumericCsv(dataLine))
            {
                result = GetPriceDataFromCsvString(dataLine);
            }

            return result;
        }

        internal Dictionary<int, double?> GetPriceDataFromCsvString(string dataLine)
        {
            var priceData = new Dictionary<int, double?>();

            try
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
            catch (Exception ex)
            {
                throw ex;
            }

            return priceData;
        }

        internal bool IsStringValidNumericCsv(string itemToValidate)
        {
            if (string.IsNullOrEmpty(itemToValidate) || string.IsNullOrWhiteSpace(itemToValidate))
            {
                throw new ApplicationException("No data supplied.");
            }

            // Assumes following string formats are acceptable for interpretation as double with up to 2 dec places:
            // [0-9]+.[0-9]{1,2} eg 1234.5, 1234.56
            // [0-9]+. eg 1., 12.
            // .[0-9]{1,2} eg .1, .12
            // [0-9]+ e.g. 1, 12
            Regex r = new Regex(@"^([0-9]+\.[0-9]{1,2}|[0-9]+\.|\.[0-9]{1,2}|[0-9]+)(,([0-9]+\.[0-9]{1,2}|[0-9]+\.|\.[0-9]{1,2}|[0-9]+))*$");
            
            if (!r.IsMatch(itemToValidate))
            {
                throw new ApplicationException("Data is invalid.");
            }

            return true;
        }
    }
}
