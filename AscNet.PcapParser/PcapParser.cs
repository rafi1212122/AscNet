using Newtonsoft.Json;
using PcapDotNet.Core;
using System.IO;
using System;
using System.Linq;
using System.Buffers.Binary;
using System.Runtime.InteropServices;
using AscNet.Common.Util;
using MessagePack;
using System.Collections.Generic;
using PcapDotNet.Packets.IpV4;

namespace AscNet.PcapParser
{
    class PcapParser
    {
        private static readonly MessagePackSerializerOptions lz4Options = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4Block);
        private static readonly Dictionary<IpV4Address, byte[]> buffer = new Dictionary<IpV4Address, byte[]>();
        private static readonly MemoryStream memoryStream = new MemoryStream();
        private static readonly List<object> packets = new List<object>();

        static void Main(string[] args)
        {
            // Check command line
            if (args.Length != 1)
            {
                Console.WriteLine("usage: " + Environment.GetCommandLineArgs()[0] + " <filename>");
                return;
            }

            // Create the offline device
            OfflinePacketDevice selectedDevice = new OfflinePacketDevice(args[0]);

            // Open the capture file
            using (PacketCommunicator communicator =
                selectedDevice.Open(65536,                                  // portion of the packet to capture
                                                                            // 65536 guarantees that the whole packet will be captured on all the link layers
                                    PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                                    1000))                                  // read timeout
            {
                // Read and dispatch packets until EOF is reached
                communicator.ReceivePackets(0, DispatcherHandler);
            }

            // ProcessPackets();

            Console.WriteLine($"Got {packets.Count} packet(s)");
            File.WriteAllText("packets.json", JsonConvert.SerializeObject(packets));
        }

        private static void DispatcherHandler(PcapDotNet.Packets.Packet packet)
        {
            var payload = packet.Ethernet.IpV4.Tcp.Payload;

            if (payload.Length < 1)
                return;

            byte[] bytes;
            if (buffer.ContainsKey(packet.Ethernet.IpV4.Source))
            {
                bytes = buffer[packet.Ethernet.IpV4.Source].Concat(payload.ToArray()).ToArray();
            }
            else
            {
                bytes = payload.ToArray();
            }

            int readLen = 0;

            while (true)
            {
                int len = (int)BinaryPrimitives.ReadUInt32LittleEndian(bytes.AsSpan(readLen));
                readLen += Marshal.SizeOf<int>();

                if (len > bytes.Length - readLen)
                {
                    buffer[packet.Ethernet.IpV4.Source] = bytes.AsSpan(readLen - 4).ToArray();
                    break;
                }

                byte[] packetBuffer = new byte[len];
                Buffer.BlockCopy(bytes, readLen, packetBuffer, 0, len);
                readLen += len;

                Crypto.HaruCrypt.Decrypt(packetBuffer);

                try
                {
                    var msgPackPacket = MessagePackSerializer.Deserialize<Packet>(packetBuffer, lz4Options);
                    var packetObj = new Dictionary<string, dynamic>
                    {
                        ["No"] = msgPackPacket.No,
                        ["Type"] = msgPackPacket.Type.ToString()
                    };

                    switch (msgPackPacket.Type)
                    {
                        case Packet.ContentType.Request:
                            var req = MessagePackSerializer.Deserialize<Packet.Request>(msgPackPacket.Content);
                            packetObj["Content"] = new
                            {
                                req.Id,
                                req.Name,
                                Content = req.Deserialize()
                            };
                            Console.WriteLine($"{req.Name}, " + JsonConvert.SerializeObject(req.Deserialize()));
                            break;
                        case Packet.ContentType.Response:
                            var rsp = MessagePackSerializer.Deserialize<Packet.Response>(msgPackPacket.Content);
                            packetObj["Content"] = new
                            {
                                rsp.Id,
                                rsp.Name,
                                Content = rsp.Deserialize()
                            };
                            Console.WriteLine($"{rsp.Name}, " + JsonConvert.SerializeObject(rsp.Deserialize()));
                            break;
                        case Packet.ContentType.Push:
                            var push = MessagePackSerializer.Deserialize<Packet.Push>(msgPackPacket.Content);
                            packetObj["Content"] = new
                            {
                                push.Name,
                                Content = push.Deserialize()
                            };
                            Console.WriteLine($"{push.Name}, " + JsonConvert.SerializeObject(push.Deserialize()));
                            break;
                        case Packet.ContentType.Exception:
                            var ex = MessagePackSerializer.Deserialize<Packet.Exception>(msgPackPacket.Content);
                            packetObj["Content"] = ex;
                            Console.WriteLine(JsonConvert.SerializeObject(ex));
                            break;
                        default:
                            break;
                    }

                    packets.Add(packetObj);
                }
                catch (Exception)
                {
                    Console.WriteLine("len: " + len + ", pack: " + Convert.ToBase64String(packetBuffer));
                    byte[] rawBuf = new byte[len + 4];
                    Buffer.BlockCopy(bytes, (readLen - len - 4), rawBuf, 0, len + 4);

                    Console.WriteLine("Ended abruptly while reading, processing: " + Convert.ToBase64String(rawBuf));
                    break;
                }

                if (readLen >= bytes.Length)
                {
                    buffer.Remove(packet.Ethernet.IpV4.Source);
                    break;
                }
            }

            // print packet timestamp and packet length
            /*Console.WriteLine(packet.Timestamp.ToString("yyyy-MM-dd hh:mm:ss.fff") + " length:" + payload.Length);
            memoryStream.Write(payload.ToArray(), 0, payload.Length);*/
        }

