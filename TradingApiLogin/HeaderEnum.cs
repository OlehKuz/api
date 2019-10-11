using System;
namespace TradingApiLogin
{
    public enum HeaderEnum
    {
        MessageID = 10,//, TransactionCode, InternalToken, InstrumentName, ExpiryDate, OptionType, NSEToken, BSEToken, OriginTime = 10,
        TableName=30,//, ISINNumber = 30,
        Segment = 3,
        Direction = 1, //MessageType, Market, Source, Destination, Purpose = 1,
        Symbol=20,//, StrikePrice = 20,
        Series =2,




        ExpiryDate =10,
         StrikePrice =20,
        OptionType = 10,
        MessageType =1,
        Market =1,
        TransactionCode =10,
        Source = 1,
        Destination = 1,
        NSEToken =10,
        BSEToken =10,
        OriginTime =10,
        Purpose =1,
        InternalToken =10,
         ISINNumber =30,
        InstrumentName =10,
    }
}
