using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public abstract class 效果
    {
        public 持续类型 持续类型 { get; set; }

        public string Name
        {
            get
            {
                return this.GetType().Name;
            }
        }
    }

    public enum 持续类型
    { 
        一回合,
        一次,
        整场战斗
    }
}
