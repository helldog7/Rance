using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 自动恢复效果 : 自己回合结束效果
    {
        public int 回复量 = 50;

        public override void Excute(技能环境 环境)
        {
            var temp = 环境.施放者.最大兵力 - 环境.施放者.兵力;
            if (temp > 回复量)
                temp = 回复量;
            环境.施放者.兵力 += temp;

            环境.ResultList.Add(new 回复结果() 
            {
                角色2 = 环境.施放者,
                效果 = this,
                回复量 = temp
            });
        }
    }

    public class 自动恢复2效果 : 自动恢复效果
    {
        public 自动恢复2效果()
        {
            回复量 = 80;
        }
    }

    public class 自动恢复3效果 : 自动恢复效果
    {
        public 自动恢复3效果()
        {
            回复量 = 120;
        }
    }
}
 