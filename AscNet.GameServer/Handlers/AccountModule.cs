using AscNet.Common.MsgPack;
using MessagePack;
using Newtonsoft.Json;

namespace AscNet.GameServer.Handlers
{
    internal class AccountModule
    {
        [PacketHandler("HandshakeRequest")]
        public static void HandshakeRequestHandler(Session session, byte[] packet)
        {
            HandshakeResponse response = new()
            {
                Code = 0,
                UtcOpenTime = 0,
                Sha1Table = null
            };

            session.SendResponse(response);
        }

        [PacketHandler("LoginRequest")]
        public static void LoginRequestHandler(Session session, byte[] packet)
        {
            LoginRequest request = MessagePackSerializer.Deserialize<LoginRequest>(packet);
            session.SendResponse(new LoginResponse
            {
                Code = 0,
                ReconnectToken = "eeeeeeeeeeeeeeh",
                UtcOffset = 0,
                UtcServerTime = (uint)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
            });

            DoLogin(session);
        }


        [PacketHandler("EnterWorldChatRequest")]
        public static void EnterWorldChatRequestHandler(Session session, byte[] packet)
        {
            EnterWorldChatResponse enterWorldChatResponse = new()
            {
                Code = 0,
                ChannelId = 0
            };
            session.SendResponse(enterWorldChatResponse);
        }

        [PacketHandler("GetWorldChannelInfoRequest")]
        public static void GetWorldChannelInfoRequestHandler(Session session, byte[] packet)
        {
            GetWorldChannelInfoResponse getWorldChannelInfoResponse = new()
            {
                Code = 0,
                ChannelInfos = { }
            };
            getWorldChannelInfoResponse.ChannelInfos.Append(new()
            {
                ChannelId = 0,
                PlayerNum = 0
            });
            session.SendResponse(getWorldChannelInfoResponse);
        }

        [PacketHandler("OfflineMessageRequest")]
        public static void OfflineMessageRequestHandler(Session session, byte[] packet)
        {
            OfflineMessageResponse offlineMessageResponse = new()
            {
                Code = 0,
                Messages = { }
            };
            session.SendResponse(offlineMessageResponse);
        }

        [PacketHandler("HeartbeatRequest")]
        public static void HeartbeatRequestHandler(Session session, byte[] packet)
        {
            HeartbeatResponse heartbeatResponse = new()
            {
                UtcServerTime = (uint)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
            };
            session.SendResponse(heartbeatResponse);
        }

        [PacketHandler("DoClientTaskEventRequest")]
        public static void DoClientTaskEventRequestHandler(Session session, byte[] packet)
        {
            DoClientTaskEventRequest doClientTaskEventRequest = MessagePackSerializer.Deserialize<DoClientTaskEventRequest>(packet);

            DoClientTaskEventResponse doClientTaskEventResponse = new()
            {
                Code = 0
            };
            session.SendResponse(doClientTaskEventResponse);
        }

        [PacketHandler("SignInRequest")]
        public static void SignInRequestHandler(Session session, byte[] packet)
        {
            SignInRequest signInRequest = MessagePackSerializer.Deserialize<SignInRequest>(packet);

            SignInResponse signInResponse = new()
            {
                Code = 0,
                RewardGoodsList = { },
            };
            session.SendResponse(signInResponse);
        }

        [PacketHandler("GetPurchaseListRequest")]
        public static void GetPurchaseListRequestHandler(Session session, byte[] packet)
        {
            GetPurchaseListRequest getPurchaseListRequest = MessagePackSerializer.Deserialize<GetPurchaseListRequest>(packet);

            GetPurchaseListResponse getPurchaseListResponse = new()
            {
                Code = 0,
                PurchaseInfoList = { }
            };
            session.SendResponse(getPurchaseListResponse);
        }

