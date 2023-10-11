#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace AscNet.Common.MsgPack
{
    [global::MessagePack.MessagePackObject(true)]
    public class HandshakeRequest
    {
        public String Sha1 { get; set; }
        public String DocumentVersion { get; set; }
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
        public Int32 LoginType { get; set; }
        public String ServerBean { get; set; }
        public Int32 LoginPlatform { get; set; }
        public String ClientVersion { get; set; }
        public String DeviceId { get; set; }
        public Int32 UserId { get; set; }
        public String Token { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class LoginResponse
    {
        public Int32 Code { get; set; }
        public Int32 UtcOffset { get; set; }
        public UInt32 UtcServerTime { get; set; }
        public String ReconnectToken { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyDailyLotteryData
    {
        public dynamic[] Lotteries { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyLogin
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyLoginPlayerData
        {
            public UInt32 Id { get; set; }
            public String Name { get; set; }
            public Int32 Level { get; set; }
            public String Sign { get; set; }
            public UInt32 DisplayCharId { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyLoginPlayerDataBirthday
            {
                public Int32 Mon { get; set; }
                public Int32 Day { get; set; }
            }

            public NotifyLoginPlayerDataBirthday Birthday { get; set; }
            public Int32 HonorLevel { get; set; }
            public String ServerId { get; set; }
            public Int32 Likes { get; set; }
            public Int32 CurrTeamId { get; set; }
            public Int32 ChallengeEventId { get; set; }
            public UInt32 CurrHeadPortraitId { get; set; }
            public Int32 CurrHeadFrameId { get; set; }
            public Int32 CurrMedalId { get; set; }
            public Int32 AppearanceShowType { get; set; }
            public Int32 DailyReceiveGiftCount { get; set; }
            public Int32 DailyActivenessRewardStatus { get; set; }
            public Int32 WeeklyActivenessRewardStatus { get; set; }
            public Int32[] Marks { get; set; }
            public UInt32[] GuideData { get; set; }
            public Int32[] Communications { get; set; }
            public dynamic[] ShowCharacters { get; set; }
            public dynamic[] ShieldFuncList { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyLoginPlayerDataAppearanceSettingInfo
            {
                public Int32 TitleType { get; set; }
                public Int32 CharacterType { get; set; }
                public Int32 FashionType { get; set; }
                public Int32 WeaponFashionType { get; set; }
                public Int32 DormitoryType { get; set; }
                public Int32 DormitoryId { get; set; }
            }

            public NotifyLoginPlayerDataAppearanceSettingInfo AppearanceSettingInfo { get; set; }
            public UInt32 CreateTime { get; set; }
            public UInt32 LastLoginTime { get; set; }
            public Int32 ReportTime { get; set; }
            public UInt32 ChangeNameTime { get; set; }
            public Int32 Flags { get; set; }
        }

        public NotifyLoginPlayerData PlayerData { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyLoginTimeLimitCtrlConfigList
        {
            public Int32 Id { get; set; }
            public UInt32 StartTime { get; set; }
            public UInt32 EndTime { get; set; }
        }

        public NotifyLoginTimeLimitCtrlConfigList[] TimeLimitCtrlConfigList { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyLoginSharePlatformConfigList
        {
            public Int32 Id { get; set; }
            public Int32[] SdkId { get; set; }
        }

        public NotifyLoginSharePlatformConfigList[] SharePlatformConfigList { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyLoginItemList
        {
            public Int32 Id { get; set; }
            public UInt32 Count { get; set; }
            public Int32 BuyTimes { get; set; }
            public Int32 TotalBuyTimes { get; set; }
            public Int32 LastBuyTime { get; set; }
            public UInt32 RefreshTime { get; set; }
            public UInt32 CreateTime { get; set; }
        }

        public NotifyLoginItemList[] ItemList { get; set; }
        public Dictionary<dynamic, dynamic> ItemRecycleDict { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyLoginCharacterList
        {
            public UInt32 Id { get; set; }
            public Int32 Level { get; set; }
            public Int32 Exp { get; set; }
            public Int32 Quality { get; set; }
            public Int32 InitQuality { get; set; }
            public Int32 Star { get; set; }
            public Int32 Grade { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyLoginCharacterListSkillList
            {
                public UInt32 Id { get; set; }
                public Int32 Level { get; set; }
            }

            public NotifyLoginCharacterListSkillList[] SkillList { get; set; }
            public dynamic[] EnhanceSkillList { get; set; }
            public UInt32 FashionId { get; set; }
            public UInt32 CreateTime { get; set; }
            public Int32 TrustLv { get; set; }
            public Int32 TrustExp { get; set; }
            public UInt32 Ability { get; set; }
            public Int32 LiberateLv { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyLoginCharacterListCharacterHeadInfo
            {
                public Int32 HeadFashionId { get; set; }
                public Int32 HeadFashionType { get; set; }
            }

            public NotifyLoginCharacterListCharacterHeadInfo CharacterHeadInfo { get; set; }
        }

        public NotifyLoginCharacterList[] CharacterList { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyLoginEquipList
        {
            public Int32 Id { get; set; }
            public UInt32 TemplateId { get; set; }
            public UInt32 CharacterId { get; set; }
            public Int32 Level { get; set; }
            public Int32 Exp { get; set; }
            public Int32 Breakthrough { get; set; }
            public dynamic[] ResonanceInfo { get; set; }
            public dynamic[] UnconfirmedResonanceInfo { get; set; }
            public dynamic[] AwakeSlotList { get; set; }
            public Boolean IsLock { get; set; }
            public UInt32 CreateTime { get; set; }
            public Boolean IsRecycle { get; set; }
        }

        public NotifyLoginEquipList[] EquipList { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyLoginFashionList
        {
            public UInt32 Id { get; set; }
            public Boolean IsLock { get; set; }
        }

        public NotifyLoginFashionList[] FashionList { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyLoginHeadPortraitList
        {
            public UInt32 Id { get; set; }
            public Int32 LeftCount { get; set; }
            public UInt32 BeginTime { get; set; }
        }

        public NotifyLoginHeadPortraitList[] HeadPortraitList { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyLoginBaseEquipLoginData
        {
            public dynamic[] BaseEquipList { get; set; }
            public dynamic[] DressedList { get; set; }
        }

        public NotifyLoginBaseEquipLoginData BaseEquipLoginData { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyLoginFubenData
        {
            public Dictionary<dynamic, dynamic> StageData { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyLoginFubenDataFubenBaseData
            {
                public Int32 RefreshTime { get; set; }
                public Int32 SelectedCharId { get; set; }
                public Int32 UrgentAlarmCount { get; set; }
                public Int32 WeeklyUrgentCount { get; set; }
                public dynamic? DayUrgentCount { get; set; }
            }

            public NotifyLoginFubenDataFubenBaseData FubenBaseData { get; set; }
            public dynamic[] UnlockHideStages { get; set; }
            public dynamic[] StageDifficulties { get; set; }
        }

        public NotifyLoginFubenData FubenData { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyLoginFubenMainLineData
        {
            public UInt32[] TreasureData { get; set; }
            public Dictionary<dynamic, dynamic> LastPassStage { get; set; }
            public dynamic[] MainChapterEventInfos { get; set; }
        }

        public NotifyLoginFubenMainLineData FubenMainLineData { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyLoginFubenChapterExtraLoginData
        {
            public dynamic[] TreasureData { get; set; }
            public dynamic[] LastPassStage { get; set; }
            public dynamic[] ChapterEventInfos { get; set; }
        }

        public NotifyLoginFubenChapterExtraLoginData FubenChapterExtraLoginData { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyLoginFubenUrgentEventData
        {
            public dynamic? UrgentEventData { get; set; }
        }

        public NotifyLoginFubenUrgentEventData FubenUrgentEventData { get; set; }
        public dynamic[] AutoFightRecords { get; set; }
        public Dictionary<dynamic, dynamic> TeamGroupData { get; set; }
        public dynamic? TeamPrefabData { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyLoginSignInf
        {
            public Int32 Id { get; set; }
            public Int32 Round { get; set; }
            public Int32 Day { get; set; }
            public Boolean Got { get; set; }
            public Int32 FinishDay { get; set; }
        }

        public NotifyLoginSignInf[] SignInfos { get; set; }
        public dynamic[] AssignChapterRecord { get; set; }
        public dynamic[] WeaponFashionList { get; set; }
        public dynamic[] PartnerList { get; set; }
        public dynamic[] ShieldedProtocolList { get; set; }
        public dynamic? LimitedLoginData { get; set; }
        public UInt32 UseBackgroundId { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyLoginFubenShortStoryLoginData
        {
            public dynamic[] TreasureData { get; set; }
            public dynamic[] LastPassStage { get; set; }
            public dynamic[] ChapterEventInfos { get; set; }
        }

        public NotifyLoginFubenShortStoryLoginData FubenShortStoryLoginData { get; set; }
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
        public dynamic[] ChipGroupDataList { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyEquipChipAutoRecycleSite
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyEquipChipAutoRecycleSiteChipRecycleSite
        {
            public Int32[] RecycleStar { get; set; }
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
            public dynamic[] PutOnPosList { get; set; }
            public dynamic[] FinishedTargets { get; set; }
        }

        public NotifyEquipGuideDataEquipGuideData EquipGuideData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyArchiveLoginData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyArchiveLoginDataMonste
        {
            public UInt32 Id { get; set; }
            public Int32 Killed { get; set; }
        }

        public NotifyArchiveLoginDataMonste[] Monsters { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyArchiveLoginDataEqui
        {
            public UInt32 Id { get; set; }
            public Int32 Level { get; set; }
            public Int32 Breakthrough { get; set; }
            public Int32 ResonanceCount { get; set; }
        }

        public NotifyArchiveLoginDataEqui[] Equips { get; set; }
        public dynamic[] MonsterUnlockIds { get; set; }
        public dynamic[] WeaponUnlockIds { get; set; }
        public dynamic[] AwarenessUnlockIds { get; set; }
        public dynamic[] MonsterSettings { get; set; }
        public dynamic[] WeaponSettings { get; set; }
        public dynamic[] AwarenessSettings { get; set; }
        public dynamic[] MonsterInfos { get; set; }
        public dynamic[] MonsterSkills { get; set; }
        public UInt32[] UnlockCgs { get; set; }
        public dynamic[] UnlockStoryDetails { get; set; }
        public dynamic[] PartnerUnlockIds { get; set; }
        public dynamic[] PartnerSettings { get; set; }
        public UInt32[] UnlockPvDetails { get; set; }
        public dynamic[] UnlockMails { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyChatLoginData
    {
        public UInt32 RefreshTime { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyChatLoginDataUnlockEmoj
        {
            public UInt32 Id { get; set; }
            public Int32 EndTime { get; set; }
        }

        public NotifyChatLoginDataUnlockEmoj[] UnlockEmojis { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifySocialData
    {
        public dynamic[] FriendData { get; set; }
        public dynamic[] ApplyData { get; set; }
        public dynamic[] Remarks { get; set; }
        public dynamic[] BlockData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyTaskData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyTaskDataTaskData
        {
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyTaskDataTaskDataTas
            {
                public UInt32 Id { get; set; }
                [global::MessagePack.MessagePackObject(true)]
                public class NotifyTaskDataTaskDataTasSchedule
                {
                    public UInt32 Id { get; set; }
                    public Int32 Value { get; set; }
                }

                public NotifyTaskDataTaskDataTasSchedule[] Schedule { get; set; }
                public Int32 State { get; set; }
                public UInt32 RecordTime { get; set; }
                public Int32 ActivityId { get; set; }
            }

            public NotifyTaskDataTaskDataTas[] Tasks { get; set; }
            public UInt32[] Course { get; set; }
            public Int32[] FinishedTasks { get; set; }
            public Int32[] NewPlayerRewardRecord { get; set; }
            public dynamic[] TaskLimitIdActiveInfos { get; set; }
            public dynamic[] NewbieRecvProgress { get; set; }
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
        public UInt32 NewPlayerTaskActiveDay { get; set; }
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
                public Int32 BeginTime { get; set; }
                public Int32 State { get; set; }
            }

            public NotifyRegression2DataDataActivityData ActivityData { get; set; }
            public dynamic? SignInData { get; set; }
            public dynamic? InviteData { get; set; }
            public dynamic[] GachaDatas { get; set; }
        }

        public NotifyRegression2DataData Data { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyMaintainerActionData
    {
        public Int32 Id { get; set; }
        public UInt32 ResetTime { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyMaintainerActionDataNod
        {
            public Int32 NodeId { get; set; }
            public Int32 NodeType { get; set; }
            public Int32 EventId { get; set; }
            public String Value { get; set; }
        }

        public NotifyMaintainerActionDataNod[] Nodes { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyMaintainerActionDataPlaye
        {
            public UInt32 PlayerId { get; set; }
            public String PlayerName { get; set; }
            public UInt32 HeadPortraitId { get; set; }
            public Int32 HeadFrameId { get; set; }
            public Int32 NodeId { get; set; }
            public Boolean IsNodeTriggered { get; set; }
            public Boolean Reverse { get; set; }
        }

        public NotifyMaintainerActionDataPlaye[] Players { get; set; }
        public Int32[] Cards { get; set; }
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
        public dynamic[] Envelopes { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyScoreTitleData
    {
        public dynamic[] TitleInfos { get; set; }
        public dynamic[] HideTypes { get; set; }
        public Boolean IsHideCollection { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyScoreTitleDataWallInf
        {
            public Int32 Id { get; set; }
            public UInt32 PedestalId { get; set; }
            public UInt32 BackgroundId { get; set; }
            public Boolean IsShow { get; set; }
            public dynamic[] CollectionSetInfos { get; set; }
        }

        public NotifyScoreTitleDataWallInf[] WallInfos { get; set; }
        public UInt16[] UnlockedDecorationIds { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyBfrtData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyBfrtDataBfrtData
        {
            public dynamic[] BfrtGroupRecords { get; set; }
            public dynamic[] BfrtTeamInfos { get; set; }
        }

        public NotifyBfrtDataBfrtData BfrtData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyTask
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyTaskTasks
        {
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyTaskTasksTas
            {
                public UInt32 Id { get; set; }
                [global::MessagePack.MessagePackObject(true)]
                public class NotifyTaskTasksTasSchedule
                {
                    public UInt32 Id { get; set; }
                    public Int32 Value { get; set; }
                }

                public NotifyTaskTasksTasSchedule[] Schedule { get; set; }
                public Int32 State { get; set; }
                public UInt32 RecordTime { get; set; }
                public Int32 ActivityId { get; set; }
            }

            public NotifyTaskTasksTas[] Tasks { get; set; }
        }

        public NotifyTaskTasks Tasks { get; set; }
        public dynamic? TaskLimitIdActiveInfos { get; set; }
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
        public dynamic[] FurnitureCreateList { get; set; }
        public dynamic[] WorkList { get; set; }
        public UInt32[] FurnitureUnlockList { get; set; }
        public Int32 SnapshotTimes { get; set; }
        public dynamic[] DormitoryList { get; set; }
        public dynamic[] VisitorList { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyDormitoryDataFurnitureList
        {
            public Int32 Id { get; set; }
            public UInt32 ConfigId { get; set; }
            public Int32 X { get; set; }
            public Int32 Y { get; set; }
            public Int32 Angle { get; set; }
            public Int32 DormitoryId { get; set; }
            public UInt32 Addition { get; set; }
            public Int32[] AttrList { get; set; }
            public Boolean IsLocked { get; set; }
        }

        public NotifyDormitoryDataFurnitureList[] FurnitureList { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyDormitoryDataCharacterList
        {
            public UInt32 CharacterId { get; set; }
            public SByte DormitoryId { get; set; }
            public Int32 Mood { get; set; }
            public Int32 Vitality { get; set; }
            public Int32 MoodSpeed { get; set; }
            public Int32 VitalitySpeed { get; set; }
            public UInt32 LastFondleRecoveryTime { get; set; }
            public Int32 LeftFondleCount { get; set; }
            public dynamic[] EventList { get; set; }
        }

        public NotifyDormitoryDataCharacterList[] CharacterList { get; set; }
        public dynamic[] Layouts { get; set; }
        public dynamic[] BindRelations { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyNameplateLoginData
    {
        public Int32 CurrentWearNameplate { get; set; }
        public dynamic[] UnlockNameplates { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyGuildDormPlayerData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyGuildDormPlayerDataGuildDormData
        {
            public Int32 CurrentCharacterId { get; set; }
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
            public dynamic[] TaskCards { get; set; }
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

            public NotifyBountyTaskInfoTaskInfoTaskPool[] TaskPool { get; set; }
        }

        public NotifyBountyTaskInfoTaskInfo TaskInfo { get; set; }
        public UInt32 RefreshTime { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyFiveTwentyRecord
    {
        public dynamic[] CharacterIds { get; set; }
        public dynamic[] GroupRecord { get; set; }
        public Int32 ActivityNo { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class PurchaseDailyNotify
    {
        public dynamic[] ExpireInfoList { get; set; }
        public dynamic[] DailyRewardInfoList { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class PurchaseDailyNotifyFreeRewardInfoList
        {
            public UInt32 Id { get; set; }
            public String Name { get; set; }
        }

        public PurchaseDailyNotifyFreeRewardInfoList[] FreeRewardInfoList { get; set; }
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
        public UInt32[] HaveBackgroundIds { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyMedalData
    {
        public dynamic[] MedalInfos { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyExploreData
    {
        public dynamic[] ChapterDatas { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyGatherRewardList
    {
        public Int32[] GatherRewards { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyDrawTicketData
    {
        public dynamic[] DrawTicketInfos { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyAccumulatedPayData
    {
        public Int32 PayId { get; set; }
        public Single PayMoney { get; set; }
        public dynamic[] PayRewardIds { get; set; }
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
        public dynamic[] MaxPointStageList { get; set; }
        public Int32 ContributeScore { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyPrequelUnlockChallengeStages
    {
        public dynamic[] UnlockChallengeStages { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyPrequelChallengeRefreshTime
    {
        public UInt32 NextRefreshTime { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyFubenPrequelData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyFubenPrequelDataFubenPrequelData
        {
            public dynamic[] RewardedStages { get; set; }
            public dynamic[] UnlockChallengeStages { get; set; }
        }

        public NotifyFubenPrequelDataFubenPrequelData FubenPrequelData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyMainLineActivity
    {
        public UInt16[] Chapters { get; set; }
        public Int32 BfrtChapter { get; set; }
        public UInt32 EndTime { get; set; }
        public Int32 HideChapterBeginTime { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyDailyFubenLoginData
    {
        public UInt32 RefreshTime { get; set; }
        public dynamic[] Records { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyBirthdayPlot
    {
        public UInt32 NextActiveYear { get; set; }
        public Int32 IsChange { get; set; }
        public dynamic[] UnLockCg { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyBossActivityData
    {
        public Int32 ActivityId { get; set; }
        public Int32 SectionId { get; set; }
        public Int32 Schedule { get; set; }
        public dynamic[] StageStarInfos { get; set; }
        public dynamic[] StarRewardIds { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyBriefStoryData
    {
        public dynamic[] FinishedIds { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyChessPursuitGroupInfo
    {
        public dynamic[] MapDBList { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyChessPursuitGroupInfoMapBossList
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

        public NotifyChessPursuitGroupInfoMapBossList[] MapBossList { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyClickClearData
    {
        public dynamic[] Activities { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyCourseData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyCourseDataData
        {
            public Int32 TotalLessonPoint { get; set; }
            public Int32 MaxTotalLessonPoint { get; set; }
            public dynamic[] ChapterDataList { get; set; }
            public dynamic? StageDataDict { get; set; }
            public dynamic[] RewardIds { get; set; }
        }

        public NotifyCourseDataData Data { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyActivityDrawList
    {
        public UInt16[] DrawIdList { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyActivityDrawGroupCount
    {
        public Int32 Count { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyExperimentData
    {
        public dynamic[] FinishIds { get; set; }
        public dynamic[] ExperimentInfos { get; set; }
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
        public dynamic[] StageDatas { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyBabelTowerDataExtraData
        {
            public Int32 ActivityNo { get; set; }
            public Int32 MaxScore { get; set; }
            public Int32 RankLevel { get; set; }
            public dynamic[] StageDatas { get; set; }
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
            public dynamic[] HistoryList { get; set; }
            public dynamic[] RewardIds { get; set; }
            public Int32 RankPlatform { get; set; }
            public Int32[] BossList { get; set; }
            public dynamic[] TrialStageInfoList { get; set; }
        }

        public NotifyFubenBossSingleDataFubenBossSingleData FubenBossSingleData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyFestivalData
    {
        public dynamic[] FestivalInfos { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyPracticeData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyPracticeDataChapterInf
        {
            public Int32 Id { get; set; }
            public UInt32[] FinishStages { get; set; }
        }

        public NotifyPracticeDataChapterInf[] ChapterInfos { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyTrialData
    {
        public Int32[] FinishTrial { get; set; }
        public Int32[] RewardRecord { get; set; }
        public dynamic[] TypeRewardRecord { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyPivotCombatData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyPivotCombatDataPivotCombatData
        {
            public Int32 ActivityId { get; set; }
            public Int32 Difficulty { get; set; }
            public dynamic[] RegionDataList { get; set; }
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
        public dynamic[] RcChapters { get; set; }
        public dynamic[] RewardIds { get; set; }
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
        public class NotifyReviewConfigReviewActivityConfigList
        {
            public Int32 Id { get; set; }
            public UInt32 StartTime { get; set; }
            public UInt32 EndTime { get; set; }
            public UInt32 RewardId { get; set; }
        }

        public NotifyReviewConfigReviewActivityConfigList[] ReviewActivityConfigList { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyStrongholdLoginData
    {
        public Int32 Id { get; set; }
        public UInt32 BeginTime { get; set; }
        public UInt32 FightBeginTime { get; set; }
        public Int32 CurDay { get; set; }
        public Int32 AssistCharacterId { get; set; }
        public Int32 SetAssistCharacterTime { get; set; }
        public Int32 BorrowCount { get; set; }
        public UInt32 ElectricEnergy { get; set; }
        public Int32 Endurance { get; set; }
        public Int32 MineralLeft { get; set; }
        public Int32 TotalMineral { get; set; }
        public dynamic[] ElectricCharacterIds { get; set; }
        public dynamic[] FinishGroupIds { get; set; }
        public dynamic[] FinishGroupInfos { get; set; }
        public dynamic[] HistoryFinishGroupInfos { get; set; }
        public dynamic[] GroupInfos { get; set; }
        public dynamic[] TeamInfos { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyStrongholdLoginDataGroupStageDat
        {
            public Int32 Id { get; set; }
            public UInt32[] StageIds { get; set; }
            public Dictionary<dynamic, dynamic> StageBuffId { get; set; }
            public Int32 SupportId { get; set; }
        }

        public NotifyStrongholdLoginDataGroupStageDat[] GroupStageDatas { get; set; }
        public Int32[] RuneList { get; set; }
        public dynamic[] RewardIds { get; set; }
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
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyStrongholdLoginDataMineRecor
        {
            public Int32 Day { get; set; }
            public Int32 MinerCount { get; set; }
            public Int32 MineralCount { get; set; }
            public Boolean IsStay { get; set; }
        }

        public NotifyStrongholdLoginDataMineRecor[] MineRecords { get; set; }
        public Int32 LevelId { get; set; }
        public dynamic[] StayDays { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifySummerSignInData
    {
        public Int32 ActId { get; set; }
        public dynamic[] MsgIdList { get; set; }
        public Int32 SurplusTimes { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyTaikoMasterData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyTaikoMasterDataTaikoMasterData
        {
            public Int32 ActivityId { get; set; }
            public dynamic[] StageDataList { get; set; }
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
        public dynamic[] ActivityInfo { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyTheatreData
    {
        public Int32 CurChapterId { get; set; }
        public Int32 CurRoleLv { get; set; }
        public Int32 DifficultyId { get; set; }
        public Int32 KeepsakeId { get; set; }
        public dynamic[] UnlockPowerIds { get; set; }
        public dynamic[] UnlockPowerFavorIds { get; set; }
        public dynamic[] EffectPowerFavorIds { get; set; }
        public dynamic[] Skills { get; set; }
        public dynamic[] RecruitRole { get; set; }
        public dynamic[] Keepsakes { get; set; }
        public dynamic[] Decorations { get; set; }
        public dynamic? CurChapterDb { get; set; }
        public Int32 ReopenCount { get; set; }
        public dynamic[] SkillIllustratedBook { get; set; }
        public dynamic? SingleTeamData { get; set; }
        public dynamic[] MultiTeamDatas { get; set; }
        public Int32 UseOwnCharacter { get; set; }
        public Int32 FavorCoin { get; set; }
        public Int32 DecorationCoin { get; set; }
        public dynamic[] PassChapterId { get; set; }
        public dynamic? PassEventRecord { get; set; }
        public Int32 PassNodeCount { get; set; }
        public dynamic[] EndingRecord { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyVoteData
    {
        public dynamic[] VoteAlarmDic { get; set; }
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
            public dynamic[] PhasesRewardList { get; set; }
        }

        public NotifyTRPGDataBossInfo BossInfo { get; set; }
        public dynamic[] TargetList { get; set; }
        public dynamic[] RewardList { get; set; }
        public dynamic[] FuncList { get; set; }
        public dynamic[] Characters { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyTRPGDataShopInf
        {
            public Int32 DisCount { get; set; }
            public Int32 AddBuyCount { get; set; }
            public UInt32 Id { get; set; }
            public dynamic[] ItemInfos { get; set; }
        }

        public NotifyTRPGDataShopInf[] ShopInfos { get; set; }
        public dynamic[] MazeInfos { get; set; }
        public dynamic[] MemoirList { get; set; }
        public Int32 ItemCapacityAdd { get; set; }
        public Boolean IsNormalPage { get; set; }
        public dynamic[] StageList { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyBiancaTheatreActivityData
    {
        public Int32 CurActivityId { get; set; }
        public Int32 CurChapterId { get; set; }
        public Int32 DifficultyId { get; set; }
        public Int32 CurTeamId { get; set; }
        public dynamic? CurChapterDb { get; set; }
        public dynamic[] Characters { get; set; }
        public dynamic[] Items { get; set; }
        public Int32 TotalExp { get; set; }
        public dynamic[] GetRewardIds { get; set; }
        public dynamic[] StrengthenDbs { get; set; }
        public dynamic? SingleTeamData { get; set; }
        public dynamic[] UnlockItemId { get; set; }
        public dynamic[] UnlockTeamId { get; set; }
        public dynamic[] UnlockDifficultyId { get; set; }
        public dynamic[] TeamRecords { get; set; }
        public dynamic[] PassChapterIds { get; set; }
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
        public class NotifyMentorDataStuden
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
            public dynamic[] StudentTask { get; set; }
            public Boolean IsOnline { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyMentorDataStudenSystemTask
            {
                public UInt32 TaskId { get; set; }
                public Int32 State { get; set; }
                public dynamic[] Schedule { get; set; }
                public Int32 Status { get; set; }
                public Int32 RewardId { get; set; }
                public dynamic[] EquipList { get; set; }
                public Boolean HasChange { get; set; }
            }

            public NotifyMentorDataStudenSystemTask[] SystemTask { get; set; }
            public dynamic[] WeeklyTask { get; set; }
            public Int32 KizunaAmount { get; set; }
            public Int32 JoinTime { get; set; }
            public Int32 ReachTime { get; set; }
            public Int32 LastLoginTime { get; set; }
            public Int32 SendGiftCount { get; set; }
        }

        public NotifyMentorDataStuden[] Students { get; set; }
        public dynamic[] ApplyList { get; set; }
        public Int32 GraduateStudentCount { get; set; }
        public dynamic[] StageReward { get; set; }
        public dynamic[] WeeklyTaskReward { get; set; }
        public Int32 WeeklyTaskCompleteCount { get; set; }
        public Int32[] Tag { get; set; }
        public Int32[] OnlineTag { get; set; }
        public String Announcement { get; set; }
        public Int32 DailyChangeTaskCount { get; set; }
        public Int32 WeeklyLevel { get; set; }
        public Int32 MonthlyStudentCount { get; set; }
        public dynamic? Message { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyMentorChat
    {
        public dynamic[] ChatMessages { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyMaintainerActionDailyReset
    {
        public Int32 UsedActionCount { get; set; }
        public Int32 ExtraActionCount { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyGuildData
    {
        public Int32 GuildId { get; set; }
        public String GuildName { get; set; }
        public Int32 GuildLevel { get; set; }
        public Int32 IconId { get; set; }
        public Int32 GuildRankLevel { get; set; }
        public Int32 HasContributeReward { get; set; }
        public Boolean HasRecruit { get; set; }
        public Int32 BossEndTime { get; set; }
        public Int32 FreeChangeGuildNameCount { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyMails
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyMailsNewMailList
        {
            public String Id { get; set; }
            public Int32 GroupId { get; set; }
            public dynamic? BatchId { get; set; }
            public Int32 Type { get; set; }
            public Int32 Status { get; set; }
            public String SendName { get; set; }
            public String Title { get; set; }
            public String Content { get; set; }
            public UInt32 CreateTime { get; set; }
            public UInt32 SendTime { get; set; }
            public UInt32 ExpireTime { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyMailsNewMailListRewardGoodsList
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

            public NotifyMailsNewMailListRewardGoodsList[] RewardGoodsList { get; set; }
            public Boolean IsForbidDelete { get; set; }
        }

        public NotifyMailsNewMailList[] NewMailList { get; set; }
        public dynamic? ExpireIdList { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class EnterWorldChatResponse
    {
        public Int32 Code { get; set; }
        public Int32 ChannelId { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class GetWorldChannelInfoResponse
    {
        public Int32 Code { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class GetWorldChannelInfoResponseChannelInf
        {
            public Int32 ChannelId { get; set; }
            public Int32 PlayerNum { get; set; }
        }

        public GetWorldChannelInfoResponseChannelInf[] ChannelInfos { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class HeartbeatResponse
    {
        public UInt32 UtcServerTime { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class GetPurchaseListRequest
    {
        public Int32[] UiTypeList { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class GetPurchaseListResponse
    {
        public Int32 Code { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class GetPurchaseListResponsePurchaseInfoList
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
            public class GetPurchaseListResponsePurchaseInfoListRewardGoodsList
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

            public GetPurchaseListResponsePurchaseInfoListRewardGoodsList[] RewardGoodsList { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class GetPurchaseListResponsePurchaseInfoListDailyRewardGoodsList
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

            public GetPurchaseListResponsePurchaseInfoListDailyRewardGoodsList[] DailyRewardGoodsList { get; set; }
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
            public class GetPurchaseListResponsePurchaseInfoListClientResetInfo
            {
                public Int32 ResetType { get; set; }
                public Int32 DayCount { get; set; }
            }

            public GetPurchaseListResponsePurchaseInfoListClientResetInfo ClientResetInfo { get; set; }
            public Boolean IsUseMail { get; set; }
            public dynamic? NormalDiscounts { get; set; }
            public dynamic? DiscountCouponInfos { get; set; }
            public dynamic? DiscountShowStr { get; set; }
            public Int32 LastBuyTime { get; set; }
            public Int32 MailCount { get; set; }
            public dynamic? PayKeySuffix { get; set; }
            public UInt32[] MutexPurchaseIds { get; set; }
            public Int32 ConvertSwitch { get; set; }
            public Boolean CanMultiply { get; set; }
            public dynamic? FashionLabel { get; set; }
        }

        public GetPurchaseListResponsePurchaseInfoList[] PurchaseInfoList { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class OfflineMessageRequest
    {
        public SByte MessageId { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class OfflineMessageResponse
    {
        public Int32 Code { get; set; }
        public dynamic? Messages { get; set; }
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
    public class SignInRequest
    {
        public Int32 Id { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyItemDataList
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyItemDataListItemDataList
        {
            public UInt32 Id { get; set; }
            public Int32 Count { get; set; }
            public Int32 BuyTimes { get; set; }
            public Int32 TotalBuyTimes { get; set; }
            public Int32 LastBuyTime { get; set; }
            public UInt32 RefreshTime { get; set; }
            public UInt32 CreateTime { get; set; }
        }

        public NotifyItemDataListItemDataList[] ItemDataList { get; set; }
        public dynamic? ItemRecycleDict { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class SignInResponse
    {
        public Int32 Code { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class SignInResponseRewardGoodsList
        {
            public Int32 RewardType { get; set; }
            public UInt32 TemplateId { get; set; }
            public Int32 Count { get; set; }
            public Int32 Level { get; set; }
            public Int32 Quality { get; set; }
            public Int32 Grade { get; set; }
            public Int32 Breakthrough { get; set; }
            public Int32 ConvertFrom { get; set; }
            public UInt32 Id { get; set; }
        }

        public SignInResponseRewardGoodsList[] RewardGoodsList { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyEquipDataList
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyEquipDataListEquipDataList
        {
            public UInt32 Id { get; set; }
            public UInt32 TemplateId { get; set; }
            public Int32 CharacterId { get; set; }
            public Int32 Level { get; set; }
            public Int32 Exp { get; set; }
            public Int32 Breakthrough { get; set; }
            public dynamic[] ResonanceInfo { get; set; }
            public dynamic[] UnconfirmedResonanceInfo { get; set; }
            public dynamic[] AwakeSlotList { get; set; }
            public Boolean IsLock { get; set; }
            public UInt32 CreateTime { get; set; }
            public Boolean IsRecycle { get; set; }
        }

        public NotifyEquipDataListEquipDataList[] EquipDataList { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class CharacterLevelUpRequest
    {
        public Dictionary<dynamic, dynamic> UseItems { get; set; }
        public UInt32 TemplateId { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyCharacterDataList
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyCharacterDataListCharacterDataList
        {
            public UInt32 Id { get; set; }
            public Int32 Level { get; set; }
            public Int32 Exp { get; set; }
            public Int32 Quality { get; set; }
            public Int32 InitQuality { get; set; }
            public Int32 Star { get; set; }
            public Int32 Grade { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyCharacterDataListCharacterDataListSkillList
            {
                public UInt32 Id { get; set; }
                public Int32 Level { get; set; }
            }

            public NotifyCharacterDataListCharacterDataListSkillList[] SkillList { get; set; }
            public dynamic[] EnhanceSkillList { get; set; }
            public UInt32 FashionId { get; set; }
            public UInt32 CreateTime { get; set; }
            public Int32 TrustLv { get; set; }
            public Int32 TrustExp { get; set; }
            public UInt32 Ability { get; set; }
            public Int32 LiberateLv { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyCharacterDataListCharacterDataListCharacterHeadInfo
            {
                public Int32 HeadFashionId { get; set; }
                public Int32 HeadFashionType { get; set; }
            }

            public NotifyCharacterDataListCharacterDataListCharacterHeadInfo CharacterHeadInfo { get; set; }
        }

        public NotifyCharacterDataListCharacterDataList[] CharacterDataList { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class CharacterLevelUpResponse
    {
        public Int32 Code { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class AreaDataResponse
    {
        public Int32 Code { get; set; }
        public Int32 TotalPoint { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class AreaDataResponseAreaList
        {
            public Int32 AreaId { get; set; }
            public Int32 Lock { get; set; }
            public Int32 Point { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class AreaDataResponseAreaListLordList
            {
                public UInt32 Id { get; set; }
                public String Name { get; set; }
                public UInt32 CurrHeadPortraitId { get; set; }
                public Int32 CurrHeadFrameId { get; set; }
                public UInt32 Point { get; set; }
            }

            public AreaDataResponseAreaListLordList[] LordList { get; set; }
            public dynamic? StageInfos { get; set; }
        }

        public AreaDataResponseAreaList[] AreaList { get; set; }
        public UInt32 GroupFightEvent { get; set; }
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
            public Int32 FirstFightPos { get; set; }
            public String TeamName { get; set; }
            public Dictionary<dynamic, dynamic> TeamData { get; set; }
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
            public Boolean IsHasAssist { get; set; }
            public Int32 FirstFightPos { get; set; }
            public UInt32[] CardIds { get; set; }
            public Int32 CaptainPos { get; set; }
            public UInt32 StageId { get; set; }
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
            public UInt32 PassTimeLimit { get; set; }
            public Int32 StarsMark { get; set; }
            public dynamic? MonsterLevel { get; set; }
            public dynamic[] EventIds { get; set; }
            public dynamic? FightEventsWithLevel { get; set; }
            public dynamic[] NormalEventIds { get; set; }
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
                [global::MessagePack.MessagePackObject(true)]
                public class PreFightResponseFightDataRoleDataAssistNpcData
                {
                    public UInt32 Id { get; set; }
                    public Int32 Level { get; set; }
                    public String Name { get; set; }
                    [global::MessagePack.MessagePackObject(true)]
                    public class PreFightResponseFightDataRoleDataAssistNpcDataNpcData
                    {
                        [global::MessagePack.MessagePackObject(true)]
                        public class PreFightResponseFightDataRoleDataAssistNpcDataNpcDataCharacter
                        {
                            public UInt32 Id { get; set; }
                            public Int32 Level { get; set; }
                            public Int32 Exp { get; set; }
                            public Int32 Quality { get; set; }
                            public Int32 InitQuality { get; set; }
                            public Int32 Star { get; set; }
                            public Int32 Grade { get; set; }
                            [global::MessagePack.MessagePackObject(true)]
                            public class PreFightResponseFightDataRoleDataAssistNpcDataNpcDataCharacterSkillList
                            {
                                public UInt32 Id { get; set; }
                                public Int32 Level { get; set; }
                            }

                            public PreFightResponseFightDataRoleDataAssistNpcDataNpcDataCharacterSkillList[] SkillList { get; set; }
                            public dynamic[] EnhanceSkillList { get; set; }
                            public UInt32 FashionId { get; set; }
                            public UInt32 CreateTime { get; set; }
                            public Int32 TrustLv { get; set; }
                            public Int32 TrustExp { get; set; }
                            public Int32 Ability { get; set; }
                            public Int32 LiberateLv { get; set; }
                            [global::MessagePack.MessagePackObject(true)]
                            public class PreFightResponseFightDataRoleDataAssistNpcDataNpcDataCharacterCharacterHeadInfo
                            {
                                public UInt32 HeadFashionId { get; set; }
                                public Int32 HeadFashionType { get; set; }
                            }

                            public PreFightResponseFightDataRoleDataAssistNpcDataNpcDataCharacterCharacterHeadInfo CharacterHeadInfo { get; set; }
                        }

                        public PreFightResponseFightDataRoleDataAssistNpcDataNpcDataCharacter Character { get; set; }
                        [global::MessagePack.MessagePackObject(true)]
                        public class PreFightResponseFightDataRoleDataAssistNpcDataNpcDataEqui
                        {
                            public Int32 Id { get; set; }
                            public UInt32 TemplateId { get; set; }
                            public UInt32 CharacterId { get; set; }
                            public Int32 Level { get; set; }
                            public Int32 Exp { get; set; }
                            public Int32 Breakthrough { get; set; }
                            public dynamic[] ResonanceInfo { get; set; }
                            public dynamic[] UnconfirmedResonanceInfo { get; set; }
                            public dynamic[] AwakeSlotList { get; set; }
                            public Boolean IsLock { get; set; }
                            public UInt32 CreateTime { get; set; }
                            public Boolean IsRecycle { get; set; }
                        }

                        public PreFightResponseFightDataRoleDataAssistNpcDataNpcDataEqui[] Equips { get; set; }
                        public dynamic[] AttribGroupList { get; set; }
                        public dynamic? CharacterSkillPlus { get; set; }
                        public dynamic[] EquipSkillPlus { get; set; }
                        public Int32 AttribReviseId { get; set; }
                        public dynamic[] EventIds { get; set; }
                        public dynamic? FightEventsWithLevel { get; set; }
                        public Int32 WeaponFashionId { get; set; }
                        public dynamic? Partner { get; set; }
                        public Boolean IsRobot { get; set; }
                        public dynamic? AttrRateTable { get; set; }
                    }

                    public PreFightResponseFightDataRoleDataAssistNpcDataNpcData NpcData { get; set; }
                    public Int32 AssistType { get; set; }
                    public Int32 RuleTemplateId { get; set; }
                    public String Sign { get; set; }
                    public UInt32 HeadPortraitId { get; set; }
                    public Int32 HeadFrameId { get; set; }
                }

                public PreFightResponseFightDataRoleDataAssistNpcData AssistNpcData { get; set; }
            }

            public PreFightResponseFightDataRoleData[] RoleData { get; set; }
            public Int32 ReviseId { get; set; }
            public Int32 PlayerLevel { get; set; }
            public dynamic? NpcGroupList { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class PreFightResponseFightDataFightControlData
            {
                public Int32 MaxFight { get; set; }
                public Int32 MaxRecommendFight { get; set; }
                public Int32 MaxShowFight { get; set; }
                public Int32 AvgFight { get; set; }
                public Int32 AvgRecommendFight { get; set; }
                public Int32 AvgShowFight { get; set; }
            }

            public PreFightResponseFightDataFightControlData FightControlData { get; set; }
            public Boolean DisableJoystick { get; set; }
            public Boolean Restartable { get; set; }
            public Boolean DisableDeadEffect { get; set; }
            public dynamic? CustomData { get; set; }
            public dynamic? Records { get; set; }
            public dynamic? StageParams { get; set; }
            public dynamic? StStageDropData { get; set; }
        }

        public PreFightResponseFightData FightData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class FightSettleRequest
    {
        [global::MessagePack.MessagePackObject(true)]
        public class FightSettleRequestResult
        {
            public Boolean IsWin { get; set; }
            public Boolean IsForceExit { get; set; }
            public UInt32 StageId { get; set; }
            public Int32 StageLevel { get; set; }
            public UInt32 FightId { get; set; }
            public Int32 RebootCount { get; set; }
            public Int32 AddStars { get; set; }
            public Int32 StartFrame { get; set; }
            public UInt32 SettleFrame { get; set; }
            public Int32 PauseFrame { get; set; }
            public Int32 ExSkillPauseFrame { get; set; }
            public UInt32 SettleCode { get; set; }
            public Int32 DodgeTimes { get; set; }
            public Int32 NormalAttackTimes { get; set; }
            public Int32 ConsumeBallTimes { get; set; }
            public Int32 StuntSkillTimes { get; set; }
            public Int32 PauseTimes { get; set; }
            public Int32 HighestCombo { get; set; }
            public Int32 DamagedTimes { get; set; }
            public Int32 MatrixTimes { get; set; }
            public UInt32 HighestDamage { get; set; }
            public UInt32 TotalDamage { get; set; }
            public UInt32 TotalDamaged { get; set; }
            public UInt32 TotalCure { get; set; }
            public UInt32[] PlayerIds { get; set; }
            public dynamic[] PlayerData { get; set; }
            public dynamic? IntToIntRecord { get; set; }
            public dynamic? StringToIntRecord { get; set; }
            public Dictionary<dynamic, dynamic> Operations { get; set; }
            public UInt32[] Codes { get; set; }
            public Int32 LeftTime { get; set; }
            public Dictionary<dynamic, dynamic> NpcHpInfo { get; set; }
            public Dictionary<dynamic, dynamic> NpcDpsTable { get; set; }
            public dynamic[] EventSet { get; set; }
            public Int32 DeathTotalMyTeam { get; set; }
            public Int32 DeathTotalEnemy { get; set; }
            public Dictionary<dynamic, dynamic> DeathRecord { get; set; }
            public dynamic[] GroupDropDatas { get; set; }
            public dynamic? EpisodeFightResults { get; set; }
            public dynamic? CustomData { get; set; }
        }

        public FightSettleRequestResult Result { get; set; }
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
            public dynamic? RewardGoodsList { get; set; }
            public Int32 LeftTime { get; set; }
            public Dictionary<dynamic, dynamic> NpcHpInfo { get; set; }
            public Int32 UrgentEnventId { get; set; }
            public dynamic? ClientAssistInfo { get; set; }
            public dynamic[] FlopRewardList { get; set; }
            public dynamic? ArenaResult { get; set; }
            public dynamic? MultiRewardGoodsList { get; set; }
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
    public class FinishTaskRequest
    {
        public UInt32 TaskId { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class FinishTaskResponse
    {
        public Int32 Code { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class FinishTaskResponseRewardGoodsList
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

        public FinishTaskResponseRewardGoodsList[] RewardGoodsList { get; set; }
    }
}
