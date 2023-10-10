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
        public Byte Code { get; set; }
        public Byte UtcOpenTime { get; set; }
        public dynamic? Sha1Table { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class LoginRequest
    {
        public Byte LoginType { get; set; }
        public String ServerBean { get; set; }
        public Byte LoginPlatform { get; set; }
        public String ClientVersion { get; set; }
        public String DeviceId { get; set; }
        public String UserId { get; set; }
        public String Token { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class LoginResponse
    {
        public Byte Code { get; set; }
        public Byte UtcOffset { get; set; }
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
            public Byte Level { get; set; }
            public String Sign { get; set; }
            public UInt32 DisplayCharId { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyLoginPlayerDataBirthday
            {
                public Byte Mon { get; set; }
                public Byte Day { get; set; }
            }

            public NotifyLoginPlayerDataBirthday Birthday { get; set; }
            public Byte HonorLevel { get; set; }
            public String ServerId { get; set; }
            public Byte Likes { get; set; }
            public Byte CurrTeamId { get; set; }
            public Byte ChallengeEventId { get; set; }
            public UInt32 CurrHeadPortraitId { get; set; }
            public Byte CurrHeadFrameId { get; set; }
            public Byte CurrMedalId { get; set; }
            public Byte AppearanceShowType { get; set; }
            public Byte DailyReceiveGiftCount { get; set; }
            public Byte DailyActivenessRewardStatus { get; set; }
            public Byte WeeklyActivenessRewardStatus { get; set; }
            public Byte[] Marks { get; set; }
            public UInt32[] GuideData { get; set; }
            public Byte[] Communications { get; set; }
            public dynamic[] ShowCharacters { get; set; }
            public dynamic[] ShieldFuncList { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyLoginPlayerDataAppearanceSettingInfo
            {
                public Byte TitleType { get; set; }
                public Byte CharacterType { get; set; }
                public Byte FashionType { get; set; }
                public Byte WeaponFashionType { get; set; }
                public Byte DormitoryType { get; set; }
                public Byte DormitoryId { get; set; }
            }

            public NotifyLoginPlayerDataAppearanceSettingInfo AppearanceSettingInfo { get; set; }
            public UInt32 CreateTime { get; set; }
            public UInt32 LastLoginTime { get; set; }
            public Byte ReportTime { get; set; }
            public UInt32 ChangeNameTime { get; set; }
            public Byte Flags { get; set; }
        }

        public NotifyLoginPlayerData PlayerData { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyLoginTimeLimitCtrlConfigList
        {
            public Byte Id { get; set; }
            public UInt32 StartTime { get; set; }
            public UInt32 EndTime { get; set; }
        }

        public NotifyLoginTimeLimitCtrlConfigList[] TimeLimitCtrlConfigList { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyLoginSharePlatformConfigList
        {
            public Byte Id { get; set; }
            public Byte[] SdkId { get; set; }
        }

        public NotifyLoginSharePlatformConfigList[] SharePlatformConfigList { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyLoginItemList
        {
            public Byte Id { get; set; }
            public UInt32 Count { get; set; }
            public Byte BuyTimes { get; set; }
            public Byte TotalBuyTimes { get; set; }
            public Byte LastBuyTime { get; set; }
            public UInt32 RefreshTime { get; set; }
            public UInt32 CreateTime { get; set; }
        }

        public NotifyLoginItemList[] ItemList { get; set; }
        public Dictionary<dynamic, dynamic> ItemRecycleDict { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyLoginCharacterList
        {
            public UInt32 Id { get; set; }
            public Byte Level { get; set; }
            public Byte Exp { get; set; }
            public Byte Quality { get; set; }
            public Byte InitQuality { get; set; }
            public Byte Star { get; set; }
            public Byte Grade { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyLoginCharacterListSkillList
            {
                public UInt32 Id { get; set; }
                public Byte Level { get; set; }
            }

            public NotifyLoginCharacterListSkillList[] SkillList { get; set; }
            public dynamic[] EnhanceSkillList { get; set; }
            public UInt32 FashionId { get; set; }
            public UInt32 CreateTime { get; set; }
            public Byte TrustLv { get; set; }
            public Byte TrustExp { get; set; }
            public UInt16 Ability { get; set; }
            public Byte LiberateLv { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyLoginCharacterListCharacterHeadInfo
            {
                public Byte HeadFashionId { get; set; }
                public Byte HeadFashionType { get; set; }
            }

            public NotifyLoginCharacterListCharacterHeadInfo CharacterHeadInfo { get; set; }
        }

        public NotifyLoginCharacterList[] CharacterList { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyLoginEquipList
        {
            public Byte Id { get; set; }
            public UInt32 TemplateId { get; set; }
            public UInt32 CharacterId { get; set; }
            public Byte Level { get; set; }
            public Byte Exp { get; set; }
            public Byte Breakthrough { get; set; }
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
            public Byte LeftCount { get; set; }
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
                public Byte RefreshTime { get; set; }
                public Byte SelectedCharId { get; set; }
                public Byte UrgentAlarmCount { get; set; }
                public Byte WeeklyUrgentCount { get; set; }
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
            public Byte Id { get; set; }
            public Byte Round { get; set; }
            public Byte Day { get; set; }
            public Boolean Got { get; set; }
            public Byte FinishDay { get; set; }
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
            public Byte[] RecycleStar { get; set; }
            public Byte Days { get; set; }
            public Byte SetRecycleTime { get; set; }
        }

        public NotifyEquipChipAutoRecycleSiteChipRecycleSite ChipRecycleSite { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyEquipGuideData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyEquipGuideDataEquipGuideData
        {
            public Byte TargetId { get; set; }
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
            public UInt16 Id { get; set; }
            public Byte Killed { get; set; }
        }

        public NotifyArchiveLoginDataMonste[] Monsters { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyArchiveLoginDataEqui
        {
            public UInt32 Id { get; set; }
            public Byte Level { get; set; }
            public Byte Breakthrough { get; set; }
            public Byte ResonanceCount { get; set; }
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
            public Byte EndTime { get; set; }
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
                public UInt16 Id { get; set; }
                [global::MessagePack.MessagePackObject(true)]
                public class NotifyTaskDataTaskDataTasSchedule
                {
                    public UInt16 Id { get; set; }
                    public Byte Value { get; set; }
                }

                public NotifyTaskDataTaskDataTasSchedule[] Schedule { get; set; }
                public Byte State { get; set; }
                public UInt32 RecordTime { get; set; }
                public Byte ActivityId { get; set; }
            }

            public NotifyTaskDataTaskDataTas[] Tasks { get; set; }
            public UInt32[] Course { get; set; }
            public Byte[] FinishedTasks { get; set; }
            public Byte[] NewPlayerRewardRecord { get; set; }
            public dynamic[] TaskLimitIdActiveInfos { get; set; }
            public dynamic[] NewbieRecvProgress { get; set; }
            public Boolean NewbieHonorReward { get; set; }
            public Byte NewbieUnlockPeriod { get; set; }
        }

        public NotifyTaskDataTaskData TaskData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyActivenessStatus
    {
        public Byte DailyActivenessRewardStatus { get; set; }
        public Byte WeeklyActivenessRewardStatus { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyNewPlayerTaskStatus
    {
        public UInt16 NewPlayerTaskActiveDay { get; set; }
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
                public Byte Id { get; set; }
                public Byte BeginTime { get; set; }
                public Byte State { get; set; }
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
        public Byte Id { get; set; }
        public UInt32 ResetTime { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyMaintainerActionDataNod
        {
            public Byte NodeId { get; set; }
            public Byte NodeType { get; set; }
            public Byte EventId { get; set; }
            public String Value { get; set; }
        }

        public NotifyMaintainerActionDataNod[] Nodes { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyMaintainerActionDataPlaye
        {
            public UInt32 PlayerId { get; set; }
            public String PlayerName { get; set; }
            public UInt32 HeadPortraitId { get; set; }
            public Byte HeadFrameId { get; set; }
            public Byte NodeId { get; set; }
            public Boolean IsNodeTriggered { get; set; }
            public Boolean Reverse { get; set; }
        }

        public NotifyMaintainerActionDataPlaye[] Players { get; set; }
        public Byte[] Cards { get; set; }
        public Byte FightWinCount { get; set; }
        public Byte BoxCount { get; set; }
        public Byte UsedActionCount { get; set; }
        public Byte ExtraActionCount { get; set; }
        public Boolean HasWarehouseNode { get; set; }
        public Byte WarehouseFinishCount { get; set; }
        public Boolean HasMentorNode { get; set; }
        public Byte MentorStatus { get; set; }
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
            public Byte Id { get; set; }
            public UInt16 PedestalId { get; set; }
            public UInt16 BackgroundId { get; set; }
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
                public UInt16 Id { get; set; }
                [global::MessagePack.MessagePackObject(true)]
                public class NotifyTaskTasksTasSchedule
                {
                    public UInt16 Id { get; set; }
                    public Byte Value { get; set; }
                }

                public NotifyTaskTasksTasSchedule[] Schedule { get; set; }
                public Byte State { get; set; }
                public UInt32 RecordTime { get; set; }
                public Byte ActivityId { get; set; }
            }

            public NotifyTaskTasksTas[] Tasks { get; set; }
        }

        public NotifyTaskTasks Tasks { get; set; }
        public dynamic? TaskLimitIdActiveInfos { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyGuildEvent
    {
        public Byte Type { get; set; }
        public UInt32 Value { get; set; }
        public Byte Value2 { get; set; }
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
        public Byte SnapshotTimes { get; set; }
        public dynamic[] DormitoryList { get; set; }
        public dynamic[] VisitorList { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyDormitoryDataFurnitureList
        {
            public Byte Id { get; set; }
            public UInt32 ConfigId { get; set; }
            public Byte X { get; set; }
            public Byte Y { get; set; }
            public Byte Angle { get; set; }
            public Byte DormitoryId { get; set; }
            public UInt16 Addition { get; set; }
            public Byte[] AttrList { get; set; }
            public Boolean IsLocked { get; set; }
        }

        public NotifyDormitoryDataFurnitureList[] FurnitureList { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyDormitoryDataCharacterList
        {
            public UInt32 CharacterId { get; set; }
            public SByte DormitoryId { get; set; }
            public Byte Mood { get; set; }
            public Byte Vitality { get; set; }
            public Byte MoodSpeed { get; set; }
            public Byte VitalitySpeed { get; set; }
            public UInt32 LastFondleRecoveryTime { get; set; }
            public Byte LeftFondleCount { get; set; }
            public dynamic[] EventList { get; set; }
        }

        public NotifyDormitoryDataCharacterList[] CharacterList { get; set; }
        public dynamic[] Layouts { get; set; }
        public dynamic[] BindRelations { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyNameplateLoginData
    {
        public Byte CurrentWearNameplate { get; set; }
        public dynamic[] UnlockNameplates { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyGuildDormPlayerData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyGuildDormPlayerDataGuildDormData
        {
            public Byte CurrentCharacterId { get; set; }
            public Byte DailyInteractRewardTotalTimes { get; set; }
            public Byte DailyInteractRewardCurTimes { get; set; }
        }

        public NotifyGuildDormPlayerDataGuildDormData GuildDormData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyBountyTaskInfo
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyBountyTaskInfoTaskInfo
        {
            public Byte RankLevel { get; set; }
            public dynamic[] TaskCards { get; set; }
            public Byte TaskPoolRefreshCount { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyBountyTaskInfoTaskInfoTaskPool
            {
                public Byte Id { get; set; }
                public UInt32 StageId { get; set; }
                public UInt16 RewardId { get; set; }
                public UInt16 EventId { get; set; }
                public UInt32 DifficultStageId { get; set; }
                public Byte Status { get; set; }
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
        public Byte ActivityNo { get; set; }
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
        public Byte[] GatherRewards { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyDrawTicketData
    {
        public dynamic[] DrawTicketInfos { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyAccumulatedPayData
    {
        public Byte PayId { get; set; }
        public Single PayMoney { get; set; }
        public dynamic[] PayRewardIds { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyArenaActivity
    {
        public Byte ActivityNo { get; set; }
        public Byte ChallengeId { get; set; }
        public Byte Status { get; set; }
        public UInt32 NextStatusTime { get; set; }
        public Byte ArenaLevel { get; set; }
        public Byte JoinActivity { get; set; }
        public Byte UnlockCount { get; set; }
        public UInt32 TeamTime { get; set; }
        public UInt32 FightTime { get; set; }
        public UInt32 ResultTime { get; set; }
        public dynamic[] MaxPointStageList { get; set; }
        public Byte ContributeScore { get; set; }
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
        public Byte BfrtChapter { get; set; }
        public UInt32 EndTime { get; set; }
        public Byte HideChapterBeginTime { get; set; }
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
        public UInt16 NextActiveYear { get; set; }
        public Byte IsChange { get; set; }
        public dynamic[] UnLockCg { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyBossActivityData
    {
        public Byte ActivityId { get; set; }
        public Byte SectionId { get; set; }
        public Byte Schedule { get; set; }
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
            public Byte Id { get; set; }
            public Byte InitHp { get; set; }
            public Byte SubBossMaxHp { get; set; }
            public Byte BossStepMin { get; set; }
            public Byte BossStepMax { get; set; }
            public Single BattleHurtRate { get; set; }
            public Byte BattleHurtMax { get; set; }
            public Byte SelfHpRate { get; set; }
            public Byte SelfHpMax { get; set; }
            public Byte ConvertHurtRate { get; set; }
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
            public Byte TotalLessonPoint { get; set; }
            public Byte MaxTotalLessonPoint { get; set; }
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
        public Byte Count { get; set; }
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
        public Byte ActivityNo { get; set; }
        public Byte Status { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyBabelTowerData
    {
        public Byte ActivityNo { get; set; }
        public Byte MaxScore { get; set; }
        public Byte RankLevel { get; set; }
        public dynamic[] StageDatas { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyBabelTowerDataExtraData
        {
            public Byte ActivityNo { get; set; }
            public Byte MaxScore { get; set; }
            public Byte RankLevel { get; set; }
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
            public Byte ActivityNo { get; set; }
            public Byte TotalScore { get; set; }
            public Byte MaxScore { get; set; }
            public Byte OldLevelType { get; set; }
            public Byte LevelType { get; set; }
            public Byte ChallengeCount { get; set; }
            public UInt32 RemainTime { get; set; }
            public Byte AutoFightCount { get; set; }
            public dynamic? CharacterPoints { get; set; }
            public dynamic[] HistoryList { get; set; }
            public dynamic[] RewardIds { get; set; }
            public Byte RankPlatform { get; set; }
            public Byte[] BossList { get; set; }
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
            public Byte Id { get; set; }
            public UInt32[] FinishStages { get; set; }
        }

        public NotifyPracticeDataChapterInf[] ChapterInfos { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyTrialData
    {
        public Byte[] FinishTrial { get; set; }
        public Byte[] RewardRecord { get; set; }
        public dynamic[] TypeRewardRecord { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyPivotCombatData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyPivotCombatDataPivotCombatData
        {
            public Byte ActivityId { get; set; }
            public Byte Difficulty { get; set; }
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
        public Byte Id { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyRepeatChallengeDataExpInfo
        {
            public Byte Level { get; set; }
            public Byte Exp { get; set; }
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
            public Byte ReportTimes { get; set; }
            public Byte LastReportTime { get; set; }
        }

        public NotifyPlayerReportDataReportData ReportData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyReviewConfig
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyReviewConfigReviewActivityConfigList
        {
            public Byte Id { get; set; }
            public UInt32 StartTime { get; set; }
            public UInt32 EndTime { get; set; }
            public UInt16 RewardId { get; set; }
        }

        public NotifyReviewConfigReviewActivityConfigList[] ReviewActivityConfigList { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyStrongholdLoginData
    {
        public Byte Id { get; set; }
        public UInt32 BeginTime { get; set; }
        public UInt32 FightBeginTime { get; set; }
        public Byte CurDay { get; set; }
        public Byte AssistCharacterId { get; set; }
        public Byte SetAssistCharacterTime { get; set; }
        public Byte BorrowCount { get; set; }
        public UInt16 ElectricEnergy { get; set; }
        public Byte Endurance { get; set; }
        public Byte MineralLeft { get; set; }
        public Byte TotalMineral { get; set; }
        public dynamic[] ElectricCharacterIds { get; set; }
        public dynamic[] FinishGroupIds { get; set; }
        public dynamic[] FinishGroupInfos { get; set; }
        public dynamic[] HistoryFinishGroupInfos { get; set; }
        public dynamic[] GroupInfos { get; set; }
        public dynamic[] TeamInfos { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyStrongholdLoginDataGroupStageDat
        {
            public Byte Id { get; set; }
            public UInt32[] StageIds { get; set; }
            public Dictionary<dynamic, dynamic> StageBuffId { get; set; }
            public Byte SupportId { get; set; }
        }

        public NotifyStrongholdLoginDataGroupStageDat[] GroupStageDatas { get; set; }
        public Byte[] RuneList { get; set; }
        public dynamic[] RewardIds { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyStrongholdLoginDataLastResultRecord
        {
            public Byte Id { get; set; }
            public Byte FinishCount { get; set; }
            public Byte MinerCount { get; set; }
            public Byte MineralCount { get; set; }
            public Byte AssistCount { get; set; }
            public Byte AssistRewardValue { get; set; }
        }

        public NotifyStrongholdLoginDataLastResultRecord LastResultRecord { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyStrongholdLoginDataMineRecor
        {
            public Byte Day { get; set; }
            public Byte MinerCount { get; set; }
            public Byte MineralCount { get; set; }
            public Boolean IsStay { get; set; }
        }

        public NotifyStrongholdLoginDataMineRecor[] MineRecords { get; set; }
        public Byte LevelId { get; set; }
        public dynamic[] StayDays { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifySummerSignInData
    {
        public Byte ActId { get; set; }
        public dynamic[] MsgIdList { get; set; }
        public Byte SurplusTimes { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyTaikoMasterData
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyTaikoMasterDataTaikoMasterData
        {
            public Byte ActivityId { get; set; }
            public dynamic[] StageDataList { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyTaikoMasterDataTaikoMasterDataSetting
            {
                public Byte AppearOffset { get; set; }
                public Byte JudgeOffset { get; set; }
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
        public Byte CurChapterId { get; set; }
        public Byte CurRoleLv { get; set; }
        public Byte DifficultyId { get; set; }
        public Byte KeepsakeId { get; set; }
        public dynamic[] UnlockPowerIds { get; set; }
        public dynamic[] UnlockPowerFavorIds { get; set; }
        public dynamic[] EffectPowerFavorIds { get; set; }
        public dynamic[] Skills { get; set; }
        public dynamic[] RecruitRole { get; set; }
        public dynamic[] Keepsakes { get; set; }
        public dynamic[] Decorations { get; set; }
        public dynamic? CurChapterDb { get; set; }
        public Byte ReopenCount { get; set; }
        public dynamic[] SkillIllustratedBook { get; set; }
        public dynamic? SingleTeamData { get; set; }
        public dynamic[] MultiTeamDatas { get; set; }
        public Byte UseOwnCharacter { get; set; }
        public Byte FavorCoin { get; set; }
        public Byte DecorationCoin { get; set; }
        public dynamic[] PassChapterId { get; set; }
        public dynamic? PassEventRecord { get; set; }
        public Byte PassNodeCount { get; set; }
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
        public UInt16 CurTargetLink { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyTRPGDataBaseInfo
        {
            public Byte Level { get; set; }
            public Byte Exp { get; set; }
            public Byte Endurance { get; set; }
        }

        public NotifyTRPGDataBaseInfo BaseInfo { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyTRPGDataBossInfo
        {
            public Byte Id { get; set; }
            public Byte ChallengeCount { get; set; }
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
            public Byte DisCount { get; set; }
            public Byte AddBuyCount { get; set; }
            public UInt32 Id { get; set; }
            public dynamic[] ItemInfos { get; set; }
        }

        public NotifyTRPGDataShopInf[] ShopInfos { get; set; }
        public dynamic[] MazeInfos { get; set; }
        public dynamic[] MemoirList { get; set; }
        public Byte ItemCapacityAdd { get; set; }
        public Boolean IsNormalPage { get; set; }
        public dynamic[] StageList { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyBiancaTheatreActivityData
    {
        public Byte CurActivityId { get; set; }
        public Byte CurChapterId { get; set; }
        public Byte DifficultyId { get; set; }
        public Byte CurTeamId { get; set; }
        public dynamic? CurChapterDb { get; set; }
        public dynamic[] Characters { get; set; }
        public dynamic[] Items { get; set; }
        public Byte TotalExp { get; set; }
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
        public Byte PlayerType { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyMentorDataTeacher
        {
            public Byte PlayerId { get; set; }
            public dynamic? PlayerName { get; set; }
            public Byte Level { get; set; }
            public Byte HeadPortraitId { get; set; }
            public Byte HeadFrameId { get; set; }
            public Boolean IsGraduate { get; set; }
            public dynamic? Tag { get; set; }
            public dynamic? OnlineTag { get; set; }
            public dynamic? Announcement { get; set; }
            public Byte StudentCount { get; set; }
            public dynamic? StudentTask { get; set; }
            public Boolean IsOnline { get; set; }
            public dynamic? SystemTask { get; set; }
            public dynamic? WeeklyTask { get; set; }
            public Byte KizunaAmount { get; set; }
            public Byte JoinTime { get; set; }
            public Byte ReachTime { get; set; }
            public Byte LastLoginTime { get; set; }
            public Byte SendGiftCount { get; set; }
        }

        public NotifyMentorDataTeacher Teacher { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyMentorDataStuden
        {
            public UInt32 PlayerId { get; set; }
            public String PlayerName { get; set; }
            public Byte Level { get; set; }
            public UInt32 HeadPortraitId { get; set; }
            public Byte HeadFrameId { get; set; }
            public Boolean IsGraduate { get; set; }
            public dynamic? Tag { get; set; }
            public dynamic? OnlineTag { get; set; }
            public dynamic? Announcement { get; set; }
            public Byte StudentCount { get; set; }
            public dynamic[] StudentTask { get; set; }
            public Boolean IsOnline { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyMentorDataStudenSystemTask
            {
                public UInt16 TaskId { get; set; }
                public Byte State { get; set; }
                public dynamic[] Schedule { get; set; }
                public Byte Status { get; set; }
                public Byte RewardId { get; set; }
                public dynamic[] EquipList { get; set; }
                public Boolean HasChange { get; set; }
            }

            public NotifyMentorDataStudenSystemTask[] SystemTask { get; set; }
            public dynamic[] WeeklyTask { get; set; }
            public Byte KizunaAmount { get; set; }
            public Byte JoinTime { get; set; }
            public Byte ReachTime { get; set; }
            public Byte LastLoginTime { get; set; }
            public Byte SendGiftCount { get; set; }
        }

        public NotifyMentorDataStuden[] Students { get; set; }
        public dynamic[] ApplyList { get; set; }
        public Byte GraduateStudentCount { get; set; }
        public dynamic[] StageReward { get; set; }
        public dynamic[] WeeklyTaskReward { get; set; }
        public Byte WeeklyTaskCompleteCount { get; set; }
        public Byte[] Tag { get; set; }
        public Byte[] OnlineTag { get; set; }
        public String Announcement { get; set; }
        public Byte DailyChangeTaskCount { get; set; }
        public Byte WeeklyLevel { get; set; }
        public Byte MonthlyStudentCount { get; set; }
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
        public Byte UsedActionCount { get; set; }
        public Byte ExtraActionCount { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyGuildData
    {
        public Byte GuildId { get; set; }
        public String GuildName { get; set; }
        public Byte GuildLevel { get; set; }
        public Byte IconId { get; set; }
        public Byte GuildRankLevel { get; set; }
        public Byte HasContributeReward { get; set; }
        public Boolean HasRecruit { get; set; }
        public Byte BossEndTime { get; set; }
        public Byte FreeChangeGuildNameCount { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyMails
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyMailsNewMailList
        {
            public String Id { get; set; }
            public Byte GroupId { get; set; }
            public dynamic? BatchId { get; set; }
            public Byte Type { get; set; }
            public Byte Status { get; set; }
            public String SendName { get; set; }
            public String Title { get; set; }
            public String Content { get; set; }
            public UInt32 CreateTime { get; set; }
            public UInt32 SendTime { get; set; }
            public UInt32 ExpireTime { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyMailsNewMailListRewardGoodsList
            {
                public Byte RewardType { get; set; }
                public UInt32 TemplateId { get; set; }
                public Byte Count { get; set; }
                public Byte Level { get; set; }
                public Byte Quality { get; set; }
                public Byte Grade { get; set; }
                public Byte Breakthrough { get; set; }
                public Byte ConvertFrom { get; set; }
                public Byte Id { get; set; }
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
        public Byte Code { get; set; }
        public Byte ChannelId { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class GetWorldChannelInfoResponse
    {
        public Byte Code { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class GetWorldChannelInfoResponseChannelInf
        {
            public Byte ChannelId { get; set; }
            public Byte PlayerNum { get; set; }
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
        public Byte[] UiTypeList { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class GetPurchaseListResponse
    {
        public Byte Code { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class GetPurchaseListResponsePurchaseInfoList
        {
            public UInt32 Id { get; set; }
            public Byte TimeToInvalid { get; set; }
            public Byte TimeToShelve { get; set; }
            public Byte TimeToUnShelve { get; set; }
            public Byte BuyTimes { get; set; }
            public Byte BuyLimitTimes { get; set; }
            public Byte ConsumeId { get; set; }
            public Byte ConsumeCount { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class GetPurchaseListResponsePurchaseInfoListRewardGoodsList
            {
                public Byte RewardType { get; set; }
                public Byte TemplateId { get; set; }
                public UInt16 Count { get; set; }
                public Byte Level { get; set; }
                public Byte Quality { get; set; }
                public Byte Grade { get; set; }
                public Byte Breakthrough { get; set; }
                public Byte ConvertFrom { get; set; }
                public UInt32 Id { get; set; }
            }

            public GetPurchaseListResponsePurchaseInfoListRewardGoodsList[] RewardGoodsList { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class GetPurchaseListResponsePurchaseInfoListDailyRewardGoodsList
            {
                public Byte RewardType { get; set; }
                public Byte TemplateId { get; set; }
                public Byte Count { get; set; }
                public Byte Level { get; set; }
                public Byte Quality { get; set; }
                public Byte Grade { get; set; }
                public Byte Breakthrough { get; set; }
                public Byte ConvertFrom { get; set; }
                public UInt32 Id { get; set; }
            }

            public GetPurchaseListResponsePurchaseInfoListDailyRewardGoodsList[] DailyRewardGoodsList { get; set; }
            public dynamic? FirstRewardGoods { get; set; }
            public dynamic? ExtraRewardGoods { get; set; }
            public Byte DailyRewardRemainDay { get; set; }
            public Boolean IsDailyRewardGet { get; set; }
            public String Name { get; set; }
            public String Desc { get; set; }
            public String Icon { get; set; }
            public Byte UiType { get; set; }
            public Byte SignInId { get; set; }
            public Byte Tag { get; set; }
            public Byte Priority { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class GetPurchaseListResponsePurchaseInfoListClientResetInfo
            {
                public Byte ResetType { get; set; }
                public Byte DayCount { get; set; }
            }

            public GetPurchaseListResponsePurchaseInfoListClientResetInfo ClientResetInfo { get; set; }
            public Boolean IsUseMail { get; set; }
            public dynamic? NormalDiscounts { get; set; }
            public dynamic? DiscountCouponInfos { get; set; }
            public dynamic? DiscountShowStr { get; set; }
            public Byte LastBuyTime { get; set; }
            public Byte MailCount { get; set; }
            public dynamic? PayKeySuffix { get; set; }
            public UInt32[] MutexPurchaseIds { get; set; }
            public Byte ConvertSwitch { get; set; }
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
        public Byte Code { get; set; }
        public dynamic? Messages { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class DoClientTaskEventRequest
    {
        public Byte ClientTaskType { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class DoClientTaskEventResponse
    {
        public Byte Code { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class SignInRequest
    {
        public Byte Id { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class NotifyItemDataList
    {
        [global::MessagePack.MessagePackObject(true)]
        public class NotifyItemDataListItemDataList
        {
            public UInt16 Id { get; set; }
            public Byte Count { get; set; }
            public Byte BuyTimes { get; set; }
            public Byte TotalBuyTimes { get; set; }
            public Byte LastBuyTime { get; set; }
            public UInt32 RefreshTime { get; set; }
            public UInt32 CreateTime { get; set; }
        }

        public NotifyItemDataListItemDataList[] ItemDataList { get; set; }
        public dynamic? ItemRecycleDict { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class SignInResponse
    {
        public Byte Code { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class SignInResponseRewardGoodsList
        {
            public Byte RewardType { get; set; }
            public UInt16 TemplateId { get; set; }
            public Byte Count { get; set; }
            public Byte Level { get; set; }
            public Byte Quality { get; set; }
            public Byte Grade { get; set; }
            public Byte Breakthrough { get; set; }
            public Byte ConvertFrom { get; set; }
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
            public UInt16 Id { get; set; }
            public UInt32 TemplateId { get; set; }
            public Byte CharacterId { get; set; }
            public Byte Level { get; set; }
            public Byte Exp { get; set; }
            public Byte Breakthrough { get; set; }
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
            public Byte Level { get; set; }
            public Byte Exp { get; set; }
            public Byte Quality { get; set; }
            public Byte InitQuality { get; set; }
            public Byte Star { get; set; }
            public Byte Grade { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyCharacterDataListCharacterDataListSkillList
            {
                public UInt32 Id { get; set; }
                public Byte Level { get; set; }
            }

            public NotifyCharacterDataListCharacterDataListSkillList[] SkillList { get; set; }
            public dynamic[] EnhanceSkillList { get; set; }
            public UInt32 FashionId { get; set; }
            public UInt32 CreateTime { get; set; }
            public Byte TrustLv { get; set; }
            public Byte TrustExp { get; set; }
            public UInt16 Ability { get; set; }
            public Byte LiberateLv { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class NotifyCharacterDataListCharacterDataListCharacterHeadInfo
            {
                public Byte HeadFashionId { get; set; }
                public Byte HeadFashionType { get; set; }
            }

            public NotifyCharacterDataListCharacterDataListCharacterHeadInfo CharacterHeadInfo { get; set; }
        }

        public NotifyCharacterDataListCharacterDataList[] CharacterDataList { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class CharacterLevelUpResponse
    {
        public Byte Code { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class AreaDataResponse
    {
        public Byte Code { get; set; }
        public Byte TotalPoint { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class AreaDataResponseAreaList
        {
            public Byte AreaId { get; set; }
            public Byte Lock { get; set; }
            public Byte Point { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class AreaDataResponseAreaListLordList
            {
                public UInt32 Id { get; set; }
                public String Name { get; set; }
                public UInt32 CurrHeadPortraitId { get; set; }
                public Byte CurrHeadFrameId { get; set; }
                public UInt32 Point { get; set; }
            }

            public AreaDataResponseAreaListLordList[] LordList { get; set; }
            public dynamic? StageInfos { get; set; }
        }

        public AreaDataResponseAreaList[] AreaList { get; set; }
        public UInt16 GroupFightEvent { get; set; }
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
            public Byte TeamId { get; set; }
            public Byte CaptainPos { get; set; }
            public Byte FirstFightPos { get; set; }
            public String TeamName { get; set; }
            public Dictionary<dynamic, dynamic> TeamData { get; set; }
        }

        public TeamSetTeamRequestTeamData TeamData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class TeamSetTeamResponse
    {
        public Byte Code { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class PreFightRequest
    {
        [global::MessagePack.MessagePackObject(true)]
        public class PreFightRequestPreFightData
        {
            public Byte ChallengeCount { get; set; }
            public Boolean IsHasAssist { get; set; }
            public Byte FirstFightPos { get; set; }
            public UInt32[] CardIds { get; set; }
            public Byte CaptainPos { get; set; }
            public UInt32 StageId { get; set; }
        }

        public PreFightRequestPreFightData PreFightData { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class PreFightResponse
    {
        public Byte Code { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class PreFightResponseFightData
        {
            public Boolean Online { get; set; }
            public UInt32 FightId { get; set; }
            public dynamic? RoomId { get; set; }
            public Byte OnlineMode { get; set; }
            public UInt32 Seed { get; set; }
            public UInt32 StageId { get; set; }
            public Byte RebootId { get; set; }
            public UInt16 PassTimeLimit { get; set; }
            public Byte StarsMark { get; set; }
            public dynamic? MonsterLevel { get; set; }
            public dynamic[] EventIds { get; set; }
            public dynamic? FightEventsWithLevel { get; set; }
            public dynamic[] NormalEventIds { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class PreFightResponseFightDataRoleData
            {
                public UInt32 Id { get; set; }
                public Byte Camp { get; set; }
                public String Name { get; set; }
                public Boolean IsRobot { get; set; }
                public Byte CaptainIndex { get; set; }
                public Byte FirstFightPos { get; set; }
                public Dictionary<dynamic, dynamic> NpcData { get; set; }
                public dynamic? CustomNpc { get; set; }
                [global::MessagePack.MessagePackObject(true)]
                public class PreFightResponseFightDataRoleDataAssistNpcData
                {
                    public UInt32 Id { get; set; }
                    public Byte Level { get; set; }
                    public String Name { get; set; }
                    [global::MessagePack.MessagePackObject(true)]
                    public class PreFightResponseFightDataRoleDataAssistNpcDataNpcData
                    {
                        [global::MessagePack.MessagePackObject(true)]
                        public class PreFightResponseFightDataRoleDataAssistNpcDataNpcDataCharacter
                        {
                            public UInt32 Id { get; set; }
                            public Byte Level { get; set; }
                            public Byte Exp { get; set; }
                            public Byte Quality { get; set; }
                            public Byte InitQuality { get; set; }
                            public Byte Star { get; set; }
                            public Byte Grade { get; set; }
                            [global::MessagePack.MessagePackObject(true)]
                            public class PreFightResponseFightDataRoleDataAssistNpcDataNpcDataCharacterSkillList
                            {
                                public UInt32 Id { get; set; }
                                public Byte Level { get; set; }
                            }

                            public PreFightResponseFightDataRoleDataAssistNpcDataNpcDataCharacterSkillList[] SkillList { get; set; }
                            public dynamic[] EnhanceSkillList { get; set; }
                            public UInt32 FashionId { get; set; }
                            public UInt32 CreateTime { get; set; }
                            public Byte TrustLv { get; set; }
                            public Byte TrustExp { get; set; }
                            public Byte Ability { get; set; }
                            public Byte LiberateLv { get; set; }
                            [global::MessagePack.MessagePackObject(true)]
                            public class PreFightResponseFightDataRoleDataAssistNpcDataNpcDataCharacterCharacterHeadInfo
                            {
                                public UInt32 HeadFashionId { get; set; }
                                public Byte HeadFashionType { get; set; }
                            }

                            public PreFightResponseFightDataRoleDataAssistNpcDataNpcDataCharacterCharacterHeadInfo CharacterHeadInfo { get; set; }
                        }

                        public PreFightResponseFightDataRoleDataAssistNpcDataNpcDataCharacter Character { get; set; }
                        [global::MessagePack.MessagePackObject(true)]
                        public class PreFightResponseFightDataRoleDataAssistNpcDataNpcDataEqui
                        {
                            public Byte Id { get; set; }
                            public UInt32 TemplateId { get; set; }
                            public UInt32 CharacterId { get; set; }
                            public Byte Level { get; set; }
                            public Byte Exp { get; set; }
                            public Byte Breakthrough { get; set; }
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
                        public Byte AttribReviseId { get; set; }
                        public dynamic[] EventIds { get; set; }
                        public dynamic? FightEventsWithLevel { get; set; }
                        public Byte WeaponFashionId { get; set; }
                        public dynamic? Partner { get; set; }
                        public Boolean IsRobot { get; set; }
                        public dynamic? AttrRateTable { get; set; }
                    }

                    public PreFightResponseFightDataRoleDataAssistNpcDataNpcData NpcData { get; set; }
                    public Byte AssistType { get; set; }
                    public Byte RuleTemplateId { get; set; }
                    public String Sign { get; set; }
                    public UInt32 HeadPortraitId { get; set; }
                    public Byte HeadFrameId { get; set; }
                }

                public PreFightResponseFightDataRoleDataAssistNpcData AssistNpcData { get; set; }
            }

            public PreFightResponseFightDataRoleData[] RoleData { get; set; }
            public Byte ReviseId { get; set; }
            public Byte PlayerLevel { get; set; }
            public dynamic? NpcGroupList { get; set; }
            [global::MessagePack.MessagePackObject(true)]
            public class PreFightResponseFightDataFightControlData
            {
                public Byte MaxFight { get; set; }
                public Byte MaxRecommendFight { get; set; }
                public Byte MaxShowFight { get; set; }
                public Byte AvgFight { get; set; }
                public Byte AvgRecommendFight { get; set; }
                public Byte AvgShowFight { get; set; }
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
            public Byte StageLevel { get; set; }
            public UInt32 FightId { get; set; }
            public Byte RebootCount { get; set; }
            public Byte AddStars { get; set; }
            public Byte StartFrame { get; set; }
            public UInt16 SettleFrame { get; set; }
            public Byte PauseFrame { get; set; }
            public Byte ExSkillPauseFrame { get; set; }
            public UInt32 SettleCode { get; set; }
            public Byte DodgeTimes { get; set; }
            public Byte NormalAttackTimes { get; set; }
            public Byte ConsumeBallTimes { get; set; }
            public Byte StuntSkillTimes { get; set; }
            public Byte PauseTimes { get; set; }
            public Byte HighestCombo { get; set; }
            public Byte DamagedTimes { get; set; }
            public Byte MatrixTimes { get; set; }
            public UInt16 HighestDamage { get; set; }
            public UInt32 TotalDamage { get; set; }
            public UInt16 TotalDamaged { get; set; }
            public UInt16 TotalCure { get; set; }
            public UInt32[] PlayerIds { get; set; }
            public dynamic[] PlayerData { get; set; }
            public dynamic? IntToIntRecord { get; set; }
            public dynamic? StringToIntRecord { get; set; }
            public Dictionary<dynamic, dynamic> Operations { get; set; }
            public UInt32[] Codes { get; set; }
            public Byte LeftTime { get; set; }
            public Dictionary<dynamic, dynamic> NpcHpInfo { get; set; }
            public Dictionary<dynamic, dynamic> NpcDpsTable { get; set; }
            public dynamic[] EventSet { get; set; }
            public Byte DeathTotalMyTeam { get; set; }
            public Byte DeathTotalEnemy { get; set; }
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
        public Byte Code { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class FightSettleResponseSettle
        {
            public Boolean IsWin { get; set; }
            public UInt32 StageId { get; set; }
            public Byte StarsMark { get; set; }
            public dynamic? RewardGoodsList { get; set; }
            public Byte LeftTime { get; set; }
            public Dictionary<dynamic, dynamic> NpcHpInfo { get; set; }
            public Byte UrgentEnventId { get; set; }
            public dynamic? ClientAssistInfo { get; set; }
            public dynamic[] FlopRewardList { get; set; }
            public dynamic? ArenaResult { get; set; }
            public dynamic? MultiRewardGoodsList { get; set; }
            public Byte ChallengeCount { get; set; }
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
        public UInt16 TaskId { get; set; }
    }


    [global::MessagePack.MessagePackObject(true)]
    public class FinishTaskResponse
    {
        public Byte Code { get; set; }
        [global::MessagePack.MessagePackObject(true)]
        public class FinishTaskResponseRewardGoodsList
        {
            public Byte RewardType { get; set; }
            public Byte TemplateId { get; set; }
            public UInt16 Count { get; set; }
            public Byte Level { get; set; }
            public Byte Quality { get; set; }
            public Byte Grade { get; set; }
            public Byte Breakthrough { get; set; }
            public Byte ConvertFrom { get; set; }
            public UInt32 Id { get; set; }
        }

        public FinishTaskResponseRewardGoodsList[] RewardGoodsList { get; set; }
    }
}
