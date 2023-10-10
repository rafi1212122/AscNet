﻿using System.Buffers.Binary;
using System.Net.Mail;
using System.Net.Sockets;
using AscNet.Common.Util;
using MessagePack;

namespace AscNet.GameServer
{
    public class Session
    {
        public readonly string id;
        public readonly TcpClient client;
        public readonly Logger c;
        private long lastPacketTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        private ushort packetNo = 0;
        private readonly MessagePackSerializerOptions lz4Options = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4Block);

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
                                    c.Error("Failed to deserialize packet: " + BitConverter.ToString(packet).Replace("-", ""));
                                }
                            }
                        }

                        foreach (var packet in packets)
                        {
                            switch (packet.Type)
                            {
                                case Packet.ContentType.Request:
                                    Packet.Request request = MessagePackSerializer.Deserialize<Packet.Request>(packet.Content);
                                    c.Log(request.Name);
                                    PacketFactory.GetPacketHandler(request.Name)?.Invoke(this, request.Content);
                                    break;
                                case Packet.ContentType.Push:
                                    Packet.Push push = MessagePackSerializer.Deserialize<Packet.Push>(packet.Content);
                                    c.Log(push.Name);
                                    PacketFactory.GetPacketHandler(push.Name)?.Invoke(this, push.Content);
                                    break;
                                case Packet.ContentType.Exception:
                                    Packet.Exception exception = MessagePackSerializer.Deserialize<Packet.Exception>(packet.Content);
                                    c.Error($"Exception packet received: {exception.Code}, {exception.Message}");
                                    break;
                                default:
                                    break;
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

        public void SendPush<T>(T push)
        {
            Packet.Push packet = new()
            {
                Name = typeof(T).Name,
                Content = MessagePackSerializer.Serialize(push)
            };

            Send(new Packet()
            {
                No = packetNo,
                Type = Packet.ContentType.Push,
                Content = MessagePackSerializer.Serialize(packet)
            });
            c.Log(packet.Name);
            packetNo++;
        }

        public void SendResponse<T>(T response)
        {
            Packet.Response packet = new()
            {
                Id = 0,
                Name = typeof(T).Name,
                Content = MessagePackSerializer.Serialize(response)
            };

            Send(new Packet()
            {
                No = packetNo,
                Type = Packet.ContentType.Response,
                Content = MessagePackSerializer.Serialize(packet)
            });
            c.Log(packet.Name);
            packetNo++;
        }

        private void Send(Packet packet)
        {
            byte[] serializedPacket = MessagePackSerializer.Serialize(packet, lz4Options);
            byte[] sendBytes = GC.AllocateUninitializedArray<byte>(serializedPacket.Length + 4);

            BinaryPrimitives.WriteInt32LittleEndian(sendBytes, serializedPacket.Length);
            Array.Copy(serializedPacket, 0, sendBytes, 4, serializedPacket.Length);

            Crypto.HaruCrypt.Encrypt(sendBytes);
            client.GetStream().Write(sendBytes);
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