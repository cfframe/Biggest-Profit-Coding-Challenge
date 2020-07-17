using System;
using System.Collections.Generic;
using System.Linq;

namespace DataExtraction
{
    public class DataFromString
    {
        public Dictionary<int, double?> GetPriceDataFromCsvString(string dataLine)
        {

            var priceData = new Dictionary<int, double?>();

            try
            {
                if (IsCsvStringValid(dataLine))
                {
                    string[] dataArray = dataLine.Split(",");

                    for (int i = 0; i < dataArray.Count(); i++)
                    {
                        try
                        {
                            priceData.Add(i + 1, double.Parse(dataArray[i]));
                        }
                        catch
                        {
                            throw new ApplicationException(string.Concat("Invalid data found at index ", i.ToString(), "."));
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

        public bool IsCsvStringValid(string stringToValidate)
        {
            //// TODO: to implement
            if (stringToValidate.Length == 0)
            {
                throw new ApplicationException("No data in supplied text.");
            }

            return true;
        }
    }
}
