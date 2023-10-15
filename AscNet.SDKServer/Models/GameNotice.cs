using Newtonsoft.Json;

namespace AscNet.SDKServer.Models
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public partial class GameNotice
    {
        [JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("Title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("Tag", NullValueHandling = NullValueHandling.Ignore)]
        public long? Tag { get; set; }

        [JsonProperty("Type", NullValueHandling = NullValueHandling.Ignore)]
        public long? Type { get; set; }

        [JsonProperty("Order", NullValueHandling = NullValueHandling.Ignore)]
        public long? Order { get; set; }

        [JsonProperty("ModifyTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? ModifyTime { get; set; }

        [JsonProperty("BeginTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? BeginTime { get; set; }

        [JsonProperty("EndTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? EndTime { get; set; }

        [JsonProperty("Content", NullValueHandling = NullValueHandling.Ignore)]
        public NoticeContent[] Content { get; set; }

        public partial class NoticeContent
        {
            [JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
            public long? Id { get; set; }

            [JsonProperty("Title", NullValueHandling = NullValueHandling.Ignore)]
            public string Title { get; set; }

            [JsonProperty("Url", NullValueHandling = NullValueHandling.Ignore)]
            public string Url { get; set; }

            [JsonProperty("Order", NullValueHandling = NullValueHandling.Ignore)]
            public string Order { get; set; }
        }
    }
}
