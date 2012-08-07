using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 自动回复 : 战斗开始被动技能
    {
        public override void Excute(技能环境 环境)
        {
            环境.施放者.效果List.Add(new 自动恢复效果());
        }
    }

    public class 自动回复2 : 战斗开始被动技能
    {
        public override void Excute(技能环境 环境)
        {
            环境.施放者.效果List.Add(new 自动恢复2效果());
        }
    }

    public class 自动回复3 : 战斗开始被动技能
    {
        public override void Excute(技能环境 环境)
        {
            环境.施放者.效果List.Add(new 自动恢复3效果());
        }
    }
}
