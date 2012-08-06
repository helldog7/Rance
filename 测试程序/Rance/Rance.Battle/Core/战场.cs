using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 战场
    {
        public string TeamA { get; set; }
        public string TeamB { get; set; }

        public int 最大回合数 { get; set; }
        public int 当前回合数 { get; set; }

        //以TeamA为标准，+1000为最大，-1000最小
        public int 战果 { get; set; }

        //以TeamA为标准，+20为最大，-20最小
        public int 战场修正 { get; set; }

        public 行动顺序 行动顺序 { get; set; }

        public List<角色> TeamAList { get; set; }
        public List<角色> TeamBList { get; set; }
    }
}
