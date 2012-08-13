using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 自动回复效果 : 自己回合结束效果
    {
        public int 回复量 = 50;

        public override void Excute(角色 角色, 技能环境 环境)
        {
            var temp = 角色.最大兵力 - 角色.兵力;
            if (temp > 回复量)
                temp = 回复量;
            角色.兵力 += temp;

            环境.ResultList.Add(new 回复结果() 
            {
                角色2 = 角色,
                效果 = this,
                回复量 = temp
            });
        }
    }

    public class 自动回复2效果 : 自动回复效果
    {
        public 自动回复2效果()
        {
            回复量 = 80;
        }
    }

    public class 自动回复3效果 : 自动回复效果
    {
        public 自动回复3效果()
        {
            回复量 = 120;
        }
    }
}
 