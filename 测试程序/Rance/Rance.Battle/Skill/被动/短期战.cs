using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 短期战 : 战斗开始被动技能
    {
        public override void Excute(技能环境 环境)
        {
            环境.战场.最大回合数 -= 3;
        }
    }

    public class 短期战2 : 战斗开始被动技能
    {
        public override void Excute(技能环境 环境)
        {
            环境.战场.最大回合数 -= 5;
        }
    }
}
