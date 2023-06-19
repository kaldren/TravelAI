using TravelAI.App.Shared;

namespace TravelAI.App.Server.Services
{
    public interface IAIService
    {
        Task<ICollection<GPTResponse>> AskChatGPT(ReportRequest model);
    }
}
