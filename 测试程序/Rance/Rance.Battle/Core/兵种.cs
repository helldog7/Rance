using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 兵种
    {
        public string Name { get; set; }
        public decimal 攻 { get; set; }
        public decimal 防 { get; set; }
        public decimal 智 { get; set; }
        public decimal 速 { get; set; }

        public bool 能否反击 { get; set; }

        public static 兵种 剑士 = new 兵种()
        {
            Name = "剑士",
            攻 = 8,
            防 = 4,
            智 = 4,
            速 = 6,
            能否反击 = true
        };

        public static 兵种 盾兵 = new 兵种()
        {
            Name = "盾兵",
            攻 = 5,
            防 = 9,
            智 = 4,
            速 = 6,
            能否反击 = true
        };

        public static 兵种 弓兵 = new 兵种()
        {
            Name = "弓兵",
            攻 = 6,
            防 = 4,
            智 = 6,
            速 = 7
        };

        public static 兵种 军师 = new 兵种()
        {
            Name = "军师",
            攻 = 4,
            防 = 4,
            智 = 9,
            速 = 5
        };

        public static 兵种 忍者 = new 兵种()
        {
            Name = "忍者",
            攻 = 7,
            防 = 5,
            智 = 4,
            速 = 9,
            能否反击 = true
        };

        public static 兵种 和尚 = new 兵种()
        {
            Name = "和尚",
            攻 = 7,
            防 = 7,
            智 = 5,
            速 = 7,
            能否反击 = true
        };

        public static 兵种 火枪 = new 兵种()
        {
            Name = "火枪",
            攻 = 9,
            防 = 4,
            智 = 4,
            速 = 8
        };

        public static 兵种 巫女 = new 兵种()
        {
            Name = "巫女",
            攻 = 5,
            防 = 4,
            智 = 8,
            速 = 6
        };

        public static 兵种 阴阳 = new 兵种()
        {
            Name = "阴阳",
            攻 = 3,
            防 = 4,
            智 = 8,
            速 = 5
        };

        public static 兵种 骑兵 = new 兵种()
        {
            Name = "骑兵",
            攻 = 5,
            防 = 5,
            智 = 5,
            速 = 7,
            能否反击 = true
        };

        public static 兵种 炮兵 = new 兵种()
        {
            Name = "炮兵",
            攻 = 8,
            防 = 5,
            智 = 4,
            速 = 5,
        };
    }
}
