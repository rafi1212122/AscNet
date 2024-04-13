using MessagePack;

namespace AscNet.GameServer.Handlers
{

    #region MsgPackScheme
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessagePackObject(true)]
    public class BossSingleRankInfoRequest
    {
    }

    [MessagePackObject(true)]
    public class BossSingleRankInfoResponse
    {
        public int Code;
    }

    [MessagePackObject(true)]
    public class GetActivityBossDataRequest
    {
    }
    
    [MessagePackObject(true)]
    public class GetActivityBossDataResponse
    {
        public int Code;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion

    internal class BossModule
    {
        [RequestPacketHandler("BossSingleRankInfoRequest")]
        public static void BossSingleRankInfoRequestHandler(Session session, Packet.Request packet)
        {
            session.SendResponse(new BossSingleRankInfoResponse() { Code = 1 }, packet.Id);
        }

        [RequestPacketHandler("GetActivityBossDataRequest")]
        public static void GetActivityBossDataRequestHandler(Session session, Packet.Request packet)
        {
            session.SendResponse(new GetActivityBossDataResponse() { Code = 1 }, packet.Id);
        }
    }
}
