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
                        where !i.是否败走 && i.行动点 > 0
                        orderby i.顺序值
                        select i).ToList(); ;
            }
        }

        public void 初始化行动表(List<角色> list)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            foreach (var 角色 in list)
            {
                int min = Convert.ToInt32((17 - 角色.实际速) * 10);
                int max = Convert.ToInt32((20 - 角色.实际速) * 10);
                角色.顺序值 = r.Next(min, max);
            }
        }

        public void 行动(角色 角色, 主动技能 技能)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int min = Convert.ToInt32((15 - 角色.实际速) * 3);
            int max = Convert.ToInt32((18 - 角色.实际速) * 3);
            角色.顺序值 += 技能.技能速度 + r.Next(min, max);

        }

        public void 打断(角色 角色)
        {
            角色.准备技能 = null;
            角色.顺序值 += 常量.打断延迟;
        }
    }
}
