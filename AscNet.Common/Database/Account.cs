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

        public static Account? FromAccessToken(string token)
        {
            return collection.AsQueryable().FirstOrDefault(x => x.AccessToken == token);
        }

        public static Account? FromPhone(string phone)
        {
            return collection.AsQueryable().FirstOrDefault(x => x.PhoneNum == phone);
        }

        public static Account? FromPhone(string phone, string password)
        {
            return collection.AsQueryable().FirstOrDefault(x => x.PhoneNum == phone && x.Password == password);
        }

        /// <exception cref="ArgumentException"></exception>
        public static Account Create(string phone, string password)
        {
            if (collection.AsQueryable().FirstOrDefault(x => x.PhoneNum == phone) is not null)
                throw new ArgumentException("Phone is already registered!", "phone");

            Account account = new()
            {
                Uid = (collection.AsQueryable().OrderByDescending(x => x.Uid).FirstOrDefault()?.Uid ?? 0) + 1,
                PhoneNum = phone,
                Email = "",
                Password = password,
                AccessToken = Guid.NewGuid().ToString(),
                Age = 0,
                IsActivation = false,
                IsAdult = true,
                IsGuest = false,
                UnfreezeTime = 0,
                IsReal = true
            };

            collection.InsertOne(account);
            return account;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("uid")]
        [BsonRequired]
        public long Uid { get; set; }

        [BsonElement("phone_num")]
        [BsonRequired]
        public string PhoneNum { get; set; }

        [BsonElement("email")]
        [BsonRequired]
        public string Email { get; set; }

        [BsonElement("password")]
        [BsonRequired]
        public string Password { get; set; }

        [BsonElement("access_token")]
        [BsonRequired]
        public string AccessToken { get; set; }

        [BsonElement("age")]
        [BsonRequired]
        public int Age { get; set; }

        [BsonElement("is_activation")]
        [BsonRequired]
        public bool IsActivation { get; set; }

        [BsonElement("is_adult")]
        [BsonRequired]
        public bool IsAdult { get; set; }

        [BsonElement("is_guest")]
        [BsonRequired]
        public bool IsGuest { get; set; }

        [BsonElement("unfreeze_time")]
        [BsonRequired]
        public int UnfreezeTime { get; set; }

        [BsonElement("is_real")]
        [BsonRequired]
        public bool IsReal { get; set; }
    }
}
