using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 治愈之风 : 准备技能
    {
        public 治愈之风()
        {
            this.技能速度 = 40;
            this.技能目标 = Battle.技能目标.己方全体;
            this.消耗行动点 = 2;
            this.准备后执行技能 = new 治愈之风后();
        }
    }

    public class 治愈之风后 : 主动技能
    {
        public 治愈之风后()
        {
            this.技能速度 = 140;
            this.技能目标 = Battle.技能目标.己方全体;
            this.消耗行动点 = 0;
        }

        public int 系数 = 8;
        public decimal 兵力系数 = 0.5m;
        public override void Excute(技能环境 环境)
        {
            int 回复量 = Convert.ToInt32(环境.施放者.兵力 * 兵力系数 + 环境.施放者.实际智 * 8);

            foreach (var 角色 in 环境.目标List)
            {
                var temp = 环境.施放者.最大兵力 - 环境.施放者.兵力;
                if (temp > 回复量)
                    temp = 回复量;
                环境.施放者.兵力 += temp;

                环境.ResultList.Add(new 回复结果()
                {
                    角色1 = 环境.施放者,
                    角色2 = 角色,
                    技能 = this,
                    回复量 = temp
                });
            }
        }
    }

    public class 治愈之风2 : 治愈之风
    {
        public 治愈之风2()
        {
            this.准备后执行技能 = new 治愈之风2后();
        }
    }

    public class 治愈之风2后 : 治愈之风后
    {
        public 治愈之风2后()
        {
            this.兵力系数 = 0.8m;
            this.系数 = 10;
        }
    }

    public class 治愈之雾 : 主动技能
    {
        public 治愈之雾()
        {
            this.技能速度 = 170;
            this.技能目标 = Battle.技能目标.己方任一;
            this.消耗行动点 = 2;
        }

        public override void Excute(技能环境 环境)
        {
            int 回复量 = Convert.ToInt32(环境.施放者.兵力 * 0.5m + 环境.施放者.实际智 * 12);

            var 角色 = 环境.目标List[0];

            var temp = 环境.施放者.最大兵力 - 环境.施放者.兵力;
            if (temp > 回复量)
                temp = 回复量;
            环境.施放者.兵力 += temp;

            环境.ResultList.Add(new 回复结果()
            {
                角色1 = 环境.施放者,
                角色2 = 角色,
                技能 = this,
                回复量 = temp
            });

        }
    }
}
