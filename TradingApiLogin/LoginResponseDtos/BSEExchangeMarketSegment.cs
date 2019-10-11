using System;
namespace TradingApiLogin
{
    public class BSEExchangeMarketSegment
    {
        public string ExchangeID{get;set;}
        public string MarketSegmentsBSEEquityMarket { get; set; }
        public string MarketSegmentsBSEDerivativesMarket { get; set; }
        public string MarketSegmentsBSECommoditiesMarket { get; set; }
        public string MarketSegmentsBSECurrencyMarket { get; set; }
        public string MarketSegmentsBSEMutualFundMarket { get; set; }
        public string MarketSegmentsBSE_SLB_Market { get; set; }
        public string MarketSegmentsBSE_OFS_Market { get; set; }
        public string MarketSegmentsBSE_DEBT_Market { get; set; }
        public string MarketSegmentsBSE_REPO_Market { get; set; }
        public string MarketSegmentsBSE_ITP_Market { get; set; }
        
    }
}
