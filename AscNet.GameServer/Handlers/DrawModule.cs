using AscNet.Common.MsgPack;
using AscNet.Common.Util;
using AscNet.GameServer.Game;
using AscNet.Table.V2.share.character;
using MessagePack;

namespace AscNet.GameServer.Handlers
{
    #region MsgPackScheme
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessagePackObject(true)]
    public class DrawDrawCardRequest
    {
        public int DrawId { get; set; }
        public int Count { get; set; }
        public int UseDrawTicketId { get; set; }
    }

    [MessagePackObject(true)]
    public class DrawDrawCardResponse
    {
        public int Code { get; set; }
        public List<RewardGoods> RewardGoodsList { get; set; } = new();
        public List<dynamic> ExtraRewardList { get; set; } = new();
        public DrawInfo ClientDrawInfo { get; set; }
    }

    [MessagePackObject(true)]
    public class DrawSetUseDrawIdRequest
    {
        public int DrawId { get; set; }
    }

    [MessagePackObject(true)]
    public class DrawSetUseDrawIdResponse
    {
        public int Code { get; set; }
        public int SwitchDrawIdCount { get; set; }
    }

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
            {
                var drawInfos = DrawManager.GetDrawInfosByGroup(DrawManager.GroupMemberTarget);
                rsp.DrawGroupInfoList.Add(new()
                {
                    Id = DrawManager.GroupMemberTarget,
                    UseDrawId = drawInfos.Count > 0 ? drawInfos.First().Id : 0,
                    Order = 1,
                    Tag = DrawManager.TagBase,
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

        [RequestPacketHandler("DrawSetUseDrawIdRequest")]
        public static void DrawSetUseDrawIdRequestHandler(Session session, Packet.Request packet)
        {
            DrawSetUseDrawIdRequest request = packet.Deserialize<DrawSetUseDrawIdRequest>();

            session.SendResponse(new DrawSetUseDrawIdResponse(), packet.Id);
        }

        [RequestPacketHandler("DrawDrawCardRequest")]
        public static void DrawDrawCardRequestHandler(Session session, Packet.Request packet)
        {
            DrawDrawCardRequest request = packet.Deserialize<DrawDrawCardRequest>();
            DrawDrawCardResponse rsp = new();

            for (int i = 0; i < request.Count; i++)
            {
                rsp.RewardGoodsList.AddRange(DrawManager.DrawDraw(request.DrawId));
            }

            // Post-processing and adding items to user's db
            NotifyItemDataList notifyItemData = new();
            NotifyEquipDataList notifyEquipData = new();
            NotifyCharacterDataList notifyCharacterData = new();
            FashionSyncNotify fashionSync = new();
            foreach (var item in rsp.RewardGoodsList)
            {
                switch ((RewardType)item.RewardType)
                {
                    case RewardType.Item:
                        notifyItemData.ItemDataList.Add(session.inventory.Do(item.TemplateId, item.Count));
                        break;
                    case RewardType.Equip:
                        notifyEquipData.EquipDataList.Add(session.character.AddEquip((uint)item.TemplateId));
                        break;
                    case RewardType.Character:
                        if (session.character.Characters.Any(x => x.Id == item.TemplateId))
                        {
                            CharacterTable? characterData = TableReaderV2.Parse<CharacterTable>().Find(x => x.Id == item.TemplateId);
                            if (characterData is not null)
                            {
                                item.ConvertFrom = characterData.Id;
                                item.TemplateId = characterData.ItemId;
                                item.Count = 18;
                                item.RewardType = (int)RewardType.Item;
                                notifyItemData.ItemDataList.Add(session.inventory.Do(item.TemplateId, item.Count));
                            }
                        }
                        else
                        {
                            var ret = session.character.AddCharacter((uint)item.TemplateId);
                            notifyCharacterData.CharacterDataList.Add(ret.Character);
                            fashionSync.FashionList.Add(ret.Fashion);
                            notifyEquipData.EquipDataList.Add(ret.Equip);
                        }
                        break;
                    default:
                        break;
                }
            }

            DrawInfo? drawInfo = DrawManager.GetDrawInfosByGroup(DrawManager.GetGroupByDrawId(request.DrawId)).Find(x => x.Id == request.DrawId);
            if (drawInfo is not null)
            {
                rsp.ClientDrawInfo = drawInfo;
                notifyItemData.ItemDataList.Add(session.inventory.Do(drawInfo.UseItemId, drawInfo.UseItemCount * -1));
            }

            if (notifyItemData.ItemDataList.Count > 0)
                session.SendPush(notifyItemData);
            if (notifyEquipData.EquipDataList.Count > 0)
                session.SendPush(notifyEquipData);
            if (fashionSync.FashionList.Count > 0)
                session.SendPush(fashionSync);
            if (notifyCharacterData.CharacterDataList.Count > 0)
                session.SendPush(notifyCharacterData);

            session.SendResponse(rsp, packet.Id);
        }
    }
}
