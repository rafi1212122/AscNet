using AscNet.Common.MsgPack;

namespace AscNet.GameServer.Handlers
{
    internal class TaskModule
    {
        [RequestPacketHandler("DoClientTaskEventRequest")]
        public static void DoClientTaskEventRequestHandler(Session session, Packet.Request packet)
        {
            DoClientTaskEventResponse doClientTaskEventResponse = new()
            {
                Code = 0
            };
            session.SendResponse(doClientTaskEventResponse, packet.Id);
        }
    }
}
