using AscNet.Common.MsgPack;
using AscNet.Table.share.chat;
using MessagePack;

namespace AscNet.GameServer.Handlers
{
    #region MsgPackScheme
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessagePackObject(true)]
    public class SelectChatChannelRequest
    {
        public int ChannelId { get; set; }
    }
    
    [MessagePackObject(true)]
    public class SelectChatChannelResponse
    {
        public int Code { get; set; }
    }
    
    [MessagePackObject(true)]
    public class GetEmojiPackageIdResponse
    {
        public int Code { get; set; }
        public List<int> OrderEmojiPackageIds { get; set; } = new();
    }
    
    [MessagePackObject(true)]
    public class SendChatRequest
    {
        public ChatData ChatData { get; set; }
        public List<long> TargetIdList { get; set; } = new();
    }
    
    [MessagePackObject(true)]
    public class SendChatResponse
    {
        public int Code { get; set; }
        public ChatData ChatData { get; set; }
        public long RefreshTime { get; set; }
    }
    
    [MessagePackObject(true)]
    public class NotifyWorldChat
    {
        public List<ChatData> ChatMessages { get; set; } = new();
    }
    
    [MessagePackObject(true)]
    public class ChatData
    {
        public int MessageId { get; set; }
        public ChatChannelType ChannelType { get; set; }
        public ChatMsgType MsgType { get; set; }
        public long SenderId { get; set; }
        public int Icon { get; set; }
        public string NickName { get; set; }
        public long TargetId { get; set; }
        public long CreateTime { get; set; }
        public string? Content { get; set; }
        public int GiftId { get; set; }
        public int GiftCount { get; set; }
        public ChatGiftState GiftStatus { get; set; }
        public bool IsRead { get; set; }
        public int CurrMedalId { get; set; }
        public int BabelTowerLevel { get; set; }
        public int BabelTowerTitleId { get; set; }
        public int GuildRankLevel { get; set; }
        public string? GuildName { get; set; }
        public int CollectWordId { get; set; }
        public int NameplateId { get; set; }
    }

    public enum ChatChannelType
    {
        System = 1,
        World = 2,
        Private = 3,
        Room = 4,
        Battle = 5,
        Guild = 6,
        Mentor = 7,
    }

    public enum ChatMsgType
    {
        Normal = 1,
        Emoji = 2,
        Gift = 3,
        Tips = 4,
        RoomMsg = 5,
        System = 6,
        SpringFestival = 7,
    }

    public enum ChatGiftState {
        None = 0,
        WaitReceive = 1, 
        Received = 2, 
        Fetched = 3, 
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#endregion

internal class ChatModule
    {
        [RequestPacketHandler("EnterWorldChatRequest")]
        public static void EnterWorldChatRequestHandler(Session session, Packet.Request packet)
        {
            EnterWorldChatResponse enterWorldChatResponse = new()
            {
                Code = 0,
                ChannelId = 0
            };
            session.SendResponse(enterWorldChatResponse, packet.Id);
        }

        [RequestPacketHandler("GetWorldChannelInfoRequest")]
        public static void GetWorldChannelInfoRequestHandler(Session session, Packet.Request packet)
        {
            GetWorldChannelInfoResponse getWorldChannelInfoResponse = new();
            getWorldChannelInfoResponse.ChannelInfos.Add(new()
            {
                ChannelId = 0, // Channel 1
                PlayerNum = 0
            });
            getWorldChannelInfoResponse.ChannelInfos.Add(new()
            {
                ChannelId = 1, // Recuruit channel (we don't use this!)
                PlayerNum = 0
            });

            session.SendResponse(getWorldChannelInfoResponse, packet.Id);
        }
        
        [RequestPacketHandler("OfflineMessageRequest")]
        public static void OfflineMessageRequestHandler(Session session, Packet.Request packet)
        {
            OfflineMessageResponse offlineMessageResponse = new()
            {
                Code = 0,
                Messages = Array.Empty<dynamic>()
            };
            session.SendResponse(offlineMessageResponse, packet.Id);
        }
        
        [RequestPacketHandler("SendChatRequest")]
        public static void SendChatRequestHandler(Session session, Packet.Request packet)
        {
            SendChatRequest request = MessagePackSerializer.Deserialize<SendChatRequest>(packet.Content);
            request.ChatData.SenderId = session.player.PlayerData.Id;
            request.ChatData.Icon = (int)session.player.PlayerData.CurrHeadPortraitId;
            request.ChatData.NickName = session.player.PlayerData.Name;

            NotifyWorldChat notifyWorldChat = new();
            notifyWorldChat.ChatMessages.Add(request.ChatData);

            session.SendPush(notifyWorldChat);
            session.SendResponse(new SendChatResponse() { Code = 0, ChatData = request.ChatData, RefreshTime = DateTimeOffset.Now.ToUnixTimeSeconds() }, packet.Id);
        }
        
        [RequestPacketHandler("SelectChatChannelRequest")]
        public static void SelectChatChannelRequestHandler(Session session, Packet.Request packet)
        {
            // SelectChatChannelRequest request = MessagePackSerializer.Deserialize<SelectChatChannelRequest>(packet.Content);

            // disabling channel switching because the game is cringe and we don't need it anyway.
            session.SendResponse(new SelectChatChannelResponse()
            {
                Code = 20033013 // ChatChannelNotExist
            }, packet.Id);
        }

        #region EmojiPackModule
        [RequestPacketHandler("GetEmojiPackageIdRequest")]
        public static void GetEmojiPackageIdRequestHandler(Session session, Packet.Request packet)
        {
            session.SendResponse(new GetEmojiPackageIdResponse()
            {
                Code = 0,
                OrderEmojiPackageIds = EmojiPackTableReader.Instance.All.Select(x => x.Id).ToList()
            }, packet.Id);
        }
        #endregion
    }
}
