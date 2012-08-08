using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 召唤:准备技能
    {
        public 召唤()
        {
            this.技能速度 = 45;
            this.技能目标 = Battle.技能目标.全体;
            this.消耗行动点 = 1;
            this.准备后执行技能 = new 召唤后();
        }
    }

    public class 召唤后 : 攻击技能
    {
        public 召唤后()
        {
            this.可被守护 = false;
            this.技能速度 = 190;
            this.能否被反击 = false;
            this.物理系 = false;
            this.消耗行动点 = 0;
            this.打断系数 = 0;
        }
    }

    public class 召唤2 : 召唤
    {
        public 召唤2()
        {
            this.准备后执行技能 = new 召唤2后();
        }
    }

    public class 召唤2后 : 召唤后
    {
        public 召唤2后()
        {
            this.伤害系数 = 1.1m;
        }
    }

    public class 召唤3 : 召唤
    {
        public 召唤3()
        {
            this.准备后执行技能 = new 召唤3后();
        }
    }

    public class 召唤3后 : 召唤后
    {
        public 召唤3后()
        {
            this.伤害系数 = 1.25m;
        }
    }
}
