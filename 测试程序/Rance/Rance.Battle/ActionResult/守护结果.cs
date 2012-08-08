using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 守护结果:ActionResult
    {
        public 技能 技能;
        public 角色 角色;
        public 角色 角色2;

        public int 守护率;
        public int 全体守护率;

        public override string ToString()
        {

            return string.Format("{0} 对{4}使用 {1},获得 {2}点守护率,{3}点全体守护率!", 角色, 技能, 守护率, 全体守护率, 角色2);
        }
    }
}
