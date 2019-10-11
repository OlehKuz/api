using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TradingApiLogin.Models.WebSocket;

namespace TradingApiLogin
{
    public class MySocketClient
    {

        private readonly string _host;
        private readonly int _port;
      
        private readonly Queue<SocketMessage> _sendingMessagesQueue;

        public MySocketClient(string host, int port)
        {
            _host = host;
            _port = port;

            _sendingMessagesQueue = new Queue<SocketMessage>();

            new Thread(StartTcpSendingThread).Start(); 
            StartTcpReceivingThread();
        }

        public void SendMessage(SocketMessage socketMessage)
        {
            lock (_sendingMessagesQueue)
                _sendingMessagesQueue.Enqueue(socketMessage);
        }

        private void StartTcpReceivingThread()
        {

            var listener = new TcpListener(IPAddress.Any, _port);
            listener.Start();

            while (true)
            {
                using (TcpClient c = listener.AcceptTcpClient())
                using (NetworkStream n = c.GetStream())
                {
                    string msg = new BinaryReader(n).ReadString();
                    Console.WriteLine(msg);
                }
            }



        }

        private void StartTcpSendingThread()
        {

            TcpClient client = new TcpClient(_host, _port);
            NetworkStream n = client.GetStream();
            BinaryWriter w = new BinaryWriter(n);
            SocketMessage message = null;
            while (true)
            {

                lock (_sendingMessagesQueue)
                {
                    if (_sendingMessagesQueue.Count > 0)
                        message = _sendingMessagesQueue.Dequeue();
                }

                if (message != null)
                {
                    w.Write(message.ToByteArray());
                    w.Flush();
                    Console.WriteLine(new BinaryReader(n, encoding:Encoding.ASCII).ReadString());

                }
            }
        }
    }
}
