using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 行动记录
    {
        public string 角色 { get; set; }
        public string 技能名 { get; set; }
        public string 目标角色 { get; set; }
        public int 伤害 { get; set; }
        public bool 败退 { get; set; }
    }
       
}
