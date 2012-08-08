using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 盾兵攻击 : 攻击技能
    {
        public 盾兵攻击()
        {
            this.可被守护 = true;
            this.技能速度 = 140;
            this.能否被反击 = true;
            this.物理系 = true;
            this.技能目标 = Battle.技能目标.最前列任一;
            this.消耗行动点 = 1;
            this.打断系数 = 100;
        }
    }

    public class 盾兵攻击2 : 盾兵攻击
    {
        public 盾兵攻击2()
        {
            this.伤害系数 = 1.1m;
        }
    }

    public class 盾兵攻击3 : 盾兵攻击
    {
        public 盾兵攻击3()
        {
            this.伤害系数 = 1.3m;
        }
    }
}
