using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 常量
    {
        public const int 最大战果 = 1000;
        public const int 最小战果 = -1000;
        public const int 最大战场修正 = 20;
        public const int 最小战场修正 = -20;
        public const int 击倒战果 = 150;
        public const decimal 反击比率 = 0.4m;
        public const int 战果系数 = 350;
        public const int 基础兵力 = 100;

        public const decimal 物理伤害系数 = 1m;
        public const decimal 法术伤害系数 = 0.7m;

        public const decimal 兵种减伤系数 = 4.2m;
        public const decimal 武将减伤系数 = 0.12m;

        public const int 打断延迟 = 60;
        public const int 战斗后回复系数 = 5;

        public static int[] 赋予效果系数 = new int[] { 10, 20, 30, 50, 70 };
    }
}
