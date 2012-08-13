using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 火枪射击 : 攻击技能
    {
        public 火枪射击()
        {
            this.可被守护 = true;
            this.技能速度 = 200;
            this.能否被反击 = false;
            this.物理系 = true;
            this.技能目标 = Battle.技能目标.同排最前列;
            this.消耗行动点 = 1;
            this.打断系数 = 100;
        }

        public int 击倒系数 = 5;
        public int 智力击倒系数 = 2;
        public decimal 伤害击倒系数 = 20m;

        public override int 单角色伤害结算(角色 角色1, 角色 角色2, bool 是否反击, int 战场修正)
        {
            var 伤害 = base.单角色伤害结算(角色1, 角色2, 是否反击, 战场修正);
            int 击倒几率 = Convert.ToInt32(伤害 * 伤害击倒系数 / 角色2.兵力 + 击倒系数 + 角色1.实际智 * 智力击倒系数);
            if (Roll.Hit(击倒几率))
                角色2.是否败走 = true;

            return 伤害;
        }
    }

    public class 火枪射击2 : 火枪射击
    {
        public 火枪射击2()
        {
            this.伤害系数 = 1.2m;
        }
    }

    public class 火枪射击3 : 火枪射击
    {
        public 火枪射击3()
        {
            this.伤害系数 = 1.4m;
        }
    }

    public class 火枪阻击 : 火枪射击
    {
        public 火枪阻击()
        {
            this.击倒系数 = 15;
            this.智力击倒系数 = 4;
        }
    }
}
