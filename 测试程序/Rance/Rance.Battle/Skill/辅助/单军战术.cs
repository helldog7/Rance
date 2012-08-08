using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 单军战术 : 主动技能
    {
        public int Level = 4;
        public 单军战术()
        {
            this.技能速度 = 140;
            this.消耗行动点 = 1;
            this.技能目标 = Battle.技能目标.己方任一;
        }

        public override void Excute(技能环境 环境)
        {
            List<int> list = new List<int>();
            int maxItem = 4;
            int value = 环境.施放者.智 / 2;
            maxItem = maxItem > value ? value : maxItem;
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < maxItem; i++)
            {
                int index = r.Next(4);
                while (list.Contains(index))
                    index = r.Next(4);

                list.Add(index);
            }

            foreach (var item in list)
            {
                赋予 赋予 = null;
                switch (item)
                {
                    case 0:
                        赋予 = new 赋予()
                        {
                            Level = Level,
                            是否单回合 = false
                        };
                        环境.目标List[0].攻击赋予 = 赋予;

                        环境.ResultList.Add(new 赋予结果()
                        {
                            赋予 = 赋予,
                            技能 = this,
                            Type = "攻击",
                            角色1 = 环境.施放者,
                            角色2 = 环境.目标List[0],
                        });
                        break;
                    case 1:
                        赋予 = new 赋予()
                        {
                            Level = Level,
                            是否单回合 = false
                        };
                        环境.目标List[0].防御赋予 = 赋予;

                        环境.ResultList.Add(new 赋予结果()
                        {
                            赋予 = 赋予,
                            技能 = this,
                            Type = "防御",
                            角色1 = 环境.施放者,
                            角色2 = 环境.目标List[0],
                        });
                        break;
                    case 2:
                        赋予 = new 赋予()
                        {
                            Level = Level,
                            是否单回合 = false
                        };
                        环境.目标List[0].速度赋予 = 赋予;

                        环境.ResultList.Add(new 赋予结果()
                        {
                            赋予 = 赋予,
                            技能 = this,
                            Type = "速度",
                            角色1 = 环境.施放者,
                            角色2 = 环境.目标List[0],
                        });
                        break;
                    case 3:
                        赋予 = new 赋予()
                        {
                            Level = Level,
                            是否单回合 = false
                        };
                        环境.目标List[0].智力赋予 = 赋予;

                        环境.ResultList.Add(new 赋予结果()
                        {
                            赋予 = 赋予,
                            技能 = this,
                            Type = "智力",
                            角色1 = 环境.施放者,
                            角色2 = 环境.目标List[0],
                        });
                        break;
                }
            }
        }
    }

    public class 单军战术2 : 单军战术
    {
        public 单军战术2() 
        {
            this.Level = 3;
        }
    }
}
