namespace TravelAI.App.Server.Services
{
    public interface IAIService
    {
        Task<string> AskChatGPT(string message);
    }
}
