using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TradingApiLogin.Models.WebSocket;

namespace TradingApiLogin.Managers
{
    public class SocketClient
    {
        private readonly string _host;
        private readonly int _port;
        private Socket _socket;
        private readonly MessageManager _messageManager;
        private readonly TcpReceiver _tcpReceiver;
        private readonly Queue<SocketMessage> _sendingMessagesQueue;

        public event EventHandler<string> OnNewMessage;

        public SocketClient(string host, int port, MessageManager messageManager, TcpReceiver tcpReceiver)
        {
            _host = host;
            _port = port;

            _sendingMessagesQueue = new Queue<SocketMessage>();
            _tcpReceiver = tcpReceiver;
            _messageManager = messageManager;
            StartTcpSendingThread();
            Thread.Sleep(20000);
            StartTcpReceivingThread();
        }

        public void SendMessage(SocketMessage socketMessage)
        {
            lock (_sendingMessagesQueue)
                _sendingMessagesQueue.Enqueue(socketMessage);
        }

        private void StartTcpReceivingThread()
        {
            OnNewMessage += _messageManager.HandleMessage;
            StringBuilder stringBuilder = new StringBuilder();
            var receivingThread = new Thread(() =>
            {
                while (true)
                {
                    if (_socket != null && _socket.Connected)
                    {
                        try
                        {
                            //
                            //StringBuilder stringBuilder = new StringBuilder();

                            //var bytes = new byte[250];
                            //var numBytesReadFromStream = _socket.Receive(bytes);

                            //if (numBytesReadFromStream > 0)
                            {
                                string oneResponse = _tcpReceiver.Receive(_socket, stringBuilder);
                                if (!string.IsNullOrEmpty(oneResponse))
                                {
                                    OnNewMessage?.Invoke(this, oneResponse);
                                }
                                //stringBuilder.Append(Encoding.ASCII.GetString(bytes));

                                //OnNewMessage?.Invoke(this, Encoding.ASCII.GetString(bytes));
                            }
                            /*if (!string.IsNullOrEmpty(oneResponse))
                            {
                                OnNewMessage?.Invoke(this, oneResponse);
                            } */
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            });

            receivingThread.Start();
        }

        private void StartTcpSendingThread()
        {
            var tcpSendingThread = new Thread(() =>
            {
                var tcpClient = new TcpClient();
                tcpClient.Connect(_host, _port);
            
                _socket = tcpClient.Client;

                while (true)
                {
                    SocketMessage message = null;

                    lock (_sendingMessagesQueue)
                    {
                        if (_sendingMessagesQueue.Count > 0)
                            message = _sendingMessagesQueue.Dequeue();
                    }

                    if (message != null)
                    {
                        try
                        {
                            _socket.Send(message.ToByteArray());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }
                    }
                }
             });

                tcpSendingThread.Start();
        }
    }
}
 