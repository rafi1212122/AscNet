using AscNet.Common.MsgPack;
using System.Text.Json;
using Newtonsoft.Json;
using System.Reflection;
using AscNet.GameServer;
using MessagePack;
using static AscNet.GameServer.Packet;

namespace AscNet.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string lines = File.ReadAllText("Data/NotifyLogin.json");
            NotifyLogin notifyLogin = System.Text.Json.JsonSerializer.Deserialize<NotifyLogin>(lines)!;
            NotifyLogin notifyLoginNew = JsonConvert.DeserializeObject<NotifyLogin>(lines)!;

            foreach (PropertyCompareResult resultItem in Compare(notifyLogin, notifyLoginNew))
            {
                Console.WriteLine("  Property name: {0} -- old: {1}, new: {2}",
                    resultItem.Name, resultItem.OldValue ?? "<null>", resultItem.NewValue ?? "<null>");
            }
        }

        class PropertyCompareResult
        {
            public string Name { get; private set; }
            public object OldValue { get; private set; }
            public object NewValue { get; private set; }

            public PropertyCompareResult(string name, object oldValue, object newValue)
            {
                Name = name;
                OldValue = oldValue;
                NewValue = newValue;
            }
        }

        class IgnorePropertyCompareAttribute : Attribute { }

        private static List<PropertyCompareResult> Compare<T>(T oldObject, T newObject, Type typecast = null)
        {
            PropertyInfo[] properties = null;
            if (typecast != null)
            {
                properties = typecast.GetProperties();
            }
            else
            {
                properties = typeof(T).GetProperties();
            }
            List<PropertyCompareResult> result = new List<PropertyCompareResult>();

            foreach (PropertyInfo pi in properties)
            {
                if (pi.CustomAttributes.Any(ca => ca.AttributeType == typeof(IgnorePropertyCompareAttribute)))
                {
                    continue;
                }

                object oldValue = pi.GetValue(oldObject), newValue = pi.GetValue(newObject);

                if (!object.Equals(oldValue, newValue))
                {
                    PropertyInfo[] propertyInfos = oldValue.GetType().GetProperties();
                    if (propertyInfos.Length > 1 && oldValue.GetType().IsClass && !oldValue.GetType().IsArray && !oldValue.GetType().IsGenericType)
                    {
                        result.AddRange(Compare(oldValue, newValue, oldValue.GetType()));
                    }
                    else
                    {
                        result.Add(new PropertyCompareResult(pi.Name, oldValue, newValue));
                    }
                }
            }

            return result;
        }

    }
}