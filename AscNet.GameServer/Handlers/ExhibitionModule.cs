using MessagePack;
using AscNet.Common.MsgPack;
using AscNet.Table.V2.share.exhibition;
using AscNet.Common.Util;
using AscNet.Table.V2.share.reward;

namespace AscNet.GameServer.Handlers
{
    #region MsgPackScheme
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessagePackObject(true)]
    public class GatherRewardRequest
    {
        public int Id;
    }

    [MessagePackObject(true)]
    public class GatherRewardResponse
    {
        public int Code;
        public List<RewardGoods> RewardGoods { get; set; } = new();
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion

    internal class ExhibitionModule
    {
        [RequestPacketHandler("GatherRewardRequest")]
        public static void HandleGatherRewardRequestHandler(Session session, Packet.Request packet)
        {
            GatherRewardRequest req = MessagePackSerializer.Deserialize<GatherRewardRequest>(packet.Content);
            ExhibitionRewardTable? exhibitionReward = TableReaderV2.Parse<ExhibitionRewardTable>().Find(x => x.Id == req.Id);
            IEnumerable<RewardGoodsTable> rewards = TableReaderV2.Parse<RewardGoodsTable>().Where(x => (TableReaderV2.Parse<RewardTable>().Find(x => x.Id == exhibitionReward?.RewardId)?.SubIds ?? new List<int>()).Contains(x.Id));

            GatherRewardResponse rsp = new();
            foreach (var rewardGoods in rewards)
            {
                int rewardTypeVal = (int)MathF.Floor((rewardGoods.TemplateId > 0 ? rewardGoods.TemplateId : rewardGoods.Id) / 1000000) + 1;
                RewardType rewardType = RewardType.Item;
                try
                {
                    rewardType = (RewardType)Enum.ToObject(typeof(RewardType), rewardTypeVal);
                }
                catch (Exception)
                {
                    session.log.Error($"Failed to convert {rewardTypeVal} to {nameof(RewardType)} enum object!");
                }

                rsp.RewardGoods.Add(new()
                {
                    Id = rewardGoods.Id,
                    TemplateId = rewardGoods.TemplateId,
                    Count = rewardGoods.Count,
                    RewardType = rewardTypeVal
                });

                switch (rewardType)
                {
                    case RewardType.Item:
                        NotifyItemDataList notifyItemData = new()
                        {
                            ItemDataList = { session.inventory.Do(rewardGoods.TemplateId, rewardGoods.Count) }
                        };
                        session.SendPush(notifyItemData);
                        break;
                    default:
                        break;
                }
            }

            session.player.GatherRewards.Add(req.Id);
            session.SendPush(new NotifyGatherReward() { Id =  req.Id });
            session.SendResponse(rsp, packet.Id);
        }
    }
}
