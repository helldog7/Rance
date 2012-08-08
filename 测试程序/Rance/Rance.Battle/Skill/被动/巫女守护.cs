using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 巫女守护 : 战斗开始被动技能
    {
        public override void Excute(技能环境 环境)
        {
            List<int> list = new List<int>();
            int maxItem = 环境.战场.己方角色List.Count;
            maxItem = maxItem > 环境.施放者.智/3 ? 环境.施放者.智/3 : maxItem;
            Random r = new Random(DateTime.Now.Millisecond);
            
            for (int i = 0; i < maxItem; i++)
            {
                int index = r.Next(maxItem);
                while(list.Contains(index))
                    index = r.Next(maxItem);

                list.Add(index);
            }

            foreach (var item in list)
            {
                角色 角色 = 环境.战场.己方角色List[item];
                赋予 赋予 = null;
                角色.Add(new 自动回复效果());
            }
        }
    }
}
