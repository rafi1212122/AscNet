using AscNet.Common.Database;
using AscNet.Common.Util;
using AscNet.GameServer.Handlers;
using AscNet.Table.V2.client.draw;
using AscNet.Table.V2.share.character;

namespace AscNet.GameServer.Game
{
    internal class DrawManager
    {
        public static readonly List<DrawSceneTable> drawSceneTables = TableReaderV2.Parse<DrawSceneTable>();
        public static readonly List<CharacterTable> charactersTables = TableReaderV2.Parse<CharacterTable>();

        #region DrawTags
        public const int TagBase = 1;
        public const int TagEvent = 2;
        public const int TagSpecialEvent = 3;
        public const int TagTargetUniframe = 4;
        public const int TagCollab = 5;
        public const int TagEndlessSummerBlue = 6;
        public const int TagCUB = 7;
        #endregion

        #region Groups
        public const int GroupMemberTarget = 1;
        public const int GroupWeaponResearch = 2;
        public const int GroupTargetWeaponResearch = 4;
        public const int GroupDormitoryResearch = 6;
        public const int GroupThemedTargetWeapon = 10;
        public const int GroupThemedEventConstruct = 11;
        public const int GroupArrivalConstruct = 12;
        public const int GroupFateArrivalConstruct = 13;
        public const int GroupArrivalEventConstruct = 14;
        public const int GroupFateThemedConstruct = 15;
        public const int GroupTargetUniframe = 16;
        public const int GroupAnniversary = 17;
        public const int GroupFateAnniversaryLimited = 18;
        public const int GroupCollabTarget = 19;
        public const int GroupFateCollabTarget = 20;
        public const int GroupCollabWeaponTarget = 21;
        public const int GroupCUBTarget = 22;
        public const int GroupWishingTarget = 23;
        public const int GroupFateWishingTarget = 24;
        #endregion

        private readonly Dictionary<int, int> selectedDrawUp = new();

        public void SetUpDrawByGroupId(int groupId, int drawId)
        {
            if (selectedDrawUp.ContainsKey(groupId))
                selectedDrawUp[groupId] = drawId;
            else
                selectedDrawUp.Add(groupId, drawId);
        }

        public static List<DrawInfo> GetDrawInfosByGroup(int groupId)
        {
            List<DrawInfo> infos = new();

            switch (groupId)
            {
                case GroupArrivalConstruct:
                    // Querying every character scene that is omniframe.
                    infos.AddRange(drawSceneTables.Where(x => x.Type == 1 && charactersTables.Any(y => y.Type == 1 && y.Id == x.ModelId)).DistinctBy(x => x.ModelId).Select(x => new DrawInfo()
                    {
                        Id = x.Id,
                        UseItemId = Inventory.FreeGem,
                        UseItemCount = 1,
                        GroupId = 12,
                        BtnDrawCount = { 1, 10 },
                        Banner = "Assets/Product/Ui/Scene3DPrefab/UiMain3dXiahuo.prefab",
                        EndTime = DateTimeOffset.Now.ToUnixTimeSeconds() * 2
                    }));
                    break;
            }

            return infos;
        }
    }
}
