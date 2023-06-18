using Microsoft.AspNetCore.Mvc;
using TravelAI.App.Shared;

namespace TravelAI.App.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        [HttpPost]
        async Task<bool> GenerateReport(ReportModel model)
        {
            return false;
        }
    }
}
