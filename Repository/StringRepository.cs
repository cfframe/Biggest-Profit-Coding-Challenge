using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class StringRepository : IRepository
    {
        public string GetPriceStringFromSource(string dataSource)
        {
            if (dataSource.Length == 0)
            {
                return null;
            }

            return dataSource;
        }
    }
}
