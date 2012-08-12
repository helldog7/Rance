using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public abstract class 主动技能 : 技能
    {
        public virtual void Excute(技能环境 环境) 
        {
            环境.施放者.是否准备 = false;
            环境.战场.行动顺序.行动(环境.施放者, this);
            环境.施放者.守护率 = 0;
            环境.施放者.全体守护率 = 0;
        }

        public List<角色> 准备技能目标List { get; set; }

        public int 技能速度 { get; set; }

        public 技能目标 技能目标 { get; set; }

        public int 消耗行动点 { get; set; }
    }
}
