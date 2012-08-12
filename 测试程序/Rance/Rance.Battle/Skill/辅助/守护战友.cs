using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 守护战友 : 主动技能
    {
        public int 倍率 = 10;
        public 守护战友()
        {
            this.技能速度 = 120;
            this.消耗行动点 = 1;
            this.技能目标 = Battle.技能目标.自己;
        }

        public override void Excute(技能环境 环境)
        {
            环境.施放者.是否准备 = false;
            环境.战场.行动顺序.行动(环境.施放者, this);

            环境.ResultList.Add(new 守护结果()
            {
                技能 = this,
                角色 = 环境.施放者,
                角色2 = 环境.施放者,
                守护率 = Convert.ToInt32(倍率 * 环境.施放者.实际智),
                全体守护率 = 0 - 环境.施放者.全体守护率 
            });

            环境.施放者.守护率 += Convert.ToInt32(倍率 * 环境.施放者.实际智);
            环境.施放者.全体守护率 = 0;
        }
    }

    public class 守护战友2 : 守护战友
    {
        public 守护战友2() 
        {
            倍率 = 20;
        }
    }

    public class 全体守护战友 : 主动技能
    {
        public int 倍率 = 10;
        public 全体守护战友()
        {
            this.技能速度 = 100;
            this.消耗行动点 = 1;
            this.技能目标 = Battle.技能目标.自己;
        }

        public override void Excute(技能环境 环境)
        {
            环境.施放者.是否准备 = false;
            环境.战场.行动顺序.行动(环境.施放者, this);
            环境.ResultList.Add(new 守护结果()
            {
                技能 = this,
                角色 = 环境.施放者,
                角色2 = 环境.施放者,
                守护率 = 0 - 环境.施放者.守护率,
                全体守护率 = Convert.ToInt32(倍率 * 环境.施放者.实际智)
            });

            环境.施放者.守护率 = 0;
            环境.施放者.全体守护率 += Convert.ToInt32(倍率 * 环境.施放者.实际智);
        }
    }

    public class 全体守护战友2 : 主动技能
    {
        public int 倍率 = 10;

        public override void Excute(技能环境 环境)
        {
            环境.施放者.是否准备 = false;
            环境.战场.行动顺序.行动(环境.施放者, this);
            环境.ResultList.Add(new 守护结果()
            {
                技能 = this,
                角色 = 环境.施放者,
                角色2 = 环境.施放者,
                守护率 = 0 - 环境.施放者.守护率,
                全体守护率 = Convert.ToInt32(倍率 * 环境.施放者.实际智) + 30
            });

            环境.施放者.守护率 = 0;
            环境.施放者.全体守护率 += Convert.ToInt32(倍率 * 环境.施放者.实际智) + 30;
        }
    }
}
