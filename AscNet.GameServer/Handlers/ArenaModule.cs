using MessagePack;

namespace AscNet.GameServer.Handlers
{
    #region MsgPackScheme
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessagePackObject(true)]
    public class JoinActivityResponse
    {
        public int Code;
        public int ChallengeId;
    }

    [MessagePackObject(true)]
    public class ScoreQueryResponse
    {
        public int Code;
        public int WaveRate;
        public List<dynamic> GroupPlayerList;
        public List<dynamic> TeamPlayerList;
        public int ChallengeId;
        public int ActivityNo;
        public int ArenaLevel;
        public int ContributeScore;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion

    internal class ArenaModule
    {
        [RequestPacketHandler("JoinActivityRequest")]
        public static void JoinActivityRequestHandler(Session session, Packet.Request packet)
        {
            session.SendResponse(new JoinActivityResponse()
            {
                ChallengeId = 3
            }, packet.Id);
        }

        [RequestPacketHandler("ScoreQueryRequest")]
        public static void ScoreQueryRequestHandler(Session session, Packet.Request packet)
        {
            session.SendResponse(new ScoreQueryResponse()
            {
                ChallengeId = 3
            }, packet.Id);
        }
    }
}
