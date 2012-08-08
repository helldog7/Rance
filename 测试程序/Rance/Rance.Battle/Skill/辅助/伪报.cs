using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 伪报:主动技能
    {
        public int 基数 = 8;
        public 伪报()
        {
            this.技能速度 = 140;
            this.消耗行动点 = 1;
            this.技能目标 = Battle.技能目标.己方全体;
        }

        public override void Excute(技能环境 环境)
        {
            环境.战场.战果 += Convert.ToInt32(环境.施放者.实际智 * 基数);
            环境.ResultList.Add(new 战果结果()
            {
                技能 = this,
                角色 = 环境.施放者,
                战果 =   Convert.ToInt32(环境.施放者.实际智 * 基数)
            });
        }
    }

    public class 伪报2 : 伪报
    {
        public 伪报2() 
        {
            this.基数 = 12;
        }
    }
}
