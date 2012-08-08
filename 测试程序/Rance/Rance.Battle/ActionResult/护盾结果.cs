using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 护盾结果:ActionResult
    {
        public 技能 技能;
        public 角色 角色1;
        public 角色 角色2;

        public override string ToString()
        {
            return string.Format("{0} 对 {1} 使用 {2},让其获得护盾!", 角色1,角色2, 技能);
        }
    }
}
