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
        public bool Verbose { get; set; } = false;
        // Add if Verbose for all methods

        public static string ObjectToJson(Object obj)
        {
            string jsonOut = $"{{\"name\":\"{obj.GetType().Name}\",";
            jsonOut += GetFields(obj) + ",";
            jsonOut += GetProperties(obj) + ",";
            jsonOut += GetMethods(obj);

            jsonOut += "}";
            return jsonOut;
        }

        private static string GetMethods(object obj)
        {
            string jsonString = "\"methods\":[";
            foreach (var field in obj.GetType().GetMethods())
            {

            }
            jsonString += "]";
            return jsonString;
        }

        private static string GetProperties(object obj)
        {
            string jsonString = "\"properties\":[";
            foreach (var field in obj.GetType().GetProperties())
            {
                if (typeof(IEnumerable).IsAssignableFrom(field.PropertyType)
                        && !typeof(string).IsAssignableFrom(field.PropertyType))
                { // Checks if the property is an enumerable. (List<T>)
                }
                else
                {
                    var fieldValue = field.GetValue(obj);
                    if (typeof(ValueType).IsAssignableFrom(field.PropertyType))
                    {
                        if (fieldValue is bool)
                        {
                            jsonString += $"{{\"name\":\"{field.Name}\",\"value\":{fieldValue.ToString().ToLower()},\"type\":\"{field.PropertyType.Name}\"}},";
                        }
                        else
                        {
                            jsonString += $"{{\"name\":\"{field.Name}\",\"value\":{fieldValue},\"type\":\"{field.PropertyType.Name}\"}},";
                        }
                    }
                    else
                    {
                        jsonString += $"{{\"name\":\"{field.Name}\",\"value\":\"{fieldValue}\",\"type\":\"{field.PropertyType.Name}\"}},";
                    }
                }
            }
            jsonString = jsonString.Remove(jsonString.Length - 1, 1);
            jsonString += "]";
            return jsonString;
        }

        private static bool IsVal(Object x)
        {
            if(typeof(ValueType).IsAssignableFrom((System.Type)x)) {
                return true;
            }
            return false;
        }

        private static string GetFields(object obj)
        {
            string jsonString = "\"fields\":[";
            foreach (var field in obj.GetType().GetFields())
            {

            }
            jsonString += "]";
            return jsonString;
        }

        public static dynamic CreateObjectFromJson(string jsonString)
        {
            var expand = new ExpandoObject() as IDictionary<string, Object>;
            Dictionary<string, string> translated = TranslateJson(jsonString);
            foreach (var entry in translated)
            {
                //Console.WriteLine($"key: {entry.Key}\t val: {entry.Value}");
                expand.Add(entry.Key, entry.Value);
            }
            return expand;
        }

        /// <summary>
        /// Translates the json string into dictionary containing variable name and value
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        private static Dictionary<string, string> TranslateJson(string jsonString)
        {
            var content = jsonString.Substring(1, jsonString.Length - 2);
            var output = new Dictionary<string, string>();
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
                }
                else if (character == ']')
                {
                    // End of an array
                    inArray = false;
                    element += arrayContent;
                }
                else
                {
                    if (inArray)
                    {
                        if (character != '\\' || character != '"') arrayContent += character;
                    }
                    else
                    {
                        if (character != ',' || character != '\\' || character != '"') element += character;
                    }
                }
                if (character == ',' && !inArray)
                {
                    elements.Add(element);
                    element = "";
                }
            }
            var el = elements.Select(i => i.Replace(@"\\", "")).ToList();
            //el.ForEach(Console.WriteLine);

            // Split the formatted list

            foreach (var line in el)
            {
                var split = line.Split(':');
                output.Add(split[0].Replace("\"", ""), split[1].Remove(split[1].Length-1, 1));
            }

            return output;
        }
    }
}