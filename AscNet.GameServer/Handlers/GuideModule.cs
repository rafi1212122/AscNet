using AscNet.Common.MsgPack;
using MessagePack;

namespace AscNet.GameServer.Handlers
{
    [MessagePackObject(true)]
    public class GuideGroupFinishRequest
    {
        public int GroupId;
    }

    [MessagePackObject(true)]
    public class GuideGroupFinishResponse
    {
        public int Code;
        public List<dynamic>? RewardGoodsList;
    }

    [MessagePackObject(true)]
    public class GuideCompleteRequest
    {
        public int GuideGroupId;
    }

    [MessagePackObject(true)]
    public class NotifyGuide
    {
        public int GuideGroupId;
    }

    [MessagePackObject(true)]
    public class GuideCompleteResponse
    {
        public int Code;
        public List<dynamic>? RewardGoodsList;
    }
    
    internal class GuideModule
    {
        [RequestPacketHandler("GuideOpenRequest")]
        public static void GuideOpenRequestHandler(Session session, Packet.Request packet)
        {
            GuideCompleteRequest request = packet.Deserialize<GuideCompleteRequest>();

            session.player.PlayerData.GuideData.Add(request.GuideGroupId);
            session.SendPush(new NotifyGuide() { GuideGroupId = request.GuideGroupId });
            session.SendResponse(new GuideOpenResponse(), packet.Id);
        }

        // TODO: Invalid, need proper types
        [RequestPacketHandler("GuideGroupFinishRequest")]
        public static void GuideGroupFinishRequestHandler(Session session, Packet.Request packet)
        {
            session.SendResponse(new GuideGroupFinishResponse(), packet.Id);
        }

        [RequestPacketHandler("GuideCompleteRequest")]
        public static void GuideCompleteRequestHandler(Session session, Packet.Request packet)
        {
            GuideCompleteRequest request = MessagePackSerializer.Deserialize<GuideCompleteRequest>(packet.Content);

            session.player.PlayerData.GuideData.Add(request.GuideGroupId);
            session.SendPush(new NotifyGuide() { GuideGroupId = request.GuideGroupId });
            session.SendResponse(new GuideCompleteResponse(), packet.Id);
        }
    }
}
