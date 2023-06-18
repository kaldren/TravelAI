using TravelAI.App.Shared;

namespace TravelAI.App.Server.Services
{
    public class ReportService : IReportService
    {
        private readonly IAIService _aiService;

        public ReportService(IAIService aiService)
        {
            _aiService = aiService;
        }

        public async Task<string> GenerateReport(ReportModel model)
        {
            var response = await _aiService.AskChatGPT(string.Empty);
            throw new NotImplementedException();
        }
    }
}
