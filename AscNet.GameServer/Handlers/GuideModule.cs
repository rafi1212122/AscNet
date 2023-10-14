using AscNet.Common.MsgPack;

namespace AscNet.GameServer.Handlers
{
    public class GuideGroupFinishRequest
    {
        public int GroupId;
    }

    public class GuideGroupFinishResponse
    {
        public int Code;
        public List<dynamic>? RewardGoodsList;
    }
    
    internal class GuideModule
    {
        [RequestPacketHandler("GuideOpenRequest")]
        public static void GuideOpenRequestHandler(Session session, Packet.Request packet)
        {
            session.SendResponse(new GuideOpenResponse(), packet.Id);
        }

        // TODO: Invalid, need proper types
        [RequestPacketHandler("GuideGroupFinishRequest")]
        public static void GuideGroupFinishRequestHandler(Session session, Packet.Request packet)
        {
            session.SendResponse(new GuideGroupFinishResponse(), packet.Id);
        }
    }
}
