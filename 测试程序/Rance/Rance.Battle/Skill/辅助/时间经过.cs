using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 时间经过 : 主动技能
    {
        public int 回合数 = 1;
        public 时间经过()
        {
            this.技能速度 = 120;
            this.消耗行动点 = 1;
            this.技能目标 = Battle.技能目标.己方全体;
        }

        public override void Excute(技能环境 环境)
        {
            base.Excute(环境);

            环境.战场.当前回合 += 回合数;
            环境.ResultList.Add(new 消耗回合结果()
            {
                技能 = this,
                角色 = 环境.施放者,
                回合数 = 回合数
            });
        }
    }

    public class 时间经过2 : 时间经过 
    {
        public 时间经过2() 
        {
            this.回合数 = 2;
        }
    }
}
