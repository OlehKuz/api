using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using TradingApiLogin.Models.REST;
using System.Net.Sockets;
using TradingApiLogin.Models.WebSocket;
using TradingApiLogin.Extention;
using TradingApiLogin.Managers;
using BOWTest.Models.REST;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

//using Microsoft.Data.Sqlite;

namespace TradingApiLogin
{
    class Program
    {
        //private static readonly 

        /*static void ParseTcpResponse()
        {
            string raw = "61 || 1 | 3 | 1734 | 0 | 0 | 0 | 0.00 || 0.00 | 0.00 | 0 || 0.00 | 0 | 0.00 | 0 | 0 | 0.00 | 0 | 0.00 | 0.00 | 0.00 | 0.00 | 0.00 | 0.00 | 0.0 | 0 | 0.00 | 0.00 | 0 | 0 | 0 | | 0.00 || SILVERAUG19PE41500.0000 || OPTFUT | 1566950400 | 41500.00 | PE ||| SILVER | 30 | -35.00 | BSE | Commodities || 1 KGS | KGS | 28 Aug 2019 |||| 1734 ^ 1 ^ 3 | 0.00 | 0.00 | 0 | 0.00 | 0.00 | 0.00 |||||||| 0.00 |||||| 61 || 1 | 3 | 1105 | 0 | 0 | 0 | 0.00 || 0.00 | 0.00 | 0 || 0.00 | 0 | 0.00 | 0 | 0 | 0.00 | 0 | 0.00 | 0.00 | 0.00 | 0.00 | 0.00 | 0.00 | 0.0 | 0 | 0.00 | 0.00 | 0 | 0 | 0 | | 0.00 || SPOTCOPPER || FUTCOM | -1 | -0.01 |||| SPOTCOPPER | 1 | 0.00 | BSE |Commodities||1 KG|MT|01 Jan 1970||||1105^1^3|0.00|0.00|0|0.00|0.00 0.00 ||||||||0.00||||||";
            string r = "61";
            int r1 = 61;
            Console.WriteLine(ASCIIEncoding.ASCII.GetBytes(raw).Length);
            Console.WriteLine(ASCIIEncoding.ASCII.GetBytes(r).Length);
            
        }*/
        static async Task BroadcastHttp(HttpClient client, JsonResponseConvert jsonResponseConvert)
        {
            string queryPreAddArbitrageMarketWatch = "http://membersim.bseindia.com/stocks/PreAddArbitrageMarketWatch?";
            PreAddArbitrageMarketWatchModel preadd = new PreAddArbitrageMarketWatchModel();
            string queryPreAdd = preadd.ConcatenatePropertyValue();
            string queryResponse = await CallApi(client, queryPreAddArbitrageMarketWatch + queryPreAdd);

            AddArbitrageMarketWatchModel addArbitrage = new AddArbitrageMarketWatchModel();
            string queryAddArbitrageMarketWatch = "http://membersim.bseindia.com/stocks/AddArbitrageMarketWatch?";
            string queryAdd = addArbitrage.ConcatenatePropertyValue();
            string queryAddResponse = await CallApi(client, queryAddArbitrageMarketWatch + queryAdd);


        }
        static void Main(string[] args)
        {
           
            // using (var context = new _⁨Users⁨magnis2⁨Downloads⁨sqlitetoolsosxx863290000⁩MastersContext())
            //{

            //var result = context.Model.GetEntityTypes();
            /* try
            {
                using (SqliteConnection con = new SqliteConnection("DataSource=/Users/magnis-2/Downloads/Masters.db,Version=2"))
                {
                    con.Open();
                    string stm = "select BCCID from BSECommodityContracts";

                    using (SqliteCommand cmd = new SqliteCommand(stm, con))
                    {
                        using (SqliteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                Console.WriteLine(rdr.GetString(1));
                            }
                        }
                    }

                    con.Close();
                }
            }

            catch (Exception ex)
            {
                var ea = ex.Message;
            }*/
            //}
            //http
            IDictionary<int, Type> dictionary = new Dictionary<int, Type>();
            dictionary.TryAdd(1, typeof(AddOrderResponse));
            JsonResponseConvert jsonResponseConvert = new JsonResponseConvert();
            try { var deserialised = jsonResponseConvert.Deserialize(dictionary[1], "|ss|str", '|'); } catch (Exception ex){ var e = ex.Message; }
            
            CookieContainer cc = new CookieContainer();
            var handler = new HttpClientHandler { CookieContainer = cc };
            var client = new HttpClient(handler);
            //BroadcastHttp(client, jsonResponseConvert).GetAwaiter().GetResult();
            //AddTcpOrder();
            //CallLogin(client, jsonResponseConvert).GetAwaiter().GetResult();
            //AfterMobileLogin(client, jsonResponseConvert, 715787).GetAwaiter().GetResult();
            //AddOrder(client, jsonResponseConvert).GetAwaiter().GetResult();

            //DoSockets();
        }
        static void AddTcpOrder()
        {
          
            ConnectMessageModel connectMessageModel = new ConnectMessageModel();
            SocketClient socketClient = new SocketClient("membersim.bseindia.com", 8083, new MessageManager(), new TcpReceiver());
            socketClient.SendMessage(connectMessageModel);
            try { Models.WebSocket.AddOrder order = new Models.WebSocket.AddOrder();
                socketClient.SendMessage(order);
                var messaege = order.Message;
            }
            
            catch (Exception ex)
            {
                var exept = ex.Message;
            }

            //  socketClient.SendMessage(order);

        }

