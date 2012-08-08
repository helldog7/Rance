using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 暗杀:攻击技能
    {
        public 暗杀()
        {
            this.可被守护 = true;
            this.技能速度 = 130;
            this.能否被反击 = false;
            this.物理系 = true;
            this.技能目标 = Battle.技能目标.全体任一;
            this.消耗行动点 = 1;
            this.打断系数 = 0;
            this.伤害系数 = 0m;
        }

         public int 击倒系数 = 10;

        public override int 单角色伤害结算(角色 角色1, 角色 角色2, bool 是否反击, int 战场修正)
        {
            int 击倒几率 = Convert.ToInt32(角色1.兵力 / 角色2.兵力 * 100 / 10 + 角色1.实际智 * 4 + 击倒系数);
            if (Roll.Hit(击倒几率))
                角色2.是否败走 = true;

            return 0;
        }
    }

    public class 暗杀2 : 暗杀
    {
        public 暗杀2()
        {
            this.击倒系数 = 18;
        }
    }
}
