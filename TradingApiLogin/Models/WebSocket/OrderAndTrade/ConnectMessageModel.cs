using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingApiLogin.Models.WebSocket
{
    public class ConnectMessageModel : SocketMessage
    {
        public string ConnectMarketWatch => "CONNECT";
        public long LoginId { get; set; } = 97;
        public string SessionKey { get; set; } = "1040875036-01226283281";
        public string ConnectionType { get; set; } = "TCP";
        public string Filler1 { get; set; }
        public string Filler2 { get; set; }
        public string Filler3 { get; set; }
        public string ThickClient { get; set; } = "Y";
        public string InteractiveMessageFlag { get; set; } = "Y";
    }
}
