using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rance.Base;

namespace Rance.Battle
{
    public class 角色
    {
        public 兵种 兵种 { get; set; }

        public int 攻 { get; set; }
        public int 防 { get; set; }
        public int 智 { get; set; }
        public int 速 { get; set; }

        public int 最大兵力 { get; set; }
        public int 兵力 { get; set; }

        public int 最大行动点 { get; set; }
        public int 行动点 { get; set; }

        public bool 是否败走 { get; set; }

        public 赋予 攻击赋予 { get; set; }
        public 赋予 防御赋予 { get; set; }
        public 赋予 速度赋予 { get; set; }
        public 赋予 智力赋予 { get; set; }

        public 被动技能 被动技能 { get; set; }
        public 主动技能 基础攻击技能 { get; set; }
        public 主动技能 攻击技能 { get; set; }
        public 主动技能 辅助技能 { get; set; }
    }
}
