using MessagePack;

namespace AscNet.GameServer.Handlers
{

    #region MsgPackScheme
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessagePackObject(true)]
    public class DormEnterRequest
    {
    }

    [MessagePackObject(true)]
    public class DormEnterResponse
    {
        public int Code;
    }
    
    [MessagePackObject(true)]
    public class DormitoryListRequest
    {
    }

    [MessagePackObject(true)]
    public class DormitoryListResponse
    {
        public int Code;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion

    internal class DormModule
    {
        // TODO: Dorm entry
        [RequestPacketHandler("DormEnterRequest")]
        public static void DormEnterRequestHandler(Session session, Packet.Request packet)
        {
            session.SendResponse(new DormEnterResponse(), packet.Id);
        }
        
        // TODO: Dorm list (called from Details section within account info menu)
        [RequestPacketHandler("DormitoryListRequest")]
        public static void DormitoryListRequestHandler(Session session, Packet.Request packet)
        {
            session.SendResponse(new DormitoryListResponse(), packet.Id);
        }
    }
}
