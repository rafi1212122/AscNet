using AscNet.Common.Util;
using AscNet.GameServer;

namespace AscNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.c.Log("Starting...");

#if DEBUG
            if (Common.Common.config.VerboseLevel < Common.VerboseLevel.Debug)
                Common.Common.config.VerboseLevel = Common.VerboseLevel.Debug;
#endif

            PacketFactory.LoadPacketHandlers();
            Task.Run(GameServer.Server.Instance.Start);
            SDKServer.SDKServer.Main(args);
        }
    }
}