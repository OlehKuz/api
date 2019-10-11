using System.ComponentModel;
namespace TradingApiLogin.OrderAndTrade
{
    public class AddOrder  //tested at SQLiteBSECommodityContracts
    {
        public long OEToken { get; set; } = 1734;   //BCCID
        public long OENSEToken { get; set; }
        public long OEBSEToken { get; set; } = 1400580;//BCCToken == BCCInstrumentId

        public long OEDestination { get; set; } = 2;//NSE
        public string InstrumentType { get; set; } = "FUTCOM";//bccinstrumentname
        public long OEMarket { get; set; } = 3;//commodities
        public string OESymbol { get; set; } = "COPPER";//bcccontractcode
        public long OEExpiryDate { get; set; } = 1569801600;
        public long OEStrikePrice { get; set; } = -1;
        public char OEOptionType { get; set; }//blank  // or string in db char
        public string OESeries { get; set; }//cant find
        public long OEVolume { get; set; } = 3;
        public long OEPrice { get; set; } = 50000;
        public long OETriggerPrice { get; set; } = 51000;
        public long OEDisclosedVolume { get; set; } = 1;
        public string USBackOfficeId { get; set; } = "SER_CT2-T9072"; // what - i can place an order ob behalf of another user? 
        public char OEFIELD3 { get; set; } = 'N'; // nse doesnt have producttype
        public long OEBuySellIndicator { get; set; } = 1; //buy
        public string OEAlphaChar { get; set; }// what is this? 
        public long OEActualApproverId { get; set; }
        public long OEVolumeRemaining { get; set; }
        public long OEDisclosedVolumeRemaining { get; set; }
        public long OEAdminUSID { get; set; } = 97;//=loginresponse.userdetails.internaluserid
        public long OEStatus { get; set; } = 2;// do i need to set it 
        public long OEProClientIndicator { get; set; } = 2;// broker order, 1-client order
        public string OESettlor { get; set; }
        public long OEOrderNumber { get; set; }
        public long OEField1 { get; set; } = 1;//dont get it 
        public string OEParticipantType { get; set; }// where are participant types
        public string OEIntuitionalClient { get; set; } = "PRO"; // should be long?
        public string OEName { get; set; }
        public long OEGoodTillDate { get; set; } 
        public long GTC { get; set; } = 1;
        public long IOC { get; set; } = 1;
        public long OEBookType { get; set; } = 1;
        public long OESegment { get; set; }
        public string OEGroup { get; set; }
        public char BlockDeal { get; set; }
        public string OEReason { get; set; }
        public string OEApproverRemarks { get; set; }
        public long OESolicitorPeriod { get; set; }
        public string SessionKey { get; set; } = "264932189-01194251249";
        [Description("Thick Client")]
        public char ThickClient { get; set; } = 'Y';
    }
}
