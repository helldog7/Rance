using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 天神庇佑效果 : 自己回合结束效果
    {
        public int 回复比率 = 10;

        public override void Excute(角色 角色, 技能环境 环境)
        {
            var temp1 = 角色.最大兵力 - 角色.兵力;
            var temp2 = 角色.最大兵力 * 回复比率 / 100;
            var result = temp1 < temp2 ? temp1 : temp2;
            角色.兵力 += result;

            环境.ResultList.Add(new 回复结果()
            {
                角色2 = 角色,
                效果 = this,
                回复量 = result
            });
        }
    }

    public class 天神庇佑2效果 : 天神庇佑效果
    {
        public 天神庇佑2效果()
        {
            回复比率 = 20;
        }
    }
}