        static void DoLogin(Session session)
        {
            NotifyLogin notifyLogin = JsonConvert.DeserializeObject<NotifyLogin>(File.ReadAllText("Data/NotifyLogin.json"))!;
            session.SendPush(notifyLogin);

            NotifyDailyLotteryData notifyDailyLotteryData = new()
            {
                Lotteries = { }
            };
            session.SendPush(notifyDailyLotteryData);

            NotifyPayInfo notifyPayInfo = new()
            {
                TotalPayMoney = 0,
                IsGetFirstPayReward = false
            };
            session.SendPush(notifyPayInfo);

            NotifyEquipChipGroupList notifyEquipChipGroupList = new()
            {
                ChipGroupDataList = { }
            };
            session.SendPush(notifyEquipChipGroupList);

            NotifyEquipChipAutoRecycleSite notifyEquipChipAutoRecycleSite = new()
            {
                ChipRecycleSite = { }
            };
            session.SendPush(notifyEquipChipAutoRecycleSite);

            NotifyEquipGuideData notifyEquipGuideData = new()
            {
                EquipGuideData = new()
                {
                    TargetId = 0,
                    PutOnPosList = { },
                    FinishedTargets = { }
                }
            };
            session.SendPush(notifyEquipGuideData);

            NotifyArchiveLoginData notifyArchiveLoginData = new()
            {
                Monsters = { },
                Equips = { },
                MonsterUnlockIds = { },
                WeaponUnlockIds = { },
                AwarenessUnlockIds = { },
                MonsterSettings = { },
                WeaponSettings = { },
                AwarenessSettings = { },
                MonsterInfos = { },
                MonsterSkills = { },
                UnlockCgs = { },
                UnlockStoryDetails = { },
                PartnerUnlockIds = { },
                PartnerSettings = { },
                UnlockPvDetails = { },
                UnlockMails = { }
            };
            session.SendPush(notifyArchiveLoginData);

            NotifyChatLoginData notifyChatLoginData = new()
            {
                RefreshTime = GetPlaceholderTime(),
                UnlockEmojis = { }
            };
            session.SendPush(notifyChatLoginData);

            NotifySocialData notifySocialData = new()
            {
                FriendData = { },
                ApplyData = { },
                Remarks = { },
                BlockData = { },
            };
            session.SendPush(notifySocialData);

            NotifyTaskData notifyTaskData = JsonConvert.DeserializeObject<NotifyTaskData>(File.ReadAllText("Data/NotifyTaskData.json"))!;
            //NotifyTaskData notifyTaskData = new()
            //{
            //    TaskData = { }
            //};
            session.SendPush(notifyTaskData);

            NotifyActivenessStatus notifyActivenessStatus = new()
            {
                DailyActivenessRewardStatus = 0,
                WeeklyActivenessRewardStatus = 0
            };
            session.SendPush(notifyActivenessStatus);

            NotifyNewPlayerTaskStatus notifyNewPlayerTaskStatus = new()
            {
                NewPlayerTaskActiveDay = 1
            };
            session.SendPush(notifyNewPlayerTaskStatus);

            NotifyRegression2Data notifyRegression2Data = new()
            {
                Data = { }
            };
            session.SendPush(notifyRegression2Data);

            NotifyMaintainerActionData notifyMaintainerActionData = new();
            session.SendPush(notifyMaintainerActionData);

            NotifyAllRedEnvelope notifyAllRedEnvelope = new()
            {
                Envelopes = { }
            };
            session.SendPush(notifyAllRedEnvelope);

            NotifyScoreTitleData notifyScoreTitleData = new()
            {
                TitleInfos = { },
                HideTypes = { },
                IsHideCollection = false,
                WallInfos = { },
            };
            session.SendPush(notifyScoreTitleData);

            NotifyBfrtData notifyBfrtData = new()
            {
                BfrtData = new()
                {
                    BfrtGroupRecords = { },
                    BfrtTeamInfos = { }
                }
            };
            session.SendPush(notifyBfrtData);

            NotifyGuildEvent notifyGuildEvent = new();
            session.SendPush(notifyGuildEvent);

            NotifyAssistData NotifyAssistData = new()
            {
                AssistData = new()
                {
                    AssistCharacterId = 1021001
                }
            };
            session.SendPush(NotifyAssistData);

            NotifyWorkNextRefreshTime notifyWorkNextRefreshTime = new()
            {
                NextRefreshTime = GetPlaceholderTime()
            };
            session.SendPush(notifyWorkNextRefreshTime);

            NotifyDormitoryData notifyDormitoryData = new()
            {
                FurnitureCreateList = { },
                WorkList = { },
                FurnitureUnlockList = { },
                SnapshotTimes = 0,
                DormitoryList = { },
                VisitorList = { },
                FurnitureList = { },
                CharacterList = { },
                Layouts = { },
                BindRelations = { }
            };
            session.SendPush(notifyDormitoryData);

            NotifyNameplateLoginData notifyNameplateLoginData = new()
            {
                CurrentWearNameplate = 0,
                UnlockNameplates = { }
            };
            session.SendPush(notifyNameplateLoginData);

            NotifyGuildDormPlayerData notifyGuildDormPlayerData = new()
            {
                GuildDormData = { }
            };
            session.SendPush(notifyGuildDormPlayerData);

            NotifyBountyTaskInfo notifyBountyTaskInfo = new()
            {
                TaskInfo = { },
                RefreshTime = GetPlaceholderTime()
            };
            session.SendPush(notifyBountyTaskInfo);

            NotifyFiveTwentyRecord notifyFiveTwentyRecord = new()
            {
                CharacterIds = { },
                GroupRecord = { },
                ActivityNo = 0
            };
            session.SendPush(notifyFiveTwentyRecord);

            PurchaseDailyNotify purchaseDailyNotify = new()
            {
                ExpireInfoList = { },
                DailyRewardInfoList = { },
                FreeRewardInfoList = { }
            };
            session.SendPush(purchaseDailyNotify);

            NotifyPurchaseRecommendConfig notifyPurchaseRecommendConfig = new()
            {
                Data = { }
            };
            session.SendPush(notifyPurchaseRecommendConfig);

            NotifyBackgroundLoginData notifyBackgroundLoginData = new()
            {
                HaveBackgroundIds = { }
            };
            session.SendPush(notifyBackgroundLoginData);

            NotifyMedalData notifyMedalData = new()
            {
                MedalInfos = { }
            };
            session.SendPush(notifyMedalData);

            NotifyExploreData notifyExploreData = new()
            {
                ChapterDatas = { }
            };
            session.SendPush(notifyExploreData);

            NotifyGatherRewardList notifyGatherRewardList = new()
            {
                GatherRewards = { }
            };
            session.SendPush(notifyGatherRewardList);

            NotifyDrawTicketData notifyDrawTicketData = new()
            {
                DrawTicketInfos = { }
            };
            session.SendPush(notifyDrawTicketData);

            NotifyAccumulatedPayData notifyAccumulatedPayData = new()
            {
                PayId = 1,
                PayMoney = 0,
                PayRewardIds = { }
            };
            session.SendPush(notifyAccumulatedPayData);

            NotifyArenaActivity notifyArenaActivity = new();
            session.SendPush(notifyArenaActivity);

            NotifyPrequelUnlockChallengeStages notifyPrequelUnlockChallengeStages = new()
            {
                UnlockChallengeStages = { }
            };
            session.SendPush(notifyPrequelUnlockChallengeStages);

            NotifyPrequelChallengeRefreshTime notifyPrequelChallengeRefreshTime = new()
            {
                NextRefreshTime = GetPlaceholderTime()
            };
            session.SendPush(notifyPrequelChallengeRefreshTime);

            NotifyFubenPrequelData notifyFubenPrequelData = new()
            {
                FubenPrequelData = { }
            };
            session.SendPush(notifyFubenPrequelData);

            NotifyMainLineActivity notifyMainLineActivity = new()
            {
                Chapters = { },
                BfrtChapter = 0,
                EndTime = GetPlaceholderTime(),
                HideChapterBeginTime = 0
            };
            session.SendPush(notifyMainLineActivity);

            NotifyDailyFubenLoginData notifyDailyFubenLoginData = new()
            {
                RefreshTime = GetPlaceholderTime(),
                Records = { }
            };
            session.SendPush(notifyDailyFubenLoginData);

            NotifyBirthdayPlot notifyBirthdayPlot = new()
            {
                NextActiveYear = 2023,
                IsChange = 1,
                UnLockCg = { }
            };
            session.SendPush(notifyBirthdayPlot);

            NotifyBossActivityData notifyBossActivityData = new();
            session.SendPush(notifyBossActivityData);

            NotifyBriefStoryData notifyBriefStoryData = new()
            {
                FinishedIds = { }
            };
            session.SendPush(notifyBriefStoryData);

            NotifyChessPursuitGroupInfo notifyChessPursuitGroupInfo = new()
            {
                MapDBList = { },
                MapBossList = { }
            };
            session.SendPush(notifyChessPursuitGroupInfo);

            NotifyClickClearData notifyClickClearData = new()
            {
                Activities = { }
            };
            session.SendPush(notifyClickClearData);

            NotifyCourseData notifyCourseData = new()
            {
                Data = { }
            };
            session.SendPush(notifyCourseData);

            NotifyActivityDrawList notifyActivityDrawList = new()
            {
                DrawIdList = { }
            };
            session.SendPush(notifyActivityDrawList);

            NotifyActivityDrawGroupCount notifyActivityDrawGroupCount = new()
            {
                Count = 1
            };
            session.SendPush(notifyActivityDrawGroupCount);

            NotifyExperimentData notifyExperimentData = new()
            {
                FinishIds = { },
                ExperimentInfos = { }
            };
            session.SendPush(notifyExperimentData);

            NotifyBabelTowerActivityStatus notifyBabelTowerActivityStatus = new();
            session.SendPush(notifyBabelTowerActivityStatus);

            NotifyBabelTowerData notifyBabelTowerData = new();
            session.SendPush(notifyBabelTowerData);

            NotifyFubenBossSingleData notifyFubenBossSingleData = new()
            {
                FubenBossSingleData = { }
            };
            session.SendPush(notifyFubenBossSingleData);

            NotifyFestivalData notifyFestivalData = new()
            {
                FestivalInfos = { }
            };
            session.SendPush(notifyFestivalData);

            NotifyPracticeData notifyPracticeData = new()
            {
                ChapterInfos = { }
            };
            session.SendPush(notifyPracticeData);

            NotifyTrialData notifyTrialData = new()
            {
                FinishTrial = { },
                RewardRecord = { },
                TypeRewardRecord = { }
            };
            session.SendPush(notifyTrialData);



            NotifyPivotCombatData notifyPivotCombatData = new()
            {
                PivotCombatData = { }
            };
            session.SendPush(notifyPivotCombatData);

            NotifySettingLoadingOption notifySettingLoadingOption = new()
            {
                LoadingData = null
            };
            session.SendPush(notifySettingLoadingOption);

            NotifyRepeatChallengeData notifyRepeatChallengeData = new();
            session.SendPush(notifyRepeatChallengeData);

            NotifyPlayerReportData notifyPlayerReportData = new()
            {
                ReportData = { }
            };
            session.SendPush(notifyPlayerReportData);

            NotifyReviewConfig notifyReviewConfig = new()
            {
                ReviewActivityConfigList = { }
            };
            session.SendPush(notifyReviewConfig);

            NotifyStrongholdLoginData notifyStrongholdLoginData = new();
            session.SendPush(notifyStrongholdLoginData);

            NotifySummerSignInData notifySummerSignInData = new();
            session.SendPush(notifySummerSignInData);

            NotifyTaikoMasterData notifyTaikoMasterData = new()
            {
                TaikoMasterData = { }
            };
            session.SendPush(notifyTaikoMasterData);

            NotifyTeachingActivityInfo notifyTeachingActivityInfo = new()
            {
                ActivityInfo = { }
            };
            session.SendPush(notifyTeachingActivityInfo);

            NotifyTheatreData notifyTheatreData = new();
            session.SendPush(notifyTheatreData);

            NotifyVoteData notifyVoteData = new()
            {
                VoteAlarmDic = { }
            };
            session.SendPush(notifyVoteData);

            NotifyTRPGData notifyTRPGData = new();
            session.SendPush(notifyTRPGData);

            NotifyBiancaTheatreActivityData notifyBiancaTheatreActivityData = new();
            session.SendPush(notifyBiancaTheatreActivityData);

            NotifyMentorData notifyMentorData = new();
            session.SendPush(notifyMentorData);

            NotifyMentorChat notifyMentorChat = new()
            {
                ChatMessages = { }
            };
            session.SendPush(notifyMentorChat);

            NotifyMaintainerActionDailyReset notifyMaintainerActionDailyReset = new()
            {
                UsedActionCount = 0,
                ExtraActionCount = 0
            };
            session.SendPush(notifyMaintainerActionDailyReset);

            NotifyGuildData notifyGuildData = new();
            session.SendPush(notifyGuildData);

            NotifyMails notifyMails = new()
            {
                NewMailList = { },
                ExpireIdList = { }
            };
            session.SendPush(notifyMails);

            NotifyItemDataList notifyItemDataList = new()
            {
                ItemDataList = { },
                ItemRecycleDict = { }
            };
            session.SendPush(notifyItemDataList);
        }

        static uint GetPlaceholderTime() => (uint)(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeMilliseconds());
    }
}
