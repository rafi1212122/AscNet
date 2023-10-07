using Newtonsoft.Json;

namespace AscNet.SDKServer.Models
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public partial class LoginNotice
    {
        [JsonProperty("BeginTime", NullValueHandling = NullValueHandling.Ignore)]
        public long BeginTime { get; set; }

        [JsonProperty("EndTime", NullValueHandling = NullValueHandling.Ignore)]
        public long EndTime { get; set; }

        [JsonProperty("HtmlUrl", NullValueHandling = NullValueHandling.Ignore)]
        public string HtmlUrl { get; set; }

        [JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("ModifyTime", NullValueHandling = NullValueHandling.Ignore)]
        public long ModifyTime { get; set; }

        [JsonProperty("Title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }
    }
}
