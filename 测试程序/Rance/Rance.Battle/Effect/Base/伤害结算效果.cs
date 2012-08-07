using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public abstract class 伤害结算效果 : 效果
    {
        public abstract int Excute(角色 角色1,角色 角色2,int 伤害,bool 是否反击);
    }
}
