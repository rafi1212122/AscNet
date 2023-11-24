using AscNet.Logging;
using System.Reflection;

namespace AscNet.Common.Util
{
    #pragma warning disable CS8618, CS8602 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public abstract class TableReader<TSelf, TScheme>
    {
        public List<TScheme> All { get; set; }
        protected abstract string FilePath { get; }
        private readonly Logger c = new(typeof(TableReader<TSelf, TScheme>), nameof(TableReader<TSelf, TScheme>), LogLevel.DEBUG, LogLevel.DEBUG);
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
        
        public abstract void Load();
    }

    public interface ITable
    {
        abstract static string File { get; }
    }

    public static class TableReaderV2
    {
        private static readonly Logger c = new(typeof(TableReaderV2), nameof(TableReaderV2), LogLevel.DEBUG, LogLevel.DEBUG);

        public static List<T> Parse<T>() where T : ITable
        {
            List<T> result = new();

            try
            {
                using (var reader = new StreamReader(T.File))
                {
                    // Read the header line to get column names
                    string headerLine = reader.ReadLine()!;
                    string[] columnNames = headerLine.Split('\t');

                    // Read data lines and parse them into objects
                    while (!reader.EndOfStream)
                    {
                        string dataLine = reader.ReadLine()!;
                        if (string.IsNullOrEmpty(dataLine))
                            break;

                        string[] values = dataLine.Split('\t');

                        T obj = MapToObject<T>(columnNames, values);
                        result.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                c.Error($"An error occurred: {ex.Message}");
            }

            return result;
        }

        static T MapToObject<T>(string[] columnNames, string[] values) where T : ITable
        {
            T obj = Activator.CreateInstance<T>();

            for (int i = 0; i < Math.Min(columnNames.Length, values.Length); i++)
            {
                PropertyInfo? prop = typeof(T).GetProperty(columnNames[i].Split('[').First());
                if (prop != null)
                {
                    if (prop.PropertyType == typeof(List<int>))
                    {
                        if (prop.GetValue(obj) is null)
                        {
                            prop.SetValue(obj, new List<int>());
                        }
                        string value = values[i];
                        if (!string.IsNullOrEmpty(value))
                        {
                            prop.PropertyType.GetMethod("Add").Invoke(prop.GetValue(obj), new object[] { int.Parse(value) });
                        }
                    }
                    else if (prop.PropertyType == typeof(List<string>))
                    {
                        if (prop.GetValue(obj) is null)
                        {
                            prop.SetValue(obj, new List<string>());
                        }
                        string value = values[i];
                        if (!string.IsNullOrEmpty(value))
                        {
                            prop.PropertyType.GetMethod("Add").Invoke(prop.GetValue(obj), new object[] { value });
                        }
                    }
                    else if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(int?))
                    {
                        if (!string.IsNullOrEmpty(values[i]))
                            prop.SetValue(obj, int.Parse(values[i]));
                        else
                            prop.SetValue(obj, null);
                    }
                    else
                    {
                        prop.SetValue(obj, values[i]);
                    }
                }
            }

            return obj;
        }
    }
}

