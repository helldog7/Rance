using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public static class Roll
    {
        public static bool Hit(int value)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int t = r.Next(1, 101);
            return value >= t;
        }
    }
}
