using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 贯通射击:攻击技能
    {
        public 贯通射击()
        {
            this.技能目标 = Battle.技能目标.一排全体;
            this.可被守护 = true;
            this.技能速度 = 200;
            this.能否被反击 = false;
            this.物理系 = true;
            this.消耗行动点 = 2;
            this.打断系数 = 60;
            this.伤害系数 = 0.7m;
        }
    }

    public class 贯通射击2 : 贯通射击
    {
        public 贯通射击2() 
        {
            this.伤害系数 = 1m;
        }
    }
}
