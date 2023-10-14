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

        [RequestPacketHandler("Ping")]
        public static void PingHandler(Session session, Packet.Request packet)
        {
            session.SendResponse(new Pong()
            {
                UtcTime = (ulong)DateTimeOffset.UtcNow.UtcTicks
            }, packet.Id);
        }
    }
}
