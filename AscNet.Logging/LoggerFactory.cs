using System.Runtime.CompilerServices;

namespace AscNet.Logging
{
    public static class LoggerFactory
    {
        public static ILogger Logger { get; set; }

        public static void Debug(string message, [CallerMemberName] string memberName = "") => Logger.Debug(message, memberName);

        public static void Error(string message, Exception ex = null, [CallerMemberName] string memberName = "") => Logger.Error(message, ex, memberName);

        public static void Fatal(string message, Exception ex = null, [CallerMemberName] string memberName = "") => Logger.Fatal(message, ex, memberName);

        public static void Info(string message, [CallerMemberName] string memberName = "") => Logger.Info(message, memberName);

        public static void Warn(string message, Exception ex = null, [CallerMemberName] string memberName = "") => Logger.Warn(message, ex, memberName);

        public static void Dispose() => Logger.Dispose();

        public static void InitializeLogger(ILogger log) => Logger = log;
    }
}
