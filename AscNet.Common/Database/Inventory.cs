using AscNet.Common.MsgPack;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace AscNet.Common.Database
{
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class Inventory
    {
        public static readonly IMongoCollection<Inventory> collection = Common.db.GetCollection<Inventory>("inventory");

        public static Inventory FromUid(long uid)
        {
            return collection.AsQueryable().FirstOrDefault(x => x.Uid == uid) ?? Create(uid);
        }

        private static Inventory Create(long uid)
        {
            Inventory inventory = new()
            {
                Uid = uid,
                Items = new()
            };

            List<ItemConfig>? defaultItems = JsonConvert.DeserializeObject<List<ItemConfig>>(File.ReadAllText("./Configs/default_items.json"));
            if (defaultItems is not null)
            {
                inventory.Items.AddRange(defaultItems.Select(item => new Item()
                {
                    Id = item.Id,
                    Count = item.Count,
                    RefreshTime = DateTimeOffset.Now.ToUnixTimeSeconds(),
                    CreateTime = DateTimeOffset.Now.ToUnixTimeSeconds()
                }));
            }

            collection.InsertOne(inventory);

            return inventory;
        }

        public void Save()
        {
            collection.ReplaceOne(Builders<Inventory>.Filter.Eq(x => x.Id, Id), this);
        }

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("uid")]
        [BsonRequired]
        public long Uid { get; set; }

        [BsonElement("items")]
        [BsonRequired]
        public List<Item> Items { get; set; }
    }

    public partial class ItemConfig
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }
    }
}
