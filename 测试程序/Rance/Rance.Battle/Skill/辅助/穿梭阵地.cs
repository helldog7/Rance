using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 穿梭阵地 : 主动技能
    {
        public int 基数 = 4;
        public 穿梭阵地()
        {
            this.技能速度 = 40;
            this.消耗行动点 = 1;
            this.技能目标 = Battle.技能目标.己方全体;
        }

        public override void Excute(技能环境 环境)
        {
            var temp = 常量.最大战场修正 - 环境.战场.战场修正;
            temp = temp > 基数 ? 基数 : temp;
            环境.战场.战场修正 += temp;
            环境.ResultList.Add(new 战场修正结果()
            {
                技能 = this,
                角色 = 环境.施放者,
                战场修正 = temp
            });
        }
    }

    public class 穿梭阵地2 : 穿梭阵地
    {
        public 穿梭阵地2()
        {
            this.基数 = 6;
        }
    }

    public class 穿梭阵地3 : 穿梭阵地
    {
        public 穿梭阵地3()
        {
            this.基数 = 8;
        }
    }
}
