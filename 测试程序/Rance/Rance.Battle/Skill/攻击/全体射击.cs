using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 全体射击 : 准备技能
    {
        public 全体射击()
        {
            this.技能速度 = 100;
            this.技能目标 = Battle.技能目标.全体;
            this.消耗行动点 = 99;
            this.准备后执行技能 = new 全体射击后();
        }
    }

    public class 全体射击后 : 攻击技能
    {
        public 全体射击后()
        {
            this.可被守护 = true;
            this.技能速度 = 140;
            this.能否被反击 = false;
            this.物理系 = true;
            this.消耗行动点 = 0;
            this.打断系数 = 60;
        }
    }

    public class 全体射击2 : 全体射击
    {
        public 全体射击2()
        {
            this.准备后执行技能 = new 全体射击2后();
        }
    }

    public class 全体射击2后 : 全体射击后
    {
        public 全体射击2后()
        {
            this.伤害系数 = 1.2m;
        }
    }
}
