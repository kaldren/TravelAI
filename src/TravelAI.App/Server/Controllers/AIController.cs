using Microsoft.AspNetCore.Mvc;

namespace TravelAI.App.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AIController : ControllerBase
    {
        async Task<bool> GenerateReport()
        {
            return false;
        }
    }
}
