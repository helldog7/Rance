using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public abstract class 主动技能 : 技能
    {
        public abstract void Excute(技能环境 环境);

        public List<角色> 准备技能目标List { get; set; }

        public int 技能速度 { get; set; }

        public 技能目标 技能目标 { get; set; }

        public int 消耗行动点 { get; set; }
    }
}
