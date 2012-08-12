using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 反击结果 : ActionResult
    {
        public 角色 角色1;
        public 角色 角色2;
        public int 伤害;
        public int 战果;
        public bool 是否败退;
        public bool 是否被护盾抵挡;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0} 对 {1} 反击,", 角色1.Name, 角色2.Name));

            if (是否被护盾抵挡)
                sb.Append("被护盾抵挡了伤害,");
            else if (是否败退)
                sb.Append(string.Format("造成了 {0}点伤害,获得了 {1}点战果,败退!", 伤害, 战果));
            else
                sb.Append(string.Format("造成了 {0}点伤害,获得了 {1}点战果.", 伤害, 战果));

            return sb.ToString();
        }
    }
}
