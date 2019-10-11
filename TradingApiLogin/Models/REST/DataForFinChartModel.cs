using Newtonsoft.Json;

namespace BOWTest.Models.REST
{
    public class DataForFinChartModel
    {
        public string Token { get; set; }
        public string ChartType { get; set; }
        public string MaxID { get; set; }
        public string Symbol { get; set; }
        public string SessionKey { get; set; }
        [JsonProperty("Thick Client")] public string ThickClient { get; set; }
    }
}
