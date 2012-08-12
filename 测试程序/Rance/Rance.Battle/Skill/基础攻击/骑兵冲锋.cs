using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 骑兵冲锋:攻击技能
    {
        public 骑兵冲锋()
        {
            this.可被守护 = true;
            this.技能速度 = 160;
            this.能否被反击 = true;
            this.物理系 = true;
            this.技能目标 = Battle.技能目标.同排全体;
            this.消耗行动点 = 1;
            this.打断系数 = 40;
            this.伤害系数 = 1m;
        }
    }

    public class 骑兵冲锋2 : 骑兵冲锋
    {
        public 骑兵冲锋2()
        {
            this.伤害系数 = 1.1m;
        }
    }

    public class 骑兵冲锋3 : 骑兵冲锋
    {
        public 骑兵冲锋3()
        {
            this.伤害系数 = 1.2m;
        }
    }
}
