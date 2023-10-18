using AscNet.Logging;

namespace AscNet.Common.Util
{
    #pragma warning disable CS8618, CS8602 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public abstract class TableReader<TSelf, TScheme>
    {
        public List<TScheme> All { get; set; }
        private readonly Logger c = new(typeof(TableReader<TSelf, TScheme>), nameof(TableReader<TSelf, TScheme>), LogLevel.DEBUG, LogLevel.DEBUG);
        protected abstract string FilePath { get; }
        private static TSelf _instance;
        
        public static TSelf Instance
        {
            get
            {
                _instance ??= Activator.CreateInstance<TSelf>();
                // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
                if ((_instance as TableReader<TSelf, TScheme>).All == null)
                {
                    (_instance as TableReader<TSelf, TScheme>).Load();
                    (_instance as TableReader<TSelf, TScheme>).c.Debug($"{typeof(TSelf).Name} Excel Loaded From {(_instance as TableReader<TSelf, TScheme>).FilePath}");
                }

                return _instance;
            }
        }
        
        protected abstract void Load();
    }
}

