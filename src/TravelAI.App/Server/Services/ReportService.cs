using Azure.Data.Tables;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
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
                // Q1 - Destinations to travel to
                StringBuilder destinationsBuilder = GeneratePlacesToTravelQuestion(model);
                string destinationJson = await _aiService.SendChatMessage(destinationsBuilder.ToString());

                Root root = JsonSerializer.Deserialize<Root>(destinationJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                // Q2 - Interesting things to do
                var places = string.Join(", ", root.Destinations.Select(p => $"({p.Location}, {p.Country})").Aggregate((i, j) => i + ", " + j));
                string thingsToDo = await _aiService.SendChatMessage($"Tell me most interesting things I can do at each of these places {places}");

                if (string.IsNullOrEmpty(destinationJson))
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
                    Places = destinationJson.Split(".").Skip(1).ToArray(),
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
            StringBuilder questionBuilder = 
                new StringBuilder
                ("Suggest me 10 places to visit in the world and return everything as JSON under 'destinations' array. " +
                "Have only these entries inside it: location, country, description, climate, averageTempC, costOfLiving, " +
                "averageMonthlyCostUSD, thingsToDo (array of strings for the most interesting things to do - not just one or two, but all), famousSites (array of strings for the most interesting things to do - not just one or two, but allarray of strings for the most interesting sites to see - not just one or two, but all), bestMonthsToVisit (array of strings). Each value must be a string. " +
                "Don't add other fields.");

            if (request.IsHot == true)
            {
                questionBuilder.Append($" It should be hot.");
            }
            if (request.IsWarm == true)
            {
                questionBuilder.Append($" It should be warm.");
            }
            if (request.IsCold == true)
            {
                questionBuilder.Append($" It should be cold.");
            }
            if (request.IsSafe == true)
            {
                questionBuilder.Append($" It should be safe.");
            }
            if (request.IsInternet == true)
            {
                questionBuilder.Append($" It should have fast internet.");
            }
            if (request.IsTop == true)
            {
                questionBuilder.Append($" It should be a preferred destination.");
            }
            if (request.IsAfrica == true)
            {
                questionBuilder.Append($" It should be in Africa.");
            }
            if (request.IsAsia == true)
            {
                questionBuilder.Append($" It should be in Asia.");
            }
            if (request.IsEurope == true)
            {
                questionBuilder.Append($" It should be in Europe.");
            }
            if (request.IsNorthAmerica == true)
            {
                questionBuilder.Append($" It should be in North America.");
            }
            if (request.IsSouthAmerica == true)
            {
                questionBuilder.Append($" It should be in South America.");
            }
            if (request.IsSpring == true)
            {
                questionBuilder.Append($" It should be Spring now.");
            }
            if (request.IsSummer == true)
            {
                questionBuilder.Append($" It should be Summer now.");
            }
            if (request.IsAutumn == true)
            {
                questionBuilder.Append($" It should be Autumn now.");
            }
            if (request.IsWinter == true)
            {
                questionBuilder.Append($" It should be Winter now.");
            }
            if (request.IsCity == true)
            {
                questionBuilder.Append($" It should be a city.");
            }
            if (request.IsTown == true)
            {
                questionBuilder.Append($" It should be a town.");
            }
            if (request.IsVillage == true)
            {
                questionBuilder.Append($" It should be a village.");
            }
            if (request.IsBeach == true)
            {
                questionBuilder.Append($" It should have beaches.");
            }
            if (request.IsMountain == true)
            {
                questionBuilder.Append($" It should be near mountains.");
            }
            if (request.IsForest == true)
            {
                questionBuilder.Append($" It should be near forest.");
            }
            if (request.IsDesert == true)
            {
                questionBuilder.Append($" It should be near desert.");
            }
            if (request.IsLake == true)
            {
                questionBuilder.Append($" It should be near lake.");
            }
            if (request.IsRiver == true)
            {
                questionBuilder.Append($" It should be near river.");
            }
            if (request.IsIsland == true)
            {
                questionBuilder.Append($" It should be an island.");
            }
            if (request.IsHistorical == true)
            {
                questionBuilder.Append($" It should be historical.");
            }
            if (request.IsReligious == true)
            {
                questionBuilder.Append($" It should be religious.");
            }
            if (request.IsAdventure == true)
            {
                questionBuilder.Append($" It should be good for adventures.");
            }
            if (request.IsSafari == true)
            {
                questionBuilder.Append($" It should be good for safari.");
            }
            if (request.IsGambling == true)
            {
                questionBuilder.Append($" It should be good for gambling.");
            }
            if (request.IsShopping == true)
            {
                questionBuilder.Append($" It should be good for shopping.");
            }
            if (request.IsTastyFood == true)
            {
                questionBuilder.Append($" It should have good food.");
            }
            if (request.IsNightlife == true)
            {
                questionBuilder.Append($" It should have good nightlife.");
            }
            if (request.IsSurfing == true)
            {
                questionBuilder.Append($" It should be good for surfing.");
            }
            if (request.IsDiving == true)
            {
                questionBuilder.Append($" It should be good for diving.");
            }
            if (request.IsSkiing == true)
            {
                questionBuilder.Append($" It should be good for skiing.");
            }
            if (request.IsHiking == true)
            {
                questionBuilder.Append($" It should be good for hiking.");
            }
            if (request.IsCamping == true)
            {
                questionBuilder.Append($" It should be good for camping.");
            }
            if (request.IsCheap == true)
            {
                questionBuilder.Append($" It should be cheap in terms of cost of living.");
            }
            if (request.IsModerate == true)
            {
                questionBuilder.Append($" It should be moderate in terms of cost of living.");
            }
            if (request.IsExpensive == true)
            {
                questionBuilder.Append($" It should be expensive in terms of cost of living.");
            }
            if (request.IsJanuary == true)
            {
                questionBuilder.Append($" It should be preferred destination for travelling in January.");
            }
            if (request.IsFebruary == true)
            {
                questionBuilder.Append($" It should be preferred destination for travelling in February.");
            }
            if (request.IsMarch == true)
            {
                questionBuilder.Append($" It should be preferred destination for travelling in March.");
            }
            if (request.IsApril == true)
            {
                questionBuilder.Append($" It should be preferred destination for travelling in April.");
            }
            if (request.IsMay == true)
            {
                questionBuilder.Append($" It should be preferred destination for travelling in May.");
            }
            if (request.IsJune == true)
            {
                questionBuilder.Append($" It should be preferred destination for travelling in June.");
            }
            if (request.IsJuly == true)
            {
                questionBuilder.Append($" It should be preferred destination for travelling in July.");
            }
            if (request.IsAugust == true)
            {
                questionBuilder.Append($" It should be preferred destination for travelling in August.");
            }
            if (request.IsSeptember == true)
            {
                questionBuilder.Append($" It should be preferred destination for travelling in September.");
            }
            if (request.IsOctober == true)
            {
                questionBuilder.Append($" It should be preferred destination for travelling in October.");
            }
            if (request.IsNovember == true)
            {
                questionBuilder.Append($" It should be preferred destination for travelling in November.");
            }
            if (request.IsDecember == true)
            {
                questionBuilder.Append($" It should be preferred destination for travelling in December.");
            }

            return questionBuilder;
        }
    }
}
