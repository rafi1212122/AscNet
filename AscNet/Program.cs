using AscNet.GameServer;
using AscNet.GameServer.Handlers;
using AscNet.GameServer.Commands;
using AscNet.Logging;
using AscNet.Common.Util;
using AscNet.Table.V2.share.reward;
using Newtonsoft.Json;

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
            // LoggerFactory.Logger.Debug(JsonConvert.SerializeObject(TableReaderV2.Parse<RewardTable>().Where(x => x.Id == null).SelectMany(x => x.SubIds)));
#endif

            PacketFactory.LoadPacketHandlers();
            CommandFactory.LoadCommands();

            Task.Run(Server.Instance.Start);
            SDKServer.SDKServer.Main(args);

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(KillProtocol);
        }

        static void KillProtocol(object? sender, EventArgs e)
        {
            LoggerFactory.Logger.Info("Shutting down...");

            foreach (var session in Server.Instance.Sessions)
            {
                session.Value.SendPush(new ShutdownNotify());
                session.Value.DisconnectProtocol();
            }
        }
    }
}