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
                    ChatMessage.FromUser("Follow exactly what I write to you. Don't write any personal responses, like 'sure', 'fine' or whatever. Do exactly what I ask you as I'm building an app and I need only the responses of what I ask for."),
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
