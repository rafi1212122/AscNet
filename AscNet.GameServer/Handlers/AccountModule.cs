using AscNet.Common.MsgPack;
using MessagePack;
using Newtonsoft.Json;

namespace AscNet.GameServer.Handlers
{
    internal class AccountModule
    {
        [PacketHandler("HandshakeRequest")]
        public static void HandshakeRequestHandler(Session session, byte[] packet)
        {
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
            LoginRequest request = MessagePackSerializer.Deserialize<LoginRequest>(packet);
            session.SendResponse(new LoginResponse
            {
                Code = 0,
                ReconnectToken = "eeeeeeeeeeeeeeh",
                UtcOffset = 0,
                UtcServerTime = (uint)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
            });

            NotifyLogin notifyLogin = JsonConvert.DeserializeObject<NotifyLogin>(File.ReadAllText("Data/NotifyLogin.json"))!;
            session.SendPush(notifyLogin);
        }
    }
}
