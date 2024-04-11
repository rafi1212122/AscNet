using AscNet.Common;
using AscNet.Common.Database;
using AscNet.Common.MsgPack;
using AscNet.Common.Util;
using AscNet.Table.V2.share.attrib;
using AscNet.Table.V2.share.equip;
using AscNet.Table.V2.share.item;
using MessagePack;

namespace AscNet.GameServer.Handlers
{
    #region MsgPackScheme
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessagePackObject(true)]
    public class EquipUpdateLockRequest
    {
        public int EquipId;
        public bool IsLock;
    }

    [MessagePackObject(true)]
    public class EquipUpdateLockResponse
    {
        public int Code;
    }

    [MessagePackObject(true)]
    public class EquipBreakthroughRequest
    {
        public int EquipId;
    }

    [MessagePackObject(true)]
    public class EquipBreakthroughResponse
    {
        public int Code;
    }

    [MessagePackObject(true)]
    public class EquipResonanceRequest
    {
        public int EquipId;
        public int Slot;
        public int? UseItemId;
        public int? UseEquipId;
        public int? SelectSkillId;
        public int? CharacterId;
        public EquipResonanceType? SelectType;
    }

    [MessagePackObject(true)]
    public class EquipResonanceResponse
    {
        public int Code;
        public ResonanceInfo ResonanceData;
    }

    [MessagePackObject(true)]
    public class EquipPutOnRequest
    {
        public int CharacterId;
        public int EquipId;
        public int Site;
    }

    [MessagePackObject(true)]
    public class EquipPutOnResponse
    {
        public int Code;
    }

    [MessagePackObject(true)]
    public class EquipTakeOffRequest
    {
        public List<int> EquipIds;
    }

    [MessagePackObject(true)]
    public class EquipTakeOffResponse
    {
        public int Code;
    }

    [MessagePackObject(true)]
    public class EquipLevelUpRequest
    {
        public int EquipId;
        public Dictionary<int, int> UseItems;
        public List<int> UseEquipIdList;
    }

    [MessagePackObject(true)]
    public class EquipLevelUpResponse
    {
        public int Code;
        public int Level;
        public int Exp;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion

    internal class EquipModule
    {
        [RequestPacketHandler("EquipLevelUpRequest")]
        public static void EquipLevelUpRequestHandler(Session session, Packet.Request packet)
        {
            EquipLevelUpRequest request = packet.Deserialize<EquipLevelUpRequest>();

            NotifyItemDataList notifyItemData = new();
            int totalExp = 0;
            int totalCost = 0;
            foreach (var item in request.UseItems)
            {
                ItemTable? itemTable = TableReaderV2.Parse<ItemTable>().FirstOrDefault(x => x.Id == item.Key);
                if (itemTable is not null)
                {
                    var upgradeInfo = itemTable.GetEquipUpgradeInfo() * item.Value;
                    totalExp += upgradeInfo.Exp;
                    totalCost += upgradeInfo.Cost;
                    notifyItemData.ItemDataList.Add(session.inventory.Do(item.Key, item.Value * -1));
                }
            }

            notifyItemData.ItemDataList.Add(session.inventory.Do(Inventory.Coin, totalCost * -1));
            session.SendPush(notifyItemData);

            EquipLevelUpResponse rsp = new()
            {
                Code = 0
            };

            var upEquip = session.character.AddEquipExp(request.EquipId, totalExp);
            if (upEquip != null)
            {
                rsp.Level = upEquip.Level;
                rsp.Exp = upEquip.Exp;

                NotifyEquipDataList notifyEquipDataList = new();
                notifyEquipDataList.EquipDataList.Add(upEquip);
                session.SendPush(notifyEquipDataList);
            }

            session.SendResponse(rsp, packet.Id);
        }

        [RequestPacketHandler("EquipBreakthroughRequest")]
        public static void EquipBreakthroughRequestHandler(Session session, Packet.Request packet)
        {
            EquipBreakthroughRequest request = packet.Deserialize<EquipBreakthroughRequest>();
            var response = new EquipBreakthroughResponse();
            var equip = session.character.Equips.Find(x => x.Id == request.EquipId);
            if (equip is null)
            {
                // EquipManagerGetCharEquipBySiteNotFound
                response.Code = 20021012;
            }
            else
            {
                EquipBreakThroughTable? equipBreakThrough = TableReaderV2.Parse<EquipBreakThroughTable>().Find(x => x.EquipId == equip.TemplateId && equip.Breakthrough == x.Times);
                if (equipBreakThrough is not null && TableReaderV2.Parse<EquipBreakThroughTable>().Any(x => x.EquipId == equip.TemplateId && equip.Breakthrough + 1 == x.Times))
                {
                    NotifyItemDataList notifyItemData = new();

                    for (int i = 0; i < Math.Min(equipBreakThrough.ItemId.Count, equipBreakThrough.ItemCount.Count); i++)
                    {
                        notifyItemData.ItemDataList.Add(session.inventory.Do(equipBreakThrough.ItemId[i], equipBreakThrough.ItemCount[i] * -1));
                    }
                    if (equipBreakThrough.UseMoney is not null && equipBreakThrough.UseMoney > 0)
                        notifyItemData.ItemDataList.Add(session.inventory.Do(equipBreakThrough.UseItemId ?? 1, (equipBreakThrough.UseMoney ?? 0) * -1));

                    session.SendPush(notifyItemData);

                    equip.Breakthrough += 1;
                    equip.Level = 1;
                    equip.Exp = 0;
                }
                else if (equipBreakThrough is not null)
                {
                    // EquipManagerBreakthroughMaxBreakthrough
                    response.Code = 20021010;
                }
                else
                {
                    // EquipBreakthroughTemplateNotFound
                    response.Code = 20021002;
                }
            }

            session.SendResponse(response, packet.Id);
        }

        [RequestPacketHandler("EquipUpdateLockRequest")]
        public static void EquipUpdateLockRequestHandler(Session session, Packet.Request packet)
        {
            EquipUpdateLockRequest request = packet.Deserialize<EquipUpdateLockRequest>();
            var response = new EquipUpdateLockResponse();
            var equip = session.character.Equips.Find(x => x.Id == request.EquipId);
            if (equip is null)
            {
                // EquipManagerGetCharEquipBySiteNotFound
                response.Code = 20021012;
            }
            else
            {
                equip.IsLock = request.IsLock;
            }

            session.SendResponse(response, packet.Id);
        }

        [RequestPacketHandler("EquipPutOnRequest")]
        public static void EquipPutOnRequestHandler(Session session, Packet.Request packet)
        {
            EquipPutOnRequest request = packet.Deserialize<EquipPutOnRequest>();

            var prevEquip = session.character.Equips.Find(x => x.CharacterId == request.CharacterId && TableReaderV2.Parse<EquipTable>().Find(t => t.Id == x.TemplateId)?.Site == request.Site);
            var toEquip = session.character.Equips.Find(x => x.Id == request.EquipId);

            if (prevEquip is not null && toEquip is not null)
            {
                prevEquip.CharacterId = 0;
            }
            if (toEquip is not null)
            {
                toEquip.CharacterId = request.CharacterId;
            }
            else
            {
                // EquipManagerGetCharEquipBySiteNotFound
                session.SendResponse(new EquipPutOnResponse() { Code = 20021012 }, packet.Id);
                return;
            }

            NotifyEquipDataList notifyEquipData = new();
            notifyEquipData.EquipDataList.Add(toEquip);
            if (prevEquip is not null)
                notifyEquipData.EquipDataList.Add(prevEquip);
            session.SendPush(notifyEquipData);

            session.SendResponse(new EquipPutOnResponse(), packet.Id);
        }

        [RequestPacketHandler("EquipTakeOffRequest")]
        public static void EquipTakeOffRequestHandler(Session session, Packet.Request packet)
        {
            EquipTakeOffRequest request = packet.Deserialize<EquipTakeOffRequest>();

            foreach (var equipId in request.EquipIds)
            {
                var equip = session.character.Equips.Find(x => x.Id == equipId);
                if (equip is not null)
                    equip.CharacterId = 0;
            }

            session.SendResponse(new EquipTakeOffResponse(), packet.Id);
        }

        // TODO: Swapping equip resonance is broken, this is only partially implemented!
        [RequestPacketHandler("EquipResonanceRequest")]
        public static void EquipResonanceRequestHandler(Session session, Packet.Request packet)
        {
            EquipResonanceRequest request = packet.Deserialize<EquipResonanceRequest>();

            var equip = session.character.Equips.Find(x => x.Id == request.EquipId);

            if (equip is null)
            {
                // EquipManagerGetCharEquipBySiteNotFound
                session.SendResponse(new EquipResonanceResponse() { Code = 20021012 }, packet.Id);
                return;
            }

            #region Pools
            EquipResonanceTable? equipResonance = TableReaderV2.Parse<EquipResonanceTable>().Find(x => x.Id == equip.TemplateId);
            List<ResonanceInfo> resonancePool = new();
            foreach (var attribPoolId in equipResonance?.AttribPoolId ?? [])
            {
                var attribPool = TableReaderV2.Parse<AttribPoolTable>().Where(x => x.PoolId == attribPoolId);
                foreach (var attrib in attribPool)
                {
                    resonancePool.Add(new()
                    {
                        Slot = request.Slot,
                        Type = EquipResonanceType.Attrib,
                        TemplateId = attrib.Id
                    });
                }
            }
            foreach (var characterSkillPoolId in equipResonance?.CharacterSkillPoolId ?? [])
            {
                throw new NotImplementedException();
            }
            foreach (var weaponSkillPoolId in equipResonance?.WeaponSkillPoolId ?? [])
            {
                throw new NotImplementedException();
            }
            #endregion

            if (request.UseItemId is not null && request.UseItemId > 0)
            {
                EquipResonanceUseItemTable? resonanceUseItem = TableReaderV2.Parse<EquipResonanceUseItemTable>().Find(x => x.Id == equip.TemplateId);
                if (resonanceUseItem is not null)
                {
                    NotifyItemDataList notifyItemData = new();
                    for (int i = 0; i < Math.Min(resonanceUseItem.ItemId.Count, resonanceUseItem.ItemCount.Count); i++)
                    {
                        notifyItemData.ItemDataList.Add(session.inventory.Do(resonanceUseItem.ItemId[i], resonanceUseItem.ItemCount[i] * -1));
                    }

                    session.SendPush(notifyItemData);
                }
                else
                {
                    session.log.Error($"EquipResonanceUseItem for template {equip.TemplateId} not found!");
                    // EquipResonanceUseItemTemplateNotFound
                    session.SendResponse(new EquipResonanceResponse() { Code = 20021038 }, packet.Id);
                    return;
                }
            }
            else if (request.UseEquipId is not null && request.UseEquipId > 0)
            {
                throw new NotImplementedException();
            }

            ResonanceInfo resonance = resonancePool[Random.Shared.Next(resonancePool.Count)];
            equip.ResonanceInfo.Add(resonance);

            session.SendResponse(new EquipResonanceResponse() { ResonanceData = resonance }, packet.Id);
        }
    }
}
