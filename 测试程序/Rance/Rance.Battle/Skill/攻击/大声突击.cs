using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 大声突击 : 攻击技能
    {
        public 大声突击()
        {
            this.可被守护 = true;
            this.技能速度 = 160;
            this.能否被反击 = true;
            this.物理系 = true;
            this.技能目标 = Battle.技能目标.最前列任一;
            this.消耗行动点 = 2;
            this.打断系数 = 100;
        }

        public override int 结算战果(int 伤害, 角色 角色)
        {
            return base.结算战果(伤害, 角色) * 2;
        }
    }
}
