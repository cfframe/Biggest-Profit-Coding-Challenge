using NUnit.Framework;

namespace StringRepository.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            DataSource = new Repository.StringRepository();
        }

        private Repository.StringRepository DataSource;

        [Test]
        public void GetPriceStringFromSource_WhenStringIsEmpty_ReturnsNull()
        {
            string priceString = DataSource.GetPriceStringFromSource(string.Empty);

            Assert.IsNull(priceString);
        }

        [Test]
        public void GetPriceStringFromSource_WhenFileFound_ReturnsString()
        {
            string fullPath = @"..\..\..\..\SampleDataSets\ChallengeSampleDataSet1.txt";

            string priceString = DataSource.GetPriceStringFromSource(fullPath);

            Assert.IsNotNull(priceString);
        }
    }
}