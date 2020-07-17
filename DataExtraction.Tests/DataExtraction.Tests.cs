using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DataExtraction.Tests
{
    public class Tests
    {
        [OneTimeSetUp]
        public void Setup()
        {
            // Should mock this.
            Extractor = new DataFromString();
            SampleDataInput1 = "18.93,20.25,17.05,16.59,21.09,16.22,21.43,27.13,18.62,21.31,23.96,25.52,19.64,23.49,15.28,22.77,23.1,26.58,27.03,23.75,27.39,15.93,17.83,18.82,21.56,25.33,25,19.33,22.08,24.03";
        }

        private DataFromString Extractor;
        private string SampleDataInput1;

        [Test]
        public void IsStringValidNumericCsv_WhenHasNonValidCharacter_ThrowsApplicationException()
        {
            Assert.Throws<ApplicationException>(() => Extractor.IsStringValidNumericCsv("10.1,abc,30.02,10.1"));
            Assert.Throws<ApplicationException>(() => Extractor.IsStringValidNumericCsv("10.1,_,30.02,10.1"));
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
            Assert.Throws<ApplicationException>(() => Extractor.IsStringValidNumericCsv(""));
        }

        [Test]
        public void GetPriceDataFromCsvString_WhenInvalidDataRetrieved_ThrowsApplicationException()
        {
            Assert.Throws<ApplicationException>(() => Extractor.GetPriceDataFromCsvString("abc"));
        }

        [Test]
        public void GetPriceDataFromCsvString_WhenNoDataRetrieved_ThrowsApplicationException()
        {
            Assert.Throws<ApplicationException>(() => Extractor.GetPriceDataFromCsvString(""));
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