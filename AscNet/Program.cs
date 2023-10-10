using AscNet.Common.Util;
using AscNet.GameServer;

namespace AscNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.c.Log("Starting...");
            PacketFactory.LoadPacketHandlers();
            Task.Run(GameServer.Server.Instance.Start);
            SDKServer.SDKServer.Main(args);
        }
    }
}