using System.Reflection;
using MongoDB.Driver;
using Config.Net;
using Newtonsoft.Json;

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

        public static void DumpTables()
        {
            IEnumerable<Type> tableTypes = Assembly.GetAssembly(typeof(Table.client.activity.ActivityGroupTable))!.GetTypes().Where(t => t.BaseType?.Name == "TableReader`2");
            string baseSavePath = "/PGR_Data/";

            foreach (Type type in tableTypes)
            {
                try
                {
                    object? readerInstance = Activator.CreateInstance(type);
                    readerInstance?.GetType().GetMethod("Load", BindingFlags.Instance | BindingFlags.Public)?.Invoke(readerInstance, null);
                    object? values = type.GetProperty("All", BindingFlags.Instance | BindingFlags.Public)?.GetValue(readerInstance);
                    if (values is not null)
                    {
                        // this will create the folder on ur drive root sorry
                        string savePath = baseSavePath + string.Join("/", type.FullName!.Split(".").Skip(2));
                        if (!Directory.Exists(Path.GetDirectoryName(savePath)))
                            Directory.CreateDirectory(Path.GetDirectoryName(savePath)!);
                        File.WriteAllText(new string(savePath.Take(savePath.Length - 11).ToArray()) + ".json", JsonConvert.SerializeObject(values, Formatting.Indented));
                        Console.WriteLine(type.FullName);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{type.FullName} failed!, {ex.Message}");
                }
            }
        }
    }
}
