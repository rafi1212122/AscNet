namespace AscNet.Logging
{
    public class ThreadSafeStreamWriter : IDisposable
    {
        private static ThreadSafeStreamWriter? _instance;

        private static StreamWriter _writer;

        private bool disposedValue;

        // TODO: add support for configuring
        private string _logFilePath = "log.log";

        private object _lock = new object();

        public ThreadSafeStreamWriter()
        {
            _writer = new StreamWriter(_logFilePath, true);
#if !RELEASE
            _writer.AutoFlush = true;
#endif
        }

        public static ThreadSafeStreamWriter Instance
        {
            get
            {
                return _instance ??= new ThreadSafeStreamWriter();
            }
        }

        public void AppendLine(string line)
        {
            lock (_lock)
            {
                _writer.WriteLine(line);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _writer.Flush();
                    _writer.Close();
                    _writer.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
