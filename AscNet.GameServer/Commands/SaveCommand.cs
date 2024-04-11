namespace AscNet.GameServer.Commands
{
    [CommandName("save")]
    internal class SaveCommand : Command
    {
        public SaveCommand(Session session, string[] args, bool validate = true) : base(session, args, validate) { }

        public override string Help => "Command to save the current session state to the database";

        public override void Execute()
        {
            session.Save();
        }
    }
}
