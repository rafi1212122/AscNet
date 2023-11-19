using AscNet.Common.MsgPack;
using MessagePack;

namespace AscNet.GameServer.Handlers
{
    #region MsgPackScheme
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessagePackObject(true)]
    public class MailReadResponse
    {
        public int Code;
    }
    
    [MessagePackObject(true)]
    public class MailReadRequest
    {
        public string Id;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion

    internal class MailModule
    {

        [RequestPacketHandler("MailReadRequest")]
        public static void MailReadRequestHandler(Session session, Packet.Request packet)
        {
            session.SendResponse(new MailReadResponse(), packet.Id);
        }
    }
}
