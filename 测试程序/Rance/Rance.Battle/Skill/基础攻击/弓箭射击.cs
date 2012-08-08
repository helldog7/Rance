using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 弓箭射击 : 攻击技能
    {
        public 弓箭射击()
        {
            this.可被守护 = true;
            this.技能速度 = 130;
            this.能否被反击 = false;
            this.物理系 = true;
            this.技能目标 = Battle.技能目标.全体任一;
            this.消耗行动点 = 1;
            this.打断系数 = 60;
        }
    }

    public class 弓箭射击2 : 弓箭射击
    {
        public 弓箭射击2()
        {
            this.伤害系数 = 1.15m;
        }
    }

    public class 弓箭射击3 : 弓箭射击
    {
        public 弓箭射击3()
        {
            this.伤害系数 = 1.3m;
        }
    }

    public class 阻击盾兵 : 弓箭射击
    {
        public override decimal Get武将加成(角色 角色1, 角色 角色2)
        {
            var value = base.Get基础伤害(角色1, 角色2);
            if (角色2.兵种.Name == "盾兵")
                value *= 2;
            return value;
        }
    }

    public class 阻击剑士 : 弓箭射击
    {
        public override decimal Get武将加成(角色 角色1, 角色 角色2)
        {
            var value = base.Get基础伤害(角色1, 角色2);
            if (角色2.兵种.Name == "剑士")
                value *= 2;
            return value;
        }
    }
}
