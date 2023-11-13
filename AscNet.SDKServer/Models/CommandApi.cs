using Newtonsoft.Json;

namespace AscNet.SDKServer.Models
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class ExecuteCommandBody
    {
        [JsonProperty("args", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Args { get; set; }
    }
}
