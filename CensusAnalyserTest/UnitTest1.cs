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
        static readonly string wrongIndianStateCensusFilePath = @"D:\BridgeLabz Problems Git Hub Local Repository\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaData.csv";
        static readonly string wrongIndianStateCensusFileType = @"D:\BridgeLabz Problems Git Hub Local Repository\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.txt";
        static readonly string wrongIndianStateCodeFileType = @"D:\BridgeLabz Problems Git Hub Local Repository\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCode.txt";
        static readonly string delimiterIndianStateCodeFilePath = @"D:\BridgeLabz Problems Git Hub Local Repository\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCode.csv";
        static readonly string wrongHeaderStateCodeFilePath = @"D:\BridgeLabz Problems Git Hub Local Repository\IndianStatesCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongIndiaStateCode.csv";

        IndianStatesCensusAnalyser.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStatesCensusAnalyser.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        /// TestCase 1.1
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            stateRecord= censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }

        /// <summary>
        /// TestCase 1.2
        /// </summary>
        [Test]
        public void GivenWrongFilePathThrowException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File not Found", e.Message);
            }
        }

        /// <summary>
        /// TestCase 1.3
        /// </summary>
        [Test]
        public void GivenWrongFileTypeThrowException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Invalid File Type", e.Message);
            }
        }

        /// <summary>
        /// TestCase 1.4
        /// </summary>
        [Test]
        public void GivenWrongFileDelimiterThrowException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianCensusFilePath, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("File Contains Wrong Delimiter", e.Message);
            }
        }

        /// <summary>
        /// TestCase 1.5
        /// </summary>
        [Test]
        public void GivenWrongFileHeaderThrowException()
        {
            try
            {
                totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusFilePath, indianStateCensusHeaders);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual("Incorrect header in Data", e.Message);
            }
        }
    }
}