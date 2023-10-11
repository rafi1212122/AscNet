using System.Net.Sockets;
using System.Net;
using AscNet.Common.Util;

namespace AscNet.GameServer
{
    public class Server
    {
        public static readonly Logger c = new(nameof(GameServer), ConsoleColor.Cyan);
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
                    c.Log($"{nameof(GameServer)} started and listening on port {Common.Common.config.GameServer.Port}");

                    while (true)
                    {
                        TcpClient tcpClient = listener.AcceptTcpClient();
                        string id = tcpClient.Client.RemoteEndPoint!.ToString()!;

                        c.Warn($"{id} connected");
                        Sessions.Add(id, new Session(id, tcpClient));
                    }
                }
                catch (Exception ex)
                {
                    c.Error("TCP listener error: " + ex.Message);
                    c.Log("Waiting 3 seconds before restarting...");
                    Thread.Sleep(3000);
                }
            }
        }
    }
}