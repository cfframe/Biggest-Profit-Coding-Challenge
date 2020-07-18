using System;
using System.IO;

namespace Repository
{
    public class FileRepository : IRepository
    {
        public string GetPricesStringFromSource(string fullPath)
        {
            if (fullPath.StartsWith("\"") && fullPath.EndsWith("\""))
            {
                fullPath = fullPath.Replace("\"","");
            }

            if (!File.Exists(fullPath))
            {
                return null;
            }

            string dataLine = File.ReadAllText(fullPath);

            return dataLine;
        }
    }
}
