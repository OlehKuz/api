using System;
namespace TradingApiLogin.LoginResponseDtos
{
    public class MCXExchangeMarketSegment
    {
        public string ExchangeID { get; set; }
        public string MarketSegmentsMCXCommodityMarket { get; set; }
        public string MarketSegmentsMCXCurrencyMarket { get; set; }
    }
}
