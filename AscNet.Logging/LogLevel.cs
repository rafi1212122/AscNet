namespace AscNet.Logging
{
    public enum LogLevel : byte
    {
        OFF = 0,
        FATAL = 8,
        ERROR = 16,
        WARN = 32,
        INFO = 64,
        DEBUG = 128,
        ALL = 255
    }
}
