using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 苦行 : 战斗开始被动技能
    {
        public int Level = 1;
        public override void Excute(技能环境 环境)
        {
            var 赋予 = new 赋予()
            {
                Level = Level,
                是否单回合 = false
            };
            环境.施放者.攻击赋予 = 赋予;
            环境.施放者.防御赋予 = 赋予;
            环境.施放者.速度赋予 = 赋予;
            环境.施放者.智力赋予 = 赋予;

            环境.ResultList.Add(new 赋予结果()
            {
                赋予 = 赋予,
                技能 = this,
                Type = "攻击",
                角色1 = 环境.施放者,
                角色2 = 环境.施放者,
            });

            环境.ResultList.Add(new 赋予结果()
            {
                赋予 = 赋予,
                技能 = this,
                Type = "防御",
                角色1 = 环境.施放者,
                角色2 = 环境.施放者,
            });

            环境.ResultList.Add(new 赋予结果()
            {
                赋予 = 赋予,
                技能 = this,
                Type = "速度",
                角色1 = 环境.施放者,
                角色2 = 环境.施放者,
            });

            环境.ResultList.Add(new 赋予结果()
            {
                赋予 = 赋予,
                技能 = this,
                Type = "智力",
                角色1 = 环境.施放者,
                角色2 = 环境.施放者,
            });

        }

        public class 苦行2 : 苦行 
        {
            public 苦行2()
            {
                this.Level = 2;
            }
        }
    }
}
