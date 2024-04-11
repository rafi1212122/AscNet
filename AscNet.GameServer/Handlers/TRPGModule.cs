using AscNet.Common.MsgPack;
using AscNet.Common.Util;
using AscNet.Table.V2.share.trpg;
using MessagePack;

namespace AscNet.GameServer.Handlers
{
    #region MsgPackScheme
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessagePackObject(true)]
    public class TRPGFunctionFinishRequest
    {
        public int FunctionId { get; set; }
    }

    [MessagePackObject(true)]
    public class TRPGFunctionFinishResponse
    {
        public int Code { get; set; }
        public List<RewardGoods> RewardList { get; set; } = new();
    }

    [MessagePackObject(true)]
    public class TRPGChangePageStatusRequest
    {
        public bool Status { get; set; }
    }

    [MessagePackObject(true)]
    public class TRPGChangePageStatusResponse
    {
        public int Code { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion

    internal class TRPGModule
    {
        [RequestPacketHandler("TRPGFunctionFinishRequest")]
        public static void TRPGFunctionFinishRequestHandler(Session session, Packet.Request packet)
        {
            TRPGFunctionFinishRequest request = MessagePackSerializer.Deserialize<TRPGFunctionFinishRequest>(packet.Content);
            TRPGFunctionTable? trpgFunction = TableReaderV2.Parse<TRPGFunctionTable>().Find(x => x.Id == request.FunctionId);

            var response = new TRPGFunctionFinishResponse();

            // TODO: Implement rewards
            /*if (trpgFunction?.RewardId is not null)
            {
                var rewardGoods = TableReaderV2.Parse<RewardGoodsTable>().Where(x => TableReaderV2.Parse<RewardTable>().Find(x => x.Id == trpgFunction.RewardId)?.SubIds.Contains(x.Id) ?? false);

                foreach (var goods in rewardGoods)
                {
                    response.RewardList.Add(new()
                    {
                        Id = goods.Id,
                        TemplateId = goods.TemplateId,
                        Count = goods.Count
                    });
                }
            }*/

            session.SendResponse(response, packet.Id);
        }

        [RequestPacketHandler("TRPGChangePageStatusRequest")]
        public static void TRPGChangePageStatusRequestHandler(Session session, Packet.Request packet)
        {
            TRPGChangePageStatusRequest request = MessagePackSerializer.Deserialize<TRPGChangePageStatusRequest>(packet.Content);

            session.SendResponse(new TRPGChangePageStatusResponse(), packet.Id);
        }
    }
}
