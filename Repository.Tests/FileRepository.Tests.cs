using NUnit.Framework;

namespace FileRepository.Tests
{
    public class Tests
    {
        [OneTimeSetUp]
        public void Setup()
        {
            DataSource = new Repository.FileRepository();
        }

        private Repository.FileRepository DataSource;

        [Test]
        public void GetPriceStringFromSource_WhenFileNotFound_ReturnsNull()
        {
            string fullPath = @"C:\alsdkfjalsjkdf.txt";

            string priceString = DataSource.GetPriceStringFromSource(fullPath);

            Assert.That(priceString, Is.Null); 
        }

        [Test]
        public void GetPriceStringFromSource_WhenFileFound_ReturnsString()
        {
            string fullPath = @"..\..\..\..\SampleDataSets\ChallengeSampleDataSet1.txt";

            string priceString = DataSource.GetPriceStringFromSource(fullPath);

            Assert.That(priceString, Is.Not.Null);
        }
    }
}