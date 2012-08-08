using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 瞄准 : 主动技能
    {
        public int Level = 4;
        public 瞄准()
        {
            this.技能速度 = 160;
            this.消耗行动点 = 1;
            this.技能目标 = Battle.技能目标.自己;
        }

        public override void Excute(技能环境 环境)
        {
            var 赋予 = new 赋予()
            {
                Level = Level,
                是否单回合 = false
            };
            环境.施放者.攻击赋予 = 赋予;

            环境.ResultList.Add(new 赋予结果()
            {
                赋予 = 赋予,
                技能 = this,
                Type = "攻击",
                角色1 = 环境.施放者,
                角色2 = 环境.施放者,
            });
        }
    }

    public class 瞄准2 : 瞄准
    {
        public 瞄准2() 
        {
            this.Level = 5;
        }
    }
}
