using Moq;
using NUnit.Framework;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DataExtraction.Tests
{
    public class Tests
    {
        private Mock<IRepository> MockRepository;
        private PricesDataFromSource Extractor;
        private string SampleDataInput1;
        
        [OneTimeSetUp]
        public void Setup()
        {
            MockRepository = new Mock<IRepository>();
            Extractor = new PricesDataFromSource(MockRepository.Object);
            SampleDataInput1 = "18.93,20.25,17.05,16.59,21.09,16.22,21.43,27.13,18.62,21.31,23.96,25.52,19.64,23.49,15.28,22.77,23.1,26.58,27.03,23.75,27.39,15.93,17.83,18.82,21.56,25.33,25,19.33,22.08,24.03";
        }

        [Test]
        public void Constructor_WhenRepositoryIsNull_ThrowArgumentNullException()
        {
            Assert.That(() => new PricesDataFromSource(null), Throws.TypeOf<ArgumentNullException>());
        }

        [TestCase("10.1,abc,30.02,10.1")]
        [TestCase("10.1,_,30.02,10.1")]
        [TestCase("")]
        [TestCase(null)]
        public void IsStringValidNumericCsv_WhenHasNonValidCharacterOrIsEmpty_ThrowsApplicationException(string stringToValidate)
        {
            Assert.That(() => Extractor.IsStringValidNumericCsv(stringToValidate), Throws.TypeOf<ApplicationException>());
        }

        [Test]
        public void IsStringValidNumericCsv_WhenHasOnlyValidCharacters_IsTrue()
        {
            Assert.That(Extractor.IsStringValidNumericCsv(SampleDataInput1), Is.True);
        }

        //[Test]
        //public void IsStringValidNumericCsv_WhenValid_ReturnsTrue()
        //{
        //    Regex r = new Regex("^[[0-9]*.[0-9]{0-2},]*[0-9]*.[0-9]{0-2}$");
        //    string itemToValidate = "10.1,20.2,30.02,10.1";

        //    bool isMatch = r.IsMatch(itemToValidate);

        //    Assert.That(isMatch, Is.True);
        //}

        [Test]
        public void IsStringValidNumericCsv_WhenLength0_ThrowsApplicationException()
        {
            Assert.That(() => Extractor.IsStringValidNumericCsv(""), Throws.TypeOf<ApplicationException>());
        }

        [TestCase("abc")]
        [TestCase(".")]
        public void GetPriceDataFromDataSource_WhenInvalidDataRetrieved_ThrowsApplicationException(string dataSource)
        {
            Assert.That(() => Extractor.GetPriceDataFromDataSource(dataSource), Throws.TypeOf<ApplicationException>());
        }

        [TestCase("abc")]
        [TestCase(".")]
        [TestCase("12.1,12.1,a")]
        public void GetPriceDataFromCsvString_WhenInvalidDataRetrieved_ThrowsApplicationException(string csvString)
        {
            Assert.That(() => Extractor.GetPriceDataFromCsvString(csvString), Throws.TypeOf<ApplicationException>());
        }

        [Test]
        public void GetPriceDataFromCsvString_WhenNoDataRetrieved_ThrowsApplicationException()
        {
            Assert.That(() => Extractor.GetPriceDataFromCsvString(""), Throws.TypeOf<ApplicationException>());
        }

        [Test]
        public void GetPriceDataFromCsvString_WhenValidDataInput_ReturnsEquivalentDictionary()
        {
            string data = "10.1,20.02,30.02,10.1";

            var expectedResult = new Dictionary<int, double?> {
                { 1, 10.1 } ,
                { 2, 20.02 } ,
                { 3, 30.02 } ,
                { 4, 10.1 }
            };

            var actualResult = Extractor.GetPriceDataFromCsvString(data);

            Assert.IsTrue(expectedResult.Count == actualResult.Count && !expectedResult.Except(actualResult).Any());
        }
    }
}