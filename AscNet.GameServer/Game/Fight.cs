using AscNet.Common.MsgPack;

namespace AscNet.GameServer.Game
{
    public class Fight
    {
        public PreFightRequest PreFight { get; set; }

        public Fight(PreFightRequest preFight)
        {
            PreFight = preFight;
        }
    }
}
