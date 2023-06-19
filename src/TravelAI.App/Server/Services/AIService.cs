using OpenAI.Interfaces;
using OpenAI.ObjectModels;
using OpenAI.ObjectModels.RequestModels;
using System.Text;
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
            request.IsCultural = true;
            request.IsSummer = true;
            request.IsSafari = true;

            var placesBuilder = GeneratePlacesToTravelQuestion(request);

            var completionResult = await _openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
            {
                Messages = new List<ChatMessage>
                {
                    ChatMessage.FromUser(placesBuilder.ToString()),
                },
                Model = Models.ChatGpt3_5Turbo,
            });
            if (completionResult.Successful)
            {
                var result = completionResult.Choices.First().Message.Content;
            }

            throw new NotImplementedException();
        }

        private StringBuilder GeneratePlacesToTravelQuestion(ReportRequest request)
        {
            StringBuilder questionBuilder = new StringBuilder("Suggest me 10 places to travel to.");

            if (request.IsHot.HasValue)
            {
                questionBuilder.Append($" It should be hot.");
            }
            if (request.IsWarm.HasValue)
            {
                questionBuilder.Append($" It should be warm.");
            }
            if (request.IsCold.HasValue)
            {
                questionBuilder.Append($" It should be cold.");
            }
            if (request.IsSafe.HasValue)
            {
                questionBuilder.Append($" It should be safe.");
            }
            if (request.HasFastInternet.HasValue)
            {
                questionBuilder.Append($" It should have fast internet.");
            }
            if (request.IsTopDestination.HasValue)
            {
                questionBuilder.Append($" It should be a preferred destination.");
            }
            if (request.IsAfrica.HasValue)
            {
                questionBuilder.Append($" It should be in Africa.");
            }
            if (request.IsAsia.HasValue)
            {
                questionBuilder.Append($" It should be in Asia.");
            }
            if (request.IsEurope.HasValue)
            {
                questionBuilder.Append($" It should be in Europe.");
            }
            if (request.IsNorthAmerica.HasValue)
            {
                questionBuilder.Append($" It should be in North America.");
            }
            if (request.IsSouthAmerica.HasValue)
            {
                questionBuilder.Append($" It should be in South America.");
            }
            if (request.IsSpring.HasValue)
            {
                questionBuilder.Append($" It should be Spring now.");
            }
            if (request.IsSummer.HasValue)
            {
                questionBuilder.Append($" It should be Summer now.");
            }
            if (request.IsAutumn.HasValue)
            {
                questionBuilder.Append($" It should be Autumn now.");
            }
            if (request.IsWinter.HasValue)
            {
                questionBuilder.Append($" It should be Winter now.");
            }
            if (request.IsCity.HasValue)
            {
                questionBuilder.Append($" It should be a city.");
            }
            if (request.IsTown.HasValue)
            {
                questionBuilder.Append($" It should be a town.");
            }
            if (request.IsVillage.HasValue)
            {
                questionBuilder.Append($" It should be a village.");
            }
            if (request.IsBeach.HasValue)
            {
                questionBuilder.Append($" It should have beaches.");
            }
            if (request.IsMountain.HasValue)
            {
                questionBuilder.Append($" It should be near mountains.");
            }
            if (request.IsForest.HasValue)
            {
                questionBuilder.Append($" It should be near forest.");
            }
            if (request.IsDesert.HasValue)
            {
                questionBuilder.Append($" It should be near desert.");
            }
            if (request.IsLake.HasValue)
            {
                questionBuilder.Append($" It should be near lake.");
            }
            if (request.IsRiver.HasValue)
            {
                questionBuilder.Append($" It should be near river.");
            }
            if (request.IsIsland.HasValue)
            {
                questionBuilder.Append($" It should be an island.");
            }
            if (request.IsHistorical.HasValue)
            {
                questionBuilder.Append($" It should be historical.");
            }
            if (request.IsReligious.HasValue)
            {
                questionBuilder.Append($" It should be religious.");
            }
            if (request.IsAdventure.HasValue)
            {
                questionBuilder.Append($" It should be good for adventures.");
            }
            if (request.IsSafari.HasValue)
            {
                questionBuilder.Append($" It should be good for safari.");
            }
            if (request.IsGambling.HasValue)
            {
                questionBuilder.Append($" It should be good for gambling.");
            }
            if (request.IsShopping.HasValue)
            {
                questionBuilder.Append($" It should be good for shopping.");
            }
            if (request.IsFood.HasValue)
            {
                questionBuilder.Append($" It should have good food.");
            }
            if (request.IsNightlife.HasValue)
            {
                questionBuilder.Append($" It should have good nightlife.");
            }
            if (request.IsSurfing.HasValue)
            {
                questionBuilder.Append($" It should be good for surfing.");
            }
            if (request.IsDiving.HasValue)
            {
                questionBuilder.Append($" It should be good for diving.");
            }
            if (request.IsSkiing.HasValue)
            {
                questionBuilder.Append($" It should be good for skiing.");
            }
            if (request.IsHiking.HasValue)
            {
                questionBuilder.Append($" It should be good for hiking.");
            }
            if (request.IsCamping.HasValue)
            {
                questionBuilder.Append($" It should be good for camping.");
            }
            if (request.IsCheapCostOfLiving.HasValue)
            {
                questionBuilder.Append($" It should be cheap in terms of cost of living.");
            }
            if (request.IsAverageCostOfLiving.HasValue)
            {
                questionBuilder.Append($" It should be moderate in terms of cost of living.");
            }
            if (request.IsExpensiveCostOfLiving.HasValue)
            {
                questionBuilder.Append($" It should be expensive in terms of cost of living.");
            }
            if (request.IsJanuary.HasValue)
            {
                questionBuilder.Append($" It should be preferred destination for travelling in January.");
            }
            if (request.IsFebruary.HasValue)
            {
                questionBuilder.Append($" It should be preferred destination for travelling in February.");
            }
            if (request.IsMarch.HasValue)
            {
                questionBuilder.Append($" It should be preferred destination for travelling in March.");
            }
            if (request.IsApril.HasValue)
            {
                questionBuilder.Append($" It should be preferred destination for travelling in April.");
            }
            if (request.IsMay.HasValue)
            {
                questionBuilder.Append($" It should be preferred destination for travelling in May.");
            }
            if (request.IsJune.HasValue)
            {
                questionBuilder.Append($" It should be preferred destination for travelling in June.");
            }
            if (request.IsJuly.HasValue)
            {
                questionBuilder.Append($" It should be preferred destination for travelling in July.");
            }
            if (request.IsAugust.HasValue)
            {
                questionBuilder.Append($" It should be preferred destination for travelling in August.");
            }
            if (request.IsSeptember.HasValue)
            {
                questionBuilder.Append($" It should be preferred destination for travelling in September.");
            }
            if (request.IsOctober.HasValue)
            {
                questionBuilder.Append($" It should be preferred destination for travelling in October.");
            }
            if (request.IsNovember.HasValue)
            {
                questionBuilder.Append($" It should be preferred destination for travelling in November.");
            }
            if (request.IsDecember.HasValue)
            {
                questionBuilder.Append($" It should be preferred destination for travelling in December.");
            }

            return questionBuilder;
        }
    }
}
