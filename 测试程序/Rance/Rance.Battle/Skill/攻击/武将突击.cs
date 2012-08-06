using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 武将突击:攻击技能
    {
        public 武将突击()
        {
            this.可被守护 = true;
            this.技能速度 = 80;
            this.能否被反击 = true;
            this.物理系 = true;
            this.技能目标 = Battle.技能目标.最前列任一;
            this.消耗行动点 = 99;
        }

        public override decimal Get基础伤害(角色 角色1,角色 角色2)
        {
            var value = base.Get基础伤害(角色1, 角色2);
            value += 角色1.攻 * 25;

            return value;
        }
    }
}
