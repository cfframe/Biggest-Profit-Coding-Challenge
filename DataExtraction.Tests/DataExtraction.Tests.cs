using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataExtraction.Tests
{
    public class Tests
    {

        //SampleDataInput1 = "18.93,20.25,17.05,16.59,21.09,16.22,21.43,27.13,18.62,21.31,23.96,25.52,19.64,23.49,15.28,22.77,23.1,26.58,27.03,23.75,27.39,15.93,17.83,18.82,21.56,25.33,25,19.33,22.08,24.03";
        //SampleDataInput2 = "22.74,22.27,20.61,26.15,21.68,21.51,19.66,24.11,20.63,20.96,26.56,26.67,26.02,27.20,19.13,16.57,26.71,25.91,17.51,15.79,26.19,18.57,19.03,19.02,19.97,19.04,21.06,25.94,17.03,15.61";
        //sampleDataSetsDirectory = @"..\..\..\..\SampleDataSets";
        //challengeSampleDataSet1Path = string.Concat(sampleDataSetsDirectory, @"\ChallengeSampleDataSet1.txt");
        //challengeSampleDataSet2Path = string.Concat(sampleDataSetsDirectory, @"\ChallengeSampleDataSet2.txt");
        //private string sampleDataSetsDirectory;
        //private string challengeSampleDataSet1Path;
        //private string challengeSampleDataSet2Path;

        [SetUp]
        public void Setup()
        {
            Extraction = new DataExtraction.DataFromString();
        }

        private DataExtraction.DataFromString Extraction;

        [Test]
        public void ValidateCsvString_WhenLength0_ThrowsApplicationException()
        {
            Assert.Throws<ApplicationException>(() => Extraction.IsCsvStringValid(""));
        }

        [Test]
        public void GetPriceDataFromCsvString_WhenInvalidDataRetrieved_ThrowsApplicationException()
        {
            Assert.Throws<ApplicationException>(() => Extraction.GetPriceDataFromCsvString("abc"));
        }

        [Test]
        public void GetPriceDataFromCsvString_WhenNoDataRetrieved_ThrowsApplicationException()
        {
            Assert.Throws<ApplicationException>(() => Extraction.GetPriceDataFromCsvString(""));
        }

        [Test]
        public void GetPriceDataFromCsvString_WhenValidDataInput_ReturnsEquivalentDictionary()
        {
            string data = "10.1, 20.02, 30.02, 10.1";

            var expectedResult = new Dictionary<int, double?> {
                { 1, 10.1 } ,
                { 2, 20.02 } ,
                { 3, 30.02 } ,
                { 4, 10.1 }
            };

            var actualResult = Extraction.GetPriceDataFromCsvString(data);

            Assert.IsTrue(expectedResult.Count == actualResult.Count && !expectedResult.Except(actualResult).Any());
        }
    }
}