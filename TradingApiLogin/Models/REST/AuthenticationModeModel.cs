using Newtonsoft.Json;

namespace BOWTest.Models.REST
{
    public class AuthenticationModeModel
    {
        [JsonProperty("verificationMode")] public int VerificationMode { get; set; }
        [JsonProperty("USLOGINID")] public string LoginID { get; set; }
        public string SessionKey { get; set; }
        [JsonProperty("Thick Client")] public string ThickClient { get; set; }
    }
}