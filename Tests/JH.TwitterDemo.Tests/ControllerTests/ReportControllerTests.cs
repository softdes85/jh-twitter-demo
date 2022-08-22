using JH.TwitterDemo.Api.Controllers;
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
        private HashTagReport hashTagReport;

        [SetUp]
        public void SetUp()
        {

            _mockReportService = new Mock<IReportService>();

            hashTagReport = new HashTagReport()
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
            _mockReportService.Setup(m => m.HashTagReport(10)).ReturnsAsync(hashTagReport);

            Api.Controllers.ReportController _mockReportController = new ReportController(_mockReportService.Object);

            var result = await _mockReportController.GetTopHashTags(10) as ObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(hashTagReport.TotalTwitts, ((HashTagReport)result.Value).TotalTwitts);
        }

    }
}
