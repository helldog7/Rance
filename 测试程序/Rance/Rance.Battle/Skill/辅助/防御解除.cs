using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 防御解除:主动技能
    {
        public 防御解除()
        {
            this.技能速度 = 140;
            this.消耗行动点 = 1;
            this.技能目标 = Battle.技能目标.全体;
        }

        public override void Excute(技能环境 环境)
        {
            foreach (var 角色 in 环境.目标List)
            {
                if (角色.守护率 > 0)
                {
                    int value = 角色.守护率 > 50 ? 50 : 角色.守护率;
                    角色.守护率 -= value;
                    环境.ResultList.Add(new 守护结果()
                    {
                        技能 = this,
                        角色 = 环境.施放者,
                        角色2 = 角色,
                        守护率 = 0 - value,
                        全体守护率 = 0
                    });
                }
                else if (角色.全体守护率 > 0)
                {
                    int value = 角色.全体守护率 > 30 ? 30 : 角色.全体守护率;
                    角色.全体守护率 -= value;
                    环境.ResultList.Add(new 守护结果()
                    {
                        技能 = this,
                        角色 = 环境.施放者,
                        角色2 = 角色,
                        守护率 = 0,
                        全体守护率 = 0 - value
                    });
                }
                

            }
        }
    }

    public class 防御解除2 : 主动技能
    {
        public 防御解除2()
        {
            this.技能速度 = 120;
            this.消耗行动点 = 1;
            this.技能目标 = Battle.技能目标.全体;
        }

        public override void Excute(技能环境 环境)
        {
            foreach (var 角色 in 环境.目标List)
            {
                if (角色.守护率 > 0)
                {
                    环境.ResultList.Add(new 守护结果()
                    {
                        技能 = this,
                        角色 = 环境.施放者,
                        角色2 = 角色,
                        守护率 = 0 - 角色.守护率,
                        全体守护率 = 0
                    });

                    角色.守护率 = 0;
                }
                else if (角色.全体守护率 > 0)
                {
                    环境.ResultList.Add(new 守护结果()
                    {
                        技能 = this,
                        角色 = 环境.施放者,
                        角色2 = 角色,
                        守护率 = 0,
                        全体守护率 = 0 - 角色.全体守护率,
                    });

                    角色.全体守护率 = 0;
                }


            }
        }
    }
}
