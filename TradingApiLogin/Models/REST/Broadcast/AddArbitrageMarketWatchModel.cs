using Newtonsoft.Json;

namespace BOWTest.Models.REST
{
    public class AddArbitrageMarketWatchModel
    {
        [JsonProperty("MWUSID")] public long LoginId { get; set; } = 97;
        public string MWName { get; set; } = "Market for session 264932189-01194251249";
        public int MWSegmentId { get; set; } = 5;
        public int MWFormat { get; set; }
        public int MWNoOfLegs { get; set; }
        public int MWType { get; set; }
        public string MWAdmin { get; set; } = "N";
        public string MWFIELD1 { get; set; }
        public string MWFIELD2 { get; set; }
        public string MWFIELD3 { get; set; }
        public string MWFIELD4 { get; set; }
        public string MWROWSTATE { get; set; }

        [JsonProperty("numberofmarketwatchfields")]
        public int NumberOfMarketWatchFields { get; set; } = 100;

        public string MWFFieldId0 { get; set; }
        public int MWFLegId0 { get; set; }
        public int MWFFMId0 { get; set; }
        public int MWFPosition0 { get; set; }
        public string MWFFIELD10 { get; set; }
        public string MWFFIELD20 { get; set; }
        public string MWFFIELD30 { get; set; }
        public string MWFFIELD40 { get; set; }
        public string MWFROWSTATE0 { get; set; }
        public string MWFFieldId1 { get; set; }
        public int MWFLegId1 { get; set; }
        public int MWFFMId1 { get; set; }
        public string MWFPosition1 { get; set; }
        public string MWFFIELD11 { get; set; }
        public string MWFFIELD21 { get; set; }
        public string MWFFIELD31 { get; set; }
        public string MWFFIELD41 { get; set; }
        public string MWFROWSTATE1 { get; set; }
        public string SessionKey { get; set; } = "264932189-01194251249";
        [JsonProperty("Thick Client")] public string ThickClient => "Y";
    }
}