using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 团结力 : 战斗开始被动技能
    {
        public override void Excute(技能环境 环境)
        {
            环境.施放者.效果List.Add(new 团结力效果());
        }
    }
}
