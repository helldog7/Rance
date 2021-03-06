﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 和尚攻击 : 攻击技能
    {
        public 和尚攻击()
        {
            this.可被守护 = true;
            this.技能速度 = 130;
            this.能否被反击 = true;
            this.物理系 = true;
            this.技能目标 = Battle.技能目标.最前列任一;
            this.消耗行动点 = 1;
            this.打断系数 = 100;
        }
    }

    public class 和尚攻击2 : 和尚攻击
    {
        public 和尚攻击2()
        {
            this.伤害系数 = 1.1m;
        }
    }

    public class 和尚攻击3 : 和尚攻击
    {
        public 和尚攻击3()
        {
            this.伤害系数 = 1.3m;
        }
    }

    public class 怪物散退 : 和尚攻击
    {
        public override decimal Get武将加成(角色 角色1, 角色 角色2)
        {
            var value = base.Get武将加成(角色1, 角色2);
            if (角色2.兵种.Name == "怪物")
                value *= 2.5m;
            return value;
        }
    }
}
