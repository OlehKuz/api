using System;
namespace TradingApiLogin
{
    public class BSECommodityContracts
    {
        public long BCCID { get; set; }
        public long BCCSequenceId { get; set; }
        public string BCCInstrumentName { get; set; }
        public long BCCToken { get; set; }
        public long BCCUnderlyingAsset { get; set; }
        public string BCCContractCode { get; set; }
        public long BCCStrikePrice { get; set; }
        public string BCCOptionType { get; set; }
        public long BCCExpiryDate { get; set; }
        public string BCCDisplayExpiryDate { get; set; }
        public string BCCContractDescription { get; set; }
        public long BCCQuotationUnit { get; set; }
        public string BCCQuotationMetric { get; set; }
        public long BCCBoardLot { get; set; }
        public long BCCPriceTick { get; set; }
        public string BCCPQFactor { get; set; }
        public string BCCTradingUnit { get; set; }
        public decimal BCCGeneralNumerator { get; set; }
        public decimal BCCGeneralDenominator { get; set; }
        public int BCCDecimalLocator { get; set; }
        public long BCCInstrumentId { get; set; }
        public string BCCProductType { get; set; }
    }
}
