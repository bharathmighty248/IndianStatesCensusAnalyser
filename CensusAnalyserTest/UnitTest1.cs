using IndianStatesCensusAnalyser;
using NUnit.Framework;
using System.Collections.Generic;
using IndianStatesCensusAnalyser.POCO;
using Newtonsoft.Json;
using static IndianStatesCensusAnalyser.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static readonly string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static readonly string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static readonly string indianStateCensusFilePath = @"D:\BridgeLabz Problems Git Hub Local Repository\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.csv";
        static readonly string indianStateCodeFilePath = @"D:\BridgeLabz Problems Git Hub Local Repository\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCode.csv";
        static readonly string wrongHeaderIndianCensusFilePath = @"D:\BridgeLabz Problems Git Hub Local Repository\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongIndiaStateCensusData.csv";
        static readonly string delimiterIndianCensusFilePath = @"D:\BridgeLabz Problems Git Hub Local Repository\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static readonly string wrongIndianStateCensusFileType = @"D:\BridgeLabz Problems Git Hub Local Repository\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.txt";
        static readonly string wrongIndianStateCodeFileType = @"D:\BridgeLabz Problems Git Hub Local Repository\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCode.txt";
        static readonly string delimiterIndianStateCodeFilePath = @"D:\BridgeLabz Problems Git Hub Local Repository\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCode.csv";
        static readonly string wrongHeaderIndianStateCodeFilePath = @"D:\BridgeLabz Problems Git Hub Local Repository\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongIndiaStateCode.csv";
        static readonly string wrongIndianStateCensusFilePath = @"D:\BridgeLabz Problems Git Hub Local Repository\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaData.csv";
        static readonly string wrongIndianStateCodeFilePath = @"D:\BridgeLabz Problems Git Hub Local Repository\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaData.csv";

        CensusAnalyser censusAnalyser;

        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        /// Test Case 1.1
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenReade_ThenShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }

        /// <summary>
        /// Test Case 1.2 
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenIncorrect_ThenShouldReturnFileNotFoundException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }

        /// <summary>
        /// Test Case 1.3 
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFileCorrect_WhenFileTypeIncorrect_ThenShouldReturnInvalidFileTypeException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }

        /// <summary>
        /// Test Case 1.4
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFileCorrect_WhenDelimiterIncorrect_ThenShouldReturnInvalidDelimiterException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }

        /// <summary>
        /// Test Case 1.5
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFileCorrect_WhenHeaderIncorrect_ThenShouldReturnInvalidHeaderException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }

        /// <summary>
        /// Test Case 2.1 
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCsvFile_WhenRead_ThenShouldReturnStateCodeDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }
        /// <summary>
        /// Test Case 2.2 
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCsvFile_WhenIncorrect_ThenShouldReturnFileNotFoundException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }
        /// <summary>
        /// Test Case 2.3 
        /// </summary>
        [Test]
        public void GivenIndianStateCodCsvFileCorrect_WhenFileTypeIncorrect_ThenShouldReturnInvalidFileTypeException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        /// <summary>
        /// Test Case 2.4 
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCsvFileCorrect_WhenDelimiterIncorrect_ThenShouldReturnInvalidDelimiterException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }

        /// <summary>
        /// Test Case 2.5 
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCsvFileCorrect_WhenHeaderIncorrect_ThenShouldReturnInvalidHeaderException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
    }
}