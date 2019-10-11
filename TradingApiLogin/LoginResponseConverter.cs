using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TradingApiLogin
{
    public class LoginResponseConverter : JsonConverter<LoginServletResponse>
    {
        private readonly char _delimeter;
        public LoginResponseConverter() : this('|') { }
        public LoginResponseConverter(char delimeter) { _delimeter = delimeter; }

        public override LoginServletResponse ReadJson(JsonReader reader, Type objectType, LoginServletResponse existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            //LoginResponse loginResponse = new LoginResponse();
            JObject jObject = JObject.Load(reader);
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(objectType);  // Reflection. 

            // Displaying output. 
            foreach (System.Attribute attr in attrs)
            {
                if (attr is KnownTypeAttribute)
                {
                    KnownTypeAttribute k = (KnownTypeAttribute)attr;
                   
                    var target = Activator.CreateInstance(k.Type);
                    var props = k.Type.GetProperties();
                    bool found = true;
                    foreach (var pair in jObject)
                    {
                        if (props.Any(z => z.Name == pair.Key))
                        {
                            var value = ParseDelimeters((string)pair.Value);
                            target.GetType().GetProperty(pair.Key).SetValue(props, pair.Value);
                            
                        }
                        
                    }
                    return (LoginServletResponse)target;

                 
                }
            }
            /*foreach (var pair in jObject)
            {
                var key = pair.Key;
                var value = ParseDelimeters((string)pair.Value);
                
            }*/
        
            return null;
        }
        private string[] ParseDelimeters(string input)
        {
            var arrayValue = input.Split(_delimeter);
            return arrayValue;
        }
        public override void WriteJson(JsonWriter writer, LoginServletResponse value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
