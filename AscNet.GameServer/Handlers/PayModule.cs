using AscNet.Common.MsgPack;
using MessagePack;

namespace AscNet.GameServer.Handlers
{
    #region MsgPackScheme
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessagePackObject(true)]
    public class PayInitiatedRequest
    {
        public string Key;
        public string? TargetParam;
    }

    [MessagePackObject(true)]
    public class PayInitiatedResponse
    {
        public int Code;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion

    internal class PayModule
    {
        [RequestPacketHandler("GetPurchaseListRequest")]
        public static void GetPurchaseListRequestHandler(Session session, Packet.Request packet)
        {
            session.SendResponse(new GetPurchaseListResponse(), packet.Id);
        }

        [RequestPacketHandler("PayInitiatedRequest")]
        public static void PayInitiatedRequestHandler(Session session, Packet.Request packet)
        {
            session.SendResponse(new PayInitiatedResponse() { Code = 1 }, packet.Id);
        }
    }
}
