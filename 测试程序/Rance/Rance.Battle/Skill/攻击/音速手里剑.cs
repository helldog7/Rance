using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 音速手里剑:攻击技能
    {
        public 音速手里剑()
        {
            this.技能目标 = Battle.技能目标.全体任一;
            this.可被守护 = true;
            this.技能速度 = 80;
            this.能否被反击 = false;
            this.物理系 = true;
            this.消耗行动点 = 2;
            this.打断系数 = 100;
            this.伤害系数 = 1.8m;
        }
    }
}
