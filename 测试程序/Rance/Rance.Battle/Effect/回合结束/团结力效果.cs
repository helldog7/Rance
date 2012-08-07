using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 团结力效果 : 回合结束效果
    {
        public override void Excute(技能环境 环境)
        {
            if (环境.施放者.兵力 * 100 / 环境.施放者.最大兵力 < 50)
            {
                var 赋予 = new 赋予()
                {
                    Level = 3,
                    是否单回合 = false
                };
                环境.施放者.防御赋予 = 赋予;

                环境.ResultList.Add(new 赋予结果()
                {
                    赋予 = 赋予,
                    技能 = new 团结力(),
                    Type = "防御",
                    角色1 = 环境.施放者,
                    角色2 = 环境.施放者,
                });
            }
        }
    }
}
