using System.Reflection;
using AscNet.Logging;
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

    [AttributeUsage(AttributeTargets.Method)]
    public class RequestPacketHandler : Attribute
    {
        public string Name { get; }

        public RequestPacketHandler(string name)
        {
            Name = name;
        }
    }

    public delegate void RequestPacketHandlerDelegate(Session session, Packet.Request packet);

    public static class PacketFactory
    {
        public static readonly Dictionary<string, RequestPacketHandlerDelegate> ReqHandlers = new();

        // TODO: Configure based on session?
        static readonly Logger log = new(typeof(PacketFactory), LogLevel.DEBUG, LogLevel.DEBUG);

        public static void LoadPacketHandlers()
        {
            LoadRequestPacketHandlers();
        }

        private static void LoadRequestPacketHandlers()
        {
            log.Info("Loading Packet Handlers...");

            IEnumerable<Type> classes = from t in Assembly.GetExecutingAssembly().GetTypes()
                                        select t;

            foreach (var method in classes.SelectMany(t => t.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)))
            {
                var attr = method.GetCustomAttribute<RequestPacketHandler>(false);
                if (attr == null || ReqHandlers.ContainsKey(attr.Name)) continue;
                ReqHandlers.Add(attr.Name, (RequestPacketHandlerDelegate)Delegate.CreateDelegate(typeof(RequestPacketHandlerDelegate), method));
#if DEBUG
                log.Info($"Loaded {method.Name}");
#endif
            }

            log.Info("Finished Loading Packet Handlers");
        }

        public static RequestPacketHandlerDelegate? GetRequestPacketHandler(string name)
        {
            ReqHandlers.TryGetValue(name, out RequestPacketHandlerDelegate? handler);
            return handler;
        }
    }
}
