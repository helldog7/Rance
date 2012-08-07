using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 反击强化效果 : 伤害结算效果
    {
        public override int Excute(角色 角色1, 角色 角色2, int 伤害, bool 是否反击)
        {
            if (是否反击)
                return 伤害 * 2;
            else
                return 伤害;
        }
    }

    public class 反击强化2效果 : 伤害结算效果
    {
        public override int Excute(角色 角色1, 角色 角色2, int 伤害, bool 是否反击)
        {
            if (是否反击)
                return 伤害 * 3;
            else
                return 伤害;
        }
    }
}
