using AscNet.Common.Database;
using AscNet.Common.MsgPack;
using AscNet.Common.Util;
using AscNet.GameServer.Handlers;
using AscNet.Logging;
using AscNet.Table.V2.client.draw;
using AscNet.Table.V2.share.character;
using AscNet.Table.V2.share.character.quality;

namespace AscNet.GameServer.Game
{
    internal class DrawManager
    {
        public static readonly List<DrawSceneTable> drawSceneTables = TableReaderV2.Parse<DrawSceneTable>();
        public static readonly List<CharacterTable> charactersTables = TableReaderV2.Parse<CharacterTable>();
        public static readonly List<CharacterQualityTable> characterQualitiesTables = TableReaderV2.Parse<CharacterQualityTable>();
        static readonly Logger log = new(typeof(DrawManager), LogLevel.DEBUG, LogLevel.DEBUG);

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
                    infos.AddRange(drawSceneTables.Where(x => x.Type == 1 && charactersTables.Any(y =>
                    {
                        // only get the S chars since this is Arrival Construct
                        int firstQuality = characterQualitiesTables.Where(x => x.CharacterId == y.Id).OrderBy(x => x.Quality).FirstOrDefault()?.Quality ?? 0;
                        return y.Type == 1 && y.Id == x.ModelId && firstQuality == 3;
                    })).DistinctBy(x => x.ModelId).Select(x => new DrawInfo()
                    {
                        Id = x.Id,
                        UseItemId = Inventory.FreeGem,
                        UseItemCount = 1,
                        GroupId = GroupArrivalConstruct,
                        BtnDrawCount = { 1, 10 },
                        Banner = "Assets/Product/Ui/Scene3DPrefab/UiMain3dXiahuo.prefab",
                        EndTime = DateTimeOffset.Now.ToUnixTimeSeconds() * 2
                    }));
                    break;
                case GroupMemberTarget:
                    // Querying every character scene that is omniframe.
                    infos.AddRange(drawSceneTables.Where(x => x.Type == 1 && charactersTables.Any(y =>
                    {
                        // only get the A chars since this is member target
                        int firstQuality = characterQualitiesTables.Where(x => x.CharacterId == y.Id).OrderBy(x => x.Quality).FirstOrDefault()?.Quality ?? 0;
                        return y.Type == 1 && y.Id == x.ModelId && firstQuality == 2;
                    })).DistinctBy(x => x.ModelId).Select(x => new DrawInfo()
                    {
                        Id = x.Id,
                        UseItemId = Inventory.FreeGem,
                        UseItemCount = 1,
                        GroupId = GroupMemberTarget,
                        BtnDrawCount = { 1, 10 },
                        Banner = "Assets/Product/Ui/Scene3DPrefab/UiMain3dXiahuo.prefab",
                        EndTime = DateTimeOffset.Now.ToUnixTimeSeconds() * 2
                    }));
                    break;
            }

            return infos;
        }

        public static int GetGroupByDrawId(int draw)
        {
            foreach (var groupId in new int[] { GroupMemberTarget, GroupWeaponResearch, GroupTargetWeaponResearch, GroupDormitoryResearch, GroupThemedTargetWeapon, GroupThemedEventConstruct, GroupArrivalConstruct, GroupFateArrivalConstruct, GroupArrivalEventConstruct, GroupFateThemedConstruct, GroupTargetUniframe, GroupAnniversary, GroupFateAnniversaryLimited, GroupCollabTarget, GroupFateCollabTarget, GroupCollabWeaponTarget, GroupCUBTarget, GroupWishingTarget, GroupFateWishingTarget})
            {
                if (GetDrawInfosByGroup(groupId).Any(x => x.Id == draw))
                {
                    return groupId;
                }
            }

            log.Error($"Get group not found for draw {draw}");
            return 0;
        }

        public static List<RewardGoods> DrawDraw(int drawId)
        {
            List<RewardGoods> rewards = new();
            var drawScene = drawSceneTables.Find(x => x.Id == drawId);
            var drawPool = TableReaderV2.Parse<DrawPreviewTable>().Find(x => x.Id == drawId);
            if (drawScene is null || drawPool is null)
            {
                log.Error($"Invalid draw id {drawId}");
                return rewards;
            }

            switch (drawScene.Type)
            {
                case 1:
                    // Character
                    if (drawPool.UpGoodsId.Count > 0 && Random.Shared.NextDouble() >= 0.7)
                    {
                        rewards.Add(new()
                        {
                            RewardType = (int)RewardType.Character,
                            Level = 1,
                            Id = drawPool.UpGoodsId[Random.Shared.Next(drawPool.UpGoodsId.Count)]
                        });
                    }
                    else
                    {
                        rewards.Add(new()
                        {
                            RewardType = (int)RewardType.Character,
                            Level = 1,
                            Id = drawPool.GoodsId[Random.Shared.Next(drawPool.GoodsId.Count)]
                        });
                    }
                    break;
                case 2:
                    // Weapon
                    break;
                case 3:
                    // CUB
                    break;
                default:
                    break;
            }

            return rewards;
        }
    }
}
