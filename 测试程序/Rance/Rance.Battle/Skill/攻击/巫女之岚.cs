using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 巫女之岚 : 准备技能
    {
        public 巫女之岚()
        {
            this.技能速度 = 80;
            this.技能目标 = Battle.技能目标.全体;
            this.消耗行动点 = 99;
            this.准备后执行技能 = new 巫女之岚后();
        }
    }

    public class 巫女之岚后 : 攻击技能
    {
        public 巫女之岚后()
        {
            this.可被守护 = false;
            this.技能速度 = 150;
            this.能否被反击 = false;
            this.物理系 = false;
            this.消耗行动点 = 0;
            this.打断系数 = 0;
            this.伤害系数 = 0.2m;
        }

        public override int 单角色伤害结算(角色 角色1, 角色 角色2, bool 是否反击, int 战场修正)
        {
            return Convert.ToInt32(角色2.兵力 * this.伤害系数);
        }
    }

    public class 巫女之岚2 : 巫女之岚
    {
        public 巫女之岚2()
        {
            this.准备后执行技能 = new 巫女之岚后();
            this.消耗行动点 = 2;
        }
    }
}
