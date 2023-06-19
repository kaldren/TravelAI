using Microsoft.AspNetCore.Mvc;
using TravelAI.App.Server.Services;
using TravelAI.App.Shared;

namespace TravelAI.App.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            await _reportService.GenerateReport(null);

            return string.Empty;
        }

        [HttpPost]
        async Task<bool> GenerateReport(ReportRequest model)
        {
            return false;
        }
    }
}
