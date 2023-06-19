using OpenAI.Interfaces;
using OpenAI.ObjectModels;
using OpenAI.ObjectModels.RequestModels;
using TravelAI.App.Shared;

namespace TravelAI.App.Server.Services
{
    public class AIService : IAIService
    {
        private readonly IOpenAIService _openAiService;

        public AIService(IOpenAIService openAiService)
        {
            _openAiService = openAiService;
        }

        public async Task<ICollection<GPTResponse>> AskChatGPT(ReportRequest request)
        {
            var completionResult = await _openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
            {
                Messages = new List<ChatMessage>
                {
                    ChatMessage.FromUser("Give me 5 to 10 places that are hot in December and have beaches."),
                },
                Model = Models.ChatGpt3_5Turbo,
            });
            if (completionResult.Successful)
            {
                var result = completionResult.Choices.First().Message.Content;
            }

            throw new NotImplementedException();
        }
    }
}
