using Config.Net;

namespace AscNet.Common
{
    public interface IConfig
    {
        [Option(DefaultValue = VerboseLevel.Normal)]
        VerboseLevel VerboseLevel { get; set; }

        [Option]
        IGameServer GameServer { get; set; }

        [Option]
        IDatabase Database { get; set; }

        [Option(DefaultValue = false)]
        bool SaveClientLogs { get; set; }


        interface IGameServer
        {
            [Option(DefaultValue = nameof(AscNet))]
            string RegionName { get; set; }

            [Option(DefaultValue = "127.0.0.1")]
            string Host { get; set; }

            [Option(DefaultValue = (ushort)2335)]
            ushort Port { get; set; }
        }

        interface IDatabase
        {
            [Option(DefaultValue = "127.0.0.1")]
            string Host { get; set; }

            [Option(DefaultValue = (ushort)27017)]
            ushort Port { get; set; }

            [Option(DefaultValue = "sf")]
            string Name { get; set; }
        }

    }

    public enum VerboseLevel
    {
        Silent = 0,
        Normal = 1,
        Debug = 2,
        SuperDebug = 3
    }
}
