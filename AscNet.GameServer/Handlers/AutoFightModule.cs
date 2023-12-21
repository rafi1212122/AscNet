using MessagePack;

namespace AscNet.GameServer.Handlers
{

    #region MsgPackScheme
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessagePackObject(true)]
    public class SweepRequest
    {
        public int StageId { get; set; }
        public int Count { get; set; }
    }

    [MessagePackObject(true)]
    public class SweepResponse
    {
        public int Code { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion

    internal class AutoFightModule
    {
        [RequestPacketHandler("SweepRequest")]
        public static void SweepRequestHandler(Session session, Packet.Request packet)
        {
            // TODO: Export FightSettle handler to another a function that can be used by this guy too 
            SweepRequest request = packet.Deserialize<SweepRequest>();

            session.SendResponse(new SweepResponse() { Code = 1 }, packet.Id);
        }
    }
}
