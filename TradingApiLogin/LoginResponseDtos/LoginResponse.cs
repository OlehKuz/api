using System;
using Newtonsoft.Json;
using TradingApiLogin.LoginResponseDtos;

namespace TradingApiLogin
{
    public class LoginServletResponse
    {
        [JsonProperty]
        public string UserConfiguration { get; set; }
        [JsonProperty]
        public UserDetails UserDetails { get; set; }
        [JsonProperty]
        public string MarketWatchDetails { get; set; }
        [JsonProperty]
        public string DefaultMarketWatch { get; set; }//should be long
        [JsonProperty]
        public string JuniorsInformation { get; set; }
        //[JsonProperty]
        //public string Filler { get; set; }  it supplied filler when it was supposed to supply exchange
        //[JsonProperty]
        //public string PasswordMessage { get; set; }
        [JsonProperty]
        public ExchangeMarketSegment ExchangeMarketSegment { get; set; }
        [JsonProperty]
        public BSEExchangeMarketSegment BSEExchangeMarketSegment { get; set; }
        [JsonProperty]
        public NSEExchangeMarketSegment NSEExchangeMarketSegment { get; set; }
        [JsonProperty]
        public NCDEXExchangeMarketSegment NCDEXExchangeMarketSegment { get; set; }
        [JsonProperty]
        public MCXExchangeMarketSegment MCXExchangeMarketSegment { get; set; }
        [JsonProperty]
        public string ValidExchangeName { get; set; }
        [JsonProperty]
        public string ValidMarketName { get; set; }
        [JsonProperty]
        public string ValidSegmentName { get; set; }
        [JsonProperty]
        public string IndexIds { get; set; }
        [JsonProperty]
        public string IndicesSource { get; set; }
        [JsonProperty]
        public string IndicesSegment { get; set; }
        [JsonProperty]
        public string IndicesLabels { get; set; }
        [JsonProperty]
        public string IndicesNames { get; set; }
        [JsonProperty]
        public string Locations { get; set; }
        [JsonProperty]
        public string Values { get; set; }
        [JsonProperty]
        public string ChangeValues { get; set; }

        [JsonProperty]
        public string IndicesString { get; set; }
        [JsonProperty]
        public string LastLoginTime_LastLogoutTime { get; set; }
        //[JsonProperty]
        //public string LastLogoutTime { get; set; }
        [JsonProperty]
        public string PasswordExpiryPeriodDayleft { get; set; }

        [JsonProperty]
        public string MemberUserDetails { get; set; }
        [JsonProperty]
        public string SettlementNo { get; set; }
        //[JsonProperty]
        //public string Filler1 { get; set; }
        [JsonProperty]
        public string DmaUser { get; set; }
        //[JsonProperty]
        //public string Filler2 { get; set; }
        [JsonProperty]
        public string InterOperabilityFeatureEnable { get; set; }
    }
}
