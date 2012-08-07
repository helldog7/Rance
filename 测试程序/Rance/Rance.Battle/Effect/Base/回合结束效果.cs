using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public abstract class 回合结束效果 : 效果
    {
        public abstract void Excute(技能环境 环境);
    }
}
