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
            this.技能速度 = 40;
            this.消耗行动点 = 0;
            this.技能目标 = Battle.技能目标.自己;
        }

        public static 待机 Instance = new 待机();
    }
}
