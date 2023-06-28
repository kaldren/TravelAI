using OpenAI.Interfaces;
using OpenAI.ObjectModels;
using OpenAI.ObjectModels.RequestModels;

namespace TravelAI.App.Server.Services
{
    public class AIService : IAIService
    {
        private readonly IOpenAIService _openAiService;

        public AIService(IOpenAIService openAiService)
        {
            _openAiService = openAiService;
        }

        public async Task<string> SendChatMessage(string message) => await SendChatMessageAsync(message);

        private async Task<string> SendChatMessageAsync(string message)
        {
            var completionResult = await _openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
            {
                Messages = new List<ChatMessage>
                {
                    ChatMessage.FromUser(message),
                },
                Model = Models.ChatGpt3_5Turbo,
            });
            if (completionResult.Successful)
            {
                return completionResult.Choices.First().Message.Content;
            }

            return string.Empty;
        }
    }
}
