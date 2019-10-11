namespace TradingApiLogin.Models.WebSocket
{
    public class AddArbitrageMarketWatchTokensModel : SocketMessage//p230
    {
        public string OpenMarketWatch => "OPEN";
        public long LoginId { get; set; }
        public string SessionKey { get; set; }
        public int MarketWatchID => 8001;
        public string KeyIdentityFier { get; set; }
    }
}
