using AscNet.Common.MsgPack;
using MessagePack;
using MongoDB.Bson.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using static AscNet.GameServer.Packet;

namespace AscNet.GameServer.Handlers
{
    internal class AccountModule
    {
        [PacketHandler("HandshakeRequest")]
        public static void HandshakeRequestHandler(Session session, byte[] packet)
        {
            HandshakeRequest request = MessagePackSerializer.Deserialize<HandshakeRequest>(packet);
            HandshakeResponse response = new()
            {
                Code = 0,
                UtcOpenTime = 0,
                Sha1Table = null
            };

            session.SendResponse(response);
        }

        [PacketHandler("LoginRequest")]
        public static void LoginRequestHandler(Session session, byte[] packet)
        {
            session.SendResponse(new LoginResponse
            {
                Code = 0,
                ReconnectToken = "eeeeeeeeeeeeeeh",
                UtcOffset = 0,
                UtcServerTime = (uint)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
            });

            session.SendResponse(JsonSerializer.Deserialize<NotifyLogin>(File.ReadAllText("Data\\NotifyLogin.json")));
        }
    }
}
