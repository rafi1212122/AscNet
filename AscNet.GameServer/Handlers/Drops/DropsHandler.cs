using AscNet.Common;
using AscNet.Common.MsgPack;
using AscNet.Common.Util;
using AscNet.Logging;
using AscNet.Table.V2.share.equip;
using AscNet.Table.V2.share.item;
using System.Reflection;

namespace AscNet.GameServer.Handlers.Drops
{
    internal static class DropsHandler
    {
        #region Items
        public const int ProofofHonor = 37;
        public const int StrangeMark = 100;
        public const int HQShard = 300;
        public const int ChallengeMedal = 350;
        public const int MarkofFriendship = 400;
        public const int NightmareMedal = 401;
        public const int ChristmasVoucher = 1000;
        public const int StarryHairclip = 1001;
        public const int SnowballBomb = 1002;
        public const int IceCreamVoucher = 1003;
        public const int GoldenRetriever = 1004;
        public const int RedPacket = 1005;
        public const int ChristmasFroggie = 1006;
        public const int PlushSheep = 1007;
        public const int SudokuHell = 1008;
        public const int LegendsoftheWild = 1009;
        public const int PortableSewingKit = 1010;
        public const int HometownSnowman = 1011;
        public const int DragonRevelation = 1012;
        public const int ArtCollection = 1013;
        public const int OldGuitar = 1014;
        public const int BitingShark = 1015;
        public const int MiniLantern = 1020;
        public const int MessageCard = 1021;
        public const int VenusRose = 1022;
        public const int VenusCoupon = 1023;
        public const int AntiqueMirror = 1024;
        public const int PortableDetector = 1025;
        public const int SwordCommand = 1026;
        public const int SignalPoint = 1027;
        public const int RaceToken = 1028;
        public const int EnameledPlumBlossom = 1029;
        public const int NewYearToken = 1030;
        public const int FateToken = 1031;
        public const int CrystalHeartPlush = 1032;
        public const int MoonDust = 1033;
        public const int CrumpledPaper = 1034;
        public const int KleinBottle = 1035;
        public const int FiveStarWeaponDrop = 10004;
        public const int FourStarWeaponDrop = 10005;
        public const int ThreeStarWeaponDrop = 10006;
        public const int TwoStarWeaponDrop = 10007;
        public const int FiveStarMemoryDrop = 10009;
        public const int FourStarMemoryDrop = 10010;
        public const int ThreeStarMemoryDrop = 10011;
        public const int TwoStarMemoryDrop = 10012;
        public const int FiveStarEquipmentDrop = 10013;
        public const int FourStarEquipmentDrop = 10014;
        public const int ThreeStarEquipmentDrop = 10015;
        public const int TwoStarEquipmentDrop = 10016;
        public const int OneStarEquipmentDrop = 10017;
        public const int TwoToFourStarEquipmentDrop = 10018;
        public const int MajorOverclockmaterial = 10034;
        public const int OverclockMaterialI = 10035;
        public const int FiveStarHQFacility = 10036;
        public const int FourStarHQFacility = 10037;
        public const int ThreeStarHQFacility = 10038;
        public const int ThreeToSixStarEquipmentDrop = 10039;
        public const int ThreeToFiveStarEquipmentDrop = 10040;
        public const int VoltaireSetDrop = 10041;
        public const int GloriaSetDrop = 10042;
        public const int RichelieuSetDrop = 10043;
        public const int SamanthaSetDrop = 10044;
        public const int IkeSetDrop = 10045;
        public const int MozartSetDrop = 10046;
        public const int Carrielynnsetdrop = 10047;
        public const int AifeSetDrop = 10048;
        public const int SixStarEquipmentDrop = 10049;
        public const int SixStarWeaponDrop = 10050;
        public const int SixStarMemoryDrop = 10051;
        /*public const int MemoryEnhancer = 10052;
        public const int MemoryEnhancer = 10053;
        public const int MemoryEnhancer = 10054;
        public const int MemoryEnhancer = 10055;
        public const int MemoryEnhancer = 10056;*/
        public const int BorderCertificate = 10057;
        public const int ProcessingUnit = 10058;
        public const int FalseWordsCertificate = 10059;
        public const int HonorMedal = 10060;
        public const int HeterosoilGrownCertificate = 10061;
        public const int MemorialPhotoAlbum = 10062;
        public const int CafeDecor = 11001;
        public const int JapaneseDecor = 11002;
        public const int CyberDecor = 11003;
        public const int CafeBlueprint = 11004;
        public const int JapaneseBlueprint = 11005;
        public const int CyberBlueprint = 11006;
        public const int Yan = 62301;
        public const int Rang = 62302;
        public const int Ying = 62303;
        public const int Sui = 62304;
        public const int Tu = 62305;
        public const int Su = 62306;
        public const int Nuan = 62307;
        public const int Chun = 62308;
        public const int YanRangYingSui = 62310;
        public const int TuSuNuanChun = 62311;
        public const int NewYearBox = 62312;
        public const int SilverHammer = 62313;
        public const int GoldenHammer = 62314;
        public const int AwakenedLion = 62315;
        public const int FortuneLion = 62316;
        public const int LockCharm = 62317;
        public const int FortuneCharacterBag = 62319;
        public const int FOSInstructorMedal = 96001;
        public const int Prayer = 96108;
        #endregion

