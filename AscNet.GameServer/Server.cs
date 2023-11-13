using System.Net.Sockets;
using System.Net;
using AscNet.Logging;

namespace AscNet.GameServer
{
    public class Server
    {
        public static Logger log;
        public readonly Dictionary<string, Session> Sessions = new();
        private static Server? _instance;
        private readonly TcpListener listener;

        public static Server Instance
        {
            get
            {
                return _instance ??= new Server();
            }
        }

        static Server()
        {
            // TODO: add loglevel based on appsettings
            LogLevel logLevel = LogLevel.DEBUG;
            LogLevel fileLogLevel = LogLevel.DEBUG;
            log = new(typeof(Server), logLevel, fileLogLevel);
        }

        public Server()
        {
            listener = new(IPAddress.Parse("0.0.0.0"), Common.Common.config.GameServer.Port);
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    listener.Start();
                    log.Info($"{nameof(GameServer)} started and listening on port {Common.Common.config.GameServer.Port}");

                    while (true)
                    {
                        TcpClient tcpClient = listener.AcceptTcpClient();
                        string id = tcpClient.Client.RemoteEndPoint!.ToString()!;

                        log.Warn($"{id} connected");
                        Sessions.Add(id, new Session(id, tcpClient));
                    }
                }
                catch (Exception ex)
                {
                    log.Error("TCP listener error: " + ex.Message);
                    log.Info("Waiting 3 seconds before restarting...");
                    Thread.Sleep(3000);
                }
            }
        }

        public Session? SessionFromUID(long uid)
        {
            return Sessions.FirstOrDefault(x => x.Value.player.PlayerData.Id == uid).Value;
        }
    }
}