        private static void ProcessPackets()
        {
            List<object> packets = new List<object>();
            byte[] msBytes = memoryStream.ToArray();
            int readLen = 0;

            while (readLen < msBytes.Length)
            {
                int len = BinaryPrimitives.ReadInt32LittleEndian(msBytes.AsSpan(readLen));
                readLen += Marshal.SizeOf<int>();

                byte[] packetBuffer = new byte[len];
                Buffer.BlockCopy(msBytes, readLen, packetBuffer, 0, len);
                readLen += len;

                Crypto.HaruCrypt.Decrypt(packetBuffer);

                try
                {
                    var packet = MessagePackSerializer.Deserialize<Packet>(packetBuffer, lz4Options);
                    var packetObj = new Dictionary<string, dynamic>
                    {
                        ["No"] = packet.No,
                        ["Type"] = packet.Type.ToString()
                    };

                    switch (packet.Type)
                    {
                        case Packet.ContentType.Request:
                            var req = MessagePackSerializer.Deserialize<Packet.Request>(packet.Content);
                            packetObj["Content"] = new
                            {
                                req.Id,
                                req.Name,
                                Content = req.Deserialize()
                            };
                            Console.WriteLine($"{req.Name}, " + JsonConvert.SerializeObject(req.Deserialize()));
                            break;
                        case Packet.ContentType.Response:
                            var rsp = MessagePackSerializer.Deserialize<Packet.Response>(packet.Content);
                            packetObj["Content"] = new
                            {
                                rsp.Id,
                                rsp.Name,
                                Content = rsp.Deserialize()
                            };
                            Console.WriteLine($"{rsp.Name}, " + JsonConvert.SerializeObject(rsp.Deserialize()));
                            break;
                        case Packet.ContentType.Push:
                            var push = MessagePackSerializer.Deserialize<Packet.Push>(packet.Content);
                            packetObj["Content"] = new
                            {
                                push.Name,
                                Content = push.Deserialize()
                            };
                            Console.WriteLine($"{push.Name}, " + JsonConvert.SerializeObject(push.Deserialize()));
                            break;
                        case Packet.ContentType.Exception:
                            var ex = MessagePackSerializer.Deserialize<Packet.Exception>(packet.Content);
                            packetObj["Content"] = ex;
                            Console.WriteLine(JsonConvert.SerializeObject(ex));
                            break;
                        default:
                            break;
                    }

                    packets.Add(packetObj);
                }
                catch (Exception)
                {
                    Console.WriteLine("len: " + len + ", pack: " + Convert.ToBase64String(packetBuffer));
                    byte[] rawBuf = new byte[len + 4];
                    Buffer.BlockCopy(msBytes, (readLen - len - 4), rawBuf, 0, len + 4);

                    Console.WriteLine("Ended abruptly while reading, processing: " + Convert.ToBase64String(rawBuf));
                    break;
                }
            }
        }
    }
}
