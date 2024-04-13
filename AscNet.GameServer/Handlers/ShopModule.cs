using AscNet.Common.MsgPack;
using MessagePack;

namespace AscNet.GameServer.Handlers
{

    #region MsgPackScheme
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessagePackObject(true)]
    public class GetShopBaseInfoRequest
    {
    }

    [MessagePackObject(true)]
    public class GetShopBaseInfoResponse
    {
        public int Code;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion

    internal class ShopModule
    {
        [RequestPacketHandler("GetShopInfoRequest")]
        public static void GetShopInfoRequestHandler(Session session, Packet.Request packet)
        {
            GetShopInfoResponse rsp = new()
            {
                Code = 0,
                ClientShop = { }
            };

            session.SendResponse(rsp, packet.Id);
        }
        
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
        
        // TODO: Dorm shop
        [RequestPacketHandler("GetShopBaseInfoRequest")]
        public static void GetShopBaseInfoRequestHandler(Session session, Packet.Request packet)
        {
            session.SendResponse(new GetShopBaseInfoResponse(), packet.Id);
        }
    }
}
