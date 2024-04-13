using MessagePack;

namespace AscNet.GameServer.Handlers
{

    #region MsgPackScheme
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessagePackObject(true)]
    public class PartnerComposeRequest
    {
        public List<int> TemplateIds;
        public bool IsOneKey;
    }

    [MessagePackObject(true)]
    public class PartnerComposeResponse
    {
        public int Code;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion

    internal class PartnerModule
    {
        [RequestPacketHandler("PartnerComposeRequest")]
        public static void PartnerComposeRequestHandler(Session session, Packet.Request packet)
        {
            session.SendResponse(new PartnerComposeResponse() { Code = 1 }, packet.Id);
        }
    }
}
