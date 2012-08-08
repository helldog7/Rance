using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 手里剑 : 攻击技能
    {
        public 手里剑()
        {
            this.可被守护 = true;
            this.技能速度 = 110;
            this.能否被反击 = false;
            this.物理系 = true;
            this.技能目标 = Battle.技能目标.全体任一;
            this.消耗行动点 = 1;
            this.打断系数 = 100;
        }
    }

    public class 手里剑2 : 手里剑
    {
        public 手里剑2()
        {
            this.伤害系数 = 1.1m;
        }
    }

    public class 手里剑3 : 手里剑
    {
        public 手里剑3()
        {
            this.伤害系数 = 1.3m;
        }
    }
}
