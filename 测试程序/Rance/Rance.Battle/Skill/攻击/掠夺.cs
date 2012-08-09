using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 掠夺:攻击技能
    {
        public 掠夺()
        {
            this.可被守护 = true;
            this.技能速度 = 130;
            this.能否被反击 = true;
            this.物理系 = true;
            this.技能目标 = Battle.技能目标.最前列任一;
            this.消耗行动点 = 1;
            this.打断系数 = 100;
        }

        public override void Excute(技能环境 环境)
        {
            base.Excute(环境);
            int 金钱 = Convert.ToInt32(环境.施放者.实际智 * 30);
            环境.战场.己方收获金钱 += 金钱;
            环境.战场.敌方收获金钱 -= 金钱;
        }
    }
}
