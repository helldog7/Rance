using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 战场修正结果:ActionResult
    {
        public 技能 技能;
        public 角色 角色;
        public int 战场修正;

        public override string ToString()
        {
            return string.Format("{0} 使用 {1},获得 {2}点战场修正!", 角色, 技能, 战场修正);
        }
    }
}
