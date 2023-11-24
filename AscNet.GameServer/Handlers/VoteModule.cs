using MessagePack;

namespace AscNet.GameServer.Handlers
{

    #region MsgPackScheme
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessagePackObject(true)]
    public class GetVoteGroupListResponse
    {
        public List<dynamic> VoteGroupListCode;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion

    internal class VoteModule
    {
        [RequestPacketHandler("GetVoteGroupListRequest")]
        public static void GetVoteGroupListRequestHandler(Session session, Packet.Request packet)
        {
            GetVoteGroupListResponse response = new();

            session.SendResponse(response, packet.Id);
        }
    }
}
