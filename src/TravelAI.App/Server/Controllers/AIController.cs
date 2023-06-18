using Microsoft.AspNetCore.Mvc;

namespace TravelAI.App.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AIController : ControllerBase
    {
        [HttpPost]
        async Task<bool> GenerateReport()
        {
            return false;
        }
    }
}
