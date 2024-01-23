using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AscNet.GameServer.Handlers
{
    #region MsgPackScheme
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessagePackObject(true)]
    public class AwarenessGetDataResponse
    {
        public dynamic AwarenessInfo { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion

    internal class AwarenessModule
    {
        [RequestPacketHandler("AwarenessGetDataRequest")]
        public static void AwarenessGetDataRequestHandler(Session session, Packet.Request packet)
        {
            session.SendResponse(new AwarenessGetDataResponse()
            {
                AwarenessInfo = {}
            }, packet.Id);
        }
    }
}
