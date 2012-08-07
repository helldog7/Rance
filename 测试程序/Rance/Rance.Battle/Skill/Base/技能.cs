using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 技能
    {
        public string Name
        {
            get
            {
                return this.GetType().Name;
            }
        }
    }
}