        static async Task AddOrder(HttpClient client, JsonResponseConvert jsonResponseConvert)
        {
            string queryAddOrder = "http://membersim.bseindia.com/stocks/AddOrder?";
            OrderAndTrade.AddOrder newOrder = new OrderAndTrade.AddOrder();
            string queryOrder1 = newOrder.ConcatenatePropertyValue();
            string AddOrderResponse = await CallApi(client, queryAddOrder + queryOrder1);
             AddOrderResponse deserializedAddOrderResponse = (AddOrderResponse)jsonResponseConvert.Deserialize(typeof(AddOrderResponse), AddOrderResponse); 
            
            //string queryAddOrder = "http://membersim.bseindia.com/stocks/AddOrder?";
            //OrderAndTrade.AddOrder newOrder = new OrderAndTrade.AddOrder();
            string queryOrder = "OEToken=" + newOrder.OEToken + "&OENSEToken=" + newOrder.OENSEToken + "&OEBSEToken=" + newOrder.OEBSEToken + "&OEDestination=" + newOrder.OEDestination + "&InstrumentType=" + newOrder.InstrumentType +
                 "&OEMarket=" + newOrder.OEMarket + "&OESymbol=" + newOrder.OESymbol + "&OEExpiryDate=" + newOrder.OEExpiryDate +
                 "&OEStrikePrice=" + newOrder.OEStrikePrice + "&OEOptionType=" + newOrder.OEOptionType + "&OESeries=" + newOrder.OESeries + "&OEVolume=" + newOrder.OEVolume +
                 "&OEPrice=" + newOrder.OEPrice + "&OETriggerPrice=" + newOrder.OETriggerPrice + "&OEDisclosedVolume=" + newOrder.OEDisclosedVolume + "&USBackOfficeId=" + newOrder.USBackOfficeId +
                 "&OEFIELD3=" + newOrder.OEFIELD3 + "&OEBuySellIndicator=" + newOrder.OEBuySellIndicator + "&OEAlphaChar=" + newOrder.OEAlphaChar + "&OEActualApproverId=" + newOrder.OEActualApproverId +
                 "&OEVolumeRemaining=" + newOrder.OEVolumeRemaining + "&OEDisclosedVolumeRemaining=" + newOrder.OEDisclosedVolumeRemaining
                 + "&OEAdminUSID=" + newOrder.OEAdminUSID + "&OEStatus=" + newOrder.OEStatus + "&OEProClientIndicator=" + newOrder.OEProClientIndicator + "&OESettlor=" + newOrder.OESettlor +
                 "&OEOrderNumber=" + newOrder.OEOrderNumber + "&OEField1=" + newOrder.OEField1 + "&OEParticipantType=" + newOrder.OEParticipantType + "&OEIntuitionalClient=" + newOrder.OEIntuitionalClient +
                 "&OEName=" + newOrder.OEName + "&OEGoodTillDate=" + newOrder.OEGoodTillDate + "&GTC=" + newOrder.GTC + "&IOC=" + newOrder.IOC +
                 "&OEBookType=" + newOrder.OEBookType + "&OESegment=" + newOrder.OESegment + "&OEGroup=" + newOrder.OEGroup + "&BlockDeal=" + newOrder.BlockDeal +
                 "&OEReason=" + newOrder.OEReason + "&OEApproverRemarks=" + newOrder.OEApproverRemarks + "&OESolicitorPeriod=" + newOrder.OESolicitorPeriod + "&SessionKey=" + newOrder.SessionKey + "&Thick Client=" + newOrder.ThickClient;
                 

            /*string queryOrder = "OEToken=" + newOrder.OEToken + "&OENSEToken=&OEBSEToken=" + newOrder.OEBSEToken + "&OEDestination=" + newOrder.OEDestination + "&InstrumentType=" + newOrder.InstrumentType +
                "&OEMarket=" + newOrder.OEMarket + "&OESymbol=" + newOrder.OESymbol + "&OEExpiryDate=" + newOrder.OEExpiryDate +
                "&OEStrikePrice=" + newOrder.OEStrikePrice + "&OEOptionType=&OESeries=&OEVolume=" + newOrder.OEVolume +
                "&OEPrice=" + newOrder.OEPrice + "&OETriggerPrice=" + newOrder.OETriggerPrice + "&OEDisclosedVolume=" + newOrder.OEDisclosedVolume + "&USBackOfficeId=" + newOrder.USBackOfficeId +
                "&OEFIELD3=" + newOrder.OEFIELD3 + "&OEBuySellIndicator=" + newOrder.OEBuySellIndicator + "&OEAlphaChar=&OEActualApproverId=&OEVolumeRemaining=&OEDisclosedVolumeRemaining=&OEAdminUSID=" + newOrder.OEAdminUSID + "&OEStatus=" + newOrder.OEStatus + "&OEProClientIndicator="
                + newOrder.OEProClientIndicator + "&OESettlor=&OEOrderNumber=&OEField1=&OEParticipantType=&OEIntuitionalClient=" + newOrder.OEIntuitionalClient +
                "&OEName=&OEGoodTillDate=&GTC=" + newOrder.GTC + "&IOC=" + newOrder.IOC +
                "&OEBookType=" + newOrder.OEBookType + "&OESegment=&OEGroup=&BlockDeal=&OEReason=&OEApproverRemarks=&OESolicitorPeriod=&SessionKey=" + newOrder.SessionKey + "&Thick Client=" + newOrder.ThickClient;
                */
            bool equal = queryOrder1.Equals(queryOrder);
            //CheckIdentity(queryOrder, queryOrder1);
            

        }
        static void CheckIdentity(string queryOrder, string queryOrder1)
        {
            for (int i = 0; i < queryOrder.Length; i++)
            {
                if (!queryOrder[i].Equals(queryOrder1[i]))
                {
                    Console.WriteLine(i);
                }
            }
        }
        static async Task<string> CallApi(HttpClient httpClient, string query)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, query);
            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string text;
            using (Stream stream = await response.Content.ReadAsStreamAsync())
            using (StreamReader readstream = new StreamReader(stream, Encoding.ASCII))
                text = readstream.ReadToEnd();
            return text;
        }
        static async Task AfterMobileLogin(HttpClient client, JsonResponseConvert jsonResponseConvert, int OTP)
        {
            string queryAuthenticationLogin = "http://membersim.bseindia.com/stocks/AuthenticationLogin?OTP=" + OTP + "&USLOGINID=SER_CT2-T9072&SessionKey=&Thick Client=Y";
            string authenticationLoginResponse = await CallApi(client, queryAuthenticationLogin);
            //AuthenticationLoginResponse deserializedAuthenticationLoginResponse = (AuthenticationLoginResponse)jsonResponseConvert.Deserialize(typeof(AuthenticationLoginResponse), authenticationLoginResponse, '|');
            Console.WriteLine(authenticationLoginResponse);
        }

        static async Task CallLogin(HttpClient client, JsonResponseConvert jsonResponseConvert)
        {

            string queryLoginServlet = "http://membersim.bseindia.com/stocks/LoginServlet?USBackOfficeId=&USLOGINID=SER_CT2-T9072&USPassword=ser.123456&USTransactionPassword=&version=1.3044&SecuritiesMaxSequenceId=1&NSEContractsMaxSequenceId=82&NcdexContractsMaxSequenceId=60&MCXContractsMaxSequenceId=139&BSEContractsMaxSequenceId=1&BSECurrencyContractsMaxSequenceId=1&NSECurrencyContractsMaxSequenceId=2125&enable2FA=Y&VenderCode=8_SER&SessionKey=&Thick Client=Y";

            string loginServletResponse = await CallApi(client, queryLoginServlet);
            //LoginServletResponse deserializedLoginServletResponse = (LoginServletResponse)jsonResponseConvert.Deserialize(typeof(LoginServletResponse), loginServletResponse);

            string queryAuthenticationMode = "http://membersim.bseindia.com/stocks/AuthenticationMode?verificationMode=1&USLOGINID=SER_CT2-T9072&SessionKey=&Thick Client=Y";
            string authenticationModeResponse = await CallApi(client, queryAuthenticationMode);
            //AuthenticationModeResponse deserializedAuthenticationModeResponse = (AuthenticationModeResponse)jsonResponseConvert.Deserialize(typeof(AuthenticationModeResponse), authenticationModeResponse, '|');
        }



        static void DoSockets()
        {
           
            RECEIVEORDERGATEWAY orderGateway = new RECEIVEORDERGATEWAY();
            ConnectMessageModel connectModel = new ConnectMessageModel();
           SocketClient socketClient = new SocketClient("membersim.bseindia.com", 8082, new MessageManager(), new TcpReceiver());
            socketClient.SendMessage(orderGateway);
            socketClient.SendMessage(connectModel);
            GetMarketByPriceModel getMarket = new GetMarketByPriceModel();
            socketClient.SendMessage(getMarket);
            /*GetMarketByPriceModel marketByPrice = new GetMarketByPriceModel();
            marketByPrice.LoginId = 97;
            marketByPrice.SessionKey = newOrder.SessionKey;
            marketByPrice.KeyIdentifier = newOrder.OEToken + "^" + newOrder.OEBSEToken + "^" + newOrder.OEMarket;
            socketClient.SendMessage(marketByPrice);
            */
            /*OrderAndTrade.AddOrder newOrder = new OrderAndTrade.AddOrder();
            AddArbitrageMarketWatchTokensModel arbitrage = new AddArbitrageMarketWatchTokensModel();
            arbitrage.LoginId = 97;
            arbitrage.SessionKey = newOrder.SessionKey;
            arbitrage.KeyIdentityFier = newOrder.OEToken + "^" + newOrder.OEBSEToken + "^" + newOrder.OEMarket;
            socketClient.SendMessage(arbitrage);*/
            //Client("Open Market by price=" + marketByPrice.OpenMarketByPrice + "|Internal USID=" + marketByPrice.LoginId + "|SessionKey=" + marketByPrice.SessionKey + "|KeyIdentifier=" + marketByPrice.KeyIdentifier);

            // Client(marketByPrice.OpenMarketByPrice + "|" + marketByPrice.LoginId + "|" + marketByPrice.SessionKey + "|" + marketByPrice.KeyIdentifier);



        }


        static void Client(string s)
        {
            Uri socketUri = new Uri("tcp://membersim.bseindia.com");

            using (TcpClient client = new TcpClient(socketUri.Host, socketUri.Port))
            using (NetworkStream n = client.GetStream())
            {
                BinaryWriter w = new BinaryWriter(n);
                w.Write(s);
                w.Flush();
                Console.WriteLine(new BinaryReader(n).ReadString());
            }
        }

    }
}

