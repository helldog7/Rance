using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public abstract class 战斗开始被动技能 : 被动技能
    {
        public abstract void Excute(技能环境 环境);
    }
}
