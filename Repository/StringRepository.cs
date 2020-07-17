namespace Repository
{
    public class StringRepository : IRepository
    {
        public string GetPriceStringFromSource(string dataSource)
        {
            // Dummy repository, for when text entered directly via application.

            return dataSource;
        }
    }
}
