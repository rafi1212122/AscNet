using System.Reflection;
using AscNet.Common.Util;
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
    public class PacketHandler : Attribute
    {
        public string Name { get; }

        public PacketHandler(string name)
        {
            Name = name;
        }
    }

    public delegate void PacketHandlerDelegate(Session session, byte[] packet);

    public static class PacketFactory
    {
        public static readonly Dictionary<string, PacketHandlerDelegate> Handlers = new();
        static readonly Logger c = new("Factory", ConsoleColor.Yellow);

        public static void LoadPacketHandlers()
        {
            c.Log("Loading Packet Handlers...");

            IEnumerable<Type> classes = from t in Assembly.GetExecutingAssembly().GetTypes()
                                        select t;

            foreach (var method in classes.SelectMany(t => t.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)))
            {
                var attr = method.GetCustomAttribute<PacketHandler>(false);
                if (attr == null || Handlers.ContainsKey(attr.Name)) continue;
                Handlers.Add(attr.Name, (PacketHandlerDelegate)Delegate.CreateDelegate(typeof(PacketHandlerDelegate), method));
#if DEBUG
                c.Log($"Loaded {method.Name}");
#endif
            }

            c.Log("Finished Loading Packet Handlers");
        }

        public static PacketHandlerDelegate? GetPacketHandler(string name)
        {
            Handlers.TryGetValue(name, out PacketHandlerDelegate? handler);
            return handler;
        }
    }
}
