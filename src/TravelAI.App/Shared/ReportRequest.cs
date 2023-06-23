namespace TravelAI.App.Shared
{
    public class ReportRequest
    {
        public bool? IsHot { get; set; }
        public bool? IsWarm { get; set; }
        public bool? IsCold { get; set; }
        public bool? IsSafe { get; set; }
        public bool? IsInternet { get; set; }
        public bool? IsTop { get; set; }

        // Continents
        public bool? IsAfrica { get; set; }
        public bool? IsAsia { get; set; }
        public bool? IsEurope { get; set; }
        public bool? IsNorthAmerica { get; set; }
        public bool? IsSouthAmerica { get; set; }
        public bool? IsOceania { get; set; }

        // Seasons
        public bool? IsSpring { get; set; }
        public bool? IsSummer { get; set; }
        public bool? IsAutumn { get; set; }
        public bool? IsWinter { get; set; }

        // Population type
        public bool? IsCity { get; set; }
        public bool? IsTown { get; set; }
        public bool? IsVillage { get; set; }

        // Destination type
        public bool? IsBeach { get; set; }
        public bool? IsMountain { get; set; }
        public bool? IsForest { get; set; }
        public bool? IsDesert { get; set; }
        public bool? IsLake { get; set; }
        public bool? IsRiver { get; set; }
        public bool? IsIsland { get; set; }
        public bool? IsHistorical { get; set; }
        public bool? IsReligious { get; set; }
        public bool? IsCultural { get; set; }
        public bool? IsAdventure { get; set; }
        public bool? IsSafari { get; set; }
        public bool? IsGambling { get; set; }
        public bool? IsShopping { get; set; }
        public bool? IsTastyFood { get; set; }
        public bool? IsNightlife { get; set; }

        public bool? IsSurfing { get; set; }
        public bool? IsDiving { get; set; }
        public bool? IsSkiing { get; set; }
        public bool? IsHiking { get; set; }
        public bool? IsCamping { get; set; }

        public bool? IsCheap { get; set; }
        public bool? IsModerate { get; set; }
        public bool? IsExpensive { get; set; }

        // Months
        public bool? IsJanuary { get; set; }
        public bool? IsFebruary { get; set; }
        public bool? IsMarch { get; set; }
        public bool? IsApril { get; set; }
        public bool? IsMay { get; set; }
        public bool? IsJune { get; set; }
        public bool? IsJuly { get; set; }
        public bool? IsAugust { get; set; }
        public bool? IsSeptember { get; set; }
        public bool? IsOctober { get; set; }
        public bool? IsNovember { get; set; }
        public bool? IsDecember { get; set; }
    }
}
