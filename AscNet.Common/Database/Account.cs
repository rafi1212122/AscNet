using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace AscNet.Common.Database
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class Account
    {
        public static readonly IMongoCollection<Account> collection = Common.db.GetCollection<Account>("accounts");

        public static Account? FromUID(long uid)
        {
            return collection.AsQueryable().FirstOrDefault(x => x.Uid == uid);
        }

        public static Account? FromToken(string token)
        {
            return collection.AsQueryable().FirstOrDefault(x => x.Token == token);
        }

        public static Account? FromUsername(string username)
        {
            return collection.AsQueryable().FirstOrDefault(x => x.Username == username);
        }

        public static Account? FromUsername(string username, string password)
        {
            return collection.AsQueryable().FirstOrDefault(x => x.Username == username && x.Password == password);
        }

        /// <exception cref="ArgumentException"></exception>
        public static Account Create(string username, string password)
        {
            if (collection.AsQueryable().FirstOrDefault(x => x.Username == username) is not null)
                throw new ArgumentException("Username is already registered!", "username");

            Account account = new()
            {
                Uid = (collection.AsQueryable().OrderByDescending(x => x.Uid).FirstOrDefault()?.Uid ?? 0) + 1,
                Username = username,
                Password = password,
                Token = Guid.NewGuid().ToString()
            };

            collection.InsertOne(account);
            return account;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("uid")]
        [BsonRequired]
        public long Uid { get; set; }

        [BsonElement("username")]
        [BsonRequired]
        public string Username { get; set; }

        [BsonElement("password")]
        [BsonRequired]
        public string Password { get; set; }

        [BsonElement("token")]
        [BsonRequired]
        public string Token { get; set; }
    }
}
