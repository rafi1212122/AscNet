using AscNet.Common.Database;
using AscNet.Common.MsgPack;
using MessagePack;
using Newtonsoft.Json;

namespace AscNet.GameServer.Handlers
{
    internal class AccountModule
    {
        [RequestPacketHandler("HandshakeRequest")]
        public static void HandshakeRequestHandler(Session session, Packet.Request packet)
        {
            // TODO: make this somehow universal, look into better architecture to handle packets
            // and automatically log their deserialized form

            HandshakeResponse response = new()
            {
                Code = 0,
                UtcOpenTime = 0,
                Sha1Table = null
            };

            session.SendResponse(response, packet.Id);
        }

        [RequestPacketHandler("LoginRequest")]
        public static void LoginRequestHandler(Session session, Packet.Request packet)
        {
            LoginRequest request = MessagePackSerializer.Deserialize<LoginRequest>(packet.Content);
            Player? player = Player.FromToken(request.Token);

            if (player is null)
            {
                session.SendResponse(new LoginResponse
                {
                    Code = 1007 // LoginInvalidLoginToken
                }, packet.Id);
                return;
            }

            session.SendResponse(new LoginResponse
            {
                Code = 0,
                ReconnectToken = player.Token,
                UtcOffset = 0,
                UtcServerTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            }, packet.Id);

            DoLogin(session);
        }

        [RequestPacketHandler("ReconnectRequest")]
        public static void ReconnectRequestHandler(Session session, Packet.Request packet)
        {
            ReconnectRequest request = MessagePackSerializer.Deserialize<ReconnectRequest>(packet.Content);
            Player? player = Player.FromToken(request.Token);

            if (player?.PlayerData.Id != request.PlayerId)
            {
                session.SendResponse(new ReconnectResponse()
                {
                    Code = 1029 // ReconnectInvalidToken
                }, packet.Id);
                return;
            }

            session.SendResponse(new ReconnectResponse()
            {
                ReconnectToken = request.Token
            }, packet.Id);
        }
        
        /* TODO
        [RequestPacketHandler("ReconnectAck")]
        public static void ReconnectAckHandler(Session session, Packet.Request packet)
        {
        }
        */

        // TODO: Move somewhere else, also split.
        static void DoLogin(Session session)
        {
            NotifyLogin notifyLogin = JsonConvert.DeserializeObject<NotifyLogin>(File.ReadAllText("Data/NotifyLogin.json"))!;
            session.SendPush(notifyLogin);

            // NEEDED to not softlock on stage selections!
            session.SendPush("NotifyFubenPrequelData", MessagePackSerializer.ConvertFromJson("{\"FubenPrequelData\": {\"RewardedStages\": [13010111, 13010112, 13010113, 13010211, 13010212, 13010213, 13010214, 13010215, 13010216, 13010311, 13010312, 13010313, 13010911, 13010912, 13010913, 13010414, 13010413, 13010415, 13010411, 13010412, 13010416, 13010316, 13010314, 13010315, 13010115, 13010116, 13010114, 13011011, 13011012, 13011013, 13011014, 13011015, 13011016], \"UnlockChallengeStages\": []}}"));
            session.SendPush("NotifyPrequelChallengeRefreshTime", MessagePackSerializer.ConvertFromJson("{\"NextRefreshTime\": 1690873200}"));
            session.SendPush("NotifyMainLineActivity", MessagePackSerializer.ConvertFromJson("{\"Chapters\": [1019], \"BfrtChapter\": 0, \"EndTime\": 1692669540, \"HideChapterBeginTime\": 0}"));
            session.SendPush("NotifyDailyFubenLoginData", MessagePackSerializer.ConvertFromJson("{\"RefreshTime\": 1690873200, \"Records\": []}"));
            session.SendPush("NotifyBriefStoryData", MessagePackSerializer.ConvertFromJson("{\"FinishedIds\": []}"));
            session.SendPush("NotifyFubenBossSingleData", MessagePackSerializer.ConvertFromJson("{\"FubenBossSingleData\": {\"ActivityNo\": 108, \"TotalScore\": 0, \"MaxScore\": 0, \"OldLevelType\": 1, \"LevelType\": 1, \"ChallengeCount\": 0, \"RemainTime\": 576710, \"AutoFightCount\": 0, \"CharacterPoints\": {}, \"HistoryList\": [{\"StageId\": 30000101, \"Score\": 12160, \"Characters\": [1021001, 1031003, 1011002], \"Partners\": []}, {\"StageId\": 30000102, \"Score\": 21438, \"Characters\": [1021001, 1031003, 1011002], \"Partners\": []}, {\"StageId\": 30000201, \"Score\": 12160, \"Characters\": [1021001, 1031003, 1041002], \"Partners\": []}, {\"StageId\": 30000202, \"Score\": 21329, \"Characters\": [1051001, 1021002, 1041002], \"Partners\": []}, {\"StageId\": 30000203, \"Score\": 44760, \"Characters\": [1021001, 1011002, 1081002], \"Partners\": []}, {\"StageId\": 30000204, \"Score\": 82792, \"Characters\": [1021001, 1031003, 1041002], \"Partners\": []}, {\"StageId\": 30000205, \"Score\": 69057, \"Characters\": [1021001, 1031003, 1041002], \"Partners\": []}], \"RewardIds\": [], \"RankPlatform\": 0, \"BossList\": [103, 105], \"TrialStageInfoList\": []}}"));
        }
    }
}
