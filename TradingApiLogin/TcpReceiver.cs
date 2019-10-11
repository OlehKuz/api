
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TradingApiLogin
{
    public class TcpReceiver
    {
        private readonly HashSet<int> readlineMessages = new HashSet<int>();
        private static int headerSizeInBytes = 2;
        private static string delimeter = "|";



        private string ReadOneResponseWithNewLineDelimeter(Socket socket)
        {
            using (NetworkStream ns = new NetworkStream(socket))
            using (StreamReader sr = new StreamReader(ns))
            return sr.ReadLine();
        }






        private string ReadOneResponseByDelimeters(Socket socket, StringBuilder stringBuilder, int messageId)
        {
            string oneResponse = string.Empty;
            int sectionsToRead = GetResponseChunksLength(messageId);
            if (sectionsToRead == -1) throw new System.Exception($"There is no message with id {messageId} in the database");
            string oneRead;
            var allbytes = new byte[250];
            int totalNumberOfSlashes = 0;
            int oneReadNumberOfSlashes = 0;
            while (totalNumberOfSlashes < sectionsToRead)
            {
                if (socket.Receive(allbytes) > 0)
                {
                    byte[] bytes = new byte[allbytes.GetUpperBound(0)-allbytes.GetLowerBound(0)];
                    Array.Copy(allbytes,allbytes.GetLowerBound(0), bytes, 0, bytes.Length);
                    oneRead = Encoding.ASCII.GetString(bytes);

                    oneReadNumberOfSlashes = CountNumberOfSlashes(oneRead);
                    if (totalNumberOfSlashes + oneReadNumberOfSlashes >= sectionsToRead)
                    {
                        oneResponse = stringBuilder.ToString();
                        stringBuilder.Clear();
                        int indexToSplitIntoResponseAndBuffer = FindSpecificOccurenceOfDelimeter(oneRead, sectionsToRead - totalNumberOfSlashes);
                        if (indexToSplitIntoResponseAndBuffer != -1)
                        {
                            oneResponse += oneRead.Substring(0, indexToSplitIntoResponseAndBuffer);
                            //to do check that we append non empty message /0
                            stringBuilder.Append(oneRead.Substring(indexToSplitIntoResponseAndBuffer));
                            break;
                        }                       
                    }
                    else
                    {
                        stringBuilder.Append(oneRead);
                        totalNumberOfSlashes += oneReadNumberOfSlashes;
                    }

                }
            }
            return oneResponse;
        }

        private int ParseHeader(string messageType)
        {
            
            if (int.TryParse(messageType, out int id)) return id;
            return -1;
        }  

        public string Receive(Socket socket, StringBuilder stringBuilder)
        {
            string headerValue = string.Empty;
            //if stringbuilder is empty
            if (stringBuilder.Length == 0)
            {
                headerValue = ReceiveHeader(socket, headerSizeInBytes);
                if (headerValue.Equals("\n")) headerValue = ReceiveHeader(socket, headerSizeInBytes);
            }
            if (stringBuilder.Length > 0)
            {
               // headerValue =  take out a part where is message id
            }
            int messageId = ParseHeader(headerValue);
            if (messageId == -1) throw new System.Exception("Response message doesnt specify message id");
            if (readlineMessages.Contains(messageId)) return ReadOneResponseWithNewLineDelimeter(socket);
            return ReadOneResponseByDelimeters(socket, stringBuilder, messageId);
        }

        private int CountNumberOfSlashes(string responseChunkRead)
        {
            return (responseChunkRead.Length - responseChunkRead.Replace(delimeter, "").Length)/ delimeter.Length;
        }


        private int FindSpecificOccurenceOfDelimeter(string containsEndOfResponse, int delimeterCount)
        {
            int counter = 0;
            for (int i = 0; i < containsEndOfResponse.Length; i++)
            {
                if (containsEndOfResponse[i].ToString().Equals(delimeter)) counter++;
                if (counter == delimeterCount) return i+1;
            }
            return -1;
        }
        private string ReceiveHeader(Socket socket, int headerSizeInBytes)
        {
            string messageType;

            byte[] headerBuffer = new byte[headerSizeInBytes];
            int totalBytesReceived = 0;
            int thisTimeBytesReceived = 0;
            byte[] header = new byte[1];
            
            while (totalBytesReceived < headerSizeInBytes)
            {
                thisTimeBytesReceived = socket.Receive(header);
                header.CopyTo(headerBuffer, totalBytesReceived);
                totalBytesReceived += thisTimeBytesReceived;
            }
            return Encoding.ASCII.GetString(headerBuffer);
          
        }

        private int GetResponseChunksLength(int id)
        {
            
            
                switch (id)
                {
                    case 57:
                        return 15;
                    case 76:
                        return 61;
                    case 61:
                        return 77;
                    case 59:
                    case 69:
                    case 63:
                    case 71:
                        return 5;
                    case 60:
                    case 82:
                        return 68;
                    case 92:
                        return 71;
                    default:
                        return -1;
                }
        
        }
      
    }
}
