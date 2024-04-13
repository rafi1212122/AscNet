using AscNet.Common.MsgPack;
using MessagePack;

namespace AscNet.GameServer.Handlers
{

    #region MsgPackScheme
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessagePackObject(true)]
    public class GuildListRecommendRequest
    {
        public int PageNo;
    }

    [MessagePackObject(true)]
    public class GuildListRecommendResponse
    {
        public int Code;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion

    internal class GuildModule
    {
        // TODO: Guild listing
        [RequestPacketHandler("GuildListRecommendRequest")]
        public static void GuildListRecommendRequestHandler(Session session, Packet.Request packet)
        {
            session.SendResponse(new GuildListRecommendResponse(), packet.Id);
        }
    }
}
