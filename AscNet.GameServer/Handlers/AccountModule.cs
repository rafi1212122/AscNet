using AscNet.Common.Database;
using AscNet.Common.MsgPack;
using AscNet.Common.Util;
using AscNet.Table.share.chat;
using AscNet.Table.share.guide;
using AscNet.Table.share.item;
using MessagePack;
using System.Diagnostics;

namespace AscNet.GameServer.Handlers
{
    #region MsgPackScheme
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessagePackObject(true)]
    public class ForceLogoutNotify
    {
        public int Code;
    }
    
    [MessagePackObject(true)]
    public class ShutdownNotify
    {
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion

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

            Session? previousSession = Server.Instance.Sessions.Select(x => x.Value).Where(x => x.GetHashCode() != session.GetHashCode()).FirstOrDefault(x => x.player.PlayerData.Id == player.PlayerData.Id);
            if (previousSession is not null)
            {
                // GateServerForceLogoutByAnotherLogin
                previousSession.SendPush(new ForceLogoutNotify() { Code = 1018 });
                previousSession.DisconnectProtocol();
            }

            session.player = player;
            session.character = Character.FromUid(player.PlayerData.Id);
            session.stage = Stage.FromUid(player.PlayerData.Id);
            session.inventory = Inventory.FromUid(player.PlayerData.Id);

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
                if (player is not null && (session.character is null || session.stage is null || session.inventory is null))
                {
                    session.character = Character.FromUid(player.PlayerData.Id);
                    session.stage = Stage.FromUid(player.PlayerData.Id);
                    session.inventory = Inventory.FromUid(player.PlayerData.Id);
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
                ItemList = session.inventory.Items,
                UseBackgroundId = 14000001 // main ui theme, table still failed to dump
            };
            if (notifyLogin.PlayerData.DisplayCharIdList.Count < 1)
                notifyLogin.PlayerData.DisplayCharIdList.Add(notifyLogin.PlayerData.DisplayCharId);
            notifyLogin.FashionList.AddRange(session.character.Fashions);

#if DEBUG
            notifyLogin.PlayerData.GuideData = GuideGroupTableReader.Instance.All.Select(x => (long)x.Id).ToList();

            StageDatum stageForChat = new()
            {
                StageId = 10030201,
                StarsMark = 7,
                Passed = true,
                PassTimesToday = 0,
                PassTimesTotal = 1,
                BuyCount = 0,
                Score = 0,
                LastPassTime = DateTimeOffset.Now.ToUnixTimeSeconds(),
                RefreshTime = DateTimeOffset.Now.ToUnixTimeSeconds(),
                CreateTime = DateTimeOffset.Now.ToUnixTimeSeconds(),
                BestRecordTime = 0,
                LastRecordTime = 0,
                BestCardIds = new List<long> { 1021001 },
                LastCardIds = new List<long> { 1021001 }
            };
            if (!notifyLogin.FubenData.StageData.ContainsKey(stageForChat.StageId))
                notifyLogin.FubenData.StageData = notifyLogin.FubenData.StageData.Append(new(stageForChat.StageId, stageForChat)).ToDictionary(x => x.Key, x => x.Value);
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

            NotifyChatLoginData notifyChatLoginData = new()
            {
                RefreshTime = ((DateTimeOffset)Process.GetCurrentProcess().StartTime).ToUnixTimeSeconds(),
                UnlockEmojis = EmojiTableReader.Instance.All.Select(x => new NotifyChatLoginData.NotifyChatLoginDataUnlockEmoji() { Id = (uint)x.Id }).ToList()
            };

            session.SendPush(notifyLogin);
            session.SendPush(notifyCharacterData);
            session.SendPush(notifyEquipData);
            session.SendPush(notifyAssistData);
            session.SendPush(notifyChatLoginData);

            #region DisclamerMail
            NotifyMails notifyMails = new();
            notifyMails.NewMailList.Add(new NotifyMails.NotifyMailsNewMailList()
            {
                Id = "0",
                Status = 0, // MAIL_STATUS_UNREAD
                SendName = "AscNet Developers",
                Title = "[IMPORTANT] Information Regarding This Server Software [有关本服务器软件的信息］",
                Content = @"Hello Commandant!
Welcome to AscNet, we are happy that you are using this Server Software.
This Server Software is always free and if you are paying to gain access to this you are being SCAMMED, we encourage you to help prevent another buyer like you by making a PSA or telling others whom you may see as potential users.
Sorry for the inconvenience.

欢迎来到 AscNet，我们很高兴您使用本服务器软件。
本服务器软件始终是免费的，如果您是通过付费来使用本软件，那您就被骗了，我们鼓励您告诉其他潜在用户，以防止再有像您这样的买家。
不便之处，敬请原谅。
[中文版为机器翻译，准确内容请参考英文信息］",
                CreateTime = ((DateTimeOffset)Process.GetCurrentProcess().StartTime).ToUnixTimeSeconds(),
                SendTime = ((DateTimeOffset)Process.GetCurrentProcess().StartTime).ToUnixTimeSeconds(),
                ExpireTime = DateTimeOffset.Now.ToUnixTimeSeconds() * 2,
                IsForbidDelete = true
            });

            NotifyWorldChat notifyWorldChat = new();
            notifyWorldChat.ChatMessages.Add(ChatModule.MakeLuciaMessage($"Hello {session.player.PlayerData.Name}! Welcome to AscNet, please read mails if you haven't already.\n如果您还没有阅读邮件，请阅读邮件"));

            session.SendPush(notifyMails);
            session.SendPush(notifyWorldChat);
            #endregion

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
