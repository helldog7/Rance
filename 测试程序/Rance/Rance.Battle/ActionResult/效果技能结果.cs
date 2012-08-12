using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 效果技能结果:ActionResult
    {
        public 攻击技能 攻击技能;
        public 角色 角色1;
        public 角色 角色2;
        public 效果 效果;

        public override string ToString()
        {
            return string.Format("{0} 对 {1} 使用 {2},使其获得 {3}!", 角色1.Name, 角色2.Name, 攻击技能.Name, 效果);
        }
    }
}
