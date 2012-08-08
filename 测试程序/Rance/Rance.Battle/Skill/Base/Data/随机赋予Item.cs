using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 随机赋予Item
    {
        public int 角色Index;
        public int 赋予Index;
        public override bool Equals(object obj)
        {
            if (!(obj is 随机赋予Item))
                return false;
            随机赋予Item item = (随机赋予Item)obj;
            return item.赋予Index == 赋予Index && item.角色Index == 角色Index;
        }
    }
}
