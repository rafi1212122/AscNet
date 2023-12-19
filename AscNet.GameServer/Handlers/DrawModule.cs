using AscNet.Common.Database;
using AscNet.Common.Util;
using AscNet.GameServer.Game;
using AscNet.Table.V2.client.draw;
using MessagePack;
using static AscNet.GameServer.Packet;

namespace AscNet.GameServer.Handlers
{
    #region MsgPackScheme
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessagePackObject(true)]
    public class DrawGetDrawInfoListResponse
    {
        public int Code { get; set; }
        public List<DrawInfo> DrawInfoList { get; set; } = new();
    }

    [MessagePackObject(true)]
    public class DrawGetDrawGroupListResponse
    {
        public int Code { get; set; }
        public List<DrawGroupInfo> DrawGroupInfoList { get; set; } = new();
    }

    [MessagePackObject(true)]
    public class DrawGroupInfo
    {
        public int Id { get; set; }
        public int SwitchDrawIdCount { get; set; }
        public int UseDrawId { get; set; }
        public int MaxSwitchDrawIdCount { get; set; }
        public int Tag { get; set; }
        public int Order { get; set; }
        public int Priority { get; set; }
        public int BottomTimes { get; set; }
        public int MaxBottomTimes { get; set; }
        public long BannerBeginTime { get; set; }
        public long BannerEndTime { get; set; }
        public long StartTime { get; set; }
        public long EndTime { get; set; }
    }

    [MessagePackObject(true)]
    public class DrawInfo
    {
        public int Id { get; set; }
        public string Banner { get; set; }
        public int UseItemId { get; set; }
        public int GroupId { get; set; }
        public List<int> BtnDrawCount { get; set; } = new();
        public List<int> PurchaseId { get; set; } = new();
        public int UseItemCount { get; set; }
        public int BottomTimes { get; set; }
        public int MaxBottomTimes { get; set; }
        public long StartTime { get; set; }
        public long EndTime { get; set; }
    }

    [MessagePackObject(true)]
    public class DrawGetDrawInfoListRequest
    {
        public int GroupId { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion

    internal class DrawModule
    {
        [RequestPacketHandler("DrawGetDrawGroupListRequest")]
        public static void DrawGetDrawGroupListRequestHandler(Session session, Packet.Request packet)
        {
            var rsp = new DrawGetDrawGroupListResponse();

            {
                var drawInfos = DrawManager.GetDrawInfosByGroup(DrawManager.GroupArrivalConstruct);
                rsp.DrawGroupInfoList.Add(new()
                {
                    Id = DrawManager.GroupArrivalConstruct,
                    UseDrawId = drawInfos.Count > 0 ? drawInfos.First().Id : 0,
                    Order = 1,
                    Tag = DrawManager.TagEvent,
                    EndTime = DateTimeOffset.Now.ToUnixTimeSeconds() * 2,
                    BannerEndTime = DateTimeOffset.Now.ToUnixTimeSeconds() * 2
                });
            }

            session.SendResponse(rsp, packet.Id);
        }

        [RequestPacketHandler("DrawGetDrawInfoListRequest")]
        public static void DrawGetDrawInfoListRequestHandler(Session session, Packet.Request packet)
        {
            DrawGetDrawInfoListRequest request = packet.Deserialize<DrawGetDrawInfoListRequest>();

            DrawGetDrawInfoListResponse rsp = new();
            rsp.DrawInfoList.AddRange(DrawManager.GetDrawInfosByGroup(request.GroupId));

            session.SendResponse(rsp, packet.Id);
        }
    }
}
