using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using AscNet.Table.share.character;
using AscNet.Table.share.character.skill;
using AscNet.Common.MsgPack;
using AscNet.Common.Util;
using Newtonsoft.Json;
using AscNet.Table.V2.share.equip;
using AscNet.Table.V2.share.character.quality;

namespace AscNet.Common.Database
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class Character
    {
        public static readonly List<CharacterLevelUpTemplate> characterLevelUpTemplates;
        public static readonly List<EquipLevelUpTemplate> equipLevelUpTemplates;
        public static readonly IMongoCollection<Character> collection = Common.db.GetCollection<Character>("characters");

        static Character()
        {
            if (File.Exists("Data/CharacterLevelUpTemplate.json"))
                characterLevelUpTemplates = JsonConvert.DeserializeObject<List<CharacterLevelUpTemplate>>(File.ReadAllText("Data/CharacterLevelUpTemplate.json")) ?? new();
            else
                characterLevelUpTemplates = new();
            if (File.Exists("Data/EquipLevelUpTemplate.json"))
                equipLevelUpTemplates = JsonConvert.DeserializeObject<List<EquipLevelUpTemplate>>(File.ReadAllText("Data/EquipLevelUpTemplate.json")) ?? new();
            else
                equipLevelUpTemplates = new();
        }

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

        /// <summary>
        /// Don't forget to send Equip, Fashion, and the Character notify after using this!
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ServerCodeException"></exception>
        public AddCharacterRet AddCharacter(uint id)
        {
            AddCharacterRet ret = new();
            CharacterTable? character = CharacterTableReader.Instance.FromId((int)id);
            CharacterSkillTable? characterSkill = CharacterSkillTableReader.Instance.FromCharacterId((int)id);
            CharacterQualityTable? characterQuality = TableReaderV2.Parse<CharacterQualityTable>().OrderBy(x => x.Quality).FirstOrDefault(x => x.CharacterId == id);
            
            if (character is null || characterSkill is null || characterQuality is null)
            {
                // CharacterManagerGetCharacterDataNotFound
                throw new ServerCodeException("Invalid character id!", 20009021);
            }
            if (Characters.FirstOrDefault(x => x.Id == character.Id) is not null)
            {
                // CharacterManagerCreateCharacterAlreadyExist
                throw new ServerCodeException("Character already obtained!", 20009022);
            }
            
            NotifyCharacterDataList.CharacterData characterData = new()
            {
                Id = (uint)character.Id,
                Level = 1,
                Exp = 0,
                Quality = characterQuality.Quality,
                InitQuality = characterQuality.Quality,
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
            characterData.SkillList.AddRange(characterSkill.SkillGroupId.Take(8).Select(x => new NotifyCharacterDataList.CharacterData.CharacterSkill()
            {
                Id = uint.Parse(x.ToString().Take(6).ToArray()),
                Level = 1
            }));
            FashionList fashion = new()
            {
                Id = character.DefaultNpcFashtionId,
                IsLock = false
            };
            Fashions.Add(fashion);
            ret.Fashion = fashion;
            if (character.EquipId > 0)
                ret.Equip = AddEquip((uint)character.EquipId, character.Id);

            Characters.Add(characterData);
            ret.Character = characterData;
            return ret;
        }

        public NotifyCharacterDataList.CharacterData? AddCharacterExp(int characterId, int exp, int maxLvl = 0)
        {
            var characterData = TableReaderV2.Parse<Table.V2.share.character.CharacterTable>().FirstOrDefault(x => x.Id == characterId);
            var character = Characters.FirstOrDefault(x => x.Id == characterId);

            if (character is not null && characterData is not null)
            {
                levelCheck:
                CharacterLevelUpTemplate? levelUpTemplate = characterLevelUpTemplates.FirstOrDefault(x => x.Level == character.Level && x.Type == characterData.Type);
                if (levelUpTemplate is not null)
                {
                    if (levelUpTemplate.Exp > exp)
                    {
                        character.Exp += (uint)Math.Max(0, exp);
                    }
                    else if (maxLvl > 0 && character.Level == maxLvl)
                    {
                        character.Exp = (uint)Math.Max(0, levelUpTemplate.Exp);
                    }
                    else
                    {
                        character.Level++;
                        exp -= (int)(levelUpTemplate.Exp - character.Exp);
                        character.Exp = 0;
                        goto levelCheck;
                    }
                }
            }

            return character;
        }

        public UpgradeCharacterSkillResult UpgradeCharacterSkillGroup(uint skillGroupId, int count)
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

            return new UpgradeCharacterSkillResult()
            {
                AffectedCharacters = affectedCharacters,
                CoinCost = totalCoinCost,
                SkillPointCost = totalSkillPointCost
            };
        }

        public NotifyEquipDataList.NotifyEquipDataListEquipData AddEquip(uint equipId, int characterId = 0)
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
            return equipData;
        }

        public NotifyEquipDataList.NotifyEquipDataListEquipData? AddEquipExp(int equipId, int exp)
        {
            var equip = Equips.FirstOrDefault(x => x.Id == equipId);
            EquipTable? equipData = TableReaderV2.Parse<EquipTable>().FirstOrDefault(x => x.Id == equip?.TemplateId);
            EquipBreakThroughTable? equipBreakThroughTable = TableReaderV2.Parse<EquipBreakThroughTable>().FirstOrDefault(x => x.EquipId == equip?.TemplateId && x.Times == equip?.Breakthrough);

            if (equip is not null && equipData is not null && equipBreakThroughTable is not null)
            {
                EquipLevelUpTemplate? levelUpTemplate = equipLevelUpTemplates.FirstOrDefault(x => x.TemplateId == equipBreakThroughTable.LevelUpTemplateId && x.Level == equip.Level);

                if (levelUpTemplate is not null)
                {
                    if (exp + equip.Exp < levelUpTemplate.Exp)
                    {
                        equip.Exp += Math.Max(0, exp);
                    }
                    else if (equip.Level < equipBreakThroughTable.LevelLimit)
                    {
                        equip.Level++;
                        exp -= levelUpTemplate.Exp - equip.Exp;
                        equip.Exp = 0;
                        return AddEquipExp(equipId, exp);
                    }
                    else
                    {
                        equip.Exp = levelUpTemplate.Exp;
                    }
                }
            }

            return equip;
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
        public List<NotifyCharacterDataList.CharacterData> Characters { get; set; }
        
        [BsonElement("equips")]
        [BsonRequired]
        public List<NotifyEquipDataList.NotifyEquipDataListEquipData> Equips { get; set; }
        
        [BsonElement("fashions")]
        [BsonRequired]
        public List<FashionList> Fashions { get; set; }
    }

    public struct UpgradeCharacterSkillResult
    {
        public int CoinCost { get; init; }
        public int SkillPointCost { get; init; }
        public List<uint> AffectedCharacters { get; init; }
    }

    public partial class CharacterLevelUpTemplate
    {
        [JsonProperty("Level")]
        public int Level { get; set; }

        [JsonProperty("Exp")]
        public int Exp { get; set; }

        [JsonProperty("AllExp")]
        public int AllExp { get; set; }

        [JsonProperty("Type")]
        public int Type { get; set; }
    }

    public partial class EquipLevelUpTemplate
    {
        [JsonProperty("Level")]
        public int Level { get; set; }

        [JsonProperty("Exp")]
        public int Exp { get; set; }

        [JsonProperty("AllExp")]
        public int AllExp { get; set; }

        [JsonProperty("TemplateId")]
        public int TemplateId { get; set; }
    }

    public struct AddCharacterRet
    {
        public NotifyCharacterDataList.CharacterData Character { get; set; }
        public NotifyEquipDataList.NotifyEquipDataListEquipData Equip { get; set; }
        public FashionList Fashion { get; set; }
    }
}
