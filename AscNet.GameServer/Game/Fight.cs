using AscNet.Common.MsgPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
