using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 效果结果:ActionResult
    {
        public 效果 效果;
        public 角色 角色;
        public string Text;

        public override string ToString()
        {
            return string.Format("{0} 对 {1} {3}!", 效果, 角色.Name, Text );
        }
    }
}
