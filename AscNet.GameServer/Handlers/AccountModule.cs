using AscNet.Common.Database;
using AscNet.Common.MsgPack;
using AscNet.Table.share.guide;
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

            session.player = player;
            session.character = Character.FromUid(player.PlayerData.Id);
            session.stage = Stage.FromUid(player.PlayerData.Id);
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
            Player? player;
            if (session.player is not null)
                player = session.player;
            else
            {
                player = Player.FromToken(request.Token);
                if (player is not null && (session.character is null || session.stage is null))
                {
                    session.character = Character.FromUid(player.PlayerData.Id);
                    session.stage = Stage.FromUid(player.PlayerData.Id);
                }
            }

            if (player?.PlayerData.Id != request.PlayerId)
            {
                session.SendResponse(new ReconnectResponse()
                {
                    Code = 1029 // ReconnectInvalidToken
                }, packet.Id);
                return;
            }

            session.player = player;
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
            NotifyLogin notifyLogin = new()
            {
                PlayerData = session.player.PlayerData,
                TeamGroupData = session.player.TeamGroups,
                BaseEquipLoginData = new(),
                FubenData = new()
                {
                    StageData = session.stage.Stages,
                    FubenBaseData = new()
                },
                FubenMainLineData = new(),
                FubenChapterExtraLoginData = new(),
                FubenUrgentEventData = new(),
                UseBackgroundId = 14000001 // main ui theme, table still failed to dump
            };
            if (notifyLogin.PlayerData.DisplayCharIdList.Count < 1)
                notifyLogin.PlayerData.DisplayCharIdList.Add(notifyLogin.PlayerData.DisplayCharId);
            notifyLogin.FashionList.AddRange(session.character.Fashions);

#if DEBUG
            // Per account settings flag(?)
            notifyLogin.PlayerData.GuideData = GuideGroupTableReader.Instance.All.Select(x => (long)x.Id).ToList();
#endif

            NotifyCharacterDataList notifyCharacterData = new();
            notifyCharacterData.CharacterDataList.AddRange(session.character.Characters);
            
            NotifyEquipDataList notifyEquipData = new();
            notifyEquipData.EquipDataList.AddRange(session.character.Equips);

            NotifyAssistData notifyAssistData = new()
            {
                AssistData = new()
                {
                    AssistCharacterId = session.character.Characters.First().Id
                }
            };

            session.SendPush(notifyLogin);
            session.SendPush(notifyCharacterData);
            session.SendPush(notifyEquipData);
            session.SendPush(notifyAssistData);

            // NEEDED to not softlock!
            session.SendPush(new NotifyFubenPrequelData() { FubenPrequelData = new() });
            session.SendPush(new NotifyPrequelChallengeRefreshTime() { NextRefreshTime = (uint)DateTimeOffset.Now.ToUnixTimeSeconds() + 3600 * 24 });
            session.SendPush(new NotifyMainLineActivity() { EndTime = 0 });
            session.SendPush(new NotifyDailyFubenLoginData() { RefreshTime = (uint)DateTimeOffset.Now.ToUnixTimeSeconds() + 3600 * 24 });
            session.SendPush(new NotifyBriefStoryData());
            session.SendPush(new NotifyFubenBossSingleData()
            {
                FubenBossSingleData = new()
                {
                    ActivityNo = 1,
                    TotalScore = 0,
                    MaxScore = 0,
                    OldLevelType = 0,
                    LevelType = 1,
                    ChallengeCount = 0,
                    RemainTime = 100000,
                    AutoFightCount = 0,
                    CharacterPoints = new {},
                    RankPlatform = 0
                }
            });
            session.SendPush(new NotifyBfrtData() { BfrtData = new() });
        }
    }
}
