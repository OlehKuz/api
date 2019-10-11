using System;
namespace TradingApiLogin.OrderAndTrade
{
    public class MessageHeader
    {
        public long MessageID { get; set; }
        public string TableName{get;set;}
        public long TransactionCode { get; set; }
        public long Direction { get; set; }
        public long InternalToken { get; set; }
        public long ISINNumber { get; set; }

    }
}
