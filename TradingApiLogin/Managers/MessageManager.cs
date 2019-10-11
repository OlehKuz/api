using System;
using System.Diagnostics;

namespace TradingApiLogin.Managers
{
    public class MessageManager
    {
        public void HandleMessage(object obj, string message)
        {
            Console.WriteLine(message);
        }
    }
}
