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
            攻 = 8m,
            防 = 5.2m,
            智 = 4m,
            速 = 6m,
            能否反击 = true
        };

        public static 兵种 盾兵 = new 兵种()
        {
            Name = "盾兵",
            攻 = 4m,
            防 = 9.2m,
            智 = 4m,
            速 = 6.2m,
            能否反击 = true
        };

        public static 兵种 弓兵 = new 兵种()
        {
            Name = "弓兵",
            攻 = 5.5m,
            防 = 3.5m,
            智 = 6m,
            速 = 6.2m
        };

        public static 兵种 军师 = new 兵种()
        {
            Name = "军师",
            攻 = 4.2m,
            防 = 3.2m,
            智 = 9m,
            速 = 5m
        };

        public static 兵种 忍者 = new 兵种()
        {
            Name = "忍者",
            攻 = 6.5m,
            防 = 4m,
            智 = 4m,
            速 = 8m,
            能否反击 = true
        };

        public static 兵种 和尚 = new 兵种()
        {
            Name = "和尚",
            攻 = 7m,
            防 = 7m,
            智 = 5m,
            速 = 7m,
            能否反击 = true
        };

        public static 兵种 火枪 = new 兵种()
        {
            Name = "火枪",
            攻 = 13m,
            防 = 4m,
            智 = 4m,
            速 = 8.4m
        };

        public static 兵种 巫女 = new 兵种()
        {
            Name = "巫女",
            攻 = 4.5m,
            防 = 3.2m,
            智 = 8m,
            速 = 5m
        };

        public static 兵种 阴阳 = new 兵种()
        {
            Name = "阴阳",
            攻 = 3m,
            防 = 3.2m,
            智 = 8m,
            速 = 5m
        };

        public static 兵种 骑兵 = new 兵种()
        {
            Name = "骑兵",
            攻 = 5m,
            防 = 4.4m,
            智 = 5m,
            速 = 6m,
            能否反击 = true
        };

        public static 兵种 炮兵 = new 兵种()
        {
            Name = "炮兵",
            攻 = 7.5m,
            防 = 4,
            智 = 4,
            速 = 5.5m,
        };
    }
}
