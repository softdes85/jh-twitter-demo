using AutoMapper;
using JH.TwitterDemo.Api.Controllers;
using JH.TwitterDemo.Api.Models;
using JH.TwitterDemo.Service.Models.Report;
using JH.TwitterDemo.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Tests.ControllerTests
{
    [TestFixture]
    public class ReportControllerTests
    {
        private Mock<IReportService> _mockReportService;
        private HashTagReport _hashTagReport;
        private IMapper _mapper;

        [SetUp]
        public void SetUp()
        {

            _mockReportService = new Mock<IReportService>();
            _mapper = Mock.Of<IMapper>();
            _hashTagReport = new HashTagReport()
            {
                TotalTwitts = 100,
                HashTags = new List<HashTagRecord>
                {
                    new HashTagRecord()
                    {
                        NumberOfReferences = 10,
                        Tag = "testTag"
                    }
                }
            };

        }

        [Test]
        public async Task GetTopHashTags_ReturnsTopHashTags()
        {
            // Arrange
            Mock.Get(_mapper)
               .Setup(s => s.Map<HashTagReportVM>(It.IsAny<HashTagReport>()))
               .Returns(new HashTagReportVM() { TotalTwitts = _hashTagReport.TotalTwitts });

            _mockReportService.Setup(m => m.HashTagReport(10)).ReturnsAsync(_hashTagReport);

            ReportController _mockReportController = new ReportController(_mockReportService.Object, _mapper);

            // Act
            var result = await _mockReportController.GetTopHashTags(10) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(_hashTagReport.TotalTwitts, ((HashTagReportVM)result.Value).TotalTwitts);
        }

    }
}
