using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 防御运 : 战斗开始被动技能
    {
        public override void Excute(技能环境 环境)
        {
            if (Roll.Hit(50))
            {
                var 赋予 = new 赋予()
                {
                    Level = 2,
                    是否单回合 = false
                };
                环境.施放者.防御赋予 = 赋予;

                环境.ResultList.Add(new 赋予结果()
                {
                    赋予 = 赋予,
                    技能 = this,
                    Type = "防御",
                    角色1 = 环境.施放者,
                    角色2 = 环境.施放者,
                });
            }
        }
    }

    public class 防御运2 : 战斗开始被动技能
    {
        public override void Excute(技能环境 环境)
        {
            if (Roll.Hit(50))
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
                    技能 = this,
                    Type = "防御",
                    角色1 = 环境.施放者,
                    角色2 = 环境.施放者,
                });
            }
            else if (Roll.Hit(80))
            {
                var 赋予 = new 赋予()
                {
                    Level = 2,
                    是否单回合 = false
                };
                环境.施放者.防御赋予 = 赋予;

                环境.ResultList.Add(new 赋予结果()
                {
                    赋予 = 赋予,
                    技能 = this,
                    Type = "防御",
                    角色1 = 环境.施放者,
                    角色2 = 环境.施放者,
                });
            }
        }
    }
}
