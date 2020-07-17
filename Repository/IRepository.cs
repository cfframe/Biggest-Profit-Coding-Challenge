using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    interface IRepository
    {
        public string GetPriceStringFromSource(string dataSource);
    }
}
