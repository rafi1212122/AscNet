#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace AscNet.Common.MsgPack
{
    [MessagePack.MessagePackObject(true)]
    public class HandshakeRequest
    {
        public string Sha1 { get; set; }
        public string DocumentVersion { get; set; }
        public string ApplicationVersion { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class HandshakeResponse
    {
        public int Code { get; set; }
        public int UtcOpenTime { get; set; }
        public dynamic? Sha1Table { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class LoginRequest
    {
        public int LoginType { get; set; }
        public string ServerBean { get; set; }
        public int LoginPlatform { get; set; }
        public string ClientVersion { get; set; }
        public string DeviceId { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class LoginResponse
    {
        public int Code { get; set; }
        public int UtcOffset { get; set; }
        public uint UtcServerTime { get; set; }
        public string ReconnectToken { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyDailyLotteryData
    {
        public dynamic[] Lotteries { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyLogin
    {
        [MessagePack.MessagePackObject(true)]
        public class NotifyLoginPlayerData
        {
            public uint Id { get; set; }
            public string Name { get; set; }
            public int Level { get; set; }
            public string Sign { get; set; }
            public uint DisplayCharId { get; set; }
            [MessagePack.MessagePackObject(true)]
            public class NotifyLoginPlayerDataBirthday
            {
                public int Mon { get; set; }
                public int Day { get; set; }
            }

            public NotifyLoginPlayerDataBirthday Birthday { get; set; }
            public int HonorLevel { get; set; }
            public string ServerId { get; set; }
            public int Likes { get; set; }
            public int CurrTeamId { get; set; }
            public int ChallengeEventId { get; set; }
            public uint CurrHeadPortraitId { get; set; }
            public int CurrHeadFrameId { get; set; }
            public int CurrMedalId { get; set; }
            public int AppearanceShowType { get; set; }
            public int DailyReceiveGiftCount { get; set; }
            public int DailyActivenessRewardStatus { get; set; }
            public int WeeklyActivenessRewardStatus { get; set; }
            public int[] Marks { get; set; }
            public uint[] GuideData { get; set; }
            public int[] Communications { get; set; }
            public dynamic[] ShowCharacters { get; set; }
            public dynamic[] ShieldFuncList { get; set; }
            [MessagePack.MessagePackObject(true)]
            public class NotifyLoginPlayerDataAppearanceSettingInfo
            {
                public int TitleType { get; set; }
                public int CharacterType { get; set; }
                public int FashionType { get; set; }
                public int WeaponFashionType { get; set; }
                public int DormitoryType { get; set; }
                public int DormitoryId { get; set; }
            }

            public NotifyLoginPlayerDataAppearanceSettingInfo AppearanceSettingInfo { get; set; }
            public uint CreateTime { get; set; }
            public uint LastLoginTime { get; set; }
            public int ReportTime { get; set; }
            public uint ChangeNameTime { get; set; }
            public int Flags { get; set; }
        }

        public NotifyLoginPlayerData PlayerData { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyLoginTimeLimitCtrlConfigList
        {
            public int Id { get; set; }
            public uint StartTime { get; set; }
            public uint EndTime { get; set; }
        }

        public NotifyLoginTimeLimitCtrlConfigList[] TimeLimitCtrlConfigList { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyLoginSharePlatformConfigList
        {
            public int Id { get; set; }
            public int[] SdkId { get; set; }
        }

        public NotifyLoginSharePlatformConfigList[] SharePlatformConfigList { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyLoginItemList
        {
            public int Id { get; set; }
            public uint Count { get; set; }
            public int BuyTimes { get; set; }
            public int TotalBuyTimes { get; set; }
            public int LastBuyTime { get; set; }
            public uint RefreshTime { get; set; }
            public uint CreateTime { get; set; }
        }

        public NotifyLoginItemList[] ItemList { get; set; }
        public Dictionary<dynamic, dynamic> ItemRecycleDict { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyLoginCharacterList
        {
            public uint Id { get; set; }
            public int Level { get; set; }
            public int Exp { get; set; }
            public int Quality { get; set; }
            public int InitQuality { get; set; }
            public int Star { get; set; }
            public int Grade { get; set; }
            [MessagePack.MessagePackObject(true)]
            public class NotifyLoginCharacterListSkillList
            {
                public uint Id { get; set; }
                public int Level { get; set; }
            }

            public NotifyLoginCharacterListSkillList[] SkillList { get; set; }
            public dynamic[] EnhanceSkillList { get; set; }
            public uint FashionId { get; set; }
            public uint CreateTime { get; set; }
            public int TrustLv { get; set; }
            public int TrustExp { get; set; }
            public uint Ability { get; set; }
            public int LiberateLv { get; set; }
            [MessagePack.MessagePackObject(true)]
            public class NotifyLoginCharacterListCharacterHeadInfo
            {
                public int HeadFashionId { get; set; }
                public int HeadFashionType { get; set; }
            }

            public NotifyLoginCharacterListCharacterHeadInfo CharacterHeadInfo { get; set; }
        }

        public NotifyLoginCharacterList[] CharacterList { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyLoginEquipList
        {
            public int Id { get; set; }
            public uint TemplateId { get; set; }
            public uint CharacterId { get; set; }
            public int Level { get; set; }
            public int Exp { get; set; }
            public int Breakthrough { get; set; }
            public dynamic[] ResonanceInfo { get; set; }
            public dynamic[] UnconfirmedResonanceInfo { get; set; }
            public dynamic[] AwakeSlotList { get; set; }
            public bool IsLock { get; set; }
            public uint CreateTime { get; set; }
            public bool IsRecycle { get; set; }
        }

        public NotifyLoginEquipList[] EquipList { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyLoginFashionList
        {
            public uint Id { get; set; }
            public bool IsLock { get; set; }
        }

        public NotifyLoginFashionList[] FashionList { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyLoginHeadPortraitList
        {
            public uint Id { get; set; }
            public int LeftCount { get; set; }
            public uint BeginTime { get; set; }
        }

        public NotifyLoginHeadPortraitList[] HeadPortraitList { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyLoginBaseEquipLoginData
        {
            public dynamic[] BaseEquipList { get; set; }
            public dynamic[] DressedList { get; set; }
        }

        public NotifyLoginBaseEquipLoginData BaseEquipLoginData { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyLoginFubenData
        {
            public Dictionary<dynamic, dynamic> StageData { get; set; }
            [MessagePack.MessagePackObject(true)]
            public class NotifyLoginFubenDataFubenBaseData
            {
                public int RefreshTime { get; set; }
                public int SelectedCharId { get; set; }
                public int UrgentAlarmCount { get; set; }
                public int WeeklyUrgentCount { get; set; }
                public dynamic? DayUrgentCount { get; set; }
            }

            public NotifyLoginFubenDataFubenBaseData FubenBaseData { get; set; }
            public dynamic[] UnlockHideStages { get; set; }
            public dynamic[] StageDifficulties { get; set; }
        }

        public NotifyLoginFubenData FubenData { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyLoginFubenMainLineData
        {
            public uint[] TreasureData { get; set; }
            public Dictionary<dynamic, dynamic> LastPassStage { get; set; }
            public dynamic[] MainChapterEventInfos { get; set; }
        }

        public NotifyLoginFubenMainLineData FubenMainLineData { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyLoginFubenChapterExtraLoginData
        {
            public dynamic[] TreasureData { get; set; }
            public dynamic[] LastPassStage { get; set; }
            public dynamic[] ChapterEventInfos { get; set; }
        }

        public NotifyLoginFubenChapterExtraLoginData FubenChapterExtraLoginData { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyLoginFubenUrgentEventData
        {
            public dynamic? UrgentEventData { get; set; }
        }

        public NotifyLoginFubenUrgentEventData FubenUrgentEventData { get; set; }
        public dynamic[] AutoFightRecords { get; set; }
        public Dictionary<dynamic, dynamic> TeamGroupData { get; set; }
        public dynamic? TeamPrefabData { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyLoginSignInf
        {
            public int Id { get; set; }
            public int Round { get; set; }
            public int Day { get; set; }
            public bool Got { get; set; }
            public int FinishDay { get; set; }
        }

        public NotifyLoginSignInf[] SignInfos { get; set; }
        public dynamic[] AssignChapterRecord { get; set; }
        public dynamic[] WeaponFashionList { get; set; }
        public dynamic[] PartnerList { get; set; }
        public dynamic[] ShieldedProtocolList { get; set; }
        public dynamic? LimitedLoginData { get; set; }
        public uint UseBackgroundId { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyLoginFubenShortStoryLoginData
        {
            public dynamic[] TreasureData { get; set; }
            public dynamic[] LastPassStage { get; set; }
            public dynamic[] ChapterEventInfos { get; set; }
        }

        public NotifyLoginFubenShortStoryLoginData FubenShortStoryLoginData { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyPayInfo
    {
        public float TotalPayMoney { get; set; }
        public bool IsGetFirstPayReward { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyEquipChipGroupList
    {
        public dynamic[] ChipGroupDataList { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyEquipChipAutoRecycleSite
    {
        [MessagePack.MessagePackObject(true)]
        public class NotifyEquipChipAutoRecycleSiteChipRecycleSite
        {
            public int[] RecycleStar { get; set; }
            public int Days { get; set; }
            public int SetRecycleTime { get; set; }
        }

        public NotifyEquipChipAutoRecycleSiteChipRecycleSite ChipRecycleSite { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyEquipGuideData
    {
        [MessagePack.MessagePackObject(true)]
        public class NotifyEquipGuideDataEquipGuideData
        {
            public int TargetId { get; set; }
            public dynamic[] PutOnPosList { get; set; }
            public dynamic[] FinishedTargets { get; set; }
        }

        public NotifyEquipGuideDataEquipGuideData EquipGuideData { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyArchiveLoginData
    {
        [MessagePack.MessagePackObject(true)]
        public class NotifyArchiveLoginDataMonste
        {
            public uint Id { get; set; }
            public int Killed { get; set; }
        }

        public NotifyArchiveLoginDataMonste[] Monsters { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyArchiveLoginDataEqui
        {
            public uint Id { get; set; }
            public int Level { get; set; }
            public int Breakthrough { get; set; }
            public int ResonanceCount { get; set; }
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
        public uint[] UnlockCgs { get; set; }
        public dynamic[] UnlockStoryDetails { get; set; }
        public dynamic[] PartnerUnlockIds { get; set; }
        public dynamic[] PartnerSettings { get; set; }
        public uint[] UnlockPvDetails { get; set; }
        public dynamic[] UnlockMails { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyChatLoginData
    {
        public uint RefreshTime { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyChatLoginDataUnlockEmoj
        {
            public uint Id { get; set; }
            public int EndTime { get; set; }
        }

        public NotifyChatLoginDataUnlockEmoj[] UnlockEmojis { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifySocialData
    {
        public dynamic[] FriendData { get; set; }
        public dynamic[] ApplyData { get; set; }
        public dynamic[] Remarks { get; set; }
        public dynamic[] BlockData { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyTaskData
    {
        [MessagePack.MessagePackObject(true)]
        public class NotifyTaskDataTaskData
        {
            [MessagePack.MessagePackObject(true)]
            public class NotifyTaskDataTaskDataTas
            {
                public uint Id { get; set; }
                [MessagePack.MessagePackObject(true)]
                public class NotifyTaskDataTaskDataTasSchedule
                {
                    public uint Id { get; set; }
                    public int Value { get; set; }
                }

                public NotifyTaskDataTaskDataTasSchedule[] Schedule { get; set; }
                public int State { get; set; }
                public uint RecordTime { get; set; }
                public int ActivityId { get; set; }
            }

            public NotifyTaskDataTaskDataTas[] Tasks { get; set; }
            public uint[] Course { get; set; }
            public int[] FinishedTasks { get; set; }
            public int[] NewPlayerRewardRecord { get; set; }
            public dynamic[] TaskLimitIdActiveInfos { get; set; }
            public dynamic[] NewbieRecvProgress { get; set; }
            public bool NewbieHonorReward { get; set; }
            public int NewbieUnlockPeriod { get; set; }
        }

        public NotifyTaskDataTaskData TaskData { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyActivenessStatus
    {
        public int DailyActivenessRewardStatus { get; set; }
        public int WeeklyActivenessRewardStatus { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyNewPlayerTaskStatus
    {
        public uint NewPlayerTaskActiveDay { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyRegression2Data
    {
        [MessagePack.MessagePackObject(true)]
        public class NotifyRegression2DataData
        {
            [MessagePack.MessagePackObject(true)]
            public class NotifyRegression2DataDataActivityData
            {
                public int Id { get; set; }
                public int BeginTime { get; set; }
                public int State { get; set; }
            }

            public NotifyRegression2DataDataActivityData ActivityData { get; set; }
            public dynamic? SignInData { get; set; }
            public dynamic? InviteData { get; set; }
            public dynamic[] GachaDatas { get; set; }
        }

        public NotifyRegression2DataData Data { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyMaintainerActionData
    {
        public int Id { get; set; }
        public uint ResetTime { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyMaintainerActionDataNod
        {
            public int NodeId { get; set; }
            public int NodeType { get; set; }
            public int EventId { get; set; }
            public string Value { get; set; }
        }

        public NotifyMaintainerActionDataNod[] Nodes { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyMaintainerActionDataPlaye
        {
            public uint PlayerId { get; set; }
            public string PlayerName { get; set; }
            public uint HeadPortraitId { get; set; }
            public int HeadFrameId { get; set; }
            public int NodeId { get; set; }
            public bool IsNodeTriggered { get; set; }
            public bool Reverse { get; set; }
        }

        public NotifyMaintainerActionDataPlaye[] Players { get; set; }
        public int[] Cards { get; set; }
        public int FightWinCount { get; set; }
        public int BoxCount { get; set; }
        public int UsedActionCount { get; set; }
        public int ExtraActionCount { get; set; }
        public bool HasWarehouseNode { get; set; }
        public int WarehouseFinishCount { get; set; }
        public bool HasMentorNode { get; set; }
        public int MentorStatus { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyAllRedEnvelope
    {
        public dynamic[] Envelopes { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyScoreTitleData
    {
        public dynamic[] TitleInfos { get; set; }
        public dynamic[] HideTypes { get; set; }
        public bool IsHideCollection { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyScoreTitleDataWallInf
        {
            public int Id { get; set; }
            public uint PedestalId { get; set; }
            public uint BackgroundId { get; set; }
            public bool IsShow { get; set; }
            public dynamic[] CollectionSetInfos { get; set; }
        }

        public NotifyScoreTitleDataWallInf[] WallInfos { get; set; }
        public ushort[] UnlockedDecorationIds { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyBfrtData
    {
        [MessagePack.MessagePackObject(true)]
        public class NotifyBfrtDataBfrtData
        {
            public dynamic[] BfrtGroupRecords { get; set; }
            public dynamic[] BfrtTeamInfos { get; set; }
        }

        public NotifyBfrtDataBfrtData BfrtData { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyTask
    {
        [MessagePack.MessagePackObject(true)]
        public class NotifyTaskTasks
        {
            [MessagePack.MessagePackObject(true)]
            public class NotifyTaskTasksTas
            {
                public uint Id { get; set; }
                [MessagePack.MessagePackObject(true)]
                public class NotifyTaskTasksTasSchedule
                {
                    public uint Id { get; set; }
                    public int Value { get; set; }
                }

                public NotifyTaskTasksTasSchedule[] Schedule { get; set; }
                public int State { get; set; }
                public uint RecordTime { get; set; }
                public int ActivityId { get; set; }
            }

            public NotifyTaskTasksTas[] Tasks { get; set; }
        }

        public NotifyTaskTasks Tasks { get; set; }
        public dynamic? TaskLimitIdActiveInfos { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyGuildEvent
    {
        public int Type { get; set; }
        public uint Value { get; set; }
        public int Value2 { get; set; }
        public dynamic? Str1 { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyAssistData
    {
        [MessagePack.MessagePackObject(true)]
        public class NotifyAssistDataAssistData
        {
            public uint AssistCharacterId { get; set; }
        }

        public NotifyAssistDataAssistData AssistData { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyWorkNextRefreshTime
    {
        public uint NextRefreshTime { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyDormitoryData
    {
        public dynamic[] FurnitureCreateList { get; set; }
        public dynamic[] WorkList { get; set; }
        public uint[] FurnitureUnlockList { get; set; }
        public int SnapshotTimes { get; set; }
        public dynamic[] DormitoryList { get; set; }
        public dynamic[] VisitorList { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyDormitoryDataFurnitureList
        {
            public int Id { get; set; }
            public uint ConfigId { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public int Angle { get; set; }
            public int DormitoryId { get; set; }
            public uint Addition { get; set; }
            public int[] AttrList { get; set; }
            public bool IsLocked { get; set; }
        }

        public NotifyDormitoryDataFurnitureList[] FurnitureList { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyDormitoryDataCharacterList
        {
            public uint CharacterId { get; set; }
            public sbyte DormitoryId { get; set; }
            public int Mood { get; set; }
            public int Vitality { get; set; }
            public int MoodSpeed { get; set; }
            public int VitalitySpeed { get; set; }
            public uint LastFondleRecoveryTime { get; set; }
            public int LeftFondleCount { get; set; }
            public dynamic[] EventList { get; set; }
        }

        public NotifyDormitoryDataCharacterList[] CharacterList { get; set; }
        public dynamic[] Layouts { get; set; }
        public dynamic[] BindRelations { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyNameplateLoginData
    {
        public int CurrentWearNameplate { get; set; }
        public dynamic[] UnlockNameplates { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyGuildDormPlayerData
    {
        [MessagePack.MessagePackObject(true)]
        public class NotifyGuildDormPlayerDataGuildDormData
        {
            public int CurrentCharacterId { get; set; }
            public int DailyInteractRewardTotalTimes { get; set; }
            public int DailyInteractRewardCurTimes { get; set; }
        }

        public NotifyGuildDormPlayerDataGuildDormData GuildDormData { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyBountyTaskInfo
    {
        [MessagePack.MessagePackObject(true)]
        public class NotifyBountyTaskInfoTaskInfo
        {
            public int RankLevel { get; set; }
            public dynamic[] TaskCards { get; set; }
            public int TaskPoolRefreshCount { get; set; }
            [MessagePack.MessagePackObject(true)]
            public class NotifyBountyTaskInfoTaskInfoTaskPool
            {
                public int Id { get; set; }
                public uint StageId { get; set; }
                public uint RewardId { get; set; }
                public uint EventId { get; set; }
                public uint DifficultStageId { get; set; }
                public int Status { get; set; }
            }

            public NotifyBountyTaskInfoTaskInfoTaskPool[] TaskPool { get; set; }
        }

        public NotifyBountyTaskInfoTaskInfo TaskInfo { get; set; }
        public uint RefreshTime { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyFiveTwentyRecord
    {
        public dynamic[] CharacterIds { get; set; }
        public dynamic[] GroupRecord { get; set; }
        public int ActivityNo { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class PurchaseDailyNotify
    {
        public dynamic[] ExpireInfoList { get; set; }
        public dynamic[] DailyRewardInfoList { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class PurchaseDailyNotifyFreeRewardInfoList
        {
            public uint Id { get; set; }
            public string Name { get; set; }
        }

        public PurchaseDailyNotifyFreeRewardInfoList[] FreeRewardInfoList { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyPurchaseRecommendConfig
    {
        [MessagePack.MessagePackObject(true)]
        public class NotifyPurchaseRecommendConfigData
        {
            public Dictionary<dynamic, dynamic> AddOrModifyConfigs { get; set; }
            public dynamic? RemoveIds { get; set; }
        }

        public NotifyPurchaseRecommendConfigData Data { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyBackgroundLoginData
    {
        public uint[] HaveBackgroundIds { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyMedalData
    {
        public dynamic[] MedalInfos { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyExploreData
    {
        public dynamic[] ChapterDatas { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyGatherRewardList
    {
        public int[] GatherRewards { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyDrawTicketData
    {
        public dynamic[] DrawTicketInfos { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyAccumulatedPayData
    {
        public int PayId { get; set; }
        public float PayMoney { get; set; }
        public dynamic[] PayRewardIds { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyArenaActivity
    {
        public int ActivityNo { get; set; }
        public int ChallengeId { get; set; }
        public int Status { get; set; }
        public uint NextStatusTime { get; set; }
        public int ArenaLevel { get; set; }
        public int JoinActivity { get; set; }
        public int UnlockCount { get; set; }
        public uint TeamTime { get; set; }
        public uint FightTime { get; set; }
        public uint ResultTime { get; set; }
        public dynamic[] MaxPointStageList { get; set; }
        public int ContributeScore { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyPrequelUnlockChallengeStages
    {
        public dynamic[] UnlockChallengeStages { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyPrequelChallengeRefreshTime
    {
        public uint NextRefreshTime { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyFubenPrequelData
    {
        [MessagePack.MessagePackObject(true)]
        public class NotifyFubenPrequelDataFubenPrequelData
        {
            public dynamic[] RewardedStages { get; set; }
            public dynamic[] UnlockChallengeStages { get; set; }
        }

        public NotifyFubenPrequelDataFubenPrequelData FubenPrequelData { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyMainLineActivity
    {
        public ushort[] Chapters { get; set; }
        public int BfrtChapter { get; set; }
        public uint EndTime { get; set; }
        public int HideChapterBeginTime { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyDailyFubenLoginData
    {
        public uint RefreshTime { get; set; }
        public dynamic[] Records { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyBirthdayPlot
    {
        public uint NextActiveYear { get; set; }
        public int IsChange { get; set; }
        public dynamic[] UnLockCg { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyBossActivityData
    {
        public int ActivityId { get; set; }
        public int SectionId { get; set; }
        public int Schedule { get; set; }
        public dynamic[] StageStarInfos { get; set; }
        public dynamic[] StarRewardIds { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyBriefStoryData
    {
        public dynamic[] FinishedIds { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyChessPursuitGroupInfo
    {
        public dynamic[] MapDBList { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyChessPursuitGroupInfoMapBossList
        {
            public int Id { get; set; }
            public int InitHp { get; set; }
            public int SubBossMaxHp { get; set; }
            public int BossStepMin { get; set; }
            public int BossStepMax { get; set; }
            public float BattleHurtRate { get; set; }
            public int BattleHurtMax { get; set; }
            public int SelfHpRate { get; set; }
            public int SelfHpMax { get; set; }
            public int ConvertHurtRate { get; set; }
        }

        public NotifyChessPursuitGroupInfoMapBossList[] MapBossList { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyClickClearData
    {
        public dynamic[] Activities { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyCourseData
    {
        [MessagePack.MessagePackObject(true)]
        public class NotifyCourseDataData
        {
            public int TotalLessonPoint { get; set; }
            public int MaxTotalLessonPoint { get; set; }
            public dynamic[] ChapterDataList { get; set; }
            public dynamic? StageDataDict { get; set; }
            public dynamic[] RewardIds { get; set; }
        }

        public NotifyCourseDataData Data { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyActivityDrawList
    {
        public ushort[] DrawIdList { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyActivityDrawGroupCount
    {
        public int Count { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyExperimentData
    {
        public dynamic[] FinishIds { get; set; }
        public dynamic[] ExperimentInfos { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyBabelTowerActivityStatus
    {
        public int ActivityNo { get; set; }
        public int Status { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyBabelTowerData
    {
        public int ActivityNo { get; set; }
        public int MaxScore { get; set; }
        public int RankLevel { get; set; }
        public dynamic[] StageDatas { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyBabelTowerDataExtraData
        {
            public int ActivityNo { get; set; }
            public int MaxScore { get; set; }
            public int RankLevel { get; set; }
            public dynamic[] StageDatas { get; set; }
        }

        public NotifyBabelTowerDataExtraData ExtraData { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyFubenBossSingleData
    {
        [MessagePack.MessagePackObject(true)]
        public class NotifyFubenBossSingleDataFubenBossSingleData
        {
            public int ActivityNo { get; set; }
            public int TotalScore { get; set; }
            public int MaxScore { get; set; }
            public int OldLevelType { get; set; }
            public int LevelType { get; set; }
            public int ChallengeCount { get; set; }
            public uint RemainTime { get; set; }
            public int AutoFightCount { get; set; }
            public dynamic? CharacterPoints { get; set; }
            public dynamic[] HistoryList { get; set; }
            public dynamic[] RewardIds { get; set; }
            public int RankPlatform { get; set; }
            public int[] BossList { get; set; }
            public dynamic[] TrialStageInfoList { get; set; }
        }

        public NotifyFubenBossSingleDataFubenBossSingleData FubenBossSingleData { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyFestivalData
    {
        public dynamic[] FestivalInfos { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyPracticeData
    {
        [MessagePack.MessagePackObject(true)]
        public class NotifyPracticeDataChapterInf
        {
            public int Id { get; set; }
            public uint[] FinishStages { get; set; }
        }

        public NotifyPracticeDataChapterInf[] ChapterInfos { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyTrialData
    {
        public int[] FinishTrial { get; set; }
        public int[] RewardRecord { get; set; }
        public dynamic[] TypeRewardRecord { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyPivotCombatData
    {
        [MessagePack.MessagePackObject(true)]
        public class NotifyPivotCombatDataPivotCombatData
        {
            public int ActivityId { get; set; }
            public int Difficulty { get; set; }
            public dynamic[] RegionDataList { get; set; }
        }

        public NotifyPivotCombatDataPivotCombatData PivotCombatData { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifySettingLoadingOption
    {
        public dynamic? LoadingData { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyRepeatChallengeData
    {
        public int Id { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyRepeatChallengeDataExpInfo
        {
            public int Level { get; set; }
            public int Exp { get; set; }
        }

        public NotifyRepeatChallengeDataExpInfo ExpInfo { get; set; }
        public dynamic[] RcChapters { get; set; }
        public dynamic[] RewardIds { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyPlayerReportData
    {
        [MessagePack.MessagePackObject(true)]
        public class NotifyPlayerReportDataReportData
        {
            public int ReportTimes { get; set; }
            public int LastReportTime { get; set; }
        }

        public NotifyPlayerReportDataReportData ReportData { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyReviewConfig
    {
        [MessagePack.MessagePackObject(true)]
        public class NotifyReviewConfigReviewActivityConfigList
        {
            public int Id { get; set; }
            public uint StartTime { get; set; }
            public uint EndTime { get; set; }
            public uint RewardId { get; set; }
        }

        public NotifyReviewConfigReviewActivityConfigList[] ReviewActivityConfigList { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyStrongholdLoginData
    {
        public int Id { get; set; }
        public uint BeginTime { get; set; }
        public uint FightBeginTime { get; set; }
        public int CurDay { get; set; }
        public int AssistCharacterId { get; set; }
        public int SetAssistCharacterTime { get; set; }
        public int BorrowCount { get; set; }
        public uint ElectricEnergy { get; set; }
        public int Endurance { get; set; }
        public int MineralLeft { get; set; }
        public int TotalMineral { get; set; }
        public dynamic[] ElectricCharacterIds { get; set; }
        public dynamic[] FinishGroupIds { get; set; }
        public dynamic[] FinishGroupInfos { get; set; }
        public dynamic[] HistoryFinishGroupInfos { get; set; }
        public dynamic[] GroupInfos { get; set; }
        public dynamic[] TeamInfos { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyStrongholdLoginDataGroupStageDat
        {
            public int Id { get; set; }
            public uint[] StageIds { get; set; }
            public Dictionary<dynamic, dynamic> StageBuffId { get; set; }
            public int SupportId { get; set; }
        }

        public NotifyStrongholdLoginDataGroupStageDat[] GroupStageDatas { get; set; }
        public int[] RuneList { get; set; }
        public dynamic[] RewardIds { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyStrongholdLoginDataLastResultRecord
        {
            public int Id { get; set; }
            public int FinishCount { get; set; }
            public int MinerCount { get; set; }
            public int MineralCount { get; set; }
            public int AssistCount { get; set; }
            public int AssistRewardValue { get; set; }
        }

        public NotifyStrongholdLoginDataLastResultRecord LastResultRecord { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyStrongholdLoginDataMineRecor
        {
            public int Day { get; set; }
            public int MinerCount { get; set; }
            public int MineralCount { get; set; }
            public bool IsStay { get; set; }
        }

        public NotifyStrongholdLoginDataMineRecor[] MineRecords { get; set; }
        public int LevelId { get; set; }
        public dynamic[] StayDays { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifySummerSignInData
    {
        public int ActId { get; set; }
        public dynamic[] MsgIdList { get; set; }
        public int SurplusTimes { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyTaikoMasterData
    {
        [MessagePack.MessagePackObject(true)]
        public class NotifyTaikoMasterDataTaikoMasterData
        {
            public int ActivityId { get; set; }
            public dynamic[] StageDataList { get; set; }
            [MessagePack.MessagePackObject(true)]
            public class NotifyTaikoMasterDataTaikoMasterDataSetting
            {
                public int AppearOffset { get; set; }
                public int JudgeOffset { get; set; }
            }

            public NotifyTaikoMasterDataTaikoMasterDataSetting Setting { get; set; }
        }

        public NotifyTaikoMasterDataTaikoMasterData TaikoMasterData { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyTeachingActivityInfo
    {
        public dynamic[] ActivityInfo { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyTheatreData
    {
        public int CurChapterId { get; set; }
        public int CurRoleLv { get; set; }
        public int DifficultyId { get; set; }
        public int KeepsakeId { get; set; }
        public dynamic[] UnlockPowerIds { get; set; }
        public dynamic[] UnlockPowerFavorIds { get; set; }
        public dynamic[] EffectPowerFavorIds { get; set; }
        public dynamic[] Skills { get; set; }
        public dynamic[] RecruitRole { get; set; }
        public dynamic[] Keepsakes { get; set; }
        public dynamic[] Decorations { get; set; }
        public dynamic? CurChapterDb { get; set; }
        public int ReopenCount { get; set; }
        public dynamic[] SkillIllustratedBook { get; set; }
        public dynamic? SingleTeamData { get; set; }
        public dynamic[] MultiTeamDatas { get; set; }
        public int UseOwnCharacter { get; set; }
        public int FavorCoin { get; set; }
        public int DecorationCoin { get; set; }
        public dynamic[] PassChapterId { get; set; }
        public dynamic? PassEventRecord { get; set; }
        public int PassNodeCount { get; set; }
        public dynamic[] EndingRecord { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyVoteData
    {
        public dynamic[] VoteAlarmDic { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyTRPGData
    {
        public uint CurTargetLink { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyTRPGDataBaseInfo
        {
            public int Level { get; set; }
            public int Exp { get; set; }
            public int Endurance { get; set; }
        }

        public NotifyTRPGDataBaseInfo BaseInfo { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyTRPGDataBossInfo
        {
            public int Id { get; set; }
            public int ChallengeCount { get; set; }
            public dynamic[] PhasesRewardList { get; set; }
        }

        public NotifyTRPGDataBossInfo BossInfo { get; set; }
        public dynamic[] TargetList { get; set; }
        public dynamic[] RewardList { get; set; }
        public dynamic[] FuncList { get; set; }
        public dynamic[] Characters { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyTRPGDataShopInf
        {
            public int DisCount { get; set; }
            public int AddBuyCount { get; set; }
            public uint Id { get; set; }
            public dynamic[] ItemInfos { get; set; }
        }

        public NotifyTRPGDataShopInf[] ShopInfos { get; set; }
        public dynamic[] MazeInfos { get; set; }
        public dynamic[] MemoirList { get; set; }
        public int ItemCapacityAdd { get; set; }
        public bool IsNormalPage { get; set; }
        public dynamic[] StageList { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyBiancaTheatreActivityData
    {
        public int CurActivityId { get; set; }
        public int CurChapterId { get; set; }
        public int DifficultyId { get; set; }
        public int CurTeamId { get; set; }
        public dynamic? CurChapterDb { get; set; }
        public dynamic[] Characters { get; set; }
        public dynamic[] Items { get; set; }
        public int TotalExp { get; set; }
        public dynamic[] GetRewardIds { get; set; }
        public dynamic[] StrengthenDbs { get; set; }
        public dynamic? SingleTeamData { get; set; }
        public dynamic[] UnlockItemId { get; set; }
        public dynamic[] UnlockTeamId { get; set; }
        public dynamic[] UnlockDifficultyId { get; set; }
        public dynamic[] TeamRecords { get; set; }
        public dynamic[] PassChapterIds { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyMentorData
    {
        public int PlayerType { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyMentorDataTeacher
        {
            public int PlayerId { get; set; }
            public dynamic? PlayerName { get; set; }
            public int Level { get; set; }
            public int HeadPortraitId { get; set; }
            public int HeadFrameId { get; set; }
            public bool IsGraduate { get; set; }
            public dynamic? Tag { get; set; }
            public dynamic? OnlineTag { get; set; }
            public dynamic? Announcement { get; set; }
            public int StudentCount { get; set; }
            public dynamic? StudentTask { get; set; }
            public bool IsOnline { get; set; }
            public dynamic? SystemTask { get; set; }
            public dynamic? WeeklyTask { get; set; }
            public int KizunaAmount { get; set; }
            public int JoinTime { get; set; }
            public int ReachTime { get; set; }
            public int LastLoginTime { get; set; }
            public int SendGiftCount { get; set; }
        }

        public NotifyMentorDataTeacher Teacher { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class NotifyMentorDataStuden
        {
            public uint PlayerId { get; set; }
            public string PlayerName { get; set; }
            public int Level { get; set; }
            public uint HeadPortraitId { get; set; }
            public int HeadFrameId { get; set; }
            public bool IsGraduate { get; set; }
            public dynamic? Tag { get; set; }
            public dynamic? OnlineTag { get; set; }
            public dynamic? Announcement { get; set; }
            public int StudentCount { get; set; }
            public dynamic[] StudentTask { get; set; }
            public bool IsOnline { get; set; }
            [MessagePack.MessagePackObject(true)]
            public class NotifyMentorDataStudenSystemTask
            {
                public uint TaskId { get; set; }
                public int State { get; set; }
                public dynamic[] Schedule { get; set; }
                public int Status { get; set; }
                public int RewardId { get; set; }
                public dynamic[] EquipList { get; set; }
                public bool HasChange { get; set; }
            }

            public NotifyMentorDataStudenSystemTask[] SystemTask { get; set; }
            public dynamic[] WeeklyTask { get; set; }
            public int KizunaAmount { get; set; }
            public int JoinTime { get; set; }
            public int ReachTime { get; set; }
            public int LastLoginTime { get; set; }
            public int SendGiftCount { get; set; }
        }

        public NotifyMentorDataStuden[] Students { get; set; }
        public dynamic[] ApplyList { get; set; }
        public int GraduateStudentCount { get; set; }
        public dynamic[] StageReward { get; set; }
        public dynamic[] WeeklyTaskReward { get; set; }
        public int WeeklyTaskCompleteCount { get; set; }
        public int[] Tag { get; set; }
        public int[] OnlineTag { get; set; }
        public string Announcement { get; set; }
        public int DailyChangeTaskCount { get; set; }
        public int WeeklyLevel { get; set; }
        public int MonthlyStudentCount { get; set; }
        public dynamic? Message { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyMentorChat
    {
        public dynamic[] ChatMessages { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyMaintainerActionDailyReset
    {
        public int UsedActionCount { get; set; }
        public int ExtraActionCount { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyGuildData
    {
        public int GuildId { get; set; }
        public string GuildName { get; set; }
        public int GuildLevel { get; set; }
        public int IconId { get; set; }
        public int GuildRankLevel { get; set; }
        public int HasContributeReward { get; set; }
        public bool HasRecruit { get; set; }
        public int BossEndTime { get; set; }
        public int FreeChangeGuildNameCount { get; set; }
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

            public NotifyMailsNewMailListRewardGoodsList[] RewardGoodsList { get; set; }
            public bool IsForbidDelete { get; set; }
        }

        public NotifyMailsNewMailList[] NewMailList { get; set; }
        public dynamic? ExpireIdList { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class EnterWorldChatResponse
    {
        public int Code { get; set; }
        public int ChannelId { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class GetWorldChannelInfoResponse
    {
        public int Code { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class GetWorldChannelInfoResponseChannelInf
        {
            public int ChannelId { get; set; }
            public int PlayerNum { get; set; }
        }

        public GetWorldChannelInfoResponseChannelInf[] ChannelInfos { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class HeartbeatResponse
    {
        public uint UtcServerTime { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class GetPurchaseListRequest
    {
        public int[] UiTypeList { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class GetPurchaseListResponse
    {
        public int Code { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class GetPurchaseListResponsePurchaseInfoList
        {
            public uint Id { get; set; }
            public int TimeToInvalid { get; set; }
            public int TimeToShelve { get; set; }
            public int TimeToUnShelve { get; set; }
            public int BuyTimes { get; set; }
            public int BuyLimitTimes { get; set; }
            public int ConsumeId { get; set; }
            public int ConsumeCount { get; set; }
            [MessagePack.MessagePackObject(true)]
            public class GetPurchaseListResponsePurchaseInfoListRewardGoodsList
            {
                public int RewardType { get; set; }
                public int TemplateId { get; set; }
                public uint Count { get; set; }
                public int Level { get; set; }
                public int Quality { get; set; }
                public int Grade { get; set; }
                public int Breakthrough { get; set; }
                public int ConvertFrom { get; set; }
                public uint Id { get; set; }
            }

            public GetPurchaseListResponsePurchaseInfoListRewardGoodsList[] RewardGoodsList { get; set; }
            [MessagePack.MessagePackObject(true)]
            public class GetPurchaseListResponsePurchaseInfoListDailyRewardGoodsList
            {
                public int RewardType { get; set; }
                public int TemplateId { get; set; }
                public int Count { get; set; }
                public int Level { get; set; }
                public int Quality { get; set; }
                public int Grade { get; set; }
                public int Breakthrough { get; set; }
                public int ConvertFrom { get; set; }
                public uint Id { get; set; }
            }

            public GetPurchaseListResponsePurchaseInfoListDailyRewardGoodsList[] DailyRewardGoodsList { get; set; }
            public dynamic? FirstRewardGoods { get; set; }
            public dynamic? ExtraRewardGoods { get; set; }
            public int DailyRewardRemainDay { get; set; }
            public bool IsDailyRewardGet { get; set; }
            public string Name { get; set; }
            public string Desc { get; set; }
            public string Icon { get; set; }
            public int UiType { get; set; }
            public int SignInId { get; set; }
            public int Tag { get; set; }
            public int Priority { get; set; }
            [MessagePack.MessagePackObject(true)]
            public class GetPurchaseListResponsePurchaseInfoListClientResetInfo
            {
                public int ResetType { get; set; }
                public int DayCount { get; set; }
            }

            public GetPurchaseListResponsePurchaseInfoListClientResetInfo ClientResetInfo { get; set; }
            public bool IsUseMail { get; set; }
            public dynamic? NormalDiscounts { get; set; }
            public dynamic? DiscountCouponInfos { get; set; }
            public dynamic? DiscountShowStr { get; set; }
            public int LastBuyTime { get; set; }
            public int MailCount { get; set; }
            public dynamic? PayKeySuffix { get; set; }
            public uint[] MutexPurchaseIds { get; set; }
            public int ConvertSwitch { get; set; }
            public bool CanMultiply { get; set; }
            public dynamic? FashionLabel { get; set; }
        }

        public GetPurchaseListResponsePurchaseInfoList[] PurchaseInfoList { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class OfflineMessageRequest
    {
        public sbyte MessageId { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class OfflineMessageResponse
    {
        public int Code { get; set; }
        public dynamic? Messages { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class DoClientTaskEventRequest
    {
        public int ClientTaskType { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class DoClientTaskEventResponse
    {
        public int Code { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class SignInRequest
    {
        public int Id { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyItemDataList
    {
        [MessagePack.MessagePackObject(true)]
        public class NotifyItemDataListItemDataList
        {
            public uint Id { get; set; }
            public int Count { get; set; }
            public int BuyTimes { get; set; }
            public int TotalBuyTimes { get; set; }
            public int LastBuyTime { get; set; }
            public uint RefreshTime { get; set; }
            public uint CreateTime { get; set; }
        }

        public NotifyItemDataListItemDataList[] ItemDataList { get; set; }
        public dynamic? ItemRecycleDict { get; set; }
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

        public SignInResponseRewardGoodsList[] RewardGoodsList { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyEquipDataList
    {
        [MessagePack.MessagePackObject(true)]
        public class NotifyEquipDataListEquipDataList
        {
            public uint Id { get; set; }
            public uint TemplateId { get; set; }
            public int CharacterId { get; set; }
            public int Level { get; set; }
            public int Exp { get; set; }
            public int Breakthrough { get; set; }
            public dynamic[] ResonanceInfo { get; set; }
            public dynamic[] UnconfirmedResonanceInfo { get; set; }
            public dynamic[] AwakeSlotList { get; set; }
            public bool IsLock { get; set; }
            public uint CreateTime { get; set; }
            public bool IsRecycle { get; set; }
        }

        public NotifyEquipDataListEquipDataList[] EquipDataList { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class CharacterLevelUpRequest
    {
        public Dictionary<dynamic, dynamic> UseItems { get; set; }
        public uint TemplateId { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class NotifyCharacterDataList
    {
        [MessagePack.MessagePackObject(true)]
        public class NotifyCharacterDataListCharacterDataList
        {
            public uint Id { get; set; }
            public int Level { get; set; }
            public int Exp { get; set; }
            public int Quality { get; set; }
            public int InitQuality { get; set; }
            public int Star { get; set; }
            public int Grade { get; set; }
            [MessagePack.MessagePackObject(true)]
            public class NotifyCharacterDataListCharacterDataListSkillList
            {
                public uint Id { get; set; }
                public int Level { get; set; }
            }

            public NotifyCharacterDataListCharacterDataListSkillList[] SkillList { get; set; }
            public dynamic[] EnhanceSkillList { get; set; }
            public uint FashionId { get; set; }
            public uint CreateTime { get; set; }
            public int TrustLv { get; set; }
            public int TrustExp { get; set; }
            public uint Ability { get; set; }
            public int LiberateLv { get; set; }
            [MessagePack.MessagePackObject(true)]
            public class NotifyCharacterDataListCharacterDataListCharacterHeadInfo
            {
                public int HeadFashionId { get; set; }
                public int HeadFashionType { get; set; }
            }

            public NotifyCharacterDataListCharacterDataListCharacterHeadInfo CharacterHeadInfo { get; set; }
        }

        public NotifyCharacterDataListCharacterDataList[] CharacterDataList { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class CharacterLevelUpResponse
    {
        public int Code { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class AreaDataResponse
    {
        public int Code { get; set; }
        public int TotalPoint { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class AreaDataResponseAreaList
        {
            public int AreaId { get; set; }
            public int Lock { get; set; }
            public int Point { get; set; }
            [MessagePack.MessagePackObject(true)]
            public class AreaDataResponseAreaListLordList
            {
                public uint Id { get; set; }
                public string Name { get; set; }
                public uint CurrHeadPortraitId { get; set; }
                public int CurrHeadFrameId { get; set; }
                public uint Point { get; set; }
            }

            public AreaDataResponseAreaListLordList[] LordList { get; set; }
            public dynamic? StageInfos { get; set; }
        }

        public AreaDataResponseAreaList[] AreaList { get; set; }
        public uint GroupFightEvent { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class Ping
    {
        public ulong UtcTime { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class Pong
    {
        public ulong UtcTime { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class TeamSetTeamRequest
    {
        [MessagePack.MessagePackObject(true)]
        public class TeamSetTeamRequestTeamData
        {
            public int TeamId { get; set; }
            public int CaptainPos { get; set; }
            public int FirstFightPos { get; set; }
            public string TeamName { get; set; }
            public Dictionary<dynamic, dynamic> TeamData { get; set; }
        }

        public TeamSetTeamRequestTeamData TeamData { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class TeamSetTeamResponse
    {
        public int Code { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class PreFightRequest
    {
        [MessagePack.MessagePackObject(true)]
        public class PreFightRequestPreFightData
        {
            public int ChallengeCount { get; set; }
            public bool IsHasAssist { get; set; }
            public int FirstFightPos { get; set; }
            public uint[] CardIds { get; set; }
            public int CaptainPos { get; set; }
            public uint StageId { get; set; }
        }

        public PreFightRequestPreFightData PreFightData { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class PreFightResponse
    {
        public int Code { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class PreFightResponseFightData
        {
            public bool Online { get; set; }
            public uint FightId { get; set; }
            public dynamic? RoomId { get; set; }
            public int OnlineMode { get; set; }
            public uint Seed { get; set; }
            public uint StageId { get; set; }
            public int RebootId { get; set; }
            public uint PassTimeLimit { get; set; }
            public int StarsMark { get; set; }
            public dynamic? MonsterLevel { get; set; }
            public dynamic[] EventIds { get; set; }
            public dynamic? FightEventsWithLevel { get; set; }
            public dynamic[] NormalEventIds { get; set; }
            [MessagePack.MessagePackObject(true)]
            public class PreFightResponseFightDataRoleData
            {
                public uint Id { get; set; }
                public int Camp { get; set; }
                public string Name { get; set; }
                public bool IsRobot { get; set; }
                public int CaptainIndex { get; set; }
                public int FirstFightPos { get; set; }
                public Dictionary<dynamic, dynamic> NpcData { get; set; }
                public dynamic? CustomNpc { get; set; }
                [MessagePack.MessagePackObject(true)]
                public class PreFightResponseFightDataRoleDataAssistNpcData
                {
                    public uint Id { get; set; }
                    public int Level { get; set; }
                    public string Name { get; set; }
                    [MessagePack.MessagePackObject(true)]
                    public class PreFightResponseFightDataRoleDataAssistNpcDataNpcData
                    {
                        [MessagePack.MessagePackObject(true)]
                        public class PreFightResponseFightDataRoleDataAssistNpcDataNpcDataCharacter
                        {
                            public uint Id { get; set; }
                            public int Level { get; set; }
                            public int Exp { get; set; }
                            public int Quality { get; set; }
                            public int InitQuality { get; set; }
                            public int Star { get; set; }
                            public int Grade { get; set; }
                            [MessagePack.MessagePackObject(true)]
                            public class PreFightResponseFightDataRoleDataAssistNpcDataNpcDataCharacterSkillList
                            {
                                public uint Id { get; set; }
                                public int Level { get; set; }
                            }

                            public PreFightResponseFightDataRoleDataAssistNpcDataNpcDataCharacterSkillList[] SkillList { get; set; }
                            public dynamic[] EnhanceSkillList { get; set; }
                            public uint FashionId { get; set; }
                            public uint CreateTime { get; set; }
                            public int TrustLv { get; set; }
                            public int TrustExp { get; set; }
                            public int Ability { get; set; }
                            public int LiberateLv { get; set; }
                            [MessagePack.MessagePackObject(true)]
                            public class PreFightResponseFightDataRoleDataAssistNpcDataNpcDataCharacterCharacterHeadInfo
                            {
                                public uint HeadFashionId { get; set; }
                                public int HeadFashionType { get; set; }
                            }

                            public PreFightResponseFightDataRoleDataAssistNpcDataNpcDataCharacterCharacterHeadInfo CharacterHeadInfo { get; set; }
                        }

                        public PreFightResponseFightDataRoleDataAssistNpcDataNpcDataCharacter Character { get; set; }
                        [MessagePack.MessagePackObject(true)]
                        public class PreFightResponseFightDataRoleDataAssistNpcDataNpcDataEqui
                        {
                            public int Id { get; set; }
                            public uint TemplateId { get; set; }
                            public uint CharacterId { get; set; }
                            public int Level { get; set; }
                            public int Exp { get; set; }
                            public int Breakthrough { get; set; }
                            public dynamic[] ResonanceInfo { get; set; }
                            public dynamic[] UnconfirmedResonanceInfo { get; set; }
                            public dynamic[] AwakeSlotList { get; set; }
                            public bool IsLock { get; set; }
                            public uint CreateTime { get; set; }
                            public bool IsRecycle { get; set; }
                        }

                        public PreFightResponseFightDataRoleDataAssistNpcDataNpcDataEqui[] Equips { get; set; }
                        public dynamic[] AttribGroupList { get; set; }
                        public dynamic? CharacterSkillPlus { get; set; }
                        public dynamic[] EquipSkillPlus { get; set; }
                        public int AttribReviseId { get; set; }
                        public dynamic[] EventIds { get; set; }
                        public dynamic? FightEventsWithLevel { get; set; }
                        public int WeaponFashionId { get; set; }
                        public dynamic? Partner { get; set; }
                        public bool IsRobot { get; set; }
                        public dynamic? AttrRateTable { get; set; }
                    }

                    public PreFightResponseFightDataRoleDataAssistNpcDataNpcData NpcData { get; set; }
                    public int AssistType { get; set; }
                    public int RuleTemplateId { get; set; }
                    public string Sign { get; set; }
                    public uint HeadPortraitId { get; set; }
                    public int HeadFrameId { get; set; }
                }

                public PreFightResponseFightDataRoleDataAssistNpcData AssistNpcData { get; set; }
            }

            public PreFightResponseFightDataRoleData[] RoleData { get; set; }
            public int ReviseId { get; set; }
            public int PlayerLevel { get; set; }
            public dynamic? NpcGroupList { get; set; }
            [MessagePack.MessagePackObject(true)]
            public class PreFightResponseFightDataFightControlData
            {
                public int MaxFight { get; set; }
                public int MaxRecommendFight { get; set; }
                public int MaxShowFight { get; set; }
                public int AvgFight { get; set; }
                public int AvgRecommendFight { get; set; }
                public int AvgShowFight { get; set; }
            }

            public PreFightResponseFightDataFightControlData FightControlData { get; set; }
            public bool DisableJoystick { get; set; }
            public bool Restartable { get; set; }
            public bool DisableDeadEffect { get; set; }
            public dynamic? CustomData { get; set; }
            public dynamic? Records { get; set; }
            public dynamic? StageParams { get; set; }
            public dynamic? StStageDropData { get; set; }
        }

        public PreFightResponseFightData FightData { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class FightSettleRequest
    {
        [MessagePack.MessagePackObject(true)]
        public class FightSettleRequestResult
        {
            public bool IsWin { get; set; }
            public bool IsForceExit { get; set; }
            public uint StageId { get; set; }
            public int StageLevel { get; set; }
            public uint FightId { get; set; }
            public int RebootCount { get; set; }
            public int AddStars { get; set; }
            public int StartFrame { get; set; }
            public uint SettleFrame { get; set; }
            public int PauseFrame { get; set; }
            public int ExSkillPauseFrame { get; set; }
            public uint SettleCode { get; set; }
            public int DodgeTimes { get; set; }
            public int NormalAttackTimes { get; set; }
            public int ConsumeBallTimes { get; set; }
            public int StuntSkillTimes { get; set; }
            public int PauseTimes { get; set; }
            public int HighestCombo { get; set; }
            public int DamagedTimes { get; set; }
            public int MatrixTimes { get; set; }
            public uint HighestDamage { get; set; }
            public uint TotalDamage { get; set; }
            public uint TotalDamaged { get; set; }
            public uint TotalCure { get; set; }
            public uint[] PlayerIds { get; set; }
            public dynamic[] PlayerData { get; set; }
            public dynamic? IntToIntRecord { get; set; }
            public dynamic? StringToIntRecord { get; set; }
            public Dictionary<dynamic, dynamic> Operations { get; set; }
            public uint[] Codes { get; set; }
            public int LeftTime { get; set; }
            public Dictionary<dynamic, dynamic> NpcHpInfo { get; set; }
            public Dictionary<dynamic, dynamic> NpcDpsTable { get; set; }
            public dynamic[] EventSet { get; set; }
            public int DeathTotalMyTeam { get; set; }
            public int DeathTotalEnemy { get; set; }
            public Dictionary<dynamic, dynamic> DeathRecord { get; set; }
            public dynamic[] GroupDropDatas { get; set; }
            public dynamic? EpisodeFightResults { get; set; }
            public dynamic? CustomData { get; set; }
        }

        public FightSettleRequestResult Result { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class FightSettleResponse
    {
        public int Code { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class FightSettleResponseSettle
        {
            public bool IsWin { get; set; }
            public uint StageId { get; set; }
            public int StarsMark { get; set; }
            public dynamic? RewardGoodsList { get; set; }
            public int LeftTime { get; set; }
            public Dictionary<dynamic, dynamic> NpcHpInfo { get; set; }
            public int UrgentEnventId { get; set; }
            public dynamic? ClientAssistInfo { get; set; }
            public dynamic[] FlopRewardList { get; set; }
            public dynamic? ArenaResult { get; set; }
            public dynamic? MultiRewardGoodsList { get; set; }
            public int ChallengeCount { get; set; }
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


    [MessagePack.MessagePackObject(true)]
    public class FinishTaskRequest
    {
        public uint TaskId { get; set; }
    }


    [MessagePack.MessagePackObject(true)]
    public class FinishTaskResponse
    {
        public int Code { get; set; }
        [MessagePack.MessagePackObject(true)]
        public class FinishTaskResponseRewardGoodsList
        {
            public int RewardType { get; set; }
            public int TemplateId { get; set; }
            public uint Count { get; set; }
            public int Level { get; set; }
            public int Quality { get; set; }
            public int Grade { get; set; }
            public int Breakthrough { get; set; }
            public int ConvertFrom { get; set; }
            public uint Id { get; set; }
        }

        public FinishTaskResponseRewardGoodsList[] RewardGoodsList { get; set; }
    }
}
