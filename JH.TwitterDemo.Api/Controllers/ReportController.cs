using AutoMapper;
using JH.TwitterDemo.Api.Models;
using JH.TwitterDemo.Service.Models.Report;
using JH.TwitterDemo.Service.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JH.TwitterDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService reportService;
        private readonly IMapper mapper;

        public ReportController(IReportService reportService, IMapper mapper)
        {
            this.reportService = reportService;
            this.mapper = mapper;
        }

        [HttpGet("{top}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HashTagReportVM))]
        public async Task<IActionResult> GetTopHashTags([FromRoute] int top)
        {
            var result = await this.reportService.HashTagReport(top);
            return Ok(this.mapper.Map<HashTagReportVM>(result));
        }
    }
}