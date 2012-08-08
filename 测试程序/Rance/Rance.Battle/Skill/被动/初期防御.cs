using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 初期防御 : 战斗开始被动技能
    {
        public override void Excute(技能环境 环境)
        {
            if (环境.施放者.守护率 == 0 && 环境.施放者.全体守护率 == 0)
            {
                环境.施放者.守护率 = 50;

                环境.ResultList.Add(new 守护结果()
                {
                    技能 = this,
                    角色 = 环境.施放者,
                    守护率 = 50,
                    全体守护率 = 0 - 环境.施放者.全体守护率
                });

                环境.施放者.全体守护率 = 0;
            }
        }
    }

    public class 初期防御2 : 战斗开始被动技能
    {
        public override void Excute(技能环境 环境)
        {

            环境.施放者.守护率 = 120;

            环境.ResultList.Add(new 守护结果()
            {
                技能 = this,
                角色 = 环境.施放者,
                守护率 = 120,
                全体守护率 = 0 - 环境.施放者.全体守护率
            });

            环境.施放者.全体守护率 = 0;
        }
    }

    public class 初期全体防御 : 战斗开始被动技能
    {
        public override void Excute(技能环境 环境)
        {
            环境.施放者.全体守护率 = 50;

            环境.ResultList.Add(new 守护结果()
            {
                技能 = this,
                角色 = 环境.施放者,
                守护率 = 0,
                全体守护率 = 50
            });

            环境.施放者.守护率 = 0;
        }
    }
}
