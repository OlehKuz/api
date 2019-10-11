using Newtonsoft.Json;

namespace BOWTest.Models.REST
{
    public class LoginServletModel
    {
        public string USBackOfficeId { get; set; }
        [JsonProperty("USLOGINID")] public string LoginId { get; set; }
        public string USPassword { get; set; }
        public string USTransactionPassword { get; set; }
        [JsonProperty("version")] public string Version { get; set; }
        public int SecuritiesMaxSequenceId { get; set; }
        public int NSEContractsMaxSequenceId { get; set; }
        public int NcdexContractsMaxSequenceId { get; set; }
        public int MCXContractsMaxSequenceId { get; set; }
        public int BSEContractsMaxSequenceId { get; set; }
        public int BSECurrencyContractsMaxSequenceId { get; set; }
        public int NSECurrencyContractsMaxSequenceId { get; set; }
        [JsonProperty("enable2FA")] public string Enable2FA { get; set; }
        public string VenderCode { get; set; }
        public string SessionKey { get; set; }
        [JsonProperty("Thick Client")] public string ThickClient { get; set; }
    }
}