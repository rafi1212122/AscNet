using AscNet.GameServer;
using AscNet.GameServer.Commands;
using AscNet.Logging;

namespace AscNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TODO: Add LogLevel parsing from appsettings file
            LoggerFactory.InitializeLogger(new Logger(typeof(Program), LogLevel.DEBUG, LogLevel.DEBUG));
            LoggerFactory.Logger.Info("Starting...");

#if DEBUG
            if (Common.Common.config.VerboseLevel < Common.VerboseLevel.Debug)
                Common.Common.config.VerboseLevel = Common.VerboseLevel.Debug;
#endif

            PacketFactory.LoadPacketHandlers();
            CommandFactory.LoadCommands();

            Task.Run(Server.Instance.Start);
            SDKServer.SDKServer.Main(args);
        }
    }
}