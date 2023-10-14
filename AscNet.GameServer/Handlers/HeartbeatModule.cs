using AscNet.Common.MsgPack;

namespace AscNet.GameServer.Handlers
{
    internal class HeartbeatModule
    {
        [RequestPacketHandler("HeartbeatRequest")]
        public static void HeartbeatRequestHandler(Session session, Packet.Request packet)
        {
            HeartbeatResponse heartbeatResponse = new()
            {
                UtcServerTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            };
            session.SendResponse(heartbeatResponse, packet.Id);
        }

        // TODO: Pong?
    }
}