        // 5★ Memory Drop
        [DropHandler(FiveStarMemoryDrop)]
        public static IEnumerable<DropHandlerRet> FiveStarMemoryDropHandler(Session session, int count)
        {
            List<DropHandlerRet> rets = new();
            EquipTable[] memoryPool = TableReaderV2.Parse<EquipTable>().Where(x => x.Type == 0 && x.Quality == 5).ToArray();

            if (GetProgressiveChance((int)session.player.PlayerData.Level, 5))
            {
                EquipTable equip = memoryPool[Random.Shared.Next(0, memoryPool.Length)];
                rets.Add(new()
                {
                    TemplateId = equip.Id,
                    Count = 1,
                    Level = 1,
                    Quality = equip.Quality
                });

                NotifyEquipDataList notifyEquipData = new();
                notifyEquipData.EquipDataList.Add(session.character.AddEquip((uint)equip.Id));
                session.SendPush(notifyEquipData);
            }

            return rets;
        }

        /// <summary>
        /// Progressive chance of getting the item based on item quality and commandant level
        /// </summary>
        private static bool GetProgressiveChance(int level, int quality)
        {
            return true;
        }
    }

    public static class DropsHandlerFactory
    {
        public static readonly Dictionary<int, DropHandlerDelegate> dropHandlers = new();
        static readonly Logger log = new(typeof(DropsHandlerFactory), LogLevel.DEBUG, LogLevel.DEBUG);

        static DropsHandlerFactory()
        {
            log.LogLevelColor[LogLevel.INFO] = ConsoleColor.White;

            log.Info("Loading drop handlers...");

            IEnumerable<Type> classes = from t in Assembly.GetExecutingAssembly().GetTypes()
                                        select t;

            foreach (var method in classes.SelectMany(t => t.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)))
            {
                var attr = method.GetCustomAttribute<DropHandler>(false);

                if (attr is null)
                    continue;

                foreach (var itemId in attr.ItemIds)
                {
                    if (dropHandlers.ContainsKey(itemId))
                        continue;
                    dropHandlers.Add(itemId, (DropHandlerDelegate)Delegate.CreateDelegate(typeof(DropHandlerDelegate), method));
                }
#if DEBUG
                log.Info($"Loaded {method.Name}");
#endif
            }

            log.Info("Finished loading drop handlers");
        }

        public static DropHandlerDelegate? GetDropHandler(int itemId)
        {
            dropHandlers.TryGetValue(itemId, out DropHandlerDelegate? handler);
            return handler;
        }
    }

    public delegate IEnumerable<DropHandlerRet> DropHandlerDelegate(Session session, int count);

    [AttributeUsage(AttributeTargets.Method)]
    public class DropHandler : Attribute
    {
        public int[] ItemIds { get; }

        public DropHandler(params int[] itemIds)
        {
            ItemIds = itemIds;
        }
    }

    public struct DropHandlerRet
    {
        public int TemplateId;
        public int Count;
        public int Level;
        public int Quality;
    }
}
