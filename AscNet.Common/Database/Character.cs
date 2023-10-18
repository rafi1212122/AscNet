using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using AscNet.Table.share.character;
using AscNet.Table.share.character.skill;
using AscNet.Common.MsgPack;

namespace AscNet.Common.Database
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class Character
    {
        public static readonly IMongoCollection<Character> collection = Common.db.GetCollection<Character>("characters");

        public static Character FromUid(long uid)
        {
            return collection.AsQueryable().FirstOrDefault(x => x.Uid == uid) ?? Create(uid);
        }

        private static Character Create(long uid)
        {
            Character character = new()
            {
                Uid = uid,
                Characters = new()
            };
            character.AddCharacter(1021001);

            collection.InsertOne(character);

            return character;
        }

        public void AddCharacter(uint id)
        {
            CharacterTable? character = CharacterTableReader.Instance.FromId((int)id);
            CharacterSkillTable? characterSkill = CharacterSkillTableReader.Instance.FromCharacterId((int)id);
            if (character is null || characterSkill is null)
                throw new ArgumentException("Invlid character id!", nameof(id));
            NotifyCharacterDataList.NotifyCharacterDataListCharacterData characterData = new()
            {
                Id = (uint)character.Id,
                Level = 1,
                Exp = 0,
                Quality = 1,
                InitQuality = 1,
                Star = 0,
                Grade = 1,
                FashionId = (uint)character.DefaultNpcFashtionId,
                CreateTime = DateTimeOffset.Now.ToUnixTimeSeconds(),
                TrustLv = 1,
                TrustExp = 0,
                Ability = 0,
                LiberateLv = 1,
                CharacterHeadInfo = new()
                {
                    HeadFashionId = (uint)character.DefaultNpcFashtionId,
                    HeadFashionType = 0
                }
            };
            characterData.SkillList.AddRange(characterSkill.SkillGroupId.Take(8).Select(x => new NotifyCharacterDataList.NotifyCharacterDataListCharacterData.NotifyCharacterDataListCharacterDataSkill() 
            {
                Id = uint.Parse(x.ToString().Take(6).ToArray()),
                Level = 1
            }));

            Characters.Add(characterData);
        }

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("uid")]
        [BsonRequired]
        public long Uid { get; set; }

        [BsonElement("uid")]
        [BsonRequired]
        public List<NotifyCharacterDataList.NotifyCharacterDataListCharacterData> Characters { get; set; }
    }
}
