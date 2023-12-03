using AscNet.Common.Util;
using AscNet.Common;
using AscNet.Table.V2.share.equip;
using AscNet.Common.MsgPack;

namespace AscNet.GameServer.Commands
{
    [CommandName("equip")]
    internal class EquipCommand : Command
    {
        public EquipCommand(Session session, string[] args, bool validate = true) : base(session, args, validate)
        {
        }

        public override string Help => "Command to interact with your equips";

        [Argument(0, @"^add$", "The operation selected (add)", ArgumentFlags.IgnoreCase)]
        string Op { get; set; } = string.Empty;

        [Argument(1, @"^[0-9]+$|^all$", "The target character, value is character id or 'all'")]
        string Target { get; set; } = string.Empty;

        public override void Execute()
        {
            NotifyEquipDataList notifyEquipData = new();

            switch (Op)
            {
                case "add":
                    if (Target == "all")
                    {
                        foreach (var equip in TableReaderV2.Parse<EquipTable>())
                        {
                            var newEquip = session.character.AddEquip((uint)equip.Id);
                            if (newEquip is not null)
                                notifyEquipData.EquipDataList.Add(newEquip);
                        }
                    }
                    else
                    {
                        var equip = TableReaderV2.Parse<EquipTable>().Find(x => x.Id == Miscs.ParseIntOr(Target)) ?? throw new ServerCodeException("Equip by id not found", 20021001);
                        var newEquip = session.character.AddEquip((uint)equip.Id);
                        if (newEquip is not null)
                            notifyEquipData.EquipDataList.Add(newEquip);
                    }
                    break;
                default:
                    throw new InvalidOperationException("Invalid operation!");
            }

            session.SendPush(notifyEquipData);
        }
    }
}
