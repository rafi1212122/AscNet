using AscNet.Common.Database;
using AscNet.Common.MsgPack;
using AscNet.Common.Util;
using AscNet.Common;
using AscNet.Table.share.fuben;
using AscNet.Table.V2.share.item;
using AscNet.Table.V2.share.reward;
using MessagePack;
using AscNet.GameServer.Handlers.Drops;

namespace AscNet.GameServer.Handlers
{
    #region MsgPackScheme
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public enum RewardType
    {
        Item = 1,
        Character = 2,
        Equip = 3,
        Fashion = 4,
        BaseEquip = 5,
        Furniture = 9,
        HeadPortrait = 10,
        DormCharacter = 11,
        ChatEmoji = 12,
        WeaponFashion = 13,
        Collection = 14,
        Background = 15,
        Pokemon = 16,
        Partner = 17,
        Nameplate = 18,
        RankScore = 20,
        Medal = 21,
        DrawTicket = 22
    }

    [MessagePackObject(true)]
    public class Operation
    {
        public bool? MoveOperated { get; set; }
        public int MoveOperation { get; set; }
        public int CameraRotationX { get; set; }
        public int CameraRotationY { get; set; }
        public int CameraInput { get; set; }
        public long IncId { get; set; }
        public int[] ClickOperation { get; set; }
        public int[] SpecialOperation { get; set; }
    }

    [MessagePackObject(true)]
    public class NpcHp
    {
        public int CharacterId { get; set; }
        public int NpcId { get; set; }
        public int Type { get; set; }
        public int Level { get; set; }
        public List<int> BuffIds { get; set; }
        public Dictionary<int, dynamic> AttrTable { get; set; }
    }

    [MessagePackObject(true)]
    public partial class NpcDpsTable
    {
        public int Value { get; set; }
        public int MaxValue { get; set; }
        public int RoleId { get; set; }
        public int NpcId { get; set; }
        public int CharacterId { get; set; }
        public int DamageTotal { get; set; }
        public int DamageNormal { get; set; }
        public List<int> DamageMagic { get; set; } = new();
        public int BreakEndure { get; set; }
        public int Cure { get; set; }
        public int Hurt { get; set; }
        public int Type { get; set; }
        public int Level { get; set; }
        public List<int> BuffIds { get; set; } = new();
        public dynamic AttrTable { get; set; }
    }

    [MessagePackObject(true)]
    public class FightSettleResult
    {
        public bool IsWin { get; set; }
        public bool IsForceExit { get; set; }
        public uint StageId { get; set; }
        public int StageLevel { get; set; }
        public long FightId { get; set; }
        public int RebootCount { get; set; }
        public int AddStars { get; set; }
        public long StartFrame { get; set; }
        public long SettleFrame { get; set; }
        public long PauseFrame { get; set; }
        public long ExSkillPauseFrame { get; set; }
        public long SettleCode { get; set; }
        public int DodgeTimes { get; set; }
        public int NormalAttackTimes { get; set; }
        public int ConsumeBallTimes { get; set; }
        public int StuntSkillTimes { get; set; }
        public int PauseTimes { get; set; }
        public int HighestCombo { get; set; }
        public int DamagedTimes { get; set; }
        public int MatrixTimes { get; set; }
        public long HighestDamage { get; set; }
        public long TotalDamage { get; set; }
        public long TotalDamaged { get; set; }
        public long TotalCure { get; set; }
        public long[] PlayerIds { get; set; }
        public dynamic[] PlayerData { get; set; }
        public dynamic? IntToIntRecord { get; set; }
        public dynamic? StringToIntRecord { get; set; }
        public Dictionary<long, Operation> Operations { get; set; }
        public long[] Codes { get; set; }
        public long LeftTime { get; set; }
        public Dictionary<int, NpcHp> NpcHpInfo { get; set; }
        public Dictionary<int, NpcDpsTable> NpcDpsTable { get; set; }
        public dynamic[] EventSet { get; set; }
        public long DeathTotalMyTeam { get; set; }
        public long DeathTotalEnemy { get; set; }
        public Dictionary<int, int> DeathRecord { get; set; } = new();
        public dynamic[] GroupDropDatas { get; set; }
        public dynamic? EpisodeFightResults { get; set; }
        public dynamic? CustomData { get; set; }
    }

