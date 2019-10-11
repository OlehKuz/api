using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace TradingApiLogin
{
    public class JsonResponseConvert
    {

        public object Deserialize(Type typeToDeserialize, string rawResponse, bool outer, char delimeter = '~',  params int[] propertyIndexesToKeep)
        {
            HashSet<int> indexToKeep = new HashSet<int> (propertyIndexesToKeep );
            var target = Activator.CreateInstance(typeToDeserialize);
            var props = target.GetType().GetProperties();
            for (int counter = 0; counter < props.Length; counter++)
            {
                if (outer && indexToKeep.Contains(counter)||!outer)
                {
                    if (rawResponse.Length == 0) break;
                    string nextToken;
                    rawResponse = ParseProperty(out nextToken, rawResponse, delimeter);

                    if (props[counter].PropertyType.IsClass && props[counter].PropertyType.Assembly.FullName == typeToDeserialize.Assembly.FullName)
                    //(prop.GetType().IsClass&&prop.GetType().Assembly==Assembly.GetExecutingAssembly())
                    {

                        object p = Deserialize(props[counter].PropertyType, nextToken, '|');
                        props[counter].SetValue(target, p);

                    }
                    else
                    {

                        if (string.IsNullOrEmpty(nextToken)) props[counter].SetValue(target, null, null);

                        else
                        {
                            //target.GetType().GetProperty(prop.Name).SetValue(target, Convert.ChangeType(nextToken, prop.PropertyType));//prop.GetType()nextToken);
                            props[counter].SetValue(target, Convert.ChangeType(nextToken, props[counter].PropertyType));
                        }

                    }
                }
                



            }
            return target;
        }
        //private readonly char _propertyDelimeter;
        /*private readonly char _valueDelimeter;
        public JsonResponseConvert() :this('~', '|')
        {
        }
        public JsonResponseConvert(char propertyDelimeter, char valueDelimeter)
        {
            _propertyDelimeter = propertyDelimeter;
            _valueDelimeter = valueDelimeter;
        }*/
        public object Deserialize(Type typeToDeserialize, string rawResponse, char delimeter = '~')
        {
            
            var target = Activator.CreateInstance(typeToDeserialize);
            var props = target.GetType().GetProperties();
            foreach (var prop in props)
            {
                if (rawResponse.Length == 0) break;
                string nextToken;
                rawResponse = ParseProperty(out nextToken, rawResponse, delimeter);

                if(prop.PropertyType.IsClass&& prop.PropertyType.Assembly.FullName == typeToDeserialize.Assembly.FullName)
                    //(prop.GetType().IsClass&&prop.GetType().Assembly==Assembly.GetExecutingAssembly())
                {
                   
                    object p = Deserialize(prop.PropertyType, nextToken, '|');
                    prop.SetValue(target, p);

                }
                else
                {

                    if (string.IsNullOrEmpty(nextToken)) prop.SetValue(target, null, null);

                    else
                    {
                        //target.GetType().GetProperty(prop.Name).SetValue(target, Convert.ChangeType(nextToken, prop.PropertyType));//prop.GetType()nextToken);
                        prop.SetValue(target, Convert.ChangeType(nextToken, prop.PropertyType));
                    }
                    
                }

                

            }
            return target;
        }

      
        /*private object ParseValues(string token)
        {
            var arrayValue = token.Split(_valueDelimeter);
            if (arrayValue.Length == 1) return arrayValue[0];
            return arrayValue;
        }*/
        private string ParseProperty(out string nextToken, string rawResponse, char delimeter)
        {
            int indexToSplit = rawResponse.IndexOf(delimeter);
            if (indexToSplit == -1)
            {
                nextToken = rawResponse;
                rawResponse = string.Empty;
            }
            else
            {
                nextToken = rawResponse.Substring(0, indexToSplit);
                rawResponse = rawResponse.Substring(indexToSplit + 1);
            }

            return rawResponse;
        }

    }
}
