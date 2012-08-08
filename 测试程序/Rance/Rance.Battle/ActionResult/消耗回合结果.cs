using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 消耗回合结果:ActionResult
    {
        public 技能 技能;
        public 角色 角色;
        public int 回合数;

        public override string ToString()
        {
            return string.Format("{0} 使用 {1},额外消耗了 {2}个回合!", 角色, 技能, 回合数);
        }
    }
}
