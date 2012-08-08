using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 准备技能:主动技能
    {
        public 主动技能 准备后执行技能 { get; set; }

        public override void Excute(技能环境 环境)
        {
            环境.施放者.准备技能 = 准备后执行技能;
            准备后执行技能.准备技能目标List = 环境.目标List;
            //环境.战场.行动顺序.行动(环境.施放者, this);
        }
    }
}
