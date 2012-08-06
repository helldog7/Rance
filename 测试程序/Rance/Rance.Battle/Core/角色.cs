using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rance.Base;

namespace Rance.Battle
{
    public class 角色
    {
        #region 基础属性
        
        public 兵种 兵种 { get; set; }

        public decimal 攻 { get; set; }
        public decimal 防 { get; set; }
        public decimal 智 { get; set; }
        public decimal 速 { get; set; }

        public int 最大兵力 { get; set; }
        public int 兵力 { get; set; }

        public int 最大行动点 { get; set; }
        public int 行动点 { get; set; }

        public bool 是否败走 { get; set; }

        public 赋予 攻击赋予 { get; set; }
        public 赋予 防御赋予 { get; set; }
        public 赋予 速度赋予 { get; set; }
        public 赋予 智力赋予 { get; set; }

        public 被动技能 被动技能 { get; set; }
        public 主动技能 基础攻击技能 { get; set; }
        public 主动技能 攻击技能 { get; set; }
        public 主动技能 辅助技能 { get; set; }

        public int 排 { get; set; }
        public int 列 { get; set; }

        public int 守护率 { get; set; }
        public int 全体守护率 { get; set; }

        public 攻击技能 准备技能 { get; set; }

        #endregion

        #region 计算属性

        public int 实际兵力
        {
            get
            {
                int i1, i2, i3;
                if (兵力 >= 500)
                    i1 = 500;
                else
                    i1 = 兵力;
                if (兵力 >= 1500)
                {
                    i2 = 500;
                    i3 = (兵力 - 1500) / 4;
                }
                else
                {
                    i2 = (兵力 - 500) / 2;
                    i3 = 0;
                }

                return i1 + i2 + i3;

            }
        }

        public decimal 实际攻
        { 
            get
            {
                if (攻击赋予 == null)
                    return 攻;
                else
                    return 攻 * (1 + 攻击赋予.Level / 10m);
            }   
        }

        public decimal 实际防
        {
            get
            {
                if (防御赋予 == null)
                    return 防;
                else
                    return 防 * (1 + 防御赋予.Level / 10m);
            }
        }

        public decimal 实际速
        {
            get
            {
                if (速度赋予 == null)
                    return 速;
                else
                    return 速 * (1 + 速度赋予.Level / 10m);
            }
        }

        public decimal 实际智
        {
            get
            {
                if (智力赋予 == null)
                    return 智;
                else
                    return 智 * (1 + 智力赋予.Level / 10m);
            }
        }
        #endregion
    }
}
