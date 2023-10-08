using MessagePack;

namespace AscNet.GameServer
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessagePackObject(false)]
    public class Packet
    {
        [Key(0)]
        public int No;

        [Key(1)]
        public ContentType Type;

        [Key(2)]
        public byte[] Content;

        public enum ContentType
        {
            Request,
            Response,
            Push,
            Exception
        }

        [MessagePackObject(false)]
        public class Request
        {
            [Key(0)]
            public int Id;

            [Key(1)]
            public string Name;

            [Key(2)]
            public byte[] Content;
        }

        [MessagePackObject(false)]
        public class Response
        {
            [Key(0)]
            public int Id;

            [Key(1)]
            public string Name;

            [Key(2)]
            public byte[] Content;
        }

        [MessagePackObject(false)]
        public class Push
        {
            [Key(0)]
            public string Name;

            [Key(1)]
            public byte[] Content;
        }

        [MessagePackObject(false)]
        public class Exception
        {
            [Key(0)]
            public int Id;

            [Key(1)]
            public int Code;

            [Key(2)]
            public string Message;
        }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
