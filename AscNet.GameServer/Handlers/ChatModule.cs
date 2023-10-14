using AscNet.Common.MsgPack;

namespace AscNet.GameServer.Handlers
{
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
            getWorldChannelInfoResponse.ChannelInfos.Append(new()
            {
                ChannelId = 0,
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
    }
}
