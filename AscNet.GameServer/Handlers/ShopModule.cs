using AscNet.Common.MsgPack;
using MessagePack;

namespace AscNet.GameServer.Handlers
{
    internal class ShopModule
    {
        /* TODO: Needs types
        [RequestPacketHandler("GetShopBaseInfoRequest")]
        public static void GetShopBaseInfoRequestHandler(Session session, Packet.Request packet)
        {
        }
        */

        [RequestPacketHandler("GetShopInfoReceiveRequest")]
        public static void GetShopInfoReceiveRequestHandler(Session session, Packet.Request packet)
        {
            GetShopInfoResponse rsp = new()
            {
                Code = 0,
                ClientShop = { }
            };

            session.SendResponse(rsp, packet.Id);
        }
    }
}
