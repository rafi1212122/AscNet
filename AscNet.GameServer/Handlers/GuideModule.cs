using AscNet.Common.MsgPack;

namespace AscNet.GameServer.Handlers
{
    internal class GuideModule
    {
        [RequestPacketHandler("GuideOpenRequest")]
        public static void GuideOpenRequestHandler(Session session, Packet.Request packet)
        {
            session.SendResponse(new GuideOpenResponse(), packet.Id);
        }
        
        /* TODO: Need this to skip tutorials
        [RequestPacketHandler("GuideGroupFinishRequest")]
        public static void GuideGroupFinishRequestHandler(Session session, Packet.Request packet)
        {
        }
        */
    }
}
