using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 炮轰:攻击技能
    {
        public 炮轰()
        {
            this.可被守护 = true;
            this.技能速度 = 160;
            this.能否被反击 = false;
            this.物理系 = true;
            this.技能目标 = Battle.技能目标.后二列任一;
            this.消耗行动点 = 1;
            this.打断系数 = 60;
        }
    }

    public class 炮轰2 : 炮轰
    {
        public 炮轰2()
        {
            this.伤害系数 = 1.15m;
        }
    }

    public class 炮轰3 : 炮轰
    {
        public 炮轰3()
        {
            this.伤害系数 = 1.35m;
        }
    }
}
