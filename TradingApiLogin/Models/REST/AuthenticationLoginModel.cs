using Newtonsoft.Json;

namespace BOWTest.Models.REST
{
    public class AuthenticationLoginModel
    {
        public string OTP { get; set; }
        [JsonProperty("USLOGINID")] public string LoginID { get; set; }
        public string SessionKey { get; set; }
        [JsonProperty("Thick Client")] public string ThickClient { get; set; }
    }
}