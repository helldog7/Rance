using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 天神庇佑 : 战斗开始被动技能
    {
        public override void Excute(技能环境 环境)
        {
            环境.施放者.效果List.Add(new 天神庇佑效果());
        }
    }

    public class 天神庇佑2 : 战斗开始被动技能
    {
        public override void Excute(技能环境 环境)
        {
            环境.施放者.效果List.Add(new 天神庇佑2效果());
        }
    }
}
