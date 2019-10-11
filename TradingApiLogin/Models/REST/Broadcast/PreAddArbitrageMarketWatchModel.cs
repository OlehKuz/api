using System.ComponentModel;
using Newtonsoft.Json;

namespace BOWTest.Models.REST
{
    public class PreAddArbitrageMarketWatchModel
    {
        public int MWID => 0;
        [Description("MWUSID")] public string LoginId { get; set; } ="SER_CT2-T9072";
        public string SessionKey { get; set; } = "264932189-01194251249";
        [Description("Thick Client")] public string ThickClient => "Y";
    }
}