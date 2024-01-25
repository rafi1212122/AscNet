using AscNet.Common.MsgPack;
using AscNet.Common.Util;
using AscNet.Table.V2.share.fashion;
using MessagePack;

namespace AscNet.GameServer.Handlers
{
    #region MsgPackScheme
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessagePackObject(true)]
    public class ChangeDisplayRequest
    {
        public int FashionId;
        public int CharId;
        public int BackgroundId;
    }

    [MessagePackObject(true)]
    public class ChangeDisplayResponse
    {
        public int Code;
        public List<long> DisplayCharIdList;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion

    internal class PhotographModule
    {
        [RequestPacketHandler("ChangeDisplayRequest")]
        public static void ChangeDisplayRequestHandler(Session session, Packet.Request packet)
        {
            ChangeDisplayRequest request = packet.Deserialize<ChangeDisplayRequest>();

            session.player.UseBackgroundId = request.BackgroundId;
            if (!session.player.PlayerData.DisplayCharIdList.Contains(request.CharId))
            {
                session.player.PlayerData.DisplayCharId = request.CharId;
                session.player.PlayerData.DisplayCharIdList.Add(request.CharId);
            }

            CharacterData? character = session.character.Characters.Find(x => x.Id == request.CharId);
            if (character is not null && character.FashionId != request.FashionId && TableReaderV2.Parse<FashionTable>().Any(x => x.CharacterId == request.CharId && x.Id == request.FashionId))
            {
                character.FashionId = (uint)request.FashionId;

                NotifyCharacterDataList notifyCharacterData = new();
                notifyCharacterData.CharacterDataList.Add(character);

                session.SendPush(notifyCharacterData);
            }

            session.SendResponse(new ChangeDisplayResponse() { DisplayCharIdList = session.player.PlayerData.DisplayCharIdList }, packet.Id);
        }
    }
}
