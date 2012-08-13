using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 待机:主动技能
    {
        public 待机()
        {
            this.技能速度 = 50;
            this.消耗行动点 = 0;
            this.技能目标 = Battle.技能目标.自己;
        }

        public static 待机 Instance = new 待机();

        public override void Excute(技能环境 环境)
        {
            环境.施放者.是否准备 = false;
            环境.战场.行动顺序.行动(环境.施放者, this);
        }

    }
}
