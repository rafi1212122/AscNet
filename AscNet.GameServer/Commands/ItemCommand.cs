using AscNet.Common.MsgPack;
using AscNet.Common.Util;
using AscNet.Table.V2.share.item;

namespace AscNet.GameServer.Commands
{
    [CommandName("item")]
    internal class ItemCommand : Command
    {
        public ItemCommand(Session session, string[] args, bool validate = true) : base(session, args, validate) { }

        public override string Help => "Command to interact with user's items";

        [Argument(0, @"^add$|^clear$|^reset$", "The operation selected (add, clear, reset)", ArgumentFlags.IgnoreCase)]
        string Op { get; set; } = string.Empty;

        [Argument(1, @"^[0-9]+$|^all$", "The target item, value is item id or 'all'", ArgumentFlags.Optional)]
        string Target { get; set; } = string.Empty;

        [Argument(2, @"^[0-9]+$|^max$", "The target item amount, value is number or 'max' (when using other than max amount will be limited to game's max limit)", ArgumentFlags.Optional)]
        string Amount { get; set; } = string.Empty;

        public override void Execute()
        {
            switch (Op.ToLower())
            {
                case "add":
                    if (Target == "all")
                    {
                        session.inventory.Items = TableReaderV2.Parse<Table.V2.share.item.ItemTable>().Select(x => new Item()
                        {
                            Id = x.Id,
                            Count = x.MaxCount ?? 999_999_999,
                            RefreshTime = DateTimeOffset.Now.ToUnixTimeSeconds(),
                            CreateTime = DateTimeOffset.Now.ToUnixTimeSeconds()
                        }).ToList();

                        NotifyItemDataList notifyItemData = new()
                        {
                            ItemDataList = session.inventory.Items
                        };
                        session.SendPush(notifyItemData);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(Target) || string.IsNullOrEmpty(Amount))
                        {
                            throw new ArgumentException("Invalid Target / Amount!");
                        }

                        if (!TableReaderV2.Parse<ItemTable>().Any(x => x.Id == Miscs.ParseIntOr(Target)))
                        {
                            throw new ArgumentException("Invalid Target item id!");
                        }

                        NotifyItemDataList notifyItemData = new();
                        notifyItemData.ItemDataList.Add(session.inventory.Do(Miscs.ParseIntOr(Target), Miscs.ParseIntOr(Amount)));
                        session.SendPush(notifyItemData);
                    }
                    break;
                default:
                    throw new InvalidOperationException("Invalid operation!");
            }
        }
    }
}
