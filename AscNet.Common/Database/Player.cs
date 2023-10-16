using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using AscNet.Common.MsgPack;

namespace AscNet.Common.Database
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class Player
    {
        public static readonly IMongoCollection<Player> collection = Common.db.GetCollection<Player>("players");

        public static Player FromId(long id)
        {
            return collection.AsQueryable().FirstOrDefault(x => x.PlayerData.Id == id) ?? Create(id);
        }

        public static Player? FromToken(string token)
        {
            return collection.AsQueryable().FirstOrDefault(x => x.Token == token);
        }

        private static Player Create(long id)
        {
            Player player = new()
            {
                Token = Guid.NewGuid().ToString(),
                PlayerData = new()
                {
                    Id = id,
                    Name = $"Commandant{id}",
                    Level = 1,
                    Sign = "",
                    DisplayCharId = 1021001,
                    Birthday = null,
                    HonorLevel = 1,
                    ServerId = "1",
                    CurrTeamId = 1,
                    CurrHeadPortraitId = 9000003,
                    AppearanceSettingInfo = new()
                    {
                        TitleType = 1,
                        CharacterType = 1,
                        FashionType = 1,
                        WeaponFashionType = 1,
                        DormitoryType = 1
                    },
                    CreateTime = DateTimeOffset.Now.ToUnixTimeSeconds(),
                    LastLoginTime = DateTimeOffset.Now.ToUnixTimeSeconds(),
                    Flags = 1
                }
            };
            collection.InsertOne(player);

            return player;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("token")]
        [BsonRequired]
        public string Token { get; set; }

        [BsonElement("player_data")]
        [BsonRequired]
        public PlayerData PlayerData { get; set; }
    }
}
