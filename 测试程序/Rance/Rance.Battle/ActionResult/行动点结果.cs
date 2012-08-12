using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 行动点结果:ActionResult
    {
        public int 行动点;
        public 角色 角色1;
        public 角色 角色2;
        public 技能 技能;

        public override string ToString()
        {
            return string.Format("{0} 对 {1} 使用 {2},使其获得 {3}点行动点!", 角色1.Name, 角色2.Name, 技能.Name, 行动点);
        }
    }
}
    