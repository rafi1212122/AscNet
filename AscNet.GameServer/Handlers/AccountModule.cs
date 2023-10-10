using AscNet.Common.MsgPack;
using MessagePack;

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
    }
}
