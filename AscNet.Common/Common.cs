using MongoDB.Driver;
using Config.Net;

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
    }
}
