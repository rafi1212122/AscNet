using Newtonsoft.Json;

namespace AscNet.SDKServer.Models
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public partial class ScrollTextNotice
    {
        [JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("ModifyTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? ModifyTime { get; set; }

        [JsonProperty("BeginTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? BeginTime { get; set; }

        [JsonProperty("EndTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? EndTime { get; set; }

        [JsonProperty("Content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }

        [JsonProperty("ScrollInterval", NullValueHandling = NullValueHandling.Ignore)]
        public long? ScrollInterval { get; set; }

        [JsonProperty("ScrollTimes", NullValueHandling = NullValueHandling.Ignore)]
        public long? ScrollTimes { get; set; }

        [JsonProperty("ShowInFight", NullValueHandling = NullValueHandling.Ignore)]
        public long? ShowInFight { get; set; }

        [JsonProperty("ShowInPhotograph", NullValueHandling = NullValueHandling.Ignore)]
        public long? ShowInPhotograph { get; set; }
    }

    public partial class ScrollPicNotice
    {
        [JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("ModifyTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? ModifyTime { get; set; }

        [JsonProperty("Content", NullValueHandling = NullValueHandling.Ignore)]
        public NoticeContent[] Content { get; set; }

        public partial class NoticeContent
        {
            [JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
            public long? Id { get; set; }

            [JsonProperty("PicAddr", NullValueHandling = NullValueHandling.Ignore)]
            public string PicAddr { get; set; }

            [JsonProperty("JumpType", NullValueHandling = NullValueHandling.Ignore)]
            public string JumpType { get; set; }

            [JsonProperty("JumpAddr", NullValueHandling = NullValueHandling.Ignore)]
            public string JumpAddr { get; set; }

            [JsonProperty("PicType", NullValueHandling = NullValueHandling.Ignore)]
            public string PicType { get; set; }

            [JsonProperty("Interval", NullValueHandling = NullValueHandling.Ignore)]
            public long? Interval { get; set; }

            [JsonProperty("BeginTime", NullValueHandling = NullValueHandling.Ignore)]
            public long? BeginTime { get; set; }

            [JsonProperty("EndTime", NullValueHandling = NullValueHandling.Ignore)]
            public long? EndTime { get; set; }

            [JsonProperty("AppearanceDay", NullValueHandling = NullValueHandling.Ignore)]
            public dynamic[] AppearanceDay { get; set; }

            [JsonProperty("AppearanceCondition", NullValueHandling = NullValueHandling.Ignore)]
            public dynamic[] AppearanceCondition { get; set; }

            [JsonProperty("DisappearanceCondition", NullValueHandling = NullValueHandling.Ignore)]
            public dynamic[] DisappearanceCondition { get; set; }

            [JsonProperty("AppearanceTime", NullValueHandling = NullValueHandling.Ignore)]
            public dynamic[] AppearanceTime { get; set; }
        }
    }
}
