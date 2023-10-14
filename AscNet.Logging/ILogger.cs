namespace AscNet.Logging
{
    public interface ILogger
    {
        void Debug(string message, string memberName = "");

        void Error(string message, Exception ex = null, string memberName = "");

        void Fatal(string message, Exception ex = null, string memberName = "");

        void Info(string message, string memberName = "");

        void Dispose();

        void Warn(string message, Exception ex = null, string memberName = "");
    }

}
