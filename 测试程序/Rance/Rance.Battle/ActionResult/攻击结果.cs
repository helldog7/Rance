using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 攻击结果:ActionResult
    {
        public 攻击技能 攻击技能;
        public 角色 角色1;
        public 角色 角色2;
        public 角色 守护角色;
        public int 伤害;
        public int 战果;
        public bool 是否败退;
        public bool 是否被护盾抵挡;
        public bool 是否打断;

        public string 补充;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0} 对 {1} 使用 {2},", 角色1.Name, 角色2.Name, 攻击技能));
            if (守护角色 != null)
                sb.Append(string.Format("被 {0} 守护,", 守护角色.Name));
            if (是否被护盾抵挡)
                sb.Append("被护盾抵挡了伤害,");
            else if (是否败退)
                sb.Append(string.Format("造成了 {0}点伤害,获得了 {1}点战果,败退!"));
            else
                sb.Append(string.Format("造成了 {0}点伤害,获得了 {1}点战果."));

            if(是否打断)
                sb.Append(string.Format("{0}的准备技能被打断!",角色2));

            if (补充 != null)
                sb.Append(补充);

            return sb.ToString();
        }
    }
}
