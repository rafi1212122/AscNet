using AscNet.Common.Util;
using AscNet.Table.V2.share.player;

namespace AscNet.GameServer.Commands
{
    [CommandName("level")]
    internal class LevelCommand : Command
    {
        public LevelCommand(Session session, string[] args, bool validate = true) : base(session, args, validate) { }

        public override string Help => "Command to change the Commandant level";

        [Argument(0, @"^[0-9]+$|^max$", "The target level, value is number or 'max'")]
        string Level { get; set; } = string.Empty;

        public override void Execute()
        {
            int maxLevel = TableReaderV2.Parse<PlayerTable>().Count;
            int level = Miscs.ParseIntOr(Level);

            if (Level == "max")
            {
                session.player.PlayerData.Level = maxLevel;
                session.ExpSanityCheck();
            }
            else if (level > 0)
            {
                session.player.PlayerData.Level = level;
                session.ExpSanityCheck();
            }
            else
            {
                throw new ArgumentException("Invalid Level!");
            }
        }
    }
}
