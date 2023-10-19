using System.Buffers.Binary;
using System.Net.Sockets;
using AscNet.Common;
using AscNet.Common.Database;
using AscNet.Common.Util;
using AscNet.Logging;
using MessagePack;
using Newtonsoft.Json;
using Logger = AscNet.Logging.Logger;

namespace AscNet.GameServer
{
    public class Session
    {
        public readonly string id;
        public readonly TcpClient client;
        public Player player = default!;
        public Character character = default!;
        public Stage stage = default!;
        public readonly Logger log;
        private long lastPacketTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        private ushort packetNo = 0;
        private readonly MessagePackSerializerOptions lz4Options = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4Block);

        public Session(string id, TcpClient tcpClient)
        {
            this.id = id;
            client = tcpClient;
            // TODO: add session based configuration? maybe from database?
            log = new(typeof(Session), id, LogLevel.DEBUG, LogLevel.DEBUG);
            log.LogLevelColor[LogLevel.INFO] = ConsoleColor.Cyan;
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
                        List<Packet> packets = new();

                        int readbytes = 0;
                        while (readbytes < len)
                        {
                            int packetLen = BinaryPrimitives.ReadInt32LittleEndian(msg.AsSpan()[readbytes..]);
                            readbytes += 4;
                            if (packetLen < 4)
                                break;
                            else
                            {
                                byte[] packet = GC.AllocateUninitializedArray<byte>(packetLen);
                                Array.Copy(msg, readbytes, packet, 0, packetLen);
                                readbytes += packetLen;
                                Crypto.HaruCrypt.Decrypt(packet);

                                try
                                {
                                    packets.Add(MessagePackSerializer.Deserialize<Packet>(packet, lz4Options));
                                }
                                catch (Exception)
                                {
                                    log.Error("Failed to deserialize packet: " + BitConverter.ToString(packet).Replace("-", ""));
                                }
                            }
                        }

                        foreach (var packet in packets)
                        {
                            byte[] debugContent = packet.Content;
                            try
                            {
                                switch (packet.Type)
                                {
                                    case Packet.ContentType.Request:
                                        Packet.Request request = MessagePackSerializer.Deserialize<Packet.Request>(packet.Content);
                                        debugContent = request.Content;

                                        RequestPacketHandlerDelegate? requestPacketHandler = PacketFactory.GetRequestPacketHandler(request.Name);
                                        if (requestPacketHandler is not null)
                                        {
                                            // TODO: with new logger this will be unnecessary
                                            if (Common.Common.config.VerboseLevel > VerboseLevel.Silent)
                                                log.Info($"{request.Name}{(Common.Common.config.VerboseLevel >= VerboseLevel.Debug ? (", " + JsonConvert.SerializeObject(MessagePackSerializer.Typeless.Deserialize(request.Content))) : "")}");
                                            requestPacketHandler.Invoke(this, request);
                                        }
                                        else
                                        {
                                            if (Common.Common.config.VerboseLevel > VerboseLevel.Silent)
                                                log.Warn($"{request.Name} handler not found!{(Common.Common.config.VerboseLevel >= VerboseLevel.Debug ? (", " + JsonConvert.SerializeObject(MessagePackSerializer.Typeless.Deserialize(request.Content))) : "")}");
                                        }
                                        break;

                                    case Packet.ContentType.Push:
                                        Packet.Push push = MessagePackSerializer.Deserialize<Packet.Push>(packet.Content);
                                        debugContent = push.Content;
                                        log.Info(push.Name);
                                        throw new NotImplementedException($"Packet push handlers not implemented ({push.Name})");

                                    case Packet.ContentType.Exception:
                                        Packet.Exception exception = MessagePackSerializer.Deserialize<Packet.Exception>(packet.Content);
                                        log.Error($"Exception packet received: {exception.Code}, {exception.Message}");
                                        break;

                                    default:
                                        log.Error($"Unknown packet received: {packet}");
                                        break;
                                }
                            }
                            catch (Exception ex)
                            {
                                log.Error("Failed to invoke handler: " + ex.Message + $", Raw {packet.Type} packet: " + BitConverter.ToString(debugContent).Replace("-", ""));
                            }
                        }
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

        public void SendPush<T>(T push) where T : new()
        {
            Packet.Push packet = new()
            {
                Name = typeof(T).Name,
                Content = MessagePackSerializer.Serialize(push)
            };
            Send(new Packet()
            {
                No = ++packetNo,
                Type = Packet.ContentType.Push,
                Content = MessagePackSerializer.Serialize(packet)
            });
            log.Info($"{packet.Name}{(Common.Common.config.VerboseLevel >= VerboseLevel.Debug ? (", " + JsonConvert.SerializeObject(push)) : "")}");
        }

        public void SendPush(string name, byte[] push)
        {
            Packet.Push packet = new()
            {
                Name = name,
                Content = push
            };
            Send(new Packet()
            {
                No = ++packetNo,
                Type = Packet.ContentType.Push,
                Content = MessagePackSerializer.Serialize(packet)
            });
            log.Info($"{name}{(Common.Common.config.VerboseLevel >= VerboseLevel.Debug ? (", " + JsonConvert.SerializeObject(MessagePackSerializer.Typeless.Deserialize(push))) : "")}");
        }

        public void SendResponse<T>(T response, int clientSeq = 0) where T : new()
        {
            Packet.Response packet = new()
            {
                Id = clientSeq,
                Name = typeof(T).Name,
                Content = MessagePackSerializer.Serialize(response)
            };
            Send(new Packet()
            {
                No = 0,
                Type = Packet.ContentType.Response,
                Content = MessagePackSerializer.Serialize(packet)
            });
            log.Info($"{packet.Name}{(Common.Common.config.VerboseLevel >= VerboseLevel.Debug ? (", " + JsonConvert.SerializeObject(response)) : "")}");
        }

        private void Send(Packet packet)
        {
            byte[] serializedPacket = MessagePackSerializer.Serialize(packet, lz4Options);
            Crypto.HaruCrypt.Encrypt(serializedPacket);

            byte[] sendBytes = GC.AllocateUninitializedArray<byte>(serializedPacket.Length + 4);

            BinaryPrimitives.WriteInt32LittleEndian(sendBytes.AsSpan()[0..4], serializedPacket.Length);
            Array.Copy(serializedPacket, 0, sendBytes, 4, serializedPacket.Length);

            client.GetStream().Write(sendBytes);
        }

        public void DisconnectProtocol()
        {
            if (Server.Instance.Sessions.GetValueOrDefault(id) is null)
                return;

            log.Warn($"{id} disconnected");
            client.Close();
            Server.Instance.Sessions.Remove(id);
        }
    }
}
