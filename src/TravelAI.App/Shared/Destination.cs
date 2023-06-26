using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAI.App.Shared
{
    public class Root
    {
        public List<Destination> Destinations { get; set; }
    }

    public class Destination
    {
        //"location": "Rio de Janeiro",
        //  "country": "Brazil",
        //  "description": "A vibrant city known for its beautiful beaches, lively culture, and famous carnival.",
        //  "climate": "Tropical savanna",
        //  "averageTempC": 27,
        //  "costOfLiving": "Moderate",
        //  "averageMonthlyCostUSD": 1200,
        //  "bestMonthsToVisit": "December to March"
        public string Location { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string Climate { get; set; }
        public string AverageTempC { get; set; }
        public string CostOfLiving { get; set; }
        public string AverageMonthlyCostUSD { get; set; }
        public string[] BestMonthsToVisit { get; set; }
    }
}
