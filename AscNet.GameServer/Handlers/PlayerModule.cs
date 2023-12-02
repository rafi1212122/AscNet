using AscNet.Common.MsgPack;
using MessagePack;

namespace AscNet.GameServer.Handlers
{

    #region MsgPackScheme
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessagePackObject(true)]
    public class ChangePlayerMarkRequest
    {
        public long MaskId;
    }

    [MessagePackObject(true)]
    public class ChangeCommunicationResponse
    {
        public int Code;
    }

    [MessagePackObject(true)]
    public class TouchBoardMutualRequest
    {
        public int CharacterId;
    }

    [MessagePackObject(true)]
    public class TouchBoardMutualResponse
    {
    }

    [MessagePackObject(true)]
    public class ChangeCommunicationRequest
    {
        public long Id;
    }

    [MessagePackObject(true)]
    public class ChangePlayerBirthdayRequest : Birthday
    {
    }

    [MessagePackObject(true)]
    public class ChangePlayerBirthdayResponse
    {
        public int Code;
    }

    [MessagePackObject(true)]
    public class ChangePlayerSignRequest
    {
        public string Msg;
    }

    [MessagePackObject(true)]
    public class ChangePlayerSignResponse
    {
        public int Code;
    }

    [MessagePackObject(true)]
    public class NotifyPlayerName
    {
        public string Name;
    }

    [MessagePackObject(true)]
    public class ChangePlayerNameRequest
    {
        public string Name;
    }

    [MessagePackObject(true)]
    public class ChangePlayerNameResponse
    {
        public int Code;
        public long NextCanChangeTime;
    }

    [MessagePackObject(true)]
    public class RemovePlayerDisplayCharIdRequest
    {
        public long CharId;
    }

    [MessagePackObject(true)]
    public class RemovePlayerDisplayCharIdResponse
    {
        public int Code;
        public List<long> DisplayCharIdList;
    }

    [MessagePackObject(true)]
    public class AddPlayerDisplayCharIdRequest
    {
        public long CharId;
    }

    [MessagePackObject(true)]
    public class AddPlayerDisplayCharIdResponse
    {
        public int Code;
        public List<long> DisplayCharIdList;
    }

    [MessagePackObject(true)]
    public class UpdatePlayerDisplayCharIdRequest
    {
        public long NewCharId;
        public long OldCharId;
    }

    [MessagePackObject(true)]
    public class UpdatePlayerDisplayCharIdResponse
    {
        public int Code;
        public List<long> DisplayCharIdList;
    }

    [MessagePackObject(true)]
    public class SetDisplayCharIdFirstRequest
    {
        public long CharId;
    }

    [MessagePackObject(true)]
    public class SetDisplayCharIdFirstResponse
    {
        public int Code;
        public List<long> DisplayCharIdList;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion

    internal class PlayerModule
    {
        [RequestPacketHandler("ChangePlayerMarkRequest")]
        public static void ChangePlayerMarkRequestHandler(Session session, Packet.Request packet)
        {
            ChangePlayerMarkRequest request = MessagePackSerializer.Deserialize<ChangePlayerMarkRequest>(packet.Content);

            if (session.player.PlayerData.Marks is null)
            {
                session.log.Debug("Marks is somehow null");
                session.player.PlayerData.Marks = new();
            }

            session.player.PlayerData.Marks.Add(request.MaskId);
            session.SendResponse(new ChangePlayerMarkResponse(), packet.Id);
        }

        [RequestPacketHandler("ChangeCommunicationRequest")]
        public static void ChangeCommunicationRequestHandler(Session session, Packet.Request packet)
        {
            ChangeCommunicationRequest request = MessagePackSerializer.Deserialize<ChangeCommunicationRequest>(packet.Content);
            session.player.PlayerData.Communications.Add(request.Id);

            session.SendResponse(new ChangeCommunicationResponse(), packet.Id);
        }

        [RequestPacketHandler("TouchBoardMutualRequest")]
        public static void TouchBoardMutualRequestHandler(Session session, Packet.Request packet)
        {
            TouchBoardMutualRequest request = MessagePackSerializer.Deserialize<TouchBoardMutualRequest>(packet.Content);

            session.SendResponse(new TouchBoardMutualResponse(), packet.Id);
        }

        [RequestPacketHandler("ChangePlayerNameRequest")]
        public static void ChangePlayerNameRequestHandler(Session session, Packet.Request packet)
        {
            ChangePlayerNameRequest request = MessagePackSerializer.Deserialize<ChangePlayerNameRequest>(packet.Content);
            session.player.PlayerData.Name = request.Name;

            NotifyPlayerName notifyPlayerName = new() { Name = session.player.PlayerData.Name };
            session.SendPush(notifyPlayerName);
            session.SendResponse(new ChangePlayerNameResponse() { NextCanChangeTime = DateTimeOffset.Now.ToUnixTimeSeconds() }, packet.Id);
        }

        [RequestPacketHandler("ChangePlayerSignRequest")]
        public static void ChangePlayerSignRequestHandler(Session session, Packet.Request packet)
        {
            ChangePlayerSignRequest request = MessagePackSerializer.Deserialize<ChangePlayerSignRequest>(packet.Content);
            session.player.PlayerData.Sign = request.Msg;

            session.SendResponse(new ChangePlayerSignResponse(), packet.Id);
        }

        [RequestPacketHandler("ChangePlayerBirthdayRequest")]
        public static void ChangePlayerBirthdayRequestHandler(Session session, Packet.Request packet)
        {
            ChangePlayerBirthdayRequest request = MessagePackSerializer.Deserialize<ChangePlayerBirthdayRequest>(packet.Content);
            session.player.PlayerData.Birthday = request;

            session.SendResponse(new ChangePlayerBirthdayResponse(), packet.Id);
        }

        [RequestPacketHandler("UpdatePlayerDisplayCharIdRequest")]
        public static void UpdatePlayerDisplayCharIdRequestHandler(Session session, Packet.Request packet)
        {
            UpdatePlayerDisplayCharIdRequest request = MessagePackSerializer.Deserialize<UpdatePlayerDisplayCharIdRequest>(packet.Content);
            if (session.player.PlayerData.DisplayCharIdList.Contains(request.OldCharId))
            {
                session.player.PlayerData.DisplayCharIdList[session.player.PlayerData.DisplayCharIdList.IndexOf(request.OldCharId)] = request.NewCharId;
            }

            session.SendResponse(new UpdatePlayerDisplayCharIdResponse() { DisplayCharIdList = session.player.PlayerData.DisplayCharIdList }, packet.Id);
        }

        [RequestPacketHandler("AddPlayerDisplayCharIdRequest")]
        public static void AddPlayerDisplayCharIdRequestHandler(Session session, Packet.Request packet)
        {
            AddPlayerDisplayCharIdRequest request = MessagePackSerializer.Deserialize<AddPlayerDisplayCharIdRequest>(packet.Content);
            session.player.PlayerData.DisplayCharIdList.Add(request.CharId);

            session.SendResponse(new AddPlayerDisplayCharIdResponse() { DisplayCharIdList = session.player.PlayerData.DisplayCharIdList }, packet.Id);
        }

        [RequestPacketHandler("RemovePlayerDisplayCharIdRequest")]
        public static void RemovePlayerDisplayCharIdRequestHandler(Session session, Packet.Request packet)
        {
            RemovePlayerDisplayCharIdRequest request = MessagePackSerializer.Deserialize<RemovePlayerDisplayCharIdRequest>(packet.Content);
            session.player.PlayerData.DisplayCharIdList.Remove(request.CharId);

            session.SendResponse(new RemovePlayerDisplayCharIdResponse() { DisplayCharIdList = session.player.PlayerData.DisplayCharIdList }, packet.Id);
        }

        [RequestPacketHandler("SetDisplayCharIdFirstRequest")]
        public static void SetDisplayCharIdFirstRequestHandler(Session session, Packet.Request packet)
        {
            SetDisplayCharIdFirstRequest request = MessagePackSerializer.Deserialize<SetDisplayCharIdFirstRequest>(packet.Content);
            session.player.PlayerData.DisplayCharIdList.Remove(request.CharId);
            session.player.PlayerData.DisplayCharIdList.Insert(0, request.CharId);

            session.SendResponse(new SetDisplayCharIdFirstResponse() { DisplayCharIdList = session.player.PlayerData.DisplayCharIdList }, packet.Id);
        }
    }
}
