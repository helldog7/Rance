using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 行动顺序
    {
        private List<角色> list = new List<角色>();
        public List<角色> List
        {
            get
            {
                return list;
            }
        }

        public void 初始化行动表(List<角色> list)
        { }

        public void 行动(角色 角色, 主动技能 技能)
        { }

        public void 打断(角色 角色)
        { }

        public void 准备(角色 角色, 准备技能 技能)
        { }
    }
}
