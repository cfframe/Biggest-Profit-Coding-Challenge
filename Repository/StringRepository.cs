namespace Repository
{
    public class StringRepository : IRepository
    {
        public string GetPricesStringFromSource(string dataSource)
        {
            // Dummy repository, for when text entered directly via application.

            return dataSource;
        }
    }
}
