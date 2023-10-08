using System.Net.Sockets;
using AscNet.Common.Util;

namespace AscNet.GameServer
{
    public class Session
    {
        public readonly string id;
        public readonly TcpClient client;
        public readonly Logger c;
        private long lastPacketTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        // private ushort packetNo = 0;

        public Session(string id, TcpClient tcpClient)
        {
            this.id = id;
            client = tcpClient;
            c = new(id, ConsoleColor.DarkGray);

            Task.Run(ClientLoop);
        }

        public async void ClientLoop()
        {
            NetworkStream stream = client.GetStream();
            byte[] msg = new byte[1 << 16];

            while (client.Connected)
            {
                try
                {
                    Array.Clear(msg, 0, msg.Length);
                    int len = stream.Read(msg, 0, msg.Length);

                    if (len > 0)
                    {
                        lastPacketTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

                    }

                }
                catch (Exception)
                {
                    break;
                }
                await Task.Delay(10);
                // 10 sec timeout
                if (DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - lastPacketTime > 10000)
                    break;
            }

            DisconnectProtocol();
        }

        public void DisconnectProtocol()
        {
            if (Server.Instance.Sessions.GetValueOrDefault(id) is null)
                return;

            c.Warn($"{id} disconnected");
            client.Close();
            Server.Instance.Sessions.Remove(id);
        }
    }
}
