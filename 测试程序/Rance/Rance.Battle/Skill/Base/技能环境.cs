using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 技能环境
    {
        public 战场 战场 { get; set; }
        public 角色 施放者 { get; set; }
        public bool IsTeamA {get;set;}
        public List<角色> 目标List { get; set; }
    }
}
