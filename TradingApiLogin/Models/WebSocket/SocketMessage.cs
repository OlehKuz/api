using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TradingApiLogin.Models.WebSocket
{
    public class SocketMessage
    {
        [JsonIgnore]
        public string Message => GetQueryString(this); 
        [JsonIgnore]
        public string HeaderMessage => GetHeaderString(this);

        private static string GetQueryString(object data)
        {
            var obj = (JObject)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(data));

            return string.Join("|", obj.Children()
                .Cast<JProperty>()
                //.Where(j => !IsDefaultValue(j.Value.ToString()))
                .Select(j => j.Value)) + "\n";
        }
        private static string GetHeaderString(object data)
        {
            var obj = (JObject)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(data));

            return string.Join("", obj.Children()
                .Cast<JProperty>()
                .Select(j => GetValue(j.Value.ToString()).PadRight(GetPadSize(j.Name))));

        }

        private static int GetPadSize(string propertyName)
        {
            HeaderEnum @enum;
            if (Enum.IsDefined(typeof(HeaderEnum), propertyName))
            {
                if (Enum.TryParse<HeaderEnum>(propertyName, true, out @enum))
                {
                    int enumValue = (int)@enum;
                    return enumValue;
                }
            }
            
          
            return -1;
        }

        private static bool IsDefaultValue(string value)
        {
            if (value == null
               || value.Equals(string.Empty)
               || value.Equals(default(long).ToString())
               || value.Equals(default(double).ToString())
               || value.Equals(default(char).ToString())
                || value.Equals(default(DateTime).ToString()))return true;

            return false;
        }

        private static string GetValue(string value)
        {
            if (value == null
                || value.Equals(string.Empty)
                || value.Equals(default(long).ToString())
                || value.Equals(default(double).ToString())
                || value.Equals(default(char).ToString()))

            { return ""; }
            return value;
        }
        public byte[] ToByteArray() =>
            Encoding.ASCII.GetBytes(Message);
    }
}