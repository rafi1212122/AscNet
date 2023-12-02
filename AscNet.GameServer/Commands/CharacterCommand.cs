using AscNet.Common.MsgPack;
using AscNet.Table.share.character;

namespace AscNet.GameServer.Commands
{
    [CommandName("character")]
    internal class CharacterCommand : Command
    {
        public CharacterCommand(Session session, string[] args, bool validate = true) : base(session, args, validate) { }

        public override string Help => "Command to modify characters.";

        [Argument(0, @"^add$", "The operation selected (add)")]
        string Op { get; set; } = string.Empty;

        [Argument(1, @"^[0-9]+$|^all$", "The target character, value is character id or 'all'")]
        string Target { get; set; } = string.Empty;

        public override void Execute()
        {
            uint id = 0;

            uint.TryParse(Target, out id);

            switch (Op)
            {
                case "add":
                    if (Target == "all")
                    {
                        new Thread(() =>
                        {
                            foreach (CharacterTable character in CharacterTableReader.Instance.All)
                            {
                                if (session.character.Characters.FirstOrDefault(c => c.Id == character.Id) is not null)
                                    session.character.AddCharacter((uint)character.Id);

                                Thread.Sleep(100);
                            }
                        }).Start();
                    }
                    else if (id > 0)
                    {
                        if (session.character.Characters.Find(c => c.Id == id) == null)
                            session.character.AddCharacter(id);
                    }
                    else
                        throw new ArgumentException("Invalid Target / ID!");
                    break;
                default:
                    throw new InvalidOperationException("Invalid operation!");
            }
        }
    }
}
