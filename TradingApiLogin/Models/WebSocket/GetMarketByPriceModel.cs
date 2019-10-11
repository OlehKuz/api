namespace TradingApiLogin.Models.WebSocket
{
    public class GetMarketByPriceModel : SocketMessage//p246
    {
        public string OpenMarketByPrice => "OPENMBP";
        public long LoginId { get; set; }= 97;
        public string SessionKey { get; set; } = "1040875036-01226283281";
        public string KeyIdentifier { get; set; }= "1734^1^3";
    }
}
