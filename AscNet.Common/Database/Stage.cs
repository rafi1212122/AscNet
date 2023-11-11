using AscNet.Common.MsgPack;
using AscNet.Table.share.guide;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Driver;

namespace AscNet.Common.Database
{
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class Stage
    {
        public static readonly IMongoCollection<Stage> collection = Common.db.GetCollection<Stage>("stages");
        
        public static Stage FromUid(long uid)
        {
            return collection.AsQueryable().FirstOrDefault(x => x.Uid == uid) ?? Create(uid);
        }

        private static Stage Create(long uid)
        {
            Stage stage = new()
            {
                Uid = uid,
                Stages = new()
            };
            foreach (var guideFight in GuideFightTableReader.Instance.All)
            {
                stage.AddStage(new StageDatum()
                {
                    StageId = guideFight.StageId,
                    StarsMark = 7,
                    Passed = true,
                    PassTimesToday = 0,
                    PassTimesTotal = 1,
                    BuyCount = 0,
                    Score = 0,
                    LastPassTime = DateTimeOffset.Now.ToUnixTimeSeconds(),
                    RefreshTime = DateTimeOffset.Now.ToUnixTimeSeconds(),
                    CreateTime = DateTimeOffset.Now.ToUnixTimeSeconds(),
                    BestRecordTime = guideFight.DefaultRecordTime,
                    LastRecordTime = guideFight.DefaultRecordTime,
                    BestCardIds = new List<long>() { 1021001 },
                    LastCardIds = new List<long>() { 1021001 }
                });
            }

            collection.InsertOne(stage);

            return stage;
        }

        public void AddStage(StageDatum stageData)
        {
            Stages.Add(stageData.StageId, stageData);
        }

        public void Save()
        {
            collection.ReplaceOne(Builders<Stage>.Filter.Eq(x => x.Id, Id), this);
        }

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("uid")]
        [BsonRequired]
        public long Uid { get; set; }

        [BsonElement("stages")]
        [BsonRequired]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfDocuments)]
        public Dictionary<long, StageDatum> Stages { get; set; }
        
    }
}

