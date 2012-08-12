using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 回复结果:ActionResult
    {
        public 角色 角色1;
        public 角色 角色2;
        public 主动技能 技能;
        public 效果 效果;
        public int 回复量;


        public override string ToString()
        {
            if (技能 != null)
                return string.Format("{0} 对 {1} 使用 {2},回复 {3}兵力!", 角色1.Name, 角色2.Name, 技能.Name, 回复量);
            else
                return string.Format("{0} 使 {1},回复 {2}兵力!", 效果.Name, 角色2.Name, 回复量);
        }
    }
}