    [MessagePackObject(true)]
    public class FightSettleRequest
    {
        public FightSettleResult Result { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion

    internal class FightModule
    {
        [RequestPacketHandler("PreFightRequest")]
        public static void PreFightRequestHandler(Session session, Packet.Request packet)
        {
            PreFightRequest req = MessagePackSerializer.Deserialize<PreFightRequest>(packet.Content);

            StageTable? stageTable = StageTableReader.Instance.FromStageId((int)req.PreFightData.StageId);
            if (stageTable is null)
            {
                // FubenManagerCheckPreFightStageInfoNotFound
                session.SendResponse(new PreFightResponse() { Code = 20003012 }, packet.Id);
                return;
            }

            PreFightResponse rsp = new()
            {
                Code = 0,
                FightData = new()
                {
                    Online = false,
                    FightId = req.PreFightData.StageId + (uint)Random.Shared.NextInt64(0, uint.MaxValue - req.PreFightData.StageId),
                    OnlineMode = 0,
                    Seed = (uint)Random.Shared.NextInt64(0, uint.MaxValue),
                    StageId = req.PreFightData.StageId,
                    RebootId = Miscs.ParseIntOr(stageTable.RebootId, 0),
                    PassTimeLimit = Miscs.ParseIntOr(stageTable.PassTimeLimit, 300),
                    StarsMark = 0
                }
            };

            rsp.FightData.RoleData.Add(new()
            {
                Id = (uint)session.player.PlayerData.Id,
                Camp = 1,
                Name = session.player.PlayerData.Name,
                IsRobot = false,
                NpcData = new()
            });

            if (req.PreFightData?.CardIds is not null)
            {
                for (int i = 0; i < req.PreFightData.CardIds.Count; i++)
                {
                    uint cardId = req.PreFightData.CardIds[i];
                    var characterData = session.character.Characters.FirstOrDefault(x => x.Id == cardId);
                    if (characterData is null)
                        continue;

                    rsp.FightData.RoleData.First(x => x.Id == session.player.PlayerData.Id).NpcData.Add(i, new
                    {
                        Character = characterData,
                        Equips = session.character.Equips.Where(x => x.CharacterId == cardId)
                    });
                }
            }

            session.fight = new(req);
            session.SendResponse(rsp, packet.Id);
        }

        [RequestPacketHandler("TeamSetTeamRequest")]
        public static void HandleTeamSetTeamRequestHandler(Session session, Packet.Request packet)
        {
            TeamSetTeamRequest req = MessagePackSerializer.Deserialize<TeamSetTeamRequest>(packet.Content);

            session.player.TeamGroups[(int)session.player.PlayerData.CurrTeamId] = new()
            {
                CaptainPos = req.TeamData.CaptainPos,
                FirstFightPos = req.TeamData.FirstFightPos,
                TeamId = req.TeamData.TeamId,
                TeamType = 1,
                TeamName = req.TeamData.TeamName,
                TeamData = req.TeamData.TeamData
            };

            session.SendResponse(new TeamSetTeamResponse(), packet.Id);
        }

        [RequestPacketHandler("EnterChallengeRequest")]
        public static void HandleEnterChallengeRequestHandler(Session session, Packet.Request packet)
        {
            session.SendResponse(new EnterChallengeResponse(), packet.Id);
        }

        [RequestPacketHandler("FightSettleRequest")]
        public static void FightSettleRequestHandler(Session session, Packet.Request packet)
        {
            FightSettleRequest req = MessagePackSerializer.Deserialize<FightSettleRequest>(packet.Content);
            Table.V2.share.fuben.StageTable? stageTable = TableReaderV2.Parse<Table.V2.share.fuben.StageTable>().FirstOrDefault(x => x.StageId == req.Result.StageId);
            if (stageTable is null)
            {
                // FightCheckManagerSettleCodeNotMatch
                session.SendResponse(new FightSettleResponse() { Code = 20032004 }, packet.Id);
                return;
            }

            int challengeCount = session.fight?.PreFight.PreFightData.ChallengeCount ?? 1;
            stageTable.CardExp *= challengeCount;
            stageTable.TeamExp *= challengeCount;

            List<RewardGoods> rewards = new();
            List<List<RewardGoods>> multiRewards = new();
            List<RewardTable> rewardTables = TableReaderV2.Parse<RewardTable>().Where(x => session.stage.Stages.ContainsKey(req.Result.StageId) ? x.Id == stageTable.FinishDropId : (x.Id == stageTable.FinishDropId || x.Id == stageTable.FirstRewardId)).ToList();
            if (rewardTables.Count == 0)
            {
                rewardTables.AddRange(TableReaderV2.Parse<RewardTable>().Where(x => session.stage.Stages.ContainsKey(req.Result.StageId) ? x.Id == stageTable.FinishRewardShow : (x.Id == stageTable.FinishRewardShow || x.Id == stageTable.FirstRewardShow)));
            }

            NotifyItemDataList notifyItemData = new();
            notifyItemData.ItemDataList.Add(session.inventory.Do(Inventory.TeamExp, stageTable.TeamExp ?? 0));

            for (int i = 0; i < challengeCount; i++)
            {
                foreach (var rewardGoodsId in rewardTables.SelectMany(x => x.SubIds))
                {
                    RewardGoodsTable? rewardGood = TableReaderV2.Parse<RewardGoodsTable>().FirstOrDefault(x => x.Id == rewardGoodsId);
                    if (rewardGood is not null)
                    {
                        // Item type formula
                        int rewardTypeVal = (int)MathF.Floor((rewardGood.TemplateId > 0 ? rewardGood.TemplateId : rewardGood.Id) / 1000000) + 1;
                        RewardType rewardType = RewardType.Item;
                        try
                        {
                            rewardType = (RewardType)Enum.ToObject(typeof(RewardType), rewardTypeVal);
                        }
                        catch (Exception)
                        {
                            session.log.Error($"Failed to convert {rewardTypeVal} to {nameof(RewardType)} enum object!");
                        }

                        // TODO: Implement other types. Other types are behaving weirdly
                        if (rewardType == RewardType.Item)
                        {
                            ItemTable? itemData = TableReaderV2.Parse<ItemTable>().Find(x => x.Id == rewardGood.TemplateId);
                            if (itemData is not null)
                            {
                                // Custom handler for some items that aren't meant to be in the inventory.
                                DropHandlerDelegate? dropHandler = DropsHandlerFactory.GetDropHandler(itemData.Id);
                                if (itemData.IsHidden() && dropHandler is not null)
                                {
                                    rewards.AddRange(dropHandler.Invoke(session, rewardGood.Count).Select(x => new RewardGoods()
                                    {
                                        Id = rewardGood.Id,
                                        TemplateId = x.TemplateId,
                                        Count = x.Count,
                                        Level = x.Level,
                                        RewardType = (int)x.Type,
                                        Quality = x.Quality
                                    }));
                                    continue;
                                }
                            }

                            notifyItemData.ItemDataList.Add(session.inventory.Do(rewardGood.TemplateId, rewardGood.Count));

                            rewards.Add(new()
                            {
                                Id = rewardGood.Id,
                                TemplateId = rewardGood.TemplateId,
                                Count = rewardGood.Count,
                                RewardType = rewardTypeVal
                            });
                        }
                    }
                }

                multiRewards.Add(new List<RewardGoods>(rewards));
                rewards.Clear();
            }

            session.SendPush(notifyItemData);
            session.ExpSanityCheck();

            if (stageTable.CardExp > 0)
            {
                Dictionary<int, long> team = session.player.TeamGroups[(int)session.player.PlayerData.CurrTeamId].TeamData;
                NotifyCharacterDataList charData = new();
                
                foreach (KeyValuePair<int, long> member in team)
                {
                    if (member.Value > 0)
                    {
                        var character = session.character.AddCharacterExp((int)member.Value, stageTable.CardExp ?? 0, (int)session.player.PlayerData.Level);
                        if (character is not null)
                            charData.CharacterDataList.Add(character);
                    }
                }
                
                session.SendPush(charData);
            }

            StageDatum stageData = new()
            {
                StageId = req.Result.StageId,
                StarsMark = 7,
                Passed = true,
                PassTimesToday = 0,
                PassTimesTotal = 1,
                BuyCount = 0,
                Score = 0,
                LastPassTime = (uint)DateTimeOffset.Now.ToUnixTimeSeconds(),
                RefreshTime = (uint)DateTimeOffset.Now.ToUnixTimeSeconds(),
                CreateTime = (uint)DateTimeOffset.Now.ToUnixTimeSeconds(),
                BestRecordTime = 0,
                LastRecordTime = 0,
                BestCardIds = req.Result.NpcDpsTable.Where(x => x.Value.CharacterId > 0).Select(x => (long)x.Value.CharacterId).ToList(),
                LastCardIds = req.Result.NpcDpsTable.Where(x => x.Value.CharacterId > 0).Select(x => (long)x.Value.CharacterId).ToList()
            };
            session.stage.AddStage(stageData);

            FightSettleResponse fightSettleResponse = new()
            {
                Settle = new()
                {
                    IsWin = true,
                    StageId = (uint)stageData.StageId,
                    StarsMark = (int)stageData.StarsMark,
                    RewardGoodsList = multiRewards.Count > 0 ? multiRewards.First() : rewards,
                    MultiRewardGoodsList = multiRewards,
                    NpcHpInfo = req.Result.NpcHpInfo,
                    ChallengeCount = challengeCount
                }
            };

            session.fight = null;
            session.SendPush(new NotifyStageData() { StageList = new() { stageData } });
            session.SendResponse(fightSettleResponse, packet.Id);
        }
    }
}
