#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
using MessagePack;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace AscNet.Common.MsgPack
{
    [global::MessagePack.MessagePackObject(true)]
    public class HandshakeRequest
    {
        public String DocumentVersion { get; set; }
        public String Sha1 { get; set; }
        public String ApplicationVersion { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class HandshakeResponse
    {
        public Int32 Code { get; set; }
        public Int32 UtcOpenTime { get; set; }
        public dynamic? Sha1Table { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class LoginRequest
    {
        public String Token { get; set; }
        public String DeviceId { get; set; }
        public Int32 LoginType { get; set; }
        public String ServerBean { get; set; }
        public Int32 LoginPlatform { get; set; }
        public String ClientVersion { get; set; }
        public Int32 UserId { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class LoginResponse
    {
        public Int32 Code { get; set; }
        public Int32 UtcOffset { get; set; }
        public Int64 UtcServerTime { get; set; }
        public String ReconnectToken { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyDailyLotteryData
    {
        public List<dynamic> Lotteries { get; set; } = new();
    }


    [MessagePackObject(true)]
    public partial class BaseEquipLoginData
    {
        public List<dynamic> BaseEquipList { get; set; } = new();
        public List<dynamic> DressedList { get; set; } = new();
    }


    [MessagePackObject(true)]
    public partial class ChangePlayerMarkResponse
    {
        public int Code { get; set; }
    }

    [MessagePackObject(true)]
    public partial class LoginCharacterList
    {
        public long Id { get; set; }
        public long Level { get; set; }
        public long Exp { get; set; }
        public long Quality { get; set; }
        public long InitQuality { get; set; }
        public long Star { get; set; }
        public long Grade { get; set; }
        public List<SkillList> SkillList { get; set; } = new();
        public List<dynamic> EnhanceSkillList { get; set; } = new();
        public long FashionId { get; set; }
        public long CreateTime { get; set; }
        public long TrustLv { get; set; }
        public long TrustExp { get; set; }
        public long Ability { get; set; }
        public long LiberateLv { get; set; }
        public CharacterHeadInfo CharacterHeadInfo { get; set; }
    }

    [MessagePackObject(true)]
    public partial class CharacterHeadInfo
    {
        public long HeadFashionId { get; set; }
        public long HeadFashionType { get; set; }
    }

    [MessagePackObject(true)]
    public partial class SkillList
    {
        public long Id { get; set; }
        public long Level { get; set; }
    }

    [MessagePackObject(true)]
    public partial class EquipList
    {
        public long Id { get; set; }
        public long TemplateId { get; set; }
        public long CharacterId { get; set; }
        public long Level { get; set; }
        public long Exp { get; set; }
        public long Breakthrough { get; set; }
        public List<ResonanceInfo> ResonanceInfo { get; set; } = new();
        public List<object> UnconfirmedResonanceInfo { get; set; } = new();
        public List<object> AwakeSlotList { get; set; } = new();
        public bool IsLock { get; set; }
        public long CreateTime { get; set; }
        public bool IsRecycle { get; set; }
    }

    [MessagePackObject(true)]
    public partial class ResonanceInfo
    {
        public long Slot { get; set; }
        public long Type { get; set; }
        public long CharacterId { get; set; }
        public long TemplateId { get; set; }
    }

    [MessagePackObject(true)]
    public partial class FashionList
    {
        public long Id { get; set; }
        public bool IsLock { get; set; }
    }

    [MessagePackObject(true)]
    public partial class FubenLoginData
    {
        public List<object> TreasureData { get; set; } = new();
        public List<object> LastPassStage { get; set; } = new();
        public List<object> ChapterEventInfos { get; set; } = new();
    }

    [MessagePackObject(true)]
    public partial class FubenData
    {
        public Dictionary<long, StageDatum> StageData { get; set; }
        public FubenBaseData FubenBaseData { get; set; }
        public List<object> UnlockHideStages { get; set; } = new();
        public List<object> StageDifficulties { get; set; } = new();
    }

    [MessagePackObject(true)]
    public partial class FubenBaseData
    {
        public long RefreshTime { get; set; }
        public long SelectedCharId { get; set; }
        public long UrgentAlarmCount { get; set; }
        public long WeeklyUrgentCount { get; set; }
        public object DayUrgentCount { get; set; }
    }

    [MessagePackObject(true)]
    public partial class ItemRecycleData
    {
        public int Id { get; set; }
        public long RecycleTime { get; set; }
        public int RecycleCount { get; set; }
    }

    [MessagePackObject(true)]
    public partial class StageDatum
    {
        public long StageId { get; set; }
        public long StarsMark { get; set; }
        public bool Passed { get; set; }
        public long PassTimesToday { get; set; }
        public long PassTimesTotal { get; set; }
        public long BuyCount { get; set; }
        public long Score { get; set; }
        public long LastPassTime { get; set; }
        public long RefreshTime { get; set; }
        public long CreateTime { get; set; }
        public long BestRecordTime { get; set; }
        public long LastRecordTime { get; set; }
        public List<long> BestCardIds { get; set; } = new();
        public List<long> LastCardIds { get; set; } = new();
    }

    [MessagePackObject(true)]
    public partial class FubenMainLineData
    {
        public List<long> TreasureData { get; set; } = new();
        public Dictionary<int, long> LastPassStage { get; set; } = new();
        public List<dynamic> MainChapterEventInfos { get; set; } = new();
    }

    [MessagePackObject(true)]
    public partial class FubenUrgentEventData
    {
        public object UrgentEventData { get; set; }
    }

    [MessagePackObject(true)]
    public partial class HeadPortraitList
    {
        public long Id { get; set; }
        public long LeftCount { get; set; }
        public long BeginTime { get; set; }
    }

    [MessagePackObject(true)]
    public partial class ItemList
    {
        public long Id { get; set; }
        public long Count { get; set; }
        public long BuyTimes { get; set; }
        public long TotalBuyTimes { get; set; }
        public long LastBuyTime { get; set; }
        public long RefreshTime { get; set; }
        public long CreateTime { get; set; }
    }

    [MessagePackObject(true)]
    public partial class PlayerData
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Level { get; set; }
        public string Sign { get; set; }
        public long DisplayCharId { get; set; }
        public Birthday? Birthday { get; set; }
        public long HonorLevel { get; set; }
        public string ServerId { get; set; }
        public long Likes { get; set; }
        public long CurrTeamId { get; set; }
        public long ChallengeEventId { get; set; }
        public long CurrHeadPortraitId { get; set; }
        public long CurrHeadFrameId { get; set; }
        public long CurrMedalId { get; set; }
        public long AppearanceShowType { get; set; }
        public long DailyReceiveGiftCount { get; set; }
        public long DailyActivenessRewardStatus { get; set; }
        public long WeeklyActivenessRewardStatus { get; set; }
        public List<long> Marks { get; set; } = new();
        public List<long> GuideData { get; set; } = new();
        public List<long> Communications { get; set; } = new();
        public List<long> ShowCharacters { get; set; } = new();
        public List<dynamic> ShieldFuncList { get; set; } = new();
        public AppearanceSettingInfo AppearanceSettingInfo { get; set; }
        public long CreateTime { get; set; }
        public long LastLoginTime { get; set; }
        public long ReportTime { get; set; }
        public long ChangeNameTime { get; set; }
        public long Flags { get; set; }
    }

    [MessagePackObject(true)]
    public partial class AppearanceSettingInfo
    {
        public long TitleType { get; set; }
        public long CharacterType { get; set; }
        public long FashionType { get; set; }
        public long WeaponFashionType { get; set; }
        public long DormitoryType { get; set; }
        public long DormitoryId { get; set; }
    }

    [MessagePackObject(true)]
    public partial class Birthday
    {
        public long Mon { get; set; }
        public long Day { get; set; }
    }

    [MessagePackObject(true)]
    public partial class SharePlatformConfigList
    {
        public long Id { get; set; }
        public List<long> SdkId { get; set; } = new();
    }

    [MessagePackObject(true)]
    public partial class SignInfo
    {
        public long Id { get; set; }
        public long Round { get; set; }
        public long Day { get; set; }
        public bool Got { get; set; }
        public long FinishDay { get; set; }
    }

    [MessagePackObject(true)]
    public partial class TeamGroupDatum
    {
        public long TeamType { get; set; }
        public long TeamId { get; set; }
        public long CaptainPos { get; set; }
        public long FirstFightPos { get; set; }
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfDocuments)]
        public Dictionary<int, long> TeamData { get; set; }
        public string? TeamName { get; set; }
    }

    [MessagePackObject(true)]
    public partial class TimeLimitCtrlConfigList
    {
        public long Id { get; set; }
        public long StartTime { get; set; }
        public long EndTime { get; set; }
    }

    [MessagePackObject(true)]
    public partial class NotifyLogin
    {
        public PlayerData PlayerData { get; set; }
        public List<TimeLimitCtrlConfigList> TimeLimitCtrlConfigList { get; set; } = new();
        public List<SharePlatformConfigList> SharePlatformConfigList { get; set; } = new();
        public List<ItemList> ItemList { get; set; } = new();
        public Dictionary<int, List<ItemRecycleData>> ItemRecycleDict { get; set; } = new();
        public List<LoginCharacterList> CharacterList { get; set; } = new();
        public List<EquipList> EquipList { get; set; } = new();
        public List<FashionList> FashionList { get; set; } = new();
        public List<HeadPortraitList> HeadPortraitList { get; set; } = new();
        public BaseEquipLoginData BaseEquipLoginData { get; set; }
        public FubenData FubenData { get; set; }
        public FubenMainLineData FubenMainLineData { get; set; }
        public FubenLoginData FubenChapterExtraLoginData { get; set; }
        public FubenUrgentEventData FubenUrgentEventData { get; set; }
        public List<dynamic> AutoFightRecords { get; set; } = new();
        public Dictionary<int, TeamGroupDatum> TeamGroupData { get; set; }
        public dynamic TeamPrefabData { get; set; }
        public List<SignInfo> SignInfos { get; set; } = new();
        public List<dynamic> AssignChapterRecord { get; set; } = new();
        public List<dynamic> WeaponFashionList { get; set; } = new();
        public List<dynamic> PartnerList { get; set; } = new();
        public List<dynamic> ShieldedProtocolList { get; set; } = new();
        public object LimitedLoginData { get; set; }
        public long UseBackgroundId { get; set; }
        public FubenLoginData FubenShortStoryLoginData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyPayInfo
    {
        public Single TotalPayMoney { get; set; }
        public Boolean IsGetFirstPayReward { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyEquipChipGroupList
    {
        public List<dynamic> ChipGroupDataList { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyEquipChipAutoRecycleSite
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyEquipChipAutoRecycleSiteChipRecycleSite
        {
            public List<Int32> RecycleStar { get; set; } = new();
            public Int32 Days { get; set; }
            public Int32 SetRecycleTime { get; set; }
        }

        public NotifyEquipChipAutoRecycleSiteChipRecycleSite ChipRecycleSite { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyEquipGuideData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyEquipGuideDataEquipGuideData
        {
            public Int32 TargetId { get; set; }
            public List<Int32> PutOnPosList { get; set; } = new();
            public List<dynamic> FinishedTargets { get; set; } = new();
        }

        public NotifyEquipGuideDataEquipGuideData EquipGuideData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyArchiveLoginData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyArchiveLoginDataMonster
        {
            public UInt32 Id { get; set; }
            public Int32 Killed { get; set; }
        }

        public List<NotifyArchiveLoginDataMonster> Monsters { get; set; } = new();
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyArchiveLoginDataEquip
        {
            public UInt32 Id { get; set; }
            public Int32 Level { get; set; }
            public Int32 Breakthrough { get; set; }
            public Int32 ResonanceCount { get; set; }
        }

        public List<NotifyArchiveLoginDataEquip> Equips { get; set; } = new();
        public List<UInt32> MonsterUnlockIds { get; set; } = new();
        public List<UInt32> WeaponUnlockIds { get; set; } = new();
        public List<UInt32> AwarenessUnlockIds { get; set; } = new();
        public List<UInt32> MonsterSettings { get; set; } = new();
        public List<UInt32> WeaponSettings { get; set; } = new();
        public List<UInt32> AwarenessSettings { get; set; } = new();
        public List<UInt32> MonsterInfos { get; set; } = new();
        public List<UInt32> MonsterSkills { get; set; } = new();
        public List<UInt32> UnlockCgs { get; set; } = new();
        public List<dynamic> UnlockStoryDetails { get; set; } = new();
        public List<dynamic> PartnerUnlockIds { get; set; } = new();
        public List<dynamic> PartnerSettings { get; set; } = new();
        public List<UInt32> UnlockPvDetails { get; set; } = new();
        public List<Int32> UnlockMails { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyChatLoginData
    {
        public UInt32 RefreshTime { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyChatLoginDataUnlockEmoji
        {
            public UInt32 Id { get; set; }
            public Int32 EndTime { get; set; }
        }

        public List<NotifyChatLoginDataUnlockEmoji> UnlockEmojis { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifySocialData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifySocialDataFriendData
        {
            public UInt32 PlayerId { get; set; }
            public UInt32 CreateTime { get; set; }
        }

        public List<NotifySocialDataFriendData> FriendData { get; set; } = new();
        public List<dynamic> ApplyData { get; set; } = new();
        public List<dynamic> Remarks { get; set; } = new();
        public List<dynamic> BlockData { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyTaskData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyTaskDataTaskData
        {
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyTaskDataTaskDataTask
            {
                public UInt32 Id { get; set; }
                [global::MessagePack.MessagePackObject(true)]
                public class NotifyTaskDataTaskDataTaskSchedule
                {
                    public UInt32 Id { get; set; }
                    public Int32 Value { get; set; }
                }

                public List<NotifyTaskDataTaskDataTaskSchedule> Schedule { get; set; } = new();
                public Int32 State { get; set; }
                public UInt32 RecordTime { get; set; }
                public Int32 ActivityId { get; set; }
            }

            public List<NotifyTaskDataTaskDataTask> Tasks { get; set; } = new();
            public List<UInt32> Course { get; set; } = new();
            public List<Int32> FinishedTasks { get; set; } = new();
            public List<Int32> NewPlayerRewardRecord { get; set; } = new();
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyTaskDataTaskDataTaskLimitIdActiveInfo
            {
                public Int32 TaskLimitId { get; set; }
                public UInt32 ActiveTime { get; set; }
            }

            public List<NotifyTaskDataTaskDataTaskLimitIdActiveInfo> TaskLimitIdActiveInfos { get; set; } = new();
            public List<Int32> NewbieRecvProgress { get; set; } = new();
            public Boolean NewbieHonorReward { get; set; }
            public Int32 NewbieUnlockPeriod { get; set; }
        }

        public NotifyTaskDataTaskData TaskData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyActivenessStatus
    {
        public Int32 DailyActivenessRewardStatus { get; set; }
        public Int32 WeeklyActivenessRewardStatus { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyNewPlayerTaskStatus
    {
        public Int32 NewPlayerTaskActiveDay { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyTask
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyTaskTasks
        {
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyTaskTasksTask
            {
                public UInt32 Id { get; set; }
                [global::MessagePack.MessagePackObject(true)]
                public class NotifyTaskTasksTaskSchedule
                {
                    public UInt32 Id { get; set; }
                    public Int32 Value { get; set; }
                }

                public List<NotifyTaskTasksTaskSchedule> Schedule { get; set; } = new();
                public Int32 State { get; set; }
                public UInt32 RecordTime { get; set; }
                public Int32 ActivityId { get; set; }
            }

            public List<NotifyTaskTasksTask> Tasks { get; set; } = new();
        }

        public NotifyTaskTasks Tasks { get; set; }
        public dynamic? TaskLimitIdActiveInfos { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyRegression2Data
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyRegression2DataData
        {
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyRegression2DataDataActivityData
            {
                public Int32 Id { get; set; }
                public UInt32 BeginTime { get; set; }
                public Int32 State { get; set; }
            }

            public NotifyRegression2DataDataActivityData ActivityData { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyRegression2DataDataSignInData
            {
                public Int32 SigninTimes { get; set; }
                public UInt32 ResetCount { get; set; }
                public List<Int32> Rewards { get; set; } = new();
            }

            public NotifyRegression2DataDataSignInData SignInData { get; set; }
            public dynamic? InviteData { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyRegression2DataDataGachaData
            {
                public Int32 Id { get; set; }
                [global::MessagePack.MessagePackObject(true)]
                public class NotifyRegression2DataDataGachaDataGroupData
                {
                    public Int32 Id { get; set; }
                    public Int32 State { get; set; }
                    [global::MessagePack.MessagePackObject(true)]
                    public class NotifyRegression2DataDataGachaDataGroupDataGridData
                    {
                        public Int32 Id { get; set; }
                        public Int32 Times { get; set; }
                    }

                    public List<NotifyRegression2DataDataGachaDataGroupDataGridData> GridDatas { get; set; } = new();
                }

                public List<NotifyRegression2DataDataGachaDataGroupData> GroupDatas { get; set; } = new();
            }

            public List<NotifyRegression2DataDataGachaData> GachaDatas { get; set; } = new();
        }

        public NotifyRegression2DataData Data { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyMaintainerActionData
    {
        public Int32 Id { get; set; }
        public UInt32 ResetTime { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyMaintainerActionDataNode
        {
            public Int32 NodeId { get; set; }
            public Int32 NodeType { get; set; }
            public Int32 EventId { get; set; }
            public String Value { get; set; }
        }

        public List<NotifyMaintainerActionDataNode> Nodes { get; set; } = new();
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyMaintainerActionDataPlayer
        {
            public UInt32 PlayerId { get; set; }
            public String PlayerName { get; set; }
            public UInt32 HeadPortraitId { get; set; }
            public Int32 HeadFrameId { get; set; }
            public Int32 NodeId { get; set; }
            public Boolean IsNodeTriggered { get; set; }
            public Boolean Reverse { get; set; }
        }

        public List<NotifyMaintainerActionDataPlayer> Players { get; set; } = new();
        public List<Int32> Cards { get; set; } = new();
        public Int32 FightWinCount { get; set; }
        public Int32 BoxCount { get; set; }
        public Int32 UsedActionCount { get; set; }
        public Int32 ExtraActionCount { get; set; }
        public Boolean HasWarehouseNode { get; set; }
        public Int32 WarehouseFinishCount { get; set; }
        public Boolean HasMentorNode { get; set; }
        public Int32 MentorStatus { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyAllRedEnvelope
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyAllRedEnvelopeEnvelope
        {
            public Int32 ActivityId { get; set; }
            public Int32 NpcId { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyAllRedEnvelopeEnvelopeReward
            {
                public Int32 ItemId { get; set; }
                public UInt32 ItemCount { get; set; }
            }

            public List<NotifyAllRedEnvelopeEnvelopeReward> Rewards { get; set; } = new();
        }

        public List<NotifyAllRedEnvelopeEnvelope> Envelopes { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyScoreTitleData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyScoreTitleDataTitleInfo
        {
            public UInt32 Id { get; set; }
            public Int32 Quality { get; set; }
            public Int32 Score { get; set; }
            public UInt32 Time { get; set; }
            public Int32 WallId { get; set; }
            public dynamic? ExpandInfo { get; set; }
        }

        public List<NotifyScoreTitleDataTitleInfo> TitleInfos { get; set; } = new();
        public List<dynamic> HideTypes { get; set; } = new();
        public Boolean IsHideCollection { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyScoreTitleDataWallInfo
        {
            public Int32 Id { get; set; }
            public UInt32 PedestalId { get; set; }
            public UInt32 BackgroundId { get; set; }
            public Boolean IsShow { get; set; }
            public List<dynamic> CollectionSetInfos { get; set; } = new();
        }

        public List<NotifyScoreTitleDataWallInfo> WallInfos { get; set; } = new();
        public List<UInt32> UnlockedDecorationIds { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyBfrtData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyBfrtDataBfrtData
        {
            public List<dynamic> BfrtGroupRecords { get; set; } = new();
            public List<dynamic> BfrtTeamInfos { get; set; } = new();
        }

        public NotifyBfrtDataBfrtData BfrtData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyGuildEvent
    {
        public Int32 Type { get; set; }
        public UInt32 Value { get; set; }
        public Int32 Value2 { get; set; }
        public dynamic? Str1 { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyAssistData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyAssistDataAssistData
        {
            public UInt32 AssistCharacterId { get; set; }
        }

        public NotifyAssistDataAssistData AssistData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyWorkNextRefreshTime
    {
        public UInt32 NextRefreshTime { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyDormitoryData
    {
        public List<dynamic> FurnitureCreateList { get; set; } = new();
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyDormitoryDataWork
        {
            public UInt32 CharacterId { get; set; }
            public Int32 WorkPos { get; set; }
            public UInt32 WorkEndTime { get; set; }
            public Int32 DormitoryNum { get; set; }
            public Int32 RewardNum { get; set; }
            public Int32 ResetCount { get; set; }
        }

        public List<NotifyDormitoryDataWork> WorkList { get; set; } = new();
        public List<UInt32> FurnitureUnlockList { get; set; } = new();
        public Int32 SnapshotTimes { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyDormitoryDataDormitory
        {
            public UInt32 DormitoryId { get; set; }
            public String DormitoryName { get; set; }
        }

        public List<NotifyDormitoryDataDormitory> DormitoryList { get; set; } = new();
        public List<dynamic> VisitorList { get; set; } = new();
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyDormitoryDataFurniture
        {
            public Int32 Id { get; set; }
            public UInt32 ConfigId { get; set; }
            public Int32 X { get; set; }
            public Int32 Y { get; set; }
            public Int32 Angle { get; set; }
            public Int32 DormitoryId { get; set; }
            public Int32 Addition { get; set; }
            public List<Int32> AttrList { get; set; } = new();
            public Boolean IsLocked { get; set; }
        }

        public List<NotifyDormitoryDataFurniture> FurnitureList { get; set; } = new();
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyDormitoryDataCharacter
        {
            public UInt32 CharacterId { get; set; }
            public Int32 DormitoryId { get; set; }
            public Int32 Mood { get; set; }
            public Int32 Vitality { get; set; }
            public Int32 MoodSpeed { get; set; }
            public Int32 VitalitySpeed { get; set; }
            public UInt32 LastFondleRecoveryTime { get; set; }
            public Int32 LeftFondleCount { get; set; }
            public List<dynamic> EventList { get; set; } = new();
        }

        public List<NotifyDormitoryDataCharacter> CharacterList { get; set; } = new();
        public List<dynamic> Layouts { get; set; } = new();
        public List<dynamic> BindRelations { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyNameplateLoginData
    {
        public Int32 CurrentWearNameplate { get; set; }
        public List<dynamic> UnlockNameplates { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifySpecialTrainLoginData
    {
        public Int32 Id { get; set; }
        public dynamic? RewardIds { get; set; }
        public dynamic? PointRewards { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyGuildDormPlayerData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyGuildDormPlayerDataGuildDormData
        {
            public UInt32 CurrentCharacterId { get; set; }
            public Int32 DailyInteractRewardTotalTimes { get; set; }
            public Int32 DailyInteractRewardCurTimes { get; set; }
        }

        public NotifyGuildDormPlayerDataGuildDormData GuildDormData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyBountyTaskInfo
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyBountyTaskInfoTaskInfo
        {
            public Int32 RankLevel { get; set; }
            public List<dynamic> TaskCards { get; set; } = new();
            public Int32 TaskPoolRefreshCount { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyBountyTaskInfoTaskInfoTaskPool
            {
                public Int32 Id { get; set; }
                public UInt32 StageId { get; set; }
                public UInt32 RewardId { get; set; }
                public UInt32 EventId { get; set; }
                public UInt32 DifficultStageId { get; set; }
                public Int32 Status { get; set; }
            }

            public List<NotifyBountyTaskInfoTaskInfoTaskPool> TaskPool { get; set; } = new();
        }

        public NotifyBountyTaskInfoTaskInfo TaskInfo { get; set; }
        public UInt32 RefreshTime { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyExpeditionData
    {
        public Int32 ActivityId { get; set; }
        public Int32 ResetTime { get; set; }
        public Int32 ChapterId { get; set; }
        public dynamic? Rewards { get; set; }
        public Int32 CanRefreshTimes { get; set; }
        public Int32 ExtraRefreshTimes { get; set; }
        public Int32 BuyRefreshTimes { get; set; }
        public Int32 RefreshTimesRecoveryTime { get; set; }
        public Int32 DailyLikeCount { get; set; }
        public Int32 RefreshTimes { get; set; }
        public Int32 RecruitLevel { get; set; }
        public Int32 NpcGroup { get; set; }
        public Int32 DefaultTeamId { get; set; }
        public dynamic? PickedCharacters { get; set; }
        public dynamic? AlternativeCharacters { get; set; }
        public dynamic? Stages { get; set; }
        public dynamic? EndlessStage { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyNieRData
    {
        public Int32 ActivityId { get; set; }
        public Boolean EasterEggFinish { get; set; }
        public List<dynamic> Characters { get; set; } = new();
        public List<dynamic> Bosses { get; set; } = new();
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyNieRDataSupport
        {
            public Int32 SupportId { get; set; }
            public Int32 Level { get; set; }
            public Int32 Exp { get; set; }
            public Int32 SelectSkillId { get; set; }
            public List<dynamic> Skills { get; set; } = new();
        }

        public NotifyNieRDataSupport Support { get; set; }
    }

    [MessagePack.MessagePackObject(true)]
    public class GetPurchaseListRequest
    {
        public List<int> UiTypeList { get; set; } = new();
    }

    [MessagePack.MessagePackObject(true)]
    public class SignInRequest
    {
        public int Id { get; set; }
    }

    [MessagePack.MessagePackObject(true)]
    public class GuideOpenRequest
    {
        public int GuideGroupId { get; set; }
    }

    [MessagePack.MessagePackObject(true)]
    public class GuideOpenResponse
    {
        public int Code { get; set; }
    }

    [MessagePack.MessagePackObject(true)]
    public class SignInResponse
    {
        public int Code { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class SignInResponseRewardGoodsList
        {
            public int RewardType { get; set; }
            public uint TemplateId { get; set; }
            public int Count { get; set; }
            public int Level { get; set; }
            public int Quality { get; set; }
            public int Grade { get; set; }
            public int Breakthrough { get; set; }
            public int ConvertFrom { get; set; }
            public uint Id { get; set; }
        }

        public List<SignInResponseRewardGoodsList> RewardGoodsList { get; set; } = new();
    }

    [MessagePack.MessagePackObject(true)]
    public class OfflineMessageRequest
    {
        public int MessageId { get; set; }
    }

    [global::MessagePack.MessagePackObject(true)]
    public class NotifyFiveTwentyRecord
    {
        public List<dynamic> CharacterIds { get; set; } = new();
        public List<dynamic> GroupRecord { get; set; } = new();
        public Int32 ActivityNo { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class PurchaseDailyNotify
    {
        public List<dynamic> ExpireInfoList { get; set; } = new();
        public List<dynamic> DailyRewardInfoList { get; set; } = new();
        [MessagePack.MessagePackObject(true)]
        public class PurchaseDailyNotifyFreeRewardInfoList
        {
            public uint Id { get; set; }
            public string Name { get; set; }
        }

        public List<PurchaseDailyNotifyFreeRewardInfoList> FreeRewardInfoList { get; set; } = new();
    }



    [global::MessagePack.MessagePackObject(true)]
    public class NotifyPurchaseRecommendConfig
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyPurchaseRecommendConfigData
        {
            public Dictionary<dynamic, dynamic> AddOrModifyConfigs { get; set; }
            public dynamic? RemoveIds { get; set; }
        }

        public NotifyPurchaseRecommendConfigData Data { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyBackgroundLoginData
    {
        public List<UInt32> HaveBackgroundIds { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyMedalData
    {
        public List<dynamic> MedalInfos { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyExploreData
    {
        public List<dynamic> ChapterDatas { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyGatherRewardList
    {
        public List<Int32> GatherRewards { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyDrawTicketData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyDrawTicketDataDrawTicketInfo
        {
            public Int32 Id { get; set; }
            public UInt32 CfgId { get; set; }
            public Int32 Count { get; set; }
            public UInt32 CreateTime { get; set; }
            public UInt32 ExpireTime { get; set; }
            public UInt32 DailyResetCount { get; set; }
        }

        public List<NotifyDrawTicketDataDrawTicketInfo> DrawTicketInfos { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyAccumulatedPayData
    {
        public Int32 PayId { get; set; }
        public Single PayMoney { get; set; }
        public List<Int32> PayRewardIds { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyFubenPrequelData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyFubenPrequelDataFubenPrequelData
        {
            public List<dynamic> RewardedStages { get; set; } = new();
            public List<dynamic> UnlockChallengeStages { get; set; } = new();
        }

        public NotifyFubenPrequelDataFubenPrequelData FubenPrequelData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyPrequelChallengeRefreshTime
    {
        public UInt32 NextRefreshTime { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyMainLineActivity
    {
        public List<UInt32> Chapters { get; set; } = new();
        public Int32 BfrtChapter { get; set; }
        public UInt32 EndTime { get; set; }
        public Int32 HideChapterBeginTime { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyDailyFubenLoginData
    {
        public UInt32 RefreshTime { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyDailyFubenLoginDataRecord
        {
            public UInt32 ChapterId { get; set; }
            public UInt32 StageId { get; set; }
        }

        public List<NotifyDailyFubenLoginDataRecord> Records { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyBirthdayPlot
    {
        public UInt32 NextActiveYear { get; set; }
        public Int32 IsChange { get; set; }
        public List<dynamic> UnLockCg { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyBossActivityData
    {
        public Int32 ActivityId { get; set; }
        public Int32 SectionId { get; set; }
        public Int32 Schedule { get; set; }
        public List<dynamic> StageStarInfos { get; set; } = new();
        public List<dynamic> StarRewardIds { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyBriefStoryData
    {
        public List<dynamic> FinishedIds { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyChessPursuitGroupInfo
    {
        public List<dynamic> MapDBList { get; set; } = new();
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyChessPursuitGroupInfoMapBoss
        {
            public Int32 Id { get; set; }
            public Int32 InitHp { get; set; }
            public Int32 SubBossMaxHp { get; set; }
            public Int32 BossStepMin { get; set; }
            public Int32 BossStepMax { get; set; }
            public Single BattleHurtRate { get; set; }
            public Int32 BattleHurtMax { get; set; }
            public Int32 SelfHpRate { get; set; }
            public Int32 SelfHpMax { get; set; }
            public Int32 ConvertHurtRate { get; set; }
        }

        public List<NotifyChessPursuitGroupInfoMapBoss> MapBossList { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyClickClearData
    {
        public List<dynamic> Activities { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyCourseData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyCourseDataData
        {
            public Int32 TotalLessonPoint { get; set; }
            public Int32 MaxTotalLessonPoint { get; set; }
            public List<dynamic> ChapterDataList { get; set; } = new();
            public dynamic? StageDataDict { get; set; }
            public List<dynamic> RewardIds { get; set; } = new();
        }

        public NotifyCourseDataData Data { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyDoomsdayDbChange
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyDoomsdayDbChangeActivityDb
        {
            public Int32 ActivityId { get; set; }
            public List<dynamic> StageDbExtList { get; set; } = new();
        }

        public NotifyDoomsdayDbChangeActivityDb ActivityDb { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyActivityDrawList
    {
        public List<UInt32> DrawIdList { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyActivityDrawGroupCount
    {
        public Int32 Count { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyExperimentData
    {
        public List<dynamic> FinishIds { get; set; } = new();
        public List<dynamic> ExperimentInfos { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyBabelTowerActivityStatus
    {
        public Int32 ActivityNo { get; set; }
        public Int32 Status { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyBabelTowerData
    {
        public Int32 ActivityNo { get; set; }
        public Int32 MaxScore { get; set; }
        public Int32 RankLevel { get; set; }
        public List<dynamic> StageDatas { get; set; } = new();
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyBabelTowerDataExtraData
        {
            public Int32 ActivityNo { get; set; }
            public Int32 MaxScore { get; set; }
            public Int32 RankLevel { get; set; }
            public List<dynamic> StageDatas { get; set; } = new();
        }

        public NotifyBabelTowerDataExtraData ExtraData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyFubenBossSingleData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyFubenBossSingleDataFubenBossSingleData
        {
            public Int32 ActivityNo { get; set; }
            public Int32 TotalScore { get; set; }
            public Int32 MaxScore { get; set; }
            public Int32 OldLevelType { get; set; }
            public Int32 LevelType { get; set; }
            public Int32 ChallengeCount { get; set; }
            public UInt32 RemainTime { get; set; }
            public Int32 AutoFightCount { get; set; }
            public dynamic? CharacterPoints { get; set; }
            public List<dynamic> HistoryList { get; set; } = new();
            public List<dynamic> RewardIds { get; set; } = new();
            public Int32 RankPlatform { get; set; }
            public List<Int32> BossList { get; set; } = new();
            public List<dynamic> TrialStageInfoList { get; set; } = new();
        }

        public NotifyFubenBossSingleDataFubenBossSingleData FubenBossSingleData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyFestivalData
    {
        public List<dynamic> FestivalInfos { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyPracticeData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyPracticeDataChapterInfo
        {
            public Int32 Id { get; set; }
            public List<UInt32> FinishStages { get; set; } = new();
        }

        public List<NotifyPracticeDataChapterInfo> ChapterInfos { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyTrialData
    {
        public List<Int32> FinishTrial { get; set; } = new();
        public List<Int32> RewardRecord { get; set; } = new();
        public List<dynamic> TypeRewardRecord { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyInfestorStatus
    {
        public Int32 Status { get; set; }
        public Int32 NextResetTime { get; set; }
        public List<dynamic> MapList { get; set; } = new();
        public Boolean IsReset { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyMaverickData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyMaverickDataMaverickData
        {
            public Int32 ActivityId { get; set; }
            public List<dynamic> PassStageDataInfos { get; set; } = new();
            public List<dynamic> MemberDataInfos { get; set; } = new();
            public Int32 Score { get; set; }
            public List<dynamic> RobotIds { get; set; } = new();
        }

        public NotifyMaverickDataMaverickData MaverickData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyMoeWarPreparationData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyMoeWarPreparationDataData
        {
            public Int32 ActivityId { get; set; }
            public Int32 MatchId { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyMoeWarPreparationDataDataStage
            {
                public Int32 LastStageRecoveryTime { get; set; }
                public List<dynamic> Stages { get; set; } = new();
                public List<dynamic> ReserveStages { get; set; } = new();
            }

            public NotifyMoeWarPreparationDataDataStage Stage { get; set; }
            public List<dynamic> GetRewardGears { get; set; } = new();
            public List<dynamic> Helpers { get; set; } = new();
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyMoeWarPreparationDataDataAssistance
            {
                public Int32 AssistanceCount { get; set; }
                public Int32 RecoveryTime { get; set; }
            }

            public NotifyMoeWarPreparationDataDataAssistance Assistance { get; set; }
            public List<dynamic> VoteItems { get; set; } = new();
        }

        public NotifyMoeWarPreparationDataData Data { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyPassportData
    {
        public Int32 ActivityId { get; set; }
        public Int32 Level { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyPassportDataPassportInfo
        {
            public Int32 Id { get; set; }
            public List<UInt32> GotRewardList { get; set; } = new();
        }

        public List<NotifyPassportDataPassportInfo> PassportInfos { get; set; } = new();
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyPassportDataLastTimeBaseInfo
        {
            public Int32 Level { get; set; }
            public UInt32 Exp { get; set; }
        }

        public NotifyPassportDataLastTimeBaseInfo LastTimeBaseInfo { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyPivotCombatData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyPivotCombatDataPivotCombatData
        {
            public Int32 ActivityId { get; set; }
            public Int32 Difficulty { get; set; }
            public List<dynamic> RegionDataList { get; set; } = new();
        }

        public NotifyPivotCombatDataPivotCombatData PivotCombatData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifySettingLoadingOption
    {
        public dynamic? LoadingData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyRepeatChallengeData
    {
        public Int32 Id { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyRepeatChallengeDataExpInfo
        {
            public Int32 Level { get; set; }
            public Int32 Exp { get; set; }
        }

        public NotifyRepeatChallengeDataExpInfo ExpInfo { get; set; }
        public List<dynamic> RcChapters { get; set; } = new();
        public List<dynamic> RewardIds { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyPlayerReportData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyPlayerReportDataReportData
        {
            public Int32 ReportTimes { get; set; }
            public Int32 LastReportTime { get; set; }
        }

        public NotifyPlayerReportDataReportData ReportData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyReviewConfig
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyReviewConfigReviewActivityConfig
        {
            public Int32 Id { get; set; }
            public UInt32 StartTime { get; set; }
            public UInt32 EndTime { get; set; }
            public UInt32 RewardId { get; set; }
        }

        public List<NotifyReviewConfigReviewActivityConfig> ReviewActivityConfigList { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifySimulatedCombatData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifySimulatedCombatDataData
        {
            public Int32 ActivityId { get; set; }
            public Int32 DailyStageStarRewardCount { get; set; }
            public List<dynamic> StarRewards { get; set; } = new();
            public List<dynamic> PointRewards { get; set; } = new();
            public List<dynamic> StageDataList { get; set; } = new();
        }

        public NotifySimulatedCombatDataData Data { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyStrongholdLoginData
    {
        public Int32 Id { get; set; }
        public UInt32 BeginTime { get; set; }
        public Int32 FightBeginTime { get; set; }
        public Int32 CurDay { get; set; }
        public Int32 AssistCharacterId { get; set; }
        public Int32 SetAssistCharacterTime { get; set; }
        public Int32 BorrowCount { get; set; }
        public UInt32 ElectricEnergy { get; set; }
        public Int32 Endurance { get; set; }
        public Int32 MineralLeft { get; set; }
        public Int32 TotalMineral { get; set; }
        public List<dynamic> ElectricCharacterIds { get; set; } = new();
        public List<dynamic> FinishGroupIds { get; set; } = new();
        public List<dynamic> FinishGroupInfos { get; set; } = new();
        public List<dynamic> HistoryFinishGroupInfos { get; set; } = new();
        public List<dynamic> GroupInfos { get; set; } = new();
        public List<dynamic> TeamInfos { get; set; } = new();
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyStrongholdLoginDataGroupStageData
        {
            public Int32 Id { get; set; }
            public List<UInt32> StageIds { get; set; } = new();
            public Dictionary<dynamic, dynamic> StageBuffId { get; set; }
            public Int32 SupportId { get; set; }
        }

        public List<NotifyStrongholdLoginDataGroupStageData> GroupStageDatas { get; set; } = new();
        public List<Int32> RuneList { get; set; } = new();
        public List<dynamic> RewardIds { get; set; } = new();
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyStrongholdLoginDataLastResultRecord
        {
            public Int32 Id { get; set; }
            public Int32 FinishCount { get; set; }
            public Int32 MinerCount { get; set; }
            public Int32 MineralCount { get; set; }
            public Int32 AssistCount { get; set; }
            public Int32 AssistRewardValue { get; set; }
        }

        public NotifyStrongholdLoginDataLastResultRecord LastResultRecord { get; set; }
        public List<dynamic> MineRecords { get; set; } = new();
        public Int32 LevelId { get; set; }
        public List<dynamic> StayDays { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifySummerSignInData
    {
        public Int32 ActId { get; set; }
        public List<Int32> MsgIdList { get; set; } = new();
        public Int32 SurplusTimes { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyTaikoMasterData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyTaikoMasterDataTaikoMasterData
        {
            public Int32 ActivityId { get; set; }
            public List<dynamic> StageDataList { get; set; } = new();
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyTaikoMasterDataTaikoMasterDataSetting
            {
                public Int32 AppearOffset { get; set; }
                public Int32 JudgeOffset { get; set; }
            }

            public NotifyTaikoMasterDataTaikoMasterDataSetting Setting { get; set; }
        }

        public NotifyTaikoMasterDataTaikoMasterData TaikoMasterData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyTeachingActivityInfo
    {
        public List<dynamic> ActivityInfo { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyTheatreData
    {
        public Int32 CurChapterId { get; set; }
        public Int32 CurRoleLv { get; set; }
        public Int32 DifficultyId { get; set; }
        public Int32 KeepsakeId { get; set; }
        public List<dynamic> UnlockPowerIds { get; set; } = new();
        public List<dynamic> UnlockPowerFavorIds { get; set; } = new();
        public List<dynamic> EffectPowerFavorIds { get; set; } = new();
        public List<Int32> Skills { get; set; } = new();
        public List<UInt32> RecruitRole { get; set; } = new();
        public List<dynamic> Keepsakes { get; set; } = new();
        public List<dynamic> Decorations { get; set; } = new();
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyTheatreDataCurChapterDb
        {
            public Int32 ChapterId { get; set; }
            public List<UInt32> RefreshRole { get; set; } = new();
            public Int32 RefreshRoleCount { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyTheatreDataCurChapterDbCurNodeDb
            {
                public Int32 NodeId { get; set; }
                [global::MessagePack.MessagePackObject(true)]
                public class NotifyTheatreDataCurChapterDbCurNodeDbSlot
                {
                    public Int32 SlotId { get; set; }
                    public Int32 RewardType { get; set; }
                    public Int32 PowerId { get; set; }
                    public Int32 TheatreStageId { get; set; }
                    public Int32 SlotType { get; set; }
                    public Int32 ConfigId { get; set; }
                    public dynamic? StoryId { get; set; }
                    public Int32 Selected { get; set; }
                    public List<UInt32> StageIds { get; set; } = new();
                    public List<dynamic> PassedStageIds { get; set; } = new();
                    public List<dynamic> PassedStageIndexs { get; set; } = new();
                    public List<dynamic> ShopItems { get; set; } = new();
                    public Int32 CurStepId { get; set; }
                    public List<dynamic> PassedStepId { get; set; } = new();
                }

                public List<NotifyTheatreDataCurChapterDbCurNodeDbSlot> Slots { get; set; } = new();
            }

            public NotifyTheatreDataCurChapterDbCurNodeDb CurNodeDb { get; set; }
            public List<dynamic> SkillToSelect { get; set; } = new();
        }

        public NotifyTheatreDataCurChapterDb CurChapterDb { get; set; }
        public Int32 ReopenCount { get; set; }
        public List<Int32> SkillIllustratedBook { get; set; } = new();
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyTheatreDataSingleTeamData
        {
            public Int32 TeamIndex { get; set; }
            public Int32 CaptainPos { get; set; }
            public Int32 FirstFightPos { get; set; }
            public List<Int32> CardIds { get; set; } = new();
            public List<UInt32> RobotIds { get; set; } = new();
        }

        public NotifyTheatreDataSingleTeamData SingleTeamData { get; set; }
        public List<dynamic> MultiTeamDatas { get; set; } = new();
        public Int32 UseOwnCharacter { get; set; }
        public Int32 FavorCoin { get; set; }
        public Int32 DecorationCoin { get; set; }
        public List<Int32> PassChapterId { get; set; } = new();
        public Dictionary<dynamic, dynamic> PassEventRecord { get; set; }
        public Int32 PassNodeCount { get; set; }
        public List<dynamic> EndingRecord { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyVoteData
    {
        public List<dynamic> VoteAlarmDic { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyTRPGData
    {
        public UInt32 CurTargetLink { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyTRPGDataBaseInfo
        {
            public Int32 Level { get; set; }
            public Int32 Exp { get; set; }
            public Int32 Endurance { get; set; }
        }

        public NotifyTRPGDataBaseInfo BaseInfo { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyTRPGDataBossInfo
        {
            public Int32 Id { get; set; }
            public Int32 ChallengeCount { get; set; }
            public List<dynamic> PhasesRewardList { get; set; } = new();
        }

        public NotifyTRPGDataBossInfo BossInfo { get; set; }
        public List<dynamic> TargetList { get; set; } = new();
        public List<dynamic> RewardList { get; set; } = new();
        public List<dynamic> FuncList { get; set; } = new();
        public List<dynamic> Characters { get; set; } = new();
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyTRPGDataShopInfo
        {
            public Int32 DisCount { get; set; }
            public Int32 AddBuyCount { get; set; }
            public UInt32 Id { get; set; }
            public List<dynamic> ItemInfos { get; set; } = new();
        }

        public List<NotifyTRPGDataShopInfo> ShopInfos { get; set; } = new();
        public List<dynamic> MazeInfos { get; set; } = new();
        public List<dynamic> MemoirList { get; set; } = new();
        public Int32 ItemCapacityAdd { get; set; }
        public Boolean IsNormalPage { get; set; }
        public List<dynamic> StageList { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyBiancaTheatreActivityData
    {
        public Int32 CurActivityId { get; set; }
        public Int32 CurChapterId { get; set; }
        public Int32 DifficultyId { get; set; }
        public Int32 CurTeamId { get; set; }
        public dynamic? CurChapterDb { get; set; }
        public List<dynamic> Characters { get; set; } = new();
        public List<dynamic> Items { get; set; } = new();
        public Int32 TotalExp { get; set; }
        public List<dynamic> GetRewardIds { get; set; } = new();
        public List<dynamic> StrengthenDbs { get; set; } = new();
        public dynamic? SingleTeamData { get; set; }
        public List<dynamic> UnlockItemId { get; set; } = new();
        public List<dynamic> UnlockTeamId { get; set; } = new();
        public List<dynamic> UnlockDifficultyId { get; set; } = new();
        public List<dynamic> TeamRecords { get; set; } = new();
        public List<dynamic> PassChapterIds { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyMentorData
    {
        public Int32 PlayerType { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyMentorDataTeacher
        {
            public Int32 PlayerId { get; set; }
            public dynamic? PlayerName { get; set; }
            public Int32 Level { get; set; }
            public Int32 HeadPortraitId { get; set; }
            public Int32 HeadFrameId { get; set; }
            public Boolean IsGraduate { get; set; }
            public dynamic? Tag { get; set; }
            public dynamic? OnlineTag { get; set; }
            public dynamic? Announcement { get; set; }
            public Int32 StudentCount { get; set; }
            public dynamic? StudentTask { get; set; }
            public Boolean IsOnline { get; set; }
            public dynamic? SystemTask { get; set; }
            public dynamic? WeeklyTask { get; set; }
            public Int32 KizunaAmount { get; set; }
            public Int32 JoinTime { get; set; }
            public Int32 ReachTime { get; set; }
            public Int32 LastLoginTime { get; set; }
            public Int32 SendGiftCount { get; set; }
        }

        public NotifyMentorDataTeacher Teacher { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyMentorDataStudent
        {
            public UInt32 PlayerId { get; set; }
            public String PlayerName { get; set; }
            public Int32 Level { get; set; }
            public UInt32 HeadPortraitId { get; set; }
            public Int32 HeadFrameId { get; set; }
            public Boolean IsGraduate { get; set; }
            public dynamic? Tag { get; set; }
            public dynamic? OnlineTag { get; set; }
            public dynamic? Announcement { get; set; }
            public Int32 StudentCount { get; set; }
            public List<dynamic> StudentTask { get; set; } = new();
            public Boolean IsOnline { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyMentorDataStudentSystemTask
            {
                public UInt32 TaskId { get; set; }
                public Int32 State { get; set; }
                public List<dynamic> Schedule { get; set; } = new();
                public Int32 Status { get; set; }
                public Int32 RewardId { get; set; }
                public List<dynamic> EquipList { get; set; } = new();
                public Boolean HasChange { get; set; }
            }

            public List<NotifyMentorDataStudentSystemTask> SystemTask { get; set; } = new();
            public List<dynamic> WeeklyTask { get; set; } = new();
            public Int32 KizunaAmount { get; set; }
            public Int32 JoinTime { get; set; }
            public Int32 ReachTime { get; set; }
            public Int32 LastLoginTime { get; set; }
            public Int32 SendGiftCount { get; set; }
        }

        public List<NotifyMentorDataStudent> Students { get; set; } = new();
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyMentorDataApply
        {
            public UInt32 ApplyId { get; set; }
            public UInt32 CreateTime { get; set; }
        }

        public List<NotifyMentorDataApply> ApplyList { get; set; } = new();
        public Int32 GraduateStudentCount { get; set; }
        public List<dynamic> StageReward { get; set; } = new();
        public List<dynamic> WeeklyTaskReward { get; set; } = new();
        public Int32 WeeklyTaskCompleteCount { get; set; }
        public List<Int32> Tag { get; set; } = new();
        public List<Int32> OnlineTag { get; set; } = new();
        public String Announcement { get; set; }
        public Int32 DailyChangeTaskCount { get; set; }
        public Int32 WeeklyLevel { get; set; }
        public Int32 MonthlyStudentCount { get; set; }
        public dynamic? Message { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyMentorChat
    {
        public List<dynamic> ChatMessages { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class ActivityResultNotify
    {
        public Int32 ChallengeId { get; set; }
        public Int32 GroupRank { get; set; }
        public Int32 OldArenaLevel { get; set; }
        public Int32 NewArenaLevel { get; set; }
        public Boolean IsProtected { get; set; }
        public Int32 ContributeScore { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class ActivityResultNotifyRewardGoods
        {
            public Int32 RewardType { get; set; }
            public Int32 TemplateId { get; set; }
            public Int32 Count { get; set; }
            public Int32 Level { get; set; }
            public Int32 Quality { get; set; }
            public Int32 Grade { get; set; }
            public Int32 Breakthrough { get; set; }
            public Int32 ConvertFrom { get; set; }
            public UInt32 Id { get; set; }
        }

        public List<ActivityResultNotifyRewardGoods> RewardGoodsList { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyArenaActivity
    {
        public Int32 ActivityNo { get; set; }
        public Int32 ChallengeId { get; set; }
        public Int32 Status { get; set; }
        public UInt32 NextStatusTime { get; set; }
        public Int32 ArenaLevel { get; set; }
        public Int32 JoinActivity { get; set; }
        public Int32 UnlockCount { get; set; }
        public UInt32 TeamTime { get; set; }
        public UInt32 FightTime { get; set; }
        public UInt32 ResultTime { get; set; }
        public List<UInt32> MaxPointStageList { get; set; } = new();
        public Int32 ContributeScore { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyGuildData
    {
        public UInt32 GuildId { get; set; }
        public String GuildName { get; set; }
        public Int32 GuildLevel { get; set; }
        public Int32 IconId { get; set; }
        public Int32 GuildRankLevel { get; set; }
        public Int32 HasContributeReward { get; set; }
        public Boolean HasRecruit { get; set; }
        public UInt32 BossEndTime { get; set; }
        public Int32 FreeChangeGuildNameCount { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyGuildWarActivityData
    {
        public Int32 ActivityNo { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyGuildWarActivityDataActivityData
        {
            public Int32 CurRoundId { get; set; }
            public Int32 RestRoundId { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyGuildWarActivityDataActivityDataRoundData
            {
                public Int32 RoundId { get; set; }
                public Int32 SkipRound { get; set; }
                public Int32 DifficultyId { get; set; }
                [global::MessagePack.MessagePackObject(true)]
                public class NotifyGuildWarActivityDataActivityDataRoundDataNodeData
                {
                    public Int32 Uid { get; set; }
                    public Int32 NodeId { get; set; }
                    public UInt32 CurHp { get; set; }
                    public UInt32 HpMax { get; set; }
                    public Int32 LastMstBornDayNo { get; set; }
                    public Int32 DeadTime { get; set; }
                    public Int32 AddRebuildTime { get; set; }
                    public Int32 IsDead { get; set; }
                    public Int32 FightCount { get; set; }
                    public Int32 CurMember { get; set; }
                    public Int32 NextMstBornTime { get; set; }
                    public Int32 Weakness { get; set; }
                    public Int32 NextBossAttackTime { get; set; }
                    public Int32 NextBossAttackDayNo { get; set; }
                }

                public List<NotifyGuildWarActivityDataActivityDataRoundDataNodeData> NodeData { get; set; } = new();
                [global::MessagePack.MessagePackObject(true)]
                public class NotifyGuildWarActivityDataActivityDataRoundDataMonsterData
                {
                    public Int32 Uid { get; set; }
                    public Int32 MonsterId { get; set; }
                    public Int32 CurNodeIdx { get; set; }
                    public Int32 CurHp { get; set; }
                    public UInt32 HpMax { get; set; }
                    public UInt32 LastMoveDayNo { get; set; }
                    public UInt32 DeadTime { get; set; }
                    public Int32 FightCount { get; set; }
                }

                public List<NotifyGuildWarActivityDataActivityDataRoundDataMonsterData> MonsterData { get; set; } = new();
                public List<dynamic> AttackPlan { get; set; } = new();
                public Int32 TotalActivation { get; set; }
                public UInt32 TotalPoint { get; set; }
                public List<dynamic> Battlelog { get; set; } = new();
            }

            public List<NotifyGuildWarActivityDataActivityDataRoundData> RoundData { get; set; } = new();
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyGuildWarActivityDataActivityDataAction
            {
                public Int32 ActionId { get; set; }
                public UInt32 CreateTime { get; set; }
                public Int32 ActionType { get; set; }
                public Int32 MonsterUid { get; set; }
                public dynamic? MonsterData { get; set; }
                public Int32 PreNodeIdx { get; set; }
                public Int32 NextNodeIdx { get; set; }
                public Int32 NodeUid { get; set; }
                public dynamic? NodeData { get; set; }
                public Int32 Damage { get; set; }
                public Int32 NodeId { get; set; }
                public Int32 RoundId { get; set; }
                public Int32 CurNodeIdx { get; set; }
                public Int32 FromNodeUid { get; set; }
                public Int32 ToNodeUid { get; set; }
                public Int32 NextBossAttackTime { get; set; }
                public Int32 DifficultyId { get; set; }
            }

            public List<NotifyGuildWarActivityDataActivityDataAction> ActionList { get; set; } = new();
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyGuildWarActivityDataActivityDataSettleData
            {
                public Int32 RoundId { get; set; }
                public Int32 DifficultyId { get; set; }
                public Int32 IsPass { get; set; }
                public UInt32 PassUseSecond { get; set; }
                public Int32 TotalActivation { get; set; }
                public Int32 PlayerActivation { get; set; }
                public Int32 PlayerPoints { get; set; }
                public Int32 BaseHpPercent { get; set; }
                public UInt32 BasePoint { get; set; }
                public Int32 FinalRankPercent { get; set; }
                public List<UInt32> CurMember { get; set; } = new();
            }

            public List<NotifyGuildWarActivityDataActivityDataSettleData> SettleDatas { get; set; } = new();
            public List<dynamic> CompleteTaskId { get; set; } = new();
            public Int32 NextDifficultyId { get; set; }
            public Int32 LastMaxDifficultyId { get; set; }
        }

        public NotifyGuildWarActivityDataActivityData ActivityData { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyGuildWarActivityDataMyRoundData
        {
            public UInt32 GuildId { get; set; }
            public Int32 RoundId { get; set; }
            public Int32 DifficultyId { get; set; }
            public Int32 SkipRound { get; set; }
            public Int32 CurNodeId { get; set; }
            public Int32 Activation { get; set; }
            public Int32 Point { get; set; }
            public List<dynamic> RewardNodeIds { get; set; } = new();
            public Int32 RoundReward { get; set; }
        }

        public List<NotifyGuildWarActivityDataMyRoundData> MyRoundData { get; set; } = new();
        public List<dynamic> FightRecords { get; set; } = new();
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyGuildWarActivityDataPopupRecord
        {
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyGuildWarActivityDataPopupRecordSettleData
            {
                public Int32 RoundId { get; set; }
                public Int32 DifficultyId { get; set; }
                public Int32 IsPass { get; set; }
                public UInt32 PassUseSecond { get; set; }
                public Int32 TotalActivation { get; set; }
                public Int32 PlayerActivation { get; set; }
                public Int32 PlayerPoints { get; set; }
                public Int32 BaseHpPercent { get; set; }
                public UInt32 BasePoint { get; set; }
                public Int32 FinalRankPercent { get; set; }
                public List<UInt32> CurMember { get; set; } = new();
            }

            public List<NotifyGuildWarActivityDataPopupRecordSettleData> SettleDatas { get; set; } = new();
        }

        public NotifyGuildWarActivityDataPopupRecord PopupRecord { get; set; }
        public List<dynamic> ActionPlayed { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyItemDataList
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyItemDataListItemData
        {
            public Int32 Id { get; set; }
            public UInt32 Count { get; set; }
            public Int32 BuyTimes { get; set; }
            public Int32 TotalBuyTimes { get; set; }
            public Int32 LastBuyTime { get; set; }
            public UInt32 RefreshTime { get; set; }
            public UInt32 CreateTime { get; set; }
        }

        public List<NotifyItemDataListItemData> ItemDataList { get; set; } = new();
        public dynamic? ItemRecycleDict { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class EnterWorldChatResponse
    {
        public Int32 Code { get; set; }
        public Int32 ChannelId { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class HeartbeatResponse
    {
        public long UtcServerTime { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class GetWorldChannelInfoResponse
    {
        public Int32 Code { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class GetWorldChannelInfoResponseChannelInfo
        {
            public Int32 ChannelId { get; set; }
            public Int32 PlayerNum { get; set; }
        }

        public List<GetWorldChannelInfoResponseChannelInfo> ChannelInfos { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class GetPurchaseListResponse
    {
        public Int32 Code { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class GetPurchaseListResponsePurchaseInfo
        {
            public UInt32 Id { get; set; }
            public Int32 TimeToInvalid { get; set; }
            public Int32 TimeToShelve { get; set; }
            public Int32 TimeToUnShelve { get; set; }
            public Int32 BuyTimes { get; set; }
            public Int32 BuyLimitTimes { get; set; }
            public Int32 ConsumeId { get; set; }
            public Int32 ConsumeCount { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class GetPurchaseListResponsePurchaseInfoRewardGoods
            {
                public Int32 RewardType { get; set; }
                public Int32 TemplateId { get; set; }
                public UInt32 Count { get; set; }
                public Int32 Level { get; set; }
                public Int32 Quality { get; set; }
                public Int32 Grade { get; set; }
                public Int32 Breakthrough { get; set; }
                public Int32 ConvertFrom { get; set; }
                public UInt32 Id { get; set; }
            }

            public List<GetPurchaseListResponsePurchaseInfoRewardGoods> RewardGoodsList { get; set; } = new();
            [global::MessagePack.MessagePackObject(true)]
            public class GetPurchaseListResponsePurchaseInfoDailyRewardGoods
            {
                public Int32 RewardType { get; set; }
                public Int32 TemplateId { get; set; }
                public Int32 Count { get; set; }
                public Int32 Level { get; set; }
                public Int32 Quality { get; set; }
                public Int32 Grade { get; set; }
                public Int32 Breakthrough { get; set; }
                public Int32 ConvertFrom { get; set; }
                public UInt32 Id { get; set; }
            }

            public List<GetPurchaseListResponsePurchaseInfoDailyRewardGoods> DailyRewardGoodsList { get; set; } = new();
            public dynamic? FirstRewardGoods { get; set; }
            public dynamic? ExtraRewardGoods { get; set; }
            public Int32 DailyRewardRemainDay { get; set; }
            public Boolean IsDailyRewardGet { get; set; }
            public String Name { get; set; }
            public String Desc { get; set; }
            public String Icon { get; set; }
            public Int32 UiType { get; set; }
            public Int32 SignInId { get; set; }
            public Int32 Tag { get; set; }
            public Int32 Priority { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class GetPurchaseListResponsePurchaseInfoClientResetInfo
            {
                public Int32 ResetType { get; set; }
                public Int32 DayCount { get; set; }
            }

            public GetPurchaseListResponsePurchaseInfoClientResetInfo ClientResetInfo { get; set; }
            public Boolean IsUseMail { get; set; }
            public dynamic? NormalDiscounts { get; set; }
            public dynamic? DiscountCouponInfos { get; set; }
            public dynamic? DiscountShowStr { get; set; }
            public Int32 LastBuyTime { get; set; }
            public Int32 MailCount { get; set; }
            public dynamic? PayKeySuffix { get; set; }
            public List<UInt32> MutexPurchaseIds { get; set; } = new();
            public Int32 ConvertSwitch { get; set; }
            public Boolean CanMultiply { get; set; }
            public dynamic? FashionLabel { get; set; }
        }

        public List<GetPurchaseListResponsePurchaseInfo> PurchaseInfoList { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class GetPlayerInfoListRequest
    {
        public List<UInt32> Ids { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class GetPlayerInfoListResponse
    {
        public Int32 Code { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class GetPlayerInfoListResponsePlayerInfo
        {
            public UInt32 Id { get; set; }
            public String Name { get; set; }
            public Int32 Level { get; set; }
            public Int32 FriendExp { get; set; }
            public String Sign { get; set; }
            public UInt32 CurrHeadPortraitId { get; set; }
            public Int32 CurrHeadFrameId { get; set; }
            public UInt32 LastLoginTime { get; set; }
            public Boolean IsOnline { get; set; }
            public Int32 CurrMedalId { get; set; }
        }

        public List<GetPlayerInfoListResponsePlayerInfo> PlayerInfoList { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class GuildListDetailRequest
    {
        public Int32 GuildId { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class GuildListDetailResponse
    {
        public Int32 Code { get; set; }
        public UInt32 GuildId { get; set; }
        public String GuildName { get; set; }
        public Int32 GuildIconId { get; set; }
        public Int32 GuildLevel { get; set; }
        public Int32 GuildMemberCount { get; set; }
        public Int32 GuildMemberMaxCount { get; set; }
        public Int32 GuildTouristCount { get; set; }
        public Int32 GuildTouristMaxCount { get; set; }
        public Int32 GuildContributeLeft { get; set; }
        public Int32 GuildContributeIn7Days { get; set; }
        public String GuildLeaderName { get; set; }
        public String GuildDeclaration { get; set; }
        public String RankNames { get; set; }
        public Int32 GiftContribute { get; set; }
        public Int32 GiftGuildLevel { get; set; }
        public Int32 GiftLevel { get; set; }
        public List<dynamic> GiftLevelGot { get; set; } = new();
        public Int32 GiftGuildGot { get; set; }
        public Int32 Build { get; set; }
        public Int32 Option { get; set; }
        public Int32 MinLevel { get; set; }
        public Int32 MaintainState { get; set; }
        public Int32 EmergenceTime { get; set; }
        public Int32 TalentPointFromBuild { get; set; }
        public dynamic? Notice { get; set; }
        public Int32 TalentSumLevel { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class GuildMemberDetailResponse
    {
        public Int32 Code { get; set; }
        public UInt32 GuildId { get; set; }
        public Boolean CanImpeach { get; set; }
        public Boolean HasImpeach { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class GuildMemberDetailResponseMembersData
        {
            public UInt32 Id { get; set; }
            public String Name { get; set; }
            public UInt32 HeadPortraitId { get; set; }
            public Int32 HeadFrameId { get; set; }
            public Int32 Level { get; set; }
            public Int32 RankLevel { get; set; }
            public Int32 ContributeIn7Days { get; set; }
            public Int32 ContributeAct { get; set; }
            public Int32 ContributeHistory { get; set; }
            public Int32 Popularity { get; set; }
            public UInt32 LastLoginTime { get; set; }
            public Int32 OnlineFlag { get; set; }
        }

        public List<GuildMemberDetailResponseMembersData> MembersData { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class GuildListApplyResponse
    {
        public Int32 Code { get; set; }
        public List<dynamic> Data { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class GuildListChatResponse
    {
        public Int32 Code { get; set; }
        public List<String> ChatList { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class GuildWarOpenSupportPanelResponse
    {
        public Int32 Code { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class GuildWarOpenSupportPanelResponseSupportDetail
        {
            public Int32 CharacterId { get; set; }
            public Int32 SupportSupply { get; set; }
            public List<dynamic> ToAssistRecords { get; set; } = new();
            public List<dynamic> MyLogs { get; set; } = new();
            public List<dynamic> GetAssistRecords { get; set; } = new();
            public List<dynamic> MyAssistRecords { get; set; } = new();
            public Int32 LastRecvTime { get; set; }
        }

        public GuildWarOpenSupportPanelResponseSupportDetail SupportDetail { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class DoClientTaskEventRequest
    {
        public Int32 ClientTaskType { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class DoClientTaskEventResponse
    {
        public Int32 Code { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class OfflineMessageResponse
    {
        public Int32 Code { get; set; }
        public dynamic? Messages { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class ReconnectRequest
    {
        public String Token { get; set; }
        public UInt32 PlayerId { get; set; }
        public Int32 LastMsgSeqNo { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class ReconnectResponse
    {
        public Int32 Code { get; set; }
        public String ReconnectToken { get; set; }
        public Int32 RequestNo { get; set; }
        public List<Int32> OfflineMessages { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class ScoreQueryResponse
    {
        public Int32 Code { get; set; }
        public Int32 ActivityNo { get; set; }
        public Int32 ChallengeId { get; set; }
        public Double WaveRate { get; set; }
        public Int32 ArenaLevel { get; set; }
        public Int32 ContributeScore { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class ScoreQueryResponseGroupPlayer
        {
            public UInt32 Id { get; set; }
            public String Name { get; set; }
            public UInt32 CurrHeadPortraitId { get; set; }
            public Int32 CurrHeadFrameId { get; set; }
            public UInt32 Point { get; set; }
            public UInt32 LastPointTime { get; set; }
        }

        public List<ScoreQueryResponseGroupPlayer> GroupPlayerList { get; set; } = new();
        [global::MessagePack.MessagePackObject(true)]
        public class ScoreQueryResponseTeamPlayer
        {
            public UInt32 Id { get; set; }
            public String Name { get; set; }
            public UInt32 CurrHeadPortraitId { get; set; }
            public Int32 CurrHeadFrameId { get; set; }
            public Int32 Point { get; set; }
            public Int32 LastPointTime { get; set; }
        }

        public List<ScoreQueryResponseTeamPlayer> TeamPlayerList { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class Ping
    {
        public UInt64 UtcTime { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class Pong
    {
        public UInt64 UtcTime { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class TeamSetTeamRequest
    {
        [global::MessagePack.MessagePackObject(true)]
        public class TeamSetTeamRequestTeamData
        {
            public Int32 TeamId { get; set; }
            public Int32 CaptainPos { get; set; }
            public Dictionary<dynamic, dynamic> TeamData { get; set; }
            public Int32 FirstFightPos { get; set; }
            public String TeamName { get; set; }
        }

        public TeamSetTeamRequestTeamData TeamData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class TeamSetTeamResponse
    {
        public Int32 Code { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class PreFightRequest
    {
        [global::MessagePack.MessagePackObject(true)]
        public class PreFightRequestPreFightData
        {
            public Int32 ChallengeCount { get; set; }
            public UInt32 StageId { get; set; }
            public List<UInt32> CardIds { get; set; } = new();
            public Int32 FirstFightPos { get; set; }
            public Int32 CaptainPos { get; set; }
            public Boolean IsHasAssist { get; set; }
        }

        public PreFightRequestPreFightData PreFightData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class PreFightResponse
    {
        public Int32 Code { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class PreFightResponseFightData
        {
            public Boolean Online { get; set; }
            public UInt32 FightId { get; set; }
            public dynamic? RoomId { get; set; }
            public Int32 OnlineMode { get; set; }
            public UInt32 Seed { get; set; }
            public UInt32 StageId { get; set; }
            public Int32 RebootId { get; set; }
            public Int32 PassTimeLimit { get; set; }
            public Int32 StarsMark { get; set; }
            public List<Int32> MonsterLevel { get; set; } = new();
            public List<dynamic> EventIds { get; set; } = new();
            public dynamic? FightEventsWithLevel { get; set; }
            public List<dynamic> NormalEventIds { get; set; } = new();
            [global::MessagePack.MessagePackObject(true)]
            public class PreFightResponseFightDataRoleData
            {
                public UInt32 Id { get; set; }
                public Int32 Camp { get; set; }
                public String Name { get; set; }
                public Boolean IsRobot { get; set; }
                public Int32 CaptainIndex { get; set; }
                public Int32 FirstFightPos { get; set; }
                public Dictionary<dynamic, dynamic> NpcData { get; set; }
                public dynamic? CustomNpc { get; set; }
                public dynamic? AssistNpcData { get; set; }
            }

            public List<PreFightResponseFightDataRoleData> RoleData { get; set; } = new();
            public Int32 ReviseId { get; set; }
            public Int32 PlayerLevel { get; set; }
            public dynamic? NpcGroupList { get; set; }
            public dynamic? FightControlData { get; set; }
            public Boolean DisableJoystick { get; set; }
            public Boolean Restartable { get; set; }
            public Boolean DisableDeadEffect { get; set; }
            public String CustomData { get; set; }
            public dynamic? Records { get; set; }
            public dynamic? StageParams { get; set; }
            public dynamic? StStageDropData { get; set; }
        }

        public PreFightResponseFightData FightData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyStageData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyStageDataStage
        {
            public UInt32 StageId { get; set; }
            public Int32 StarsMark { get; set; }
            public Boolean Passed { get; set; }
            public Int32 PassTimesToday { get; set; }
            public Int32 PassTimesTotal { get; set; }
            public Int32 BuyCount { get; set; }
            public Int32 Score { get; set; }
            public UInt32 LastPassTime { get; set; }
            public UInt32 RefreshTime { get; set; }
            public UInt32 CreateTime { get; set; }
            public Int32 BestRecordTime { get; set; }
            public Int32 LastRecordTime { get; set; }
            public List<UInt32> BestCardIds { get; set; } = new();
            public List<UInt32> LastCardIds { get; set; } = new();
        }

        public List<NotifyStageDataStage> StageList { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class FightSettleResponse
    {
        public Int32 Code { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class FightSettleResponseSettle
        {
            public Boolean IsWin { get; set; }
            public UInt32 StageId { get; set; }
            public Int32 StarsMark { get; set; }
            public List<dynamic> RewardGoodsList { get; set; } = new();
            public Int32 LeftTime { get; set; }
            public Dictionary<dynamic, dynamic> NpcHpInfo { get; set; }
            public Int32 UrgentEnventId { get; set; }
            public dynamic? ClientAssistInfo { get; set; }
            public List<dynamic> FlopRewardList { get; set; } = new();
            public dynamic? ArenaResult { get; set; }
            public List<Object[]> MultiRewardGoodsList { get; set; } = new();
            public Int32 ChallengeCount { get; set; }
            public dynamic? UnionKillResult { get; set; }
            public dynamic? InfestorBossFightResult { get; set; }
            public dynamic? GuildBossFightResult { get; set; }
            public dynamic? WorldBossFightResult { get; set; }
            public dynamic? BossSingleFightResult { get; set; }
            public dynamic? NieRBossFightResult { get; set; }
            public dynamic? TRPGBossFightResult { get; set; }
            public dynamic? ExpeditionFightResult { get; set; }
            public dynamic? ChessPursuitResult { get; set; }
            public dynamic? StrongholdFightResult { get; set; }
            public dynamic? AreaWarFightResult { get; set; }
            public dynamic? GuildWarFightResult { get; set; }
            public dynamic? ReformFightResult { get; set; }
            public dynamic? KillZoneStageResult { get; set; }
            public dynamic? EpisodeFightResult { get; set; }
            public dynamic? StTargetStageFightResult { get; set; }
            public dynamic? StMapTierDataOperation { get; set; }
            public dynamic? SimulateTrainFightResult { get; set; }
            public dynamic? SuperSmashBrosBattleResult { get; set; }
            public dynamic? SpecialTrainRankFightResult { get; set; }
            public dynamic? DoubleTowerFightResult { get; set; }
            public dynamic? TaikoMasterSettleResult { get; set; }
            public dynamic? MultiDimFightResult { get; set; }
            public dynamic? MoewarParkourSettleResult { get; set; }
            public dynamic? SpecialTrainBreakthroughResult { get; set; }
            public dynamic? TwoSideTowerSettleResult { get; set; }
            public dynamic? BabelTowerSettleResult { get; set; }
        }

        public FightSettleResponseSettle Settle { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class CharacterUpgradeSkillGroupRequest
    {
        public UInt32 SkillGroupId { get; set; }
        public Int32 Count { get; set; }
    }

    [MessagePack.MessagePackObject(true)]
    public class NotifyPrequelUnlockChallengeStages
    {
        public List<dynamic> UnlockChallengeStages { get; set; } = new();
    }

    [global::MessagePack.MessagePackObject(true)]
    public class NotifyCharacterDataList
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyCharacterDataListCharacterData
        {
            public UInt32 Id { get; set; }
            public Int32 Level { get; set; }
            public UInt32 Exp { get; set; }
            public Int32 Quality { get; set; }
            public Int32 InitQuality { get; set; }
            public Int32 Star { get; set; }
            public Int32 Grade { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyCharacterDataListCharacterDataSkill
            {
                public UInt32 Id { get; set; }
                public Int32 Level { get; set; }
            }

            public List<NotifyCharacterDataListCharacterDataSkill> SkillList { get; set; } = new();
            public List<dynamic> EnhanceSkillList { get; set; } = new();
            public UInt32 FashionId { get; set; }
            public Int64 CreateTime { get; set; }
            public Int32 TrustLv { get; set; }
            public Int32 TrustExp { get; set; }
            public Int32 Ability { get; set; }
            public Int32 LiberateLv { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyCharacterDataListCharacterDataCharacterHeadInfo
            {
                public UInt32 HeadFashionId { get; set; }
                public Int32 HeadFashionType { get; set; }
            }

            public NotifyCharacterDataListCharacterDataCharacterHeadInfo CharacterHeadInfo { get; set; }
        }

        public List<NotifyCharacterDataListCharacterData> CharacterDataList { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class CharacterUpgradeSkillGroupResponse
    {
        public Int32 Code { get; set; }
        public Int32 Level { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class GetShopInfoRequest
    {
        public UInt32 Id { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class ItemUseRequest
    {
        public UInt32 Id { get; set; }
        public UInt32 RecycleTime { get; set; }
        public Int32 Count { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class ItemUseResponse
    {
        public Int32 Code { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class ItemUseResponseRewardGoods
        {
            public Int32 RewardType { get; set; }
            public Int32 TemplateId { get; set; }
            public UInt32 Count { get; set; }
            public Int32 Level { get; set; }
            public Int32 Quality { get; set; }
            public Int32 Grade { get; set; }
            public Int32 Breakthrough { get; set; }
            public Int32 ConvertFrom { get; set; }
            public UInt32 Id { get; set; }
        }

        public List<ItemUseResponseRewardGoods> RewardGoodsList { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyPlayerLevel
    {
        public Int32 Level { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyArchiveEquip
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyArchiveEquipEquip
        {
            public UInt32 Id { get; set; }
            public Int32 Level { get; set; }
            public Int32 Breakthrough { get; set; }
            public Int32 ResonanceCount { get; set; }
        }

        public List<NotifyArchiveEquipEquip> Equips { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyArchiveMonsterRecord
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyArchiveMonsterRecordMonster
        {
            public UInt32 Id { get; set; }
            public UInt32 Killed { get; set; }
        }

        public List<NotifyArchiveMonsterRecordMonster> Monsters { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyEquipDataList
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyEquipDataListEquipData
        {
            public UInt32 Id { get; set; }
            public UInt32 TemplateId { get; set; }
            public Int32 CharacterId { get; set; }
            public Int32 Level { get; set; }
            public Int32 Exp { get; set; }
            public Int32 Breakthrough { get; set; }
            public List<dynamic> ResonanceInfo { get; set; } = new();
            public List<dynamic> UnconfirmedResonanceInfo { get; set; } = new();
            public List<dynamic> AwakeSlotList { get; set; } = new();
            public Boolean IsLock { get; set; }
            public UInt32 CreateTime { get; set; }
            public Boolean IsRecycle { get; set; }
        }

        public List<NotifyEquipDataListEquipData> EquipDataList { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class GetVoteGroupListResponse
    {
        [global::MessagePack.MessagePackObject(true)]
        public class GetVoteGroupListResponseVoteGroup
        {
            public Int32 Id { get; set; }
            public Int32 TimeToClose { get; set; }
            public Dictionary<dynamic, dynamic> VoteDic { get; set; }
        }

        public List<GetVoteGroupListResponseVoteGroup> VoteGroupList { get; set; } = new();
    }


    [global::MessagePack.MessagePackObject(true)]
    public class GetShopInfoResponse
    {
        public Int32 Code { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class GetShopInfoResponseClientShop
        {
            public UInt32 Id { get; set; }
            public String Name { get; set; }
            public Int32 RefreshTime { get; set; }
            public Int32 ClosedTime { get; set; }
            public Int32 ManualRefreshTimes { get; set; }
            public Int32 ManualResetTimesLimit { get; set; }
            public Int32 RefreshCostId { get; set; }
            public Int32 RefreshCostCount { get; set; }
            public Int32 TotalBuyTimes { get; set; }
            public Int32 BuyTimesLimit { get; set; }
            public List<Int32> ShowIds { get; set; } = new();
            [global::MessagePack.MessagePackObject(true)]
            public class GetShopInfoResponseClientShopGoods
            {
                public UInt32 Id { get; set; }
                public UInt32 Priority { get; set; }
                [global::MessagePack.MessagePackObject(true)]
                public class GetShopInfoResponseClientShopGoodsRewardGoods
                {
                    public Int32 RewardType { get; set; }
                    public UInt32 TemplateId { get; set; }
                    public Int32 Count { get; set; }
                    public Int32 Level { get; set; }
                    public Int32 Quality { get; set; }
                    public Int32 Grade { get; set; }
                    public Int32 Breakthrough { get; set; }
                    public Int32 ConvertFrom { get; set; }
                    public Int32 Id { get; set; }
                }

                public GetShopInfoResponseClientShopGoodsRewardGoods RewardGoods { get; set; }
                [global::MessagePack.MessagePackObject(true)]
                public class GetShopInfoResponseClientShopGoodsConsume
                {
                    public Int32 Id { get; set; }
                    public UInt32 Count { get; set; }
                }

                public List<GetShopInfoResponseClientShopGoodsConsume> ConsumeList { get; set; } = new();
                public Int32 TotalBuyTimes { get; set; }
                public Int32 BuyTimesLimit { get; set; }
                public dynamic? OnSales { get; set; }
                public Int32 OnSaleTime { get; set; }
                public Int32 SelloutTime { get; set; }
                public Int32 RefreshTime { get; set; }
                public Int32 Tags { get; set; }
                public dynamic? PayKeySuffix { get; set; }
                public List<dynamic> ConditionIds { get; set; } = new();
                public Int32 GiftRewardId { get; set; }
                public Int32 AutoResetClockId { get; set; }
            }

            public List<GetShopInfoResponseClientShopGoods> GoodsList { get; set; } = new();
            public List<Int32> ScreenGroupList { get; set; } = new();
            public List<dynamic> ConditionIds { get; set; } = new();
            public dynamic? RefreshTips { get; set; }
        }

        public GetShopInfoResponseClientShop ClientShop { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyMails
    {
        [MessagePack.MessagePackObject(true)]
        public class NotifyMailsNewMailList
        {
            public string Id { get; set; }
            public int GroupId { get; set; }
            public dynamic? BatchId { get; set; }
            public int Type { get; set; }
            public int Status { get; set; }
            public string SendName { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public uint CreateTime { get; set; }
            public uint SendTime { get; set; }
            public uint ExpireTime { get; set; }
            [MessagePack.MessagePackObject(true)]
            public class NotifyMailsNewMailListRewardGoodsList
            {
                public int RewardType { get; set; }
                public uint TemplateId { get; set; }
                public int Count { get; set; }
                public int Level { get; set; }
                public int Quality { get; set; }
                public int Grade { get; set; }
                public int Breakthrough { get; set; }
                public int ConvertFrom { get; set; }
                public int Id { get; set; }
            }

            public List<NotifyMailsNewMailListRewardGoodsList> RewardGoodsList { get; set; } = new();
            public bool IsForbidDelete { get; set; }
        }

        public List<NotifyMailsNewMailList> NewMailList { get; set; } = new();
        public dynamic? ExpireIdList { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyMaintainerActionDailyReset
    {
        public int UsedActionCount { get; set; }
        public int ExtraActionCount { get; set; }
    }

}
