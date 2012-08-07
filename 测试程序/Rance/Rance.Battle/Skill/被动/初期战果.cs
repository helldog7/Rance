using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 初期战果 : 战斗开始被动技能
    {
        public override void Excute(技能环境 环境)
        {
            环境.战场.战果 += 50;
        }
    }
}
