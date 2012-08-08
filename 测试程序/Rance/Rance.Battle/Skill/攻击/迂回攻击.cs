using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 迂回攻击:攻击技能
    {
        public 迂回攻击()
        {
            this.可被守护 = true;
            this.技能速度 = 130;
            this.能否被反击 = false;
            this.物理系 = true;
            this.技能目标 = Battle.技能目标.最前列任一;
            this.消耗行动点 = 1;
            this.打断系数 = 100;
        }
    }
}
