using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TradingApiLogin.Extention
{
    public static class ClassExtention
    {
        public static string ConcatenatePropertyValue<TClass>(this TClass obj) where TClass : class, new()
        {
            StringBuilder query = new StringBuilder();
            var properties = typeof(TClass).GetProperties();

            foreach (var prop in properties)
            {

                query.Append(prop.GetDescription() + "=" + GetPropertyValue(prop, obj) + "&");
            }
            return query.ToString(0, query.Length - 1);

        }

        private static string GetPropertyValue<TClass>(PropertyInfo property, TClass obj) where TClass : class, new()
        {
            Type type = property.PropertyType;
            var value = property.GetValue(obj);
            if (value == null)return string.Empty;
            return value.ToString();
        }
        public static string GetDescription(this PropertyInfo property) 
        {
            return property.GetCustomAttributes(typeof(DescriptionAttribute), false)
                .Cast<DescriptionAttribute>()
                .FirstOrDefault()?.Description
                ?? property.Name;
        }
        
    }
}
