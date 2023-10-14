using AscNet.Common.MsgPack;

namespace AscNet.GameServer.Handlers
{
    internal class PlayerModule
    {
        [RequestPacketHandler("ChangePlayerMarkRequest")]
        public static void ChangePlayerMarkRequestHandler(Session session, Packet.Request packet)
        {
            session.SendResponse(new ChangePlayerMarkResponse(), packet.Id);
        }
    }
}
