using AscNet.Common.MsgPack;
using AscNet.Common.Util;
using AscNet.Table.V2.share.fashion;
using MessagePack;

namespace AscNet.GameServer.Handlers
{
    #region MsgPackScheme
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessagePackObject(true)]
    public class FashionUnLockRequest
    {
        public uint FashionId { get; set; }
    }

    [MessagePackObject(true)]
    public class FashionUnLockResponse
    {
        public int Code { get; set; }
    }

    [MessagePackObject(true)]
    public class FashionUseRequest
    {
        public uint FashionId { get; set; }
    }

    [MessagePackObject(true)]
    public class FashionUseResponse
    {
        public int Code { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion

    internal class FashionModule
    {
        [RequestPacketHandler("FashionUseRequest")]
        public static void HandleFashionUseRequestHandler(Session session, Packet.Request packet)
        {
            FashionUseRequest req = packet.Deserialize<FashionUseRequest>();
            var character = session.character.Characters.Find(x => x.Id == TableReaderV2.Parse<FashionTable>().Find(x => x.Id == req.FashionId)?.CharacterId);

            if (character is not null)
            {
                character.FashionId = req.FashionId;

                NotifyCharacterDataList notifyCharacterData = new();
                notifyCharacterData.CharacterDataList.Add(character);
                session.SendPush(notifyCharacterData);
            }

            session.SendResponse(new FashionUseResponse(), packet.Id);
        }

        [RequestPacketHandler("FashionUnLockRequest")]
        public static void HandleFashionUnLockRequestHandler(Session session, Packet.Request packet)
        {
            FashionUnLockRequest req = packet.Deserialize<FashionUnLockRequest>();
            var fashion = session.character.Fashions.Find(x => x.Id == req.FashionId);
            if (fashion is not null && fashion.IsLock)
            {
                fashion.IsLock = false;
                FashionSyncNotify fashionSync = new();
                fashionSync.FashionList.Add(fashion);
                session.SendPush(fashionSync);
            }

            session.SendResponse(new FashionUnLockResponse(), packet.Id);
        }
    }
}
