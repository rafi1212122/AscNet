using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using AscNet.Table.share.character;
using AscNet.Table.share.character.skill;
using AscNet.Common.MsgPack;
using AscNet.Common.Util;

namespace AscNet.Common.Database
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class Character
    {
        public static readonly IMongoCollection<Character> collection = Common.db.GetCollection<Character>("characters");

        private uint NextEquipId => Equips.MaxBy(x => x.Id)?.Id + 1 ?? 1;

        public static Character FromUid(long uid)
        {
            return collection.AsQueryable().FirstOrDefault(x => x.Uid == uid) ?? Create(uid);
        }

        private static Character Create(long uid)
        {
            Character character = new()
            {
                Uid = uid,
                Characters = new(),
                Equips = new(),
                Fashions = new()
            };
            // Lucia havers by default
            character.AddCharacter(1021001);

            collection.InsertOne(character);

            return character;
        }

        public void AddCharacter(uint id)
        {
            CharacterTable? character = CharacterTableReader.Instance.FromId((int)id);
            CharacterSkillTable? characterSkill = CharacterSkillTableReader.Instance.FromCharacterId((int)id);
            
            if (character is null || characterSkill is null)
                throw new ArgumentException("Invalid character id!", nameof(id));
            if (Characters.FirstOrDefault(x => x.Id == character.Id) is not null)
                throw new ArgumentException("Character already obtained!", nameof(id));
            
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
            Fashions.Add(new()
            {
                Id = character.DefaultNpcFashtionId,
                IsLock = false
            });
            if (character.EquipId > 0)
                AddEquip((uint)character.EquipId, character.Id);

            Characters.Add(characterData);
        }

        public UpgradeCharacterResult UpgradeCharacterSkillGroup(uint skillGroupId, int count)
        {
            List<uint> affectedCharacters = new();
            int totalCoinCost = 0;
            int totalSkillPointCost = 0;
            IEnumerable<int> affectedSkills = CharacterSkillGroupTableReader.Instance.All.Where(x => x.Id == skillGroupId).SelectMany(x => x.SkillId);

            foreach (var skillId in affectedSkills)
            {
                foreach (var character in Characters.Where(x => x.SkillList.Any(x => x.Id == skillId)))
                {
                    var characterSkill = character.SkillList.First(x => x.Id == skillId);
                    int targetLevel = characterSkill.Level + count;

                    while (characterSkill.Level < targetLevel)
                    {
                        var skillUpgrade = CharacterSkillUpgradeTableReader.Instance.All.FirstOrDefault(x => x.SkillId == skillId && Miscs.ParseIntOr(x.Level) == characterSkill.Level);

                        totalCoinCost += Miscs.ParseIntOr(skillUpgrade?.UseCoin);
                        totalSkillPointCost += Miscs.ParseIntOr(skillUpgrade?.UseSkillPoint);

                        characterSkill.Level++;
                    }
                    affectedCharacters.Add(character.Id);
                }
            }

            return new UpgradeCharacterResult()
            {
                AffectedCharacters = affectedCharacters,
                CoinCost = totalCoinCost,
                SkillPointCost = totalSkillPointCost
            };
        }

        public void AddEquip(uint equipId, int characterId = 0)
        {
            NotifyEquipDataList.NotifyEquipDataListEquipData equipData = new()
            {
                Id = NextEquipId,
                TemplateId = equipId,
                CharacterId = characterId,
                Level = 1,
                Exp = 0,
                Breakthrough = 0,
                ResonanceInfo = new(),
                UnconfirmedResonanceInfo = new(),
                AwakeSlotList = new(),
                IsLock = false,
                CreateTime = (uint)DateTimeOffset.Now.ToUnixTimeSeconds(),
                IsRecycle = false
            };
            
            Equips.Add(equipData);
        }

        public void Save()
        {
            collection.ReplaceOne(Builders<Character>.Filter.Eq(x => x.Id, Id), this);
        }

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("uid")]
        [BsonRequired]
        public long Uid { get; set; }

        [BsonElement("characters")]
        [BsonRequired]
        public List<NotifyCharacterDataList.NotifyCharacterDataListCharacterData> Characters { get; set; }
        
        [BsonElement("equips")]
        [BsonRequired]
        public List<NotifyEquipDataList.NotifyEquipDataListEquipData> Equips { get; set; }
        
        [BsonElement("fashions")]
        [BsonRequired]
        public List<FashionList> Fashions { get; set; }
    }

    public struct UpgradeCharacterResult
    {
        public int CoinCost { get; init; }
        public int SkillPointCost { get; init; }
        public List<uint> AffectedCharacters { get; init; }
    }
}
