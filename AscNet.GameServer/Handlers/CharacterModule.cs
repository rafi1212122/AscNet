using AscNet.Common.Database;
using AscNet.Common.MsgPack;

namespace AscNet.GameServer.Handlers
{
    internal class CharacterModule
    {
        [RequestPacketHandler("CharacterUpgradeSkillGroupRequest")]
        public static void CharacterUpgradeSkillGroupRequestHandler(Session session, Packet.Request packet)
        {
            CharacterUpgradeSkillGroupRequest request = packet.Deserialize<CharacterUpgradeSkillGroupRequest>();

            var upgradeResult = session.character.UpgradeCharacterSkillGroup(request.SkillGroupId, request.Count);
            session.inventory.Do(Inventory.Coin, upgradeResult.CoinCost * -1);
            session.inventory.Do(Inventory.SkillPoint, upgradeResult.SkillPointCost * -1);

            NotifyCharacterDataList notifyCharacterData = new();
            notifyCharacterData.CharacterDataList.AddRange(session.character.Characters.Where(x => upgradeResult.AffectedCharacters.Contains(x.Id)));

            NotifyItemDataList notifyItemData = new();
            notifyItemData.ItemDataList.AddRange(session.inventory.Items.Where(x => x.Id == Inventory.Coin || x.Id == Inventory.SkillPoint));

            session.SendPush(notifyCharacterData);
            session.SendPush(notifyItemData);

            session.SendResponse(new CharacterUpgradeSkillGroupResponse(), packet.Id);
        }
    }
}
