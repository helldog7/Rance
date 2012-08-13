using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 团结力效果 : 回合结束效果
    {
        public override void Excute(角色 角色 ,技能环境 环境)
        {
            if (角色.兵力 * 100 / 角色.最大兵力 < 50)
            {
                var 赋予 = new 赋予()
                {
                    Level = 3,
                    是否单回合 = false
                };
                角色.防御赋予 = 赋予;

                环境.ResultList.Add(new 赋予结果()
                {
                    赋予 = 赋予,
                    技能 = new 团结力(),
                    Type = "防御",
                    角色1 = 角色,
                    角色2 = 角色,
                });
            }
        }
    }
}
