using AscNet.Common.MsgPack;

namespace AscNet.GameServer.Handlers
{
    internal class SignInModule
    {
        [RequestPacketHandler("SignInRequest")]
        public static void SignInRequestHandler(Session session, Packet.Request packet)
        {
            SignInResponse signInResponse = new();
            session.SendResponse(signInResponse, packet.Id);
        }
    }
}
