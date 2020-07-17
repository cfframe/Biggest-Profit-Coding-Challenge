using System;
using System.IO;

namespace Repository
{
    public class FileRepository : IRepository
    {
        public string GetPriceStringFromSource(string fullPath)
        {

            if (!File.Exists(fullPath))
            {
                return null;
            }

            string dataLine = File.ReadAllText(fullPath);

            return dataLine;
        }
    }
}
