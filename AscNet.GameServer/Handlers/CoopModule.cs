using MessagePack;

namespace AscNet.GameServer.Handlers
{

    #region MsgPackScheme
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessagePackObject(true)]
    public class CreateRoomRequest
    {
        public int StageId;
        public int StageLevel;
        public bool Automatch;
    }

    [MessagePackObject(true)]
    public class CreateRoomResponse
    {
        public int Code;
    }

    [MessagePackObject(true)]
    public class MatchRoomRequest
    {
        public int StageId;
    }
    
    [MessagePackObject(true)]
    public class MatchRoomResponse
    {
        public int Code;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion

    internal class CoopModule
    {
        [RequestPacketHandler("CreateRoomRequest")]
        public static void CreateRoomRequestHandler(Session session, Packet.Request packet)
        {
            session.SendResponse(new CreateRoomResponse() { Code = 1 }, packet.Id);
        }

        [RequestPacketHandler("MatchRoomRequest")]
        public static void MatchRoomRequestHandler(Session session, Packet.Request packet)
        {
            session.SendResponse(new MatchRoomResponse() { Code = 1 }, packet.Id);
        }
    }
}
