using System;
namespace TradingApiLogin.BroadcastRelatedMessages
{
    public class PreAddArbitrageMarketWatchRequest
    {
      public long MWID { get; set; }
      public string MWUSID { get; set; }
      public string SessionKey { get; set; }
      public char ThickClient { get; set; }
    }
}
