using AscNet.Common.MsgPack;
using AscNet.Common.Util;
using AscNet.GameServer.Handlers;
using AscNet.Table.V2.share.fashion;

namespace AscNet.GameServer.Commands
{
    [CommandName("coating")]
    internal class CoatingCommand : Command
    {
        public CoatingCommand(Session session, string[] args, bool validate = true) : base(session, args, validate) { }

        public override string Help => "Command to unlock all coatings of characters.";

        [Argument(0, @"^unlock$", "The operation selected (unlock)")]
        string Op { get; set; } = string.Empty;

        [Argument(1, @"^[0-9]+$|^all$", "The target character, value is character id or 'all' for all owned character")]
        string Target { get; set; } = string.Empty;

        public override void Execute()
        {
            int characterId = Miscs.ParseIntOr(Target);

            switch (Op)
            {
                case "unlock":
                    if (Target == "all")
                    {
                        List<FashionList> newFashions = new();
                        foreach (var fashion in TableReaderV2.Parse<FashionTable>().Where(x => session.character.Characters.Any(y => y.Id == x.CharacterId)))
                        {
                            if (session.character.Fashions.Any(x => x.Id == fashion.Id))
                                continue;

                            newFashions.Add(new() { Id = fashion.Id });
                        }

                        session.SendPush(new FashionSyncNotify() { FashionList = newFashions });
                        session.character.Fashions.AddRange(newFashions);
                    }
                    else
                    {
                        List<FashionList> newFashions = new();
                        foreach (var fashion in TableReaderV2.Parse<FashionTable>().Where(x => x.CharacterId == characterId))
                        {
                            if (session.character.Fashions.Any(x => x.Id == fashion.Id))
                                continue;

                            newFashions.Add(new() { Id = fashion.Id });
                        }

                        session.SendPush(new FashionSyncNotify() { FashionList = newFashions });
                        session.character.Fashions.AddRange(newFashions);
                    }

                    break;
                default:
                    throw new InvalidOperationException("Invalid operation!");
            }
        }
    }
}
