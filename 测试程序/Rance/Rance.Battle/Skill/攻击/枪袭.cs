using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 枪袭 : 攻击技能
    {
        public int 基数 = 2;
        public 枪袭()
        {
            this.可被守护 = true;
            this.技能速度 = 145;
            this.能否被反击 = true;
            this.物理系 = true;
            this.技能目标 = Battle.技能目标.最前列任一;
            this.消耗行动点 = 2;
            this.打断系数 = 100;
        }

        public override decimal Get基础伤害(角色 角色1, 角色 角色2)
        {
            var value = base.Get基础伤害(角色1, 角色2);
            value = value * 基数;

            return value;
        }
    }

    public class 枪袭2 : 枪袭
    {
        public 枪袭2()
        {
            基数 = 3;
        }
    }
}
