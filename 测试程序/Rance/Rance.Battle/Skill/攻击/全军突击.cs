using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 全军突击:攻击技能
    {
        public decimal 基数 = 1.8m;
        public 全军突击()
        {
            this.可被守护 = true;
            this.技能速度 = 160;
            this.能否被反击 = true;
            this.物理系 = true;
            this.技能目标 = Battle.技能目标.最前列任一;
            this.消耗行动点 = 2;
            this.打断系数 = 100;
        }

        public override decimal Get基础伤害(角色 角色1,角色 角色2)
        {
            角色1.临时防 = 0;

            var value = base.Get基础伤害(角色1, 角色2);
            value = Convert.ToInt32(value * 基数);

            return value;
        }
    }

    public class 全军突击2 : 全军突击
    {
        public 全军突击2() 
        {
            this.基数 = 2.6m;
        }
    }
}
