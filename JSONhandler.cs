using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Globalization;
using System.Text;

namespace TestingDiscordRPGStuff
{
    public class JSONhandler
    {
        public static string ObjectToJson(Object obj)
        {
            string jsonOut = "{";

            foreach (var property in obj.GetType().GetProperties())
            {
                if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType)
                        && !typeof(string).IsAssignableFrom(property.PropertyType))
                { // Checks if the property is an enumerable. (List<T>)
                    jsonOut += $"\"{property.Name}\":[";
                    if (property.GetValue(obj) is null) {
                        jsonOut += "],";
                        continue;
                    }
                    foreach (var item in (IEnumerable)property.GetValue(obj))
                    {
                        if (item is ValueType)
                        { // Value is a string
                            if (item is bool)
                            {
                                jsonOut += $"{item.ToString().ToLower()},";
                            } else
                            {
                                jsonOut += $"{item},";
                            }
                        }
                        else
                        {
                            jsonOut += $"\"{item}\",";
                        }

                    }
                    jsonOut = jsonOut.Remove(jsonOut.Length - 1);
                    jsonOut += $"],";
                }
                else
                {
                    if (typeof(ValueType).IsAssignableFrom(property.PropertyType))
                    { // The value is a Value
                        if (property.GetValue(obj) is bool)
                        {
                            jsonOut += $"\"{property.Name}\":{property.GetValue(obj).ToString().ToLower()},";
                        } else
                        {
                            jsonOut += $"\"{property.Name}\":{property.GetValue(obj)},";
                        }
                    }
                    else
                    {
                        jsonOut += $"\"{property.Name}\":\"{property.GetValue(obj)}\",";
                    }
                }
            }
            jsonOut = jsonOut.Remove(jsonOut.Length - 1);
            jsonOut += "}";
            return jsonOut;
        }


        public static dynamic CreateObjectFromJson(string jsonString)
        {
            dynamic expand = new ExpandoObject();
            var content = jsonString.Substring(1, jsonString.Length - 2);
            var elements = new List<string>();
            string element = "";
            string arrayContent = "";
            bool inArray = false;
            foreach (var character in content)
            {
                if (character == '[')
                {
                    // Start of an array
                    inArray = true;
                } else if (character == ']')
                {
                    // End of an array
                    inArray = false;
                    element += arrayContent;
                } else
                {
                    if (inArray)
                    {
                        if (character != '\\' || character != '"') arrayContent += character;
                    } else
                    {
                        if (character != ',' || character != '\\' || character != '"') element += character;
                    }
                }
                if (character == ',' && ! inArray)
                {
                    elements.Add(element);
                    element = "";
                }
            }
            var el = elements.Select(i => i.Replace(@"\", "")).ToList();
            Console.WriteLine(el);
            return expand;
        }
    }
}