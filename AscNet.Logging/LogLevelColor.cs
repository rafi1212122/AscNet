namespace AscNet.Logging
{
    public class LogLevelColor
    {

        public ConsoleColor Debug { get; set; } = ConsoleColor.Magenta;

        public ConsoleColor Info { get; set; } = ConsoleColor.Green;

        public ConsoleColor Warning { get; set; } = ConsoleColor.Yellow;

        public ConsoleColor Error { get; set; } = ConsoleColor.Red;

        public ConsoleColor Fatal { get; set; } = ConsoleColor.DarkRed;

    }
}
