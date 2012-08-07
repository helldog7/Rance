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
            this.技能速度 = 30;
            this.能否被反击 = false;
            this.物理系 = true;
            this.技能目标 = Battle.技能目标.同排最前列;
            this.消耗行动点 = 1;            
        }

        public int 击倒系数 = 15;

        public override int 单角色伤害结算(角色 角色1, 角色 角色2)
        {
            var 伤害 =  base.单角色伤害结算(角色1, 角色2);
            int 击倒几率 = Convert.ToInt32(伤害 / 角色2.兵力 / 10) + 击倒系数;
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
            this.击倒系数 = 35;
        }
    }
}
