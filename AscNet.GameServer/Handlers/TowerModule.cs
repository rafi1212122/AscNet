using MessagePack;

namespace AscNet.GameServer.Handlers
{
    #region MsgPackScheme
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessagePackObject(true)]
    public class CharacterTowerSaveTriggerConditionIdRequest
    {
        public int ConditionId;
        public int ChapterId;
    }

    [MessagePackObject(true)]
    public class CharacterTowerSaveTriggerConditionIdResponse
    {
        public int Code;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion
    
    internal class TowerModule
    {
        [RequestPacketHandler("CharacterTowerSaveTriggerConditionIdRequest")]
        public static void CharacterTowerSaveTriggerConditionIdRequestHandler(Session session, Packet.Request packet)
        {
            session.SendResponse(new CharacterTowerSaveTriggerConditionIdResponse(), packet.Id);
        }
    }
}
