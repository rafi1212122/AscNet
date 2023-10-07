using AscNet.Common.Util;

namespace AscNet.SDKServer.Models
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class RemoteConfig
    {
        [PropertyOrder(0)]
        public string Key { get; set; }

        [PropertyOrder(1)]
        public string Type { get; set; }

        [PropertyOrder(2)]
        public string Value { get; set; }
    }

    public static class RemoteConfigExtension
    {
        public static void AddConfig<T>(this List<RemoteConfig> remoteConfigs, string key, T value)
        {
            if (!typeMap.TryGetValue(typeof(T), out string? typeStr) || value is null)
                throw new ArgumentException("Unsupported value!", nameof(value));

            RemoteConfig remoteConfig = new()
            {
                Key = key,
                Type = typeStr
            };

            switch (typeStr)
            {
                case "int":
                case "float":
                case "string":
                    remoteConfig.Value = value.ToString() ?? "";
                    break;
                case "bool":
                    remoteConfig.Value = value.ToString() == "True" ? "1" : "0";
                    break;
                default:
                    break;
            }

            remoteConfigs.Add(remoteConfig);
        }

        private static Dictionary<Type, string> typeMap = new Dictionary<Type, string>
        {
            { typeof(string), "string" },
            { typeof(int), "int" },
            { typeof(bool), "bool" },
            { typeof(float), "float" },
        };
    }
}
