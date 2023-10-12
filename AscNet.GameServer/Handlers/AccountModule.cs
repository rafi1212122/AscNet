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
            // TODO: make this somehow universal, look into better architecture to handle packets
            // and automatically log their deserialized form
            HandshakeRequest request = MessagePackSerializer.Deserialize<HandshakeRequest>(packet);
            session.c.Log("HandshakeRequest" + " " + JsonConvert.SerializeObject(request));

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
            session.c.Log("LoginRequest" + " " + JsonConvert.SerializeObject(request));

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
            //EnterWorldChatRequest request = MessagePackSerializer.Deserialize<EnterWorldChatRequest>(packet);
            //session.c.Log("EnterWorldChatRequest" + " " + JsonConvert.SerializeObject(request));

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
            //GetWorldChannelInfoRequest request = MessagePackSerializer.Deserialize<GetWorldChannelInfoRequest>(packet);
            //session.c.Log("GetWorldChannelInfoRequest" + " " + JsonConvert.SerializeObject(request));

            GetWorldChannelInfoResponse getWorldChannelInfoResponse = new();
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
            OfflineMessageRequest request = MessagePackSerializer.Deserialize<OfflineMessageRequest>(packet);
            session.c.Log("OfflineMessageRequest" + " " + JsonConvert.SerializeObject(request));

            OfflineMessageResponse offlineMessageResponse = new()
            {
                Code = 0,
                Messages = Array.Empty<dynamic>()
            };
            session.SendResponse(offlineMessageResponse);
        }

        [PacketHandler("HeartbeatRequest")]
        public static void HeartbeatRequestHandler(Session session, byte[] packet)
        {
            //HeartbeatRequest request = MessagePackSerializer.Deserialize<HeartbeatRequest>(packet);
            //session.c.Log("HeartbeatRequest" + " " + JsonConvert.SerializeObject(request));

            HeartbeatResponse heartbeatResponse = new()
            {
                UtcServerTime = (uint)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
            };
            session.SendResponse(heartbeatResponse);
        }

        [PacketHandler("DoClientTaskEventRequest")]
        public static void DoClientTaskEventRequestHandler(Session session, byte[] packet)
        {
            DoClientTaskEventRequest request = MessagePackSerializer.Deserialize<DoClientTaskEventRequest>(packet);
            session.c.Log("DoClientTaskEventRequest" + " " + JsonConvert.SerializeObject(request));

            DoClientTaskEventResponse doClientTaskEventResponse = new()
            {
                Code = 0
            };
            session.SendResponse(doClientTaskEventResponse);
        }

        [PacketHandler("SignInRequest")]
        public static void SignInRequestHandler(Session session, byte[] packet)
        {
            SignInRequest request = MessagePackSerializer.Deserialize<SignInRequest>(packet);
            session.c.Log("SignInRequest" + " " + JsonConvert.SerializeObject(request));

            SignInResponse signInResponse = new();
            session.SendResponse(signInResponse);
        }

        [PacketHandler("GetPurchaseListRequest")]
        public static void GetPurchaseListRequestHandler(Session session, byte[] packet)
        {
            GetPurchaseListRequest request = MessagePackSerializer.Deserialize<GetPurchaseListRequest>(packet);
            session.c.Log("GetPurchaseListRequest" + " " + JsonConvert.SerializeObject(request));

            GetPurchaseListResponse getPurchaseListResponse = new();
            session.SendResponse(getPurchaseListResponse);
        }

        // TODO: Move somewhere else, also split.
        static void DoLogin(Session session)
        {
            NotifyLogin notifyLogin = JsonConvert.DeserializeObject<NotifyLogin>(File.ReadAllText("Data/NotifyLogin.json"))!;
            session.SendPush(notifyLogin);

            NotifyDailyLotteryData notifyDailyLotteryData = new();
            session.SendPush(notifyDailyLotteryData);

            NotifyPayInfo notifyPayInfo = new()
            {
                TotalPayMoney = 0,
                IsGetFirstPayReward = false
            };
            session.SendPush(notifyPayInfo);

            NotifyEquipChipGroupList notifyEquipChipGroupList = new();
            session.SendPush(notifyEquipChipGroupList);

            NotifyEquipChipAutoRecycleSite notifyEquipChipAutoRecycleSite = new()
            {
                ChipRecycleSite = new NotifyEquipChipAutoRecycleSite.NotifyEquipChipAutoRecycleSiteChipRecycleSite()
            };
            session.SendPush(notifyEquipChipAutoRecycleSite);

            NotifyEquipGuideData notifyEquipGuideData = new()
            {
                EquipGuideData = new()
            };
            session.SendPush(notifyEquipGuideData);

            NotifyArchiveLoginData notifyArchiveLoginData = new();
            session.SendPush(notifyArchiveLoginData);

            NotifyChatLoginData notifyChatLoginData = new()
            {
                RefreshTime = GetPlaceholderTime()
            };
            session.SendPush(notifyChatLoginData);

            NotifySocialData notifySocialData = new();
            session.SendPush(notifySocialData);

            NotifyTaskData notifyTaskData = JsonConvert.DeserializeObject<NotifyTaskData>(File.ReadAllText("Data/NotifyTaskData.json"))!;
            //NotifyTaskData notifyTaskData = new()
            //{
            //    TaskData = Array.Empty<dynamic>()
            //};
            session.SendPush(notifyTaskData);

            NotifyActivenessStatus notifyActivenessStatus = new();
            session.SendPush(notifyActivenessStatus);

            NotifyNewPlayerTaskStatus notifyNewPlayerTaskStatus = new()
            {
                NewPlayerTaskActiveDay = 1
            };
            session.SendPush(notifyNewPlayerTaskStatus);

            NotifyRegression2Data notifyRegression2Data = new()
            {
                Data = new NotifyRegression2Data.NotifyRegression2DataData()
            };
            session.SendPush(notifyRegression2Data);

            NotifyAllRedEnvelope notifyAllRedEnvelope = new();
            session.SendPush(notifyAllRedEnvelope);

            NotifyScoreTitleData notifyScoreTitleData = new();
            session.SendPush(notifyScoreTitleData);

            NotifyBfrtData notifyBfrtData = new()
            {
                BfrtData = new()
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

            NotifyDormitoryData notifyDormitoryData = new();
            session.SendPush(notifyDormitoryData);

            NotifyNameplateLoginData notifyNameplateLoginData = new();
            session.SendPush(notifyNameplateLoginData);

            NotifyGuildDormPlayerData notifyGuildDormPlayerData = new()
            {
                GuildDormData = new NotifyGuildDormPlayerData.NotifyGuildDormPlayerDataGuildDormData()
            };
            session.SendPush(notifyGuildDormPlayerData);

            NotifyBountyTaskInfo notifyBountyTaskInfo = new()
            {
                TaskInfo = new NotifyBountyTaskInfo.NotifyBountyTaskInfoTaskInfo
                {
                    RankLevel = 1,
                    TaskPoolRefreshCount = 0
                },
                RefreshTime = GetPlaceholderTime()
            };
            session.SendPush(notifyBountyTaskInfo);

            NotifyFiveTwentyRecord notifyFiveTwentyRecord = new();
            session.SendPush(notifyFiveTwentyRecord);

            PurchaseDailyNotify purchaseDailyNotify = new();
            session.SendPush(purchaseDailyNotify);

            NotifyPurchaseRecommendConfig notifyPurchaseRecommendConfig = new()
            {
                Data = new NotifyPurchaseRecommendConfig.NotifyPurchaseRecommendConfigData
                {
                    AddOrModifyConfigs = new(),
                    RemoveIds = Array.Empty<dynamic>()
                }
            };
            session.SendPush(notifyPurchaseRecommendConfig);

            NotifyBackgroundLoginData notifyBackgroundLoginData = new();
            session.SendPush(notifyBackgroundLoginData);

            NotifyMedalData notifyMedalData = new();
            session.SendPush(notifyMedalData);

            NotifyExploreData notifyExploreData = new();
            session.SendPush(notifyExploreData);

            NotifyGatherRewardList notifyGatherRewardList = new();
            session.SendPush(notifyGatherRewardList);

            NotifyDrawTicketData notifyDrawTicketData = new();
            session.SendPush(notifyDrawTicketData);

            NotifyAccumulatedPayData notifyAccumulatedPayData = new()
            {
                PayId = 1,
                PayMoney = 0
            };
            session.SendPush(notifyAccumulatedPayData);

            NotifyArenaActivity notifyArenaActivity = new();
            session.SendPush(notifyArenaActivity);

            NotifyPrequelUnlockChallengeStages notifyPrequelUnlockChallengeStages = new();
            session.SendPush(notifyPrequelUnlockChallengeStages);

            NotifyPrequelChallengeRefreshTime notifyPrequelChallengeRefreshTime = new()
            {
                NextRefreshTime = GetPlaceholderTime()
            };
            session.SendPush(notifyPrequelChallengeRefreshTime);

            NotifyFubenPrequelData notifyFubenPrequelData = new()
            {
                FubenPrequelData = new()
            };
            session.SendPush(notifyFubenPrequelData);

            NotifyMainLineActivity notifyMainLineActivity = new()
            {
                BfrtChapter = 0,
                EndTime = GetPlaceholderTime(),
                HideChapterBeginTime = 0
            };
            session.SendPush(notifyMainLineActivity);

            NotifyDailyFubenLoginData notifyDailyFubenLoginData = new()
            {
                RefreshTime = GetPlaceholderTime()
            };
            session.SendPush(notifyDailyFubenLoginData);

            NotifyBirthdayPlot notifyBirthdayPlot = new()
            {
                NextActiveYear = 2023,
                IsChange = 1
            };
            session.SendPush(notifyBirthdayPlot);

            NotifyBossActivityData notifyBossActivityData = new()
            {
                ActivityId = 11,
                SectionId = 1,
                Schedule = 0
            };
            session.SendPush(notifyBossActivityData);

            NotifyBriefStoryData notifyBriefStoryData = new();
            session.SendPush(notifyBriefStoryData);

            NotifyChessPursuitGroupInfo notifyChessPursuitGroupInfo = new();
            session.SendPush(notifyChessPursuitGroupInfo);

            NotifyClickClearData notifyClickClearData = new();
            session.SendPush(notifyClickClearData);

            NotifyCourseData notifyCourseData = new()
            {
                Data = new NotifyCourseData.NotifyCourseDataData
                {
                    MaxTotalLessonPoint = 0,
                    StageDataDict = new Dictionary<dynamic, dynamic>(),
                    TotalLessonPoint = 0
                }
            };
            session.SendPush(notifyCourseData);

            NotifyActivityDrawList notifyActivityDrawList = new();
            session.SendPush(notifyActivityDrawList);

            NotifyActivityDrawGroupCount notifyActivityDrawGroupCount = new()
            {
                Count = 1
            };
            session.SendPush(notifyActivityDrawGroupCount);

            NotifyExperimentData notifyExperimentData = new();
            session.SendPush(notifyExperimentData);

            NotifyBabelTowerData notifyBabelTowerData = new()
            {
                ActivityNo = 13,
                MaxScore = 0,
                RankLevel = 0,
                StageDatas = new(),
                ExtraData = new()
            };
            session.SendPush(notifyBabelTowerData);

            /* Not needed?
            NotifyBabelTowerActivityStatus notifyBabelTowerActivityStatus = new();
            session.SendPush(notifyBabelTowerActivityStatus);
            */

            NotifyFubenBossSingleData notifyFubenBossSingleData = new()
            {
                FubenBossSingleData = new NotifyFubenBossSingleData.NotifyFubenBossSingleDataFubenBossSingleData()
            };
            session.SendPush(notifyFubenBossSingleData);

            NotifyFestivalData notifyFestivalData = new();
            session.SendPush(notifyFestivalData);

            NotifyPracticeData notifyPracticeData = new();
            session.SendPush(notifyPracticeData);

            NotifyTrialData notifyTrialData = new();
            session.SendPush(notifyTrialData);

            NotifyPivotCombatData notifyPivotCombatData = new()
            {
                PivotCombatData = new NotifyPivotCombatData.NotifyPivotCombatDataPivotCombatData
                {
                    ActivityId = 0,
                    Difficulty = 0
                }
            };
            session.SendPush(notifyPivotCombatData);

            NotifySettingLoadingOption notifySettingLoadingOption = new()
            {
                LoadingData = null
            };
            session.SendPush(notifySettingLoadingOption);

            NotifyTask notifyTask = new()
            {
                TaskLimitIdActiveInfos = Array.Empty<int>()
            };

            NotifyRepeatChallengeData notifyRepeatChallengeData = new()
            {
                Id = 20,
                ExpInfo = new() { Level = 1 }
            };
            session.SendPush(notifyRepeatChallengeData);



            NotifyPlayerReportData notifyPlayerReportData = new()
            {
                ReportData = new NotifyPlayerReportData.NotifyPlayerReportDataReportData()
            };
            session.SendPush(notifyPlayerReportData);

            NotifyReviewConfig notifyReviewConfig = new();
            session.SendPush(notifyReviewConfig);

            NotifyStrongholdLoginData notifyStrongholdLoginData = new()
            {
                Id = 21
            };
            session.SendPush(notifyStrongholdLoginData);

            NotifySummerSignInData notifySummerSignInData = new()
            {
                ActId = 1,
                SurplusTimes = 1
            };
            session.SendPush(notifySummerSignInData);

            NotifyTaikoMasterData notifyTaikoMasterData = new()
            {
                TaikoMasterData = new NotifyTaikoMasterData.NotifyTaikoMasterDataTaikoMasterData()
                {
                    Setting = new()
                }
            };
            session.SendPush(notifyTaikoMasterData);

            NotifyTeachingActivityInfo notifyTeachingActivityInfo = new();
            session.SendPush(notifyTeachingActivityInfo);

            NotifyTheatreData notifyTheatreData = new();
            session.SendPush(notifyTheatreData);

            NotifyVoteData notifyVoteData = new();
            session.SendPush(notifyVoteData);

            NotifyTRPGData notifyTRPGData = new()
            {
                BossInfo = new(),
                BaseInfo = new()
                {
                    Level = 1
                }
            };
            session.SendPush(notifyTRPGData);

            NotifyBiancaTheatreActivityData notifyBiancaTheatreActivityData = new()
            {
                CurActivityId = 1
            };
            session.SendPush(notifyBiancaTheatreActivityData);

            NotifyMentorData notifyMentorData = new()
            {
                PlayerType = 2,
                Announcement = "",
                WeeklyLevel = 28
            };
            session.SendPush(notifyMentorData);

            NotifyMentorChat notifyMentorChat = new();
            session.SendPush(notifyMentorChat);

            NotifyMaintainerActionDailyReset notifyMaintainerActionDailyReset = new();
            session.SendPush(notifyMaintainerActionDailyReset);

            NotifyGuildData notifyGuildData = new()
            {
                GuildName = string.Empty,
                GuildRankLevel = 0
            };
            session.SendPush(notifyGuildData);

            NotifyMails notifyMails = new();
            session.SendPush(notifyMails);

            NotifyItemDataList notifyItemDataList = new()
            {
                ItemRecycleDict = Array.Empty<dynamic>()
            };
            session.SendPush(notifyItemDataList);
        }

        static uint GetPlaceholderTime() => (uint)(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeMilliseconds());
    }
}
