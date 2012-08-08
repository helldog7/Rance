using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 疾风点破:攻击技能
    {
        public 疾风点破()
        {
            this.可被守护 = true;
            this.技能速度 = 150;
            this.能否被反击 = false;
            this.物理系 = true;
            this.技能目标 = Battle.技能目标.全体任一;
            this.消耗行动点 = 2;
            this.打断系数 = 60;
        }

        public int 击倒系数 = 15;

        public override int 单角色伤害结算(角色 角色1, 角色 角色2, bool 是否反击, int 战场修正)
        {
            var 伤害 = base.单角色伤害结算(角色1, 角色2, 是否反击, 战场修正);
            int 击倒几率 = Convert.ToInt32(伤害 / 角色2.兵力 / 30 + 击倒系数 + 角色1.实际智 * 2);
            if (Roll.Hit(击倒几率))
                角色2.是否败走 = true;

            return 伤害;
        }
    }
}
