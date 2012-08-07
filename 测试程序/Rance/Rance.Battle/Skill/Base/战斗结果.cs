using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 战斗结果
    {
        public List<角色> 角色List { get; set; }
        public bool Win { get; set; }
        public List<int> 回复兵力List { get; set; }
        public int 掉武将率 { get; set; }
        public int 掉装备率 { get; set; }
        public int 获得金钱 { get; set; }
    }
}
