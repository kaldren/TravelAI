namespace TravelAI.App.Server.Services
{
    public interface IAIService
    {
        Task<string> SendChatMessage(string message);
    }
}
