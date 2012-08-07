using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 鬼召唤 : 攻击技能
    {
        public 鬼召唤()
        {
            this.可被守护 = false;
            this.技能速度 = 80;
            this.能否被反击 = false;
            this.物理系 = false;
            this.消耗行动点 = 1;
            this.打断系数 = 0;
            this.伤害系数 = 0.5m;
        }
    }

    public class 鬼召唤2 : 鬼召唤
    {
        public 鬼召唤2()
        {
            this.伤害系数 = 0.8m;
        }
    }
}
