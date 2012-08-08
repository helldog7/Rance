using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 生机转换:主动技能
    {
        public 生机转换()
        {
            this.技能速度 = 120;
            this.消耗行动点 = 2;
            this.技能目标 = Battle.技能目标.己方任一;
        }

        public override void Excute(技能环境 环境)
        {
            int value = 环境.目标List[0].最大行动点 - 环境.目标List[0].行动点;
            value = value > 1 ? 1 : value;

            环境.目标List[0].行动点 += value;

            环境.ResultList.Add(new 行动点结果()
            {
                技能 = this,
                角色1 = 环境.施放者,
                角色2 = 环境.目标List[0],
                行动点 = value,
            });

        }
    }

    public class 生机转换2 : 主动技能
    {
        public 生机转换2()
        {
            this.技能速度 = 120;
            this.消耗行动点 = 99;
            this.技能目标 = Battle.技能目标.己方全体;
        }

        public override void Excute(技能环境 环境)
        {
            foreach (var 角色 in 环境.目标List)
            {
                int value = 角色.最大行动点 - 角色.行动点;
                value = value > 1 ? 1 : value;

                环境.目标List[0].行动点 += value;

                环境.ResultList.Add(new 行动点结果()
                {
                    技能 = this,
                    角色1 = 环境.施放者,
                    角色2 = 角色,
                    行动点 = value,
                });

            }
        }
    }
}
