﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 赋予解除结果 : ActionResult
    {
        public string Type;
        public 角色 角色1;
        public 角色 角色2;
        public 技能 技能;

        public override string ToString()
        {
            return string.Format("{0} 对 {1} 使用 {2},解除 {3}赋予!", 角色1.Name, 角色2.Name, 技能.Name, Type);
        }
    }
}
