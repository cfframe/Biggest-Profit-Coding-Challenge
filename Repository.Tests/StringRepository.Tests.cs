using NUnit.Framework;

namespace StringRepository.Tests
{
    public class Tests
    {
        // Nothing to test - dummy repository
        [OneTimeSetUp]
        public void Setup()
        {
            DataSource = new Repository.StringRepository();
        }

        private Repository.StringRepository DataSource;

    }
}