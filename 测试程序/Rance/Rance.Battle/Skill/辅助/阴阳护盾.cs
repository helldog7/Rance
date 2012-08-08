using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 阴阳护盾:主动技能
    {
        public 阴阳护盾()
        {
            this.技能速度 = 160;
            this.消耗行动点 = 1;
            this.技能目标 = Battle.技能目标.自己;
        }

        public override void Excute(技能环境 环境)
        {
            
            环境.施放者.护盾 = true;

            环境.ResultList.Add(new 护盾结果()
            {
                技能 = this,
                角色1 = 环境.施放者,
                角色2 = 环境.施放者,
            });
        }
    }

    public class 全体阴阳护盾 : 准备技能
    {
        public 全体阴阳护盾()
        {
            this.技能速度 = 200;
            this.技能目标 = Battle.技能目标.己方全体;
            this.消耗行动点 = 99;
            this.准备后执行技能 = new 全体阴阳护盾后();
        }
    }

    public class 全体阴阳护盾后 : 主动技能 
    {
        public override void Excute(技能环境 环境)
        {
            foreach (var 角色 in 环境.目标List)
            {
                角色.护盾 = true;

                环境.ResultList.Add(new 护盾结果()
                {
                    技能 = this,
                    角色1 = 环境.施放者,
                    角色2 = 角色,
                });
            }
        }
    }
}
