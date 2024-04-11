using Config.Net;
using MongoDB.Driver;

namespace AscNet.Common
{
    public static class Common
    {
        public static readonly IConfig config;
        private static readonly MongoClient mongoClient;
        public static readonly IMongoDatabase db;

        static Common()
        {
            config = new ConfigurationBuilder<IConfig>().UseJsonFile("Configs/config.json").Build();
            
            mongoClient = new(
               new MongoClientSettings
               {
                   Server = new MongoServerAddress(config.Database.Host, config.Database.Port),
                   //    Credential = MongoCredential.CreateCredential("admin", config.Database.Username, config.Database.Password)
               }
           );
           db = mongoClient.GetDatabase(config.Database.Name);
        }

        /*
        public static void DumpTables()
        {
            IEnumerable<Type> tableTypes = Assembly.GetAssembly(typeof(Table.V2.client.activity.ActivityGroupTable))!.GetTypes().Where(t => typeof(ITable).IsAssignableFrom(t));
            string baseSavePath = "/PGR_Data/";

            Console.WriteLine($"Found {tableTypes.Count()} types!");
            foreach (Type type in tableTypes)
            {
                try
                {
                    object? values = typeof(TableReaderV2).GetMethod("Parse")?.MakeGenericMethod(type).Invoke(null, null);
                    if (values is not null)
                    {
                        // this will create the folder on ur drive root sorry
                        string savePath = baseSavePath + string.Join("/", type.FullName!.Split(".").Skip(3));
                        if (!Directory.Exists(Path.GetDirectoryName(savePath)))
                            Directory.CreateDirectory(Path.GetDirectoryName(savePath)!);
                        File.WriteAllText(new string(savePath.Take(savePath.Length - 5).ToArray()) + ".json", JsonConvert.SerializeObject(values, Formatting.Indented));
                        Console.WriteLine(type.FullName);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{type.FullName} failed!, {ex.Message}");
                }
            }
        }
        */
    }

    public class ServerCodeException : Exception
    {
        public int Code { get; set; }

        public ServerCodeException(string message, int code)
            : base(message)
        {
            Code = code;
        }
    }
}
