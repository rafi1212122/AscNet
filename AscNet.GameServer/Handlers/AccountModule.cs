using AscNet.Common.MsgPack;
using MessagePack;
using Newtonsoft.Json;

namespace AscNet.GameServer.Handlers
{
    internal class AccountModule
    {
        [RequestPacketHandler("HandshakeRequest")]
        public static void HandshakeRequestHandler(Session session, Packet.Request packet)
        {
            // TODO: make this somehow universal, look into better architecture to handle packets
            // and automatically log their deserialized form

            HandshakeResponse response = new()
            {
                Code = 0,
                UtcOpenTime = 0,
                Sha1Table = null
            };

            session.SendResponse(response, packet.Id);
        }

        [RequestPacketHandler("LoginRequest")]
        public static void LoginRequestHandler(Session session, Packet.Request packet)
        {
            session.SendResponse(new LoginResponse
            {
                Code = 0,
                ReconnectToken = "eeeeeeeeeeeeeeh",
                UtcOffset = 0,
                UtcServerTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            }, packet.Id);

            DoLogin(session);
        }

        // TODO: Move somewhere else, also split.
        static void DoLogin(Session session)
        {
            NotifyLogin notifyLogin = JsonConvert.DeserializeObject<NotifyLogin>(File.ReadAllText("Data/NotifyLogin.json"))!;
            session.SendPush(notifyLogin);
        }
    }
}
