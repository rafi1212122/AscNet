namespace AscNet.Logging
{
    public class Logger : ILogger
    {
        #region Members

        private readonly string _logFilePath = "log.log";
        private readonly string _loggerName = "DefaultLogger";
        private readonly LogLevel _logLevel = LogLevel.ALL;
        private readonly LogLevel _fileLogLevel = LogLevel.ALL;
        private bool _disposed;
        private Type _loggerType;

        #endregion

        #region Instantiation

        public Logger(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public Logger(string logFilePath, LogLevel logLevel) : this(logFilePath) => _logLevel = logLevel;

        public Logger(Type loggerType, string logFilePath, LogLevel logLevel) : this(logFilePath, logLevel)
        {
            _loggerType = loggerType;
            _loggerName = loggerType.Namespace.RemoveBefore('.');
        }

        public Logger(Type loggerType, LogLevel logLevel, LogLevel fileLogLevel)
        {
            _logLevel = logLevel;
            _fileLogLevel = fileLogLevel;
            _loggerType = loggerType;
            _loggerName = loggerType.Name;
        }

        public Logger(Type loggerType, string loggerName, LogLevel logLevel, LogLevel fileLogLevel)
        {
            _logLevel = logLevel;
            _fileLogLevel = fileLogLevel;
            _loggerType = loggerType;
            _loggerName = loggerName;
        }

        #endregion

        #region Methods

        public void Debug(string message, string memberName = "")
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                Append(message, memberName, LogLevel.DEBUG);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Error(string message, Exception ex = null, string memberName = "")
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                if (ex == null)
                {
                    Append(message, memberName, LogLevel.ERROR);
                }
                else
                {
                    Append(message + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, memberName,
                        LogLevel.ERROR);
                }
            }
        }

        public void Fatal(string message, Exception ex = null, string memberName = "")
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                if (ex == null)
                {
                    Append(message, memberName, LogLevel.FATAL);
                }
                else
                {
                    Append(message + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, memberName,
                        LogLevel.FATAL);
                }
            }
        }

        public void Info(string message, string memberName = "")
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                Append(message, memberName, LogLevel.INFO);
            }
        }

        public void Trace(string message, Exception ex)
        {
            // TODO
            throw new NotImplementedException();
        }

        public void Warn(string message, Exception ex = null, string memberName = "")
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                if (ex == null)
                {
                    Append(message, memberName, LogLevel.WARN);
                }
                else
                {
                    Append(message + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, memberName,
                        LogLevel.WARN);
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    ThreadSafeStreamWriter.Instance.Dispose();
                }

                _loggerType = null;
                _disposed = true;
            }
        }

        private void Append(string message, string memberName, LogLevel logLevel)
        {
            if (!string.IsNullOrWhiteSpace(memberName))
            {
                AppendToConsole($"[{memberName}][{_loggerName}]: {message}", logLevel);
                AppendToFile($"[{memberName}][{_loggerName}]: {message}", logLevel);
            }
            else
            {
                AppendToConsole($"[{_loggerName}]: {message}", logLevel);
                AppendToFile($"[{_loggerName}]: {message}", logLevel);
            }
        }

        private void AppendToConsole(string message, LogLevel logLevel)
        {
            if (logLevel <= _logLevel)
            {
                switch (logLevel)
                {
                    case LogLevel.DEBUG:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;

                    case LogLevel.INFO:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;

                    case LogLevel.WARN:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;

                    case LogLevel.ERROR:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;

                    case LogLevel.FATAL:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
                }

                Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}][{logLevel}]{message}");
                Console.ResetColor();
            }
        }

        private void AppendToFile(string message, LogLevel logLevel)
        {
            if (logLevel <= _fileLogLevel)
            {
                ThreadSafeStreamWriter.Instance.AppendLine($"[{DateTime.Now:dd.MM.yyyy HH:mm:ss.fff}][{_loggerType.Namespace}][{_loggerName}][{logLevel}]{message}");
            }
        }

        #endregion
    }

}
