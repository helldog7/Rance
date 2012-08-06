using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public abstract class 战场开始效果 : 效果
    {
        abstract void Excute(战场 战场,bool 是否己方);
    }
}
