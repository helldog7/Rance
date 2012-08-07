using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 巫女祝福 : 战斗开始被动技能
    {
        class 巫女祝福Item
        {
            public int 角色Index;
            public int 赋予Index;
            public override bool Equals(object obj)
            {
                if (!(obj is 巫女祝福Item))
                    return false;
                巫女祝福Item item = (巫女祝福Item)obj;
                return item.赋予Index == 赋予Index && item.角色Index == 角色Index;
            }
        }

        public override void Excute(技能环境 环境)
        {
            List<巫女祝福Item> list = new List<巫女祝福Item>();
            int maxItem = 环境.战场.己方角色List.Count * 4;
            maxItem = maxItem > 环境.施放者.智 + 2 ?  环境.施放者.智 + 2 : maxItem;
            for (int i = 0; i < maxItem; i++)
            {
                巫女祝福Item item = newItem(环境.战场.己方角色List.Count,list);
                list.Add(item);
            }

            foreach (var item in list)
            {
                角色 角色 = 环境.战场.己方角色List[item.角色Index];
                赋予 赋予 = null;
                switch (item.赋予Index)
                { 
                    case 0:
                        赋予 = new 赋予()
                        {
                            Level = 1,
                            是否单回合 = false
                        };
                        角色.攻击赋予 = 赋予;

                        环境.ResultList.Add(new 赋予结果()
                        {
                            赋予 = 赋予,
                            技能 = this,
                            Type = "攻击",
                            角色1 = 环境.施放者,
                            角色2 = 角色,
                        });
                        break;
                    case 1:
                        赋予 = new 赋予()
                        {
                            Level = 1,
                            是否单回合 = false
                        };
                        角色.防御赋予 = 赋予;

                        环境.ResultList.Add(new 赋予结果()
                        {
                            赋予 = 赋予,
                            技能 = this,
                            Type = "防御",
                            角色1 = 环境.施放者,
                            角色2 = 角色,
                        });
                        break;
                    case 2:
                        赋予 = new 赋予()
                        {
                            Level = 1,
                            是否单回合 = false
                        };
                        角色.速度赋予 = 赋予;

                        环境.ResultList.Add(new 赋予结果()
                        {
                            赋予 = 赋予,
                            技能 = this,
                            Type = "速度",
                            角色1 = 环境.施放者,
                            角色2 = 角色,
                        });
                        break;
                    case 3:
                        赋予 = new 赋予()
                        {
                            Level = 1,
                            是否单回合 = false
                        };
                        角色.智力赋予 = 赋予;

                        环境.ResultList.Add(new 赋予结果()
                        {
                            赋予 = 赋予,
                            技能 = this,
                            Type = "智力",
                            角色1 = 环境.施放者,
                            角色2 = 角色,
                        });
                        break;
                }
            }
        }

        private 巫女祝福Item newItem(int 人数, List<巫女祝福Item> list)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            巫女祝福Item item = new 巫女祝福Item() 
            {
                角色Index = r.Next(人数),
                赋予Index = r.Next(4)
            };

            if(list.Contains(item))
                return  newItem(人数,list);

            return item;
        }
    }
}
