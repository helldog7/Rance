﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance
{
    public class UI技能
    {
        public string Name { get; set; }
        public int 行动点 { get; set; }

        public override string ToString()
        {
            return string.Format(string.Format("{0} (消耗:{1})", Name, 行动点));
        }
    }
}
