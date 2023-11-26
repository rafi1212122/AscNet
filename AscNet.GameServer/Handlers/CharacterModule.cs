using AscNet.Common.Database;
using AscNet.Common.MsgPack;
using AscNet.Common.Util;
using AscNet.Table.V2.share.item;
using AscNet.Table.V2.share.character;
using MessagePack;
using AscNet.Common;

namespace AscNet.GameServer.Handlers
{
    #region MsgPackScheme
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessagePackObject(true)]
    public class CharacterLevelUpRequest
    {
        public uint TemplateId;
        public Dictionary<int, int> UseItems;
    }
    
    [MessagePackObject(true)]
    public class CharacterLevelUpResponse
    {
        public int Code;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion

    internal class CharacterModule
    {
        [RequestPacketHandler("CharacterUpgradeSkillGroupRequest")]
        public static void CharacterUpgradeSkillGroupRequestHandler(Session session, Packet.Request packet)
        {
            CharacterUpgradeSkillGroupRequest request = packet.Deserialize<CharacterUpgradeSkillGroupRequest>();

            var upgradeResult = session.character.UpgradeCharacterSkillGroup(request.SkillGroupId, request.Count);

            NotifyCharacterDataList notifyCharacterData = new();
            notifyCharacterData.CharacterDataList.AddRange(session.character.Characters.Where(x => upgradeResult.AffectedCharacters.Contains(x.Id)));

            NotifyItemDataList notifyItemData = new();
            notifyItemData.ItemDataList.AddRange(new Item[] { 
                session.inventory.Do(Inventory.Coin, upgradeResult.CoinCost * -1), 
                session.inventory.Do(Inventory.SkillPoint, upgradeResult.SkillPointCost * -1) 
            });

            session.SendPush(notifyCharacterData);
            session.SendPush(notifyItemData);

            session.SendResponse(new CharacterUpgradeSkillGroupResponse(), packet.Id);
        }

        [RequestPacketHandler("CharacterLevelUpRequest")]
        public static void CharacterLevelUpRequestHandler(Session session, Packet.Request packet)
        {
            CharacterLevelUpRequest request = packet.Deserialize<CharacterLevelUpRequest>();
            CharacterTable? characterData = TableReaderV2.Parse<CharacterTable>().FirstOrDefault(x => x.Id == request.TemplateId);

            if (characterData is null || !session.character.Characters.Any(x => x.Id == characterData.Id))
            {
                // CharacterManagerGetCharacterTemplateNotFound
                session.SendResponse(new CharacterLevelUpResponse() { Code = 20009001 }, packet.Id);
                return;
            }

            NotifyItemDataList notifyItemData = new();
            int totalExp = 0;
            foreach (var item in request.UseItems)
            {
                ItemTable? itemTable = TableReaderV2.Parse<ItemTable>().FirstOrDefault(x => x.Id == item.Key);
                if (itemTable is not null)
                {
                    totalExp += itemTable.GetCharacterExp(characterData.Type) * item.Value;
                    notifyItemData.ItemDataList.Add(session.inventory.Do(item.Key, item.Value * -1));
                }
            }
            session.SendPush(notifyItemData);

            var characterUp = session.character.AddCharacterExp(characterData.Id, totalExp, (int)session.player.PlayerData.Level);
            if (characterUp is not null)
            {
                NotifyCharacterDataList notifyCharacterData = new();
                notifyCharacterData.CharacterDataList.Add(characterUp);
                session.SendPush(notifyCharacterData);
            }

            session.SendResponse(new CharacterLevelUpResponse(), packet.Id);
        }
    }
}
