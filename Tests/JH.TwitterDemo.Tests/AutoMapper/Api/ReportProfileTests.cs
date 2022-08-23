using AutoMapper;
using JH.TwitterDemo.Api.Mapper;
using JH.TwitterDemo.Api.Models;
using JH.TwitterDemo.Service.Models.Report;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JH.TwitterDemo.Tests.AutoMapper.Api
{
    [TestFixture()]
    public class ReportProfileTests
    {
        private MapperConfiguration config;
        private IMapper mapper;

        [SetUp]
        public void Setup()
        {
            config = new MapperConfiguration(cfg => cfg.AddProfile<ReportProfile>());
            config.AssertConfigurationIsValid();
            mapper = config.CreateMapper();
        }

        [Test]
        public void Test_HashTagReportToHashTagReportVM_Mapper()
        {
            // Arrange
            int numberOfReferences = 5;
            var tagText = "TagText";
            int totalTwitts = 10;
            var hashTagReport = new HashTagReport()
            {
               TotalTwitts = totalTwitts,
               HashTags = new List<HashTagRecord>() { new HashTagRecord() { Tag = tagText, NumberOfReferences = 5 } }
            };

            // Act
            var actual = mapper.Map<HashTagReportVM>(hashTagReport);

            // Arrange
            Assert.AreEqual(actual.TotalTwitts, totalTwitts);
            Assert.AreEqual(actual.HashTags.Count(), 1);
            Assert.AreEqual(actual.HashTags.FirstOrDefault().NumberOfReferences, numberOfReferences);
            Assert.AreEqual(actual.HashTags.FirstOrDefault().Tag, tagText);
        }
    }
}

