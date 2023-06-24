using Azure.Data.Tables;
using System.Text;
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

        public async Task<string> GenerateReport(ReportRequest model)
        {
            string url = string.Empty;

            try
            {
                // Q1 - Places to travel
                StringBuilder placesToTravel = GeneratePlacesToTravelQuestion(model);
                string placesToTravelResponse = await _aiService.SendChatMessage(placesToTravel.ToString());

                if (string.IsNullOrEmpty(placesToTravelResponse))
                    return url;

                // Q2 - Interesting things to do
                string thingsToDo = await _aiService.SendChatMessage($"Tell me most interesting things I can do at each of these places {string.Join(", ", placesToTravelResponse.Split(".").Skip(1))}");

                if (string.IsNullOrEmpty(placesToTravelResponse))
                    return url;

                // Insert into database
                TableServiceClient tableServiceClient = new TableServiceClient("DefaultEndpointsProtocol=https;AccountName=travelaicosmos;AccountKey=a67ihiAaTgPMdnxE3iNmaYMfzNttMyjGuQfg4m2ca2gTMTY2PEffVynMRrgBNMLvRw1ifzOJYfCyACDbZzIqnw==;TableEndpoint=https://travelaicosmos.table.cosmos.azure.com:443/;");
                // New instance of TableClient class referencing the server-side table
                TableClient tableClient = tableServiceClient.GetTableClient(
                    tableName: "reports"
                );

                await tableClient.CreateIfNotExistsAsync();

                // Create new item using composite key constructor
                var prod1 = new ReportTableModel()
                {
                    RowKey = "68719518388",
                    PartitionKey = "gear-surf-surfboards",
                    Places = placesToTravelResponse.Split(".").Skip(1).ToArray(),
                    ThingsToDo = thingsToDo.Split(".").Skip(1).ToArray(),
                };

                // Add new item to server-side table
                var response = await tableClient.AddEntityAsync<ReportTableModel>(prod1);
            }
            catch (Exception)
            {
                return url;
            }

            // Generate URL of the report
            url = "https://www.google.com/";
            return url;
        }

        private StringBuilder GeneratePlacesToTravelQuestion(ReportRequest request)
        {
            StringBuilder questionBuilder = new StringBuilder("Suggest me 10 places inside countries to travel to, without anything else, just their names ordered numerically.");

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
            if (request.IsInternet.HasValue)
            {
                questionBuilder.Append($" It should have fast internet.");
            }
            if (request.IsTop.HasValue)
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
            if (request.IsTastyFood.HasValue)
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
            if (request.IsCheap.HasValue)
            {
                questionBuilder.Append($" It should be cheap in terms of cost of living.");
            }
            if (request.IsModerate.HasValue)
            {
                questionBuilder.Append($" It should be moderate in terms of cost of living.");
            }
            if (request.IsExpensive.HasValue)
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
