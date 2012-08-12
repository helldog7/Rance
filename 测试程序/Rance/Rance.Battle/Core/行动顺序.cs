using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 行动顺序
    {
        private List<角色> list = new List<角色>();
        public List<角色> List
        {
            get
            {
                return (from i in list
                        where !i.是否败走 &&
                              (i.准备技能 != null || i.行动点 > 0 )
                        orderby i.顺序值
                        select i).ToList(); ;
            }
        }

        public void 初始化行动表(List<角色> list)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            foreach (var 角色 in list)
            {
                int min = Convert.ToInt32((19 - 角色.实际速) * 100);
                int max = 0;
                if (角色.实际速 >= 9)
                    max = Convert.ToInt32((23 - 角色.实际速) * 100);
                else if (角色.实际速 >= 11)
                    max = Convert.ToInt32((25 - 角色.实际速) * 100);
                else if (角色.实际速 >= 12)
                    max = Convert.ToInt32((26.5m - 角色.实际速) * 100);
                else
                    max = Convert.ToInt32((22 - 角色.实际速) * 100);
                角色.顺序值 = r.Next(min, max) / 10m + (18 - 角色.兵种.速) * 10 * 1.7m ;
            }
            this.list = list;
        }

        public void 行动(角色 角色, 主动技能 技能)
        {
            角色.顺序值 += 技能.技能速度 * 0.6m + (11 - 角色.实际速) * 8;
        }

        public void 打断(角色 角色)
        {
            角色.准备技能 = null;
            角色.顺序值 += 常量.打断延迟;
        }
    }
}
