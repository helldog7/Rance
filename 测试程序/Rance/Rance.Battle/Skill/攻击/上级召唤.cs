using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 上级召唤:准备技能
    {
        public 上级召唤()
        {
            this.技能速度 = 200;
            this.技能目标 = Battle.技能目标.全体;
            this.消耗行动点 = 99;
            this.准备后执行技能 = new 上级召唤后();
        }
    }

    public class 上级召唤后 : 攻击技能
    {
        public 上级召唤后()
        {
            this.可被守护 = false;
            this.技能速度 = 80;
            this.能否被反击 = false;
            this.物理系 = false;
            this.消耗行动点 = 0;
            this.打断系数 = 0;
            this.伤害系数 = 2;
        }
    }

    public class 上级召唤2 : 上级召唤
    {
        public 上级召唤2()
        {
            this.准备后执行技能 = new 上级召唤2后();
        }
    }

    public class 上级召唤2后 : 上级召唤后
    {
        public 上级召唤2后()
        {
            this.伤害系数 = 3m;
        }
    }
}
