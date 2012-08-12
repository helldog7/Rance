using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 战术解除 : 主动技能
    {
        public int 基数 = 0;
        public 战术解除()
        {
            this.技能速度 = 130;
            this.消耗行动点 = 1;
            this.技能目标 = Battle.技能目标.全体;
        }

        public override void Excute(技能环境 环境)
        {
            base.Excute(环境);

            List<int> list = new List<int>();
            int total = 0;
            foreach (var 角色 in 环境.战场.敌方角色List)
            {
                if (角色.是否败走)
                    continue;

                if (角色.攻击赋予 != null)
                    total++;
                if (角色.防御赋予 != null)
                    total++;
                if (角色.速度赋予 != null)
                    total++;
                if (角色.智力赋予 != null)
                    total++;
            }
            int value = 环境.施放者.智 / 2 + 基数;
            total = total > value ? value : total;
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < total; i++)
            {
                int index = r.Next(环境.战场.敌方角色List.Count);
                角色 角色 = 环境.战场.敌方角色List[index];
                if (角色.是否败走)
                {
                    i--;
                    continue;
                }
                int index2 = r.Next(4);
                switch (index2)
                {
                    case 0:
                        if (角色.攻击赋予 == null)
                        {
                            i--;
                            continue;
                        }
                        else
                        {
                            角色.攻击赋予 = null;
                            环境.ResultList.Add(new 赋予解除结果()
                            {
                                技能 = this,
                                Type = "攻击",
                                角色1 = 环境.施放者,
                                角色2 = 角色,
                            });
                        }
                        break;
                    case 1:
                        if (角色.防御赋予 == null)
                        {
                            i--;
                            continue;
                        }
                        else
                        {
                            角色.防御赋予 = null;
                            环境.ResultList.Add(new 赋予解除结果()
                            {
                                技能 = this,
                                Type = "防御",
                                角色1 = 环境.施放者,
                                角色2 = 角色,
                            });
                        }
                        break;
                    case 2:
                        if (角色.速度赋予 == null)
                        {
                            i--;
                            continue;
                        }
                        else
                        {
                            角色.速度赋予 = null;
                            环境.ResultList.Add(new 赋予解除结果()
                            {
                                技能 = this,
                                Type = "速度",
                                角色1 = 环境.施放者,
                                角色2 = 角色,
                            });
                        }
                        break;
                    case 3:
                        if (角色.智力赋予 == null)
                        {
                            i--;
                            continue;
                        }
                        else
                        {
                            角色.智力赋予 = null;
                            环境.ResultList.Add(new 赋予解除结果()
                            {
                                技能 = this,
                                Type = "攻击",
                                角色1 = 环境.施放者,
                                角色2 = 角色,
                            });
                        }
                        break;
                }

            }
        }
    }

    public class 战术解除2 : 战术解除
    {
        public 战术解除2()
        {
            this.基数 = 3;
        }
    }

    public class 单体战术解除 : 主动技能
    {
        public 单体战术解除()
        {
            this.技能速度 = 140;
            this.消耗行动点 = 1;
            this.技能目标 = Battle.技能目标.全体任一;
        }

        public override void Excute(技能环境 环境)
        {
            if (环境.目标List[0].攻击赋予 != null)
            {
                环境.目标List[0].攻击赋予 = null;
                环境.ResultList.Add(new 赋予解除结果()
                {
                    技能 = this,
                    Type = "攻击",
                    角色1 = 环境.施放者,
                    角色2 = 环境.目标List[0],
                });
            }

            if (环境.目标List[0].防御赋予 != null)
            {
                环境.目标List[0].防御赋予 = null;
                环境.ResultList.Add(new 赋予解除结果()
                {
                    技能 = this,
                    Type = "防御",
                    角色1 = 环境.施放者,
                    角色2 = 环境.目标List[0],
                });
            }

            if (环境.目标List[0].速度赋予 != null)
            {
                环境.目标List[0].速度赋予 = null;
                环境.ResultList.Add(new 赋予解除结果()
                {
                    技能 = this,
                    Type = "速度",
                    角色1 = 环境.施放者,
                    角色2 = 环境.目标List[0],
                });
            }

            if (环境.目标List[0].智力赋予 != null)
            {
                环境.目标List[0].智力赋予 = null;
                环境.ResultList.Add(new 赋予解除结果()
                {
                    技能 = this,
                    Type = "智力",
                    角色1 = 环境.施放者,
                    角色2 = 环境.目标List[0],
                });
            }
        }
    }
}
