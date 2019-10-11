using System;
namespace TradingApiLogin
{
    public class UserDetails
    {
        public long UserInternalID { get; set; }
        public long SessionKey { get; set; }
        public string SettNo { get; set; } // bigInt?
        public string Filler { get; set;}
        public string UserId { get; set; }
        public int UserTypeP { get; set; }
        public bool AllowDownloadFromServer { get; set; }
        public bool SendAllData { get; set; }
        public bool SendSelfData { get; set; }
        public bool IsSpeculativeClient { get; set; }
        public bool AllowPro { get; set; }
        public string ProClientId { get; set; } // own ... enum?
        public bool AllowParticipant { get; set; }
        public char DownloadFlag { get; set; }
        public long TransactionPassword { get; set; }
        public char MarkToMarket { get; set; }
        public string ExchangeCategoryMarkets { get; set; }
    }
}
