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

            string priceString = DataSource.GetPricesStringFromSource(fullPath);

            Assert.That(priceString, Is.Null); 
        }

        [TestCase(@"..\..\..\..\SampleDataSets\ChallengeSampleDataSet1.txt")]
        [TestCase("\"..\\..\\..\\..\\SampleDataSets\\ChallengeSampleDataSet1.txt\"")]
        public void GetPriceStringFromSource_WhenFileFound_ReturnsString(string stringToTest)
        {
            string priceString = DataSource.GetPricesStringFromSource(stringToTest);

            Assert.That(priceString, Is.Not.Null);
        }
    }
}