using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 战果结果:ActionResult
    {
        public 技能 技能;
        public 角色 角色;
        public int 战果;

        public override string ToString()
        {
            return string.Format("{0} 使用 {1},获得 {2}点战果!", 角色, 技能, 战果);
        }
    }
}
