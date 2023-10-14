using AscNet.Common.MsgPack;

namespace AscNet.GameServer.Handlers
{
    internal class PayModule
    {
        [RequestPacketHandler("GetPurchaseListRequest")]
        public static void GetPurchaseListRequestHandler(Session session, Packet.Request packet)
        {
            GetPurchaseListResponse getPurchaseListResponse = new();
            session.SendResponse(getPurchaseListResponse, packet.Id);
        }
    }
}
