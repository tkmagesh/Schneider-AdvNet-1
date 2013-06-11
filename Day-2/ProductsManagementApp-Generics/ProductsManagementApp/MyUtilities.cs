using System.Collections.Generic;
using System.Reflection;

namespace ProductsManagementApp
{
    public static class MyUtilities
    {
        public static string Format(this IFormat obj, string delimeter = ",")
        {
            var result = string.Empty;
            var objType = obj.GetType();
            var properties = objType.GetProperties();
            var props = new SortedDictionary<int, PropertyInfo>();
            
            foreach (var property in properties)
            {
                var formatAttributes = property.GetCustomAttributes(typeof (FormatAttribute), false);
                if (formatAttributes.Length > 0)
                {
                    var formatAttribute = (FormatAttribute) formatAttributes[0];
                    if (formatAttribute.IsVisible)
                        props.Add(formatAttribute.Order, property);
                }
                else
                {
                    props.Add(props.Count,property);
                }
            }

            foreach (var prop in props)
            {
                result += prop.Value.GetValue(obj, null) + delimeter;
            }
            return result;
        }
    }
}