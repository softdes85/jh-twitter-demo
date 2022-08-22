using JH.TwitterDemo.Data.Dtos;
using JH.TwitterDemo.Data.Repositories.Interfaces;
using JH.TwitterDemo.Service.Services;
using JH.TwitterDemo.Service.Services.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Tests.Services
{
    [TestFixture()]
    public class ReportServiceTests
    {
        private IHashTagRepository hashTagRepository;
        private ITwittRepository twittRepository;
        private IReportService reportService;

        [SetUp]
        public void Setup()
        {
            hashTagRepository = Mock.Of<IHashTagRepository>();
            twittRepository = Mock.Of<ITwittRepository>();
            reportService = new ReportService(hashTagRepository, twittRepository);
        }

        [Test]
        public async Task When_HashTagReport_Report_Returned()
        {
            // Arrange
            int allCount = 10;
            var test = new List<HashTagCount>() { new HashTagCount() };
            Mock.Get(hashTagRepository)
                .Setup(s => s.TopNAsync(It.IsAny<int>()))
                .ReturnsAsync(test);
            Mock.Get(twittRepository)
                .Setup(s => s.TotalCount())
                .ReturnsAsync(allCount);

            // Act
            var result = await reportService.HashTagReport(2);

            // Assert
            Assert.AreEqual(result.TotalTwitts, allCount);
            Mock.VerifyAll();
        }
    }
}