using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 角色
    {
        #region 基础属性

        public string Name { get; set; }

        public 兵种 兵种 { get; set; }

        public int 临时攻 { get; set; }
        public int 临时防 { get; set; }
        public int 临时智 { get; set; }
        public int 临时速 { get; set; }
        public int 攻 { get; set; }
        public int 防 { get; set; }
        public int 智 { get; set; }
        public int 速 { get; set; }

        public int 最大兵力 { get; set; }
        public int 兵力 { get; set; }

        public decimal 顺序值 { get; set; }

        public int 最大行动点 { get; set; }
        public int 行动点 { get; set; }

        public bool 是否败走 { get; set; }
        public bool 是否准备 { get; set; }
        public bool 是否完结 { get; set; }

        public bool IsTeamA { get; set; }

        private 赋予 _攻击赋予;
        public 赋予 攻击赋予 
        {
            get { return _攻击赋予; }
            set {
                if (_攻击赋予 != null && _攻击赋予.Level > value.Level)
                    return;
                _攻击赋予 = value;
            }
        }
        private 赋予 _防御赋予;
        public 赋予 防御赋予
        {
            get { return _防御赋予; }
            set
            {
                if (_防御赋予 != null && _防御赋予.Level > value.Level)
                    return;
                _防御赋予 = value;
            }
        }
        private 赋予 _速度赋予;
        public 赋予 速度赋予
        {
            get { return _速度赋予; }
            set
            {
                if (_速度赋予 != null && _速度赋予.Level > value.Level)
                    return;
                _速度赋予 = value;
            }
        }
        private 赋予 _智力赋予;
        public 赋予 智力赋予
        {
            get { return _智力赋予; ; }
            set
            {
                if (_智力赋予 != null && _智力赋予.Level > value.Level)
                    return;
                _智力赋予 = value;
            }
        }

        public 被动技能 被动技能 { get; set; }
        public 主动技能 基础攻击技能 { get; set; }
        public 主动技能 技能1 { get; set; }
        public 主动技能 技能2 { get; set; }
        public 技能 特殊技能 { get; set; }
        public 主动技能 待机 { get; set; }

        public int 排 { get; set; }
        public int 列 { get; set; }

        public int 守护率 { get; set; }
        public int 全体守护率 { get; set; }

        public 主动技能 准备技能 { get; set; }

        public bool 护盾 { get; set; }

        public List<效果> 效果List = new List<效果>();

        public void Add(效果 效果)
        {
            foreach (var item in 效果List.ToArray())
            {
                if (item.GetType() == 效果.GetType())
                    return;

                if (item.GetType().IsSubclassOf(效果.GetType()))
                    return;

                if (效果.GetType().IsSubclassOf(item.GetType()))
                    效果List.Remove(item);
            }

            效果List.Add(效果);
        }

        

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
                    return 临时攻;
                else
                    return 临时攻 * (1 + 攻击赋予.Level / 10m);
            }   
        }

        public decimal 实际防
        {
            get
            {
                if (防御赋予 == null)
                    return 临时防;
                else
                    return 临时防 * (1 + 防御赋予.Level / 10m);
            }
        }

        public decimal 实际速
        {
            get
            {
                if (速度赋予 == null)
                    return 临时速;
                else
                    return 临时速 * (1 + 速度赋予.Level / 10m);
            }
        }

        public decimal 实际智
        {
            get
            {
                if (智力赋予 == null)
                    return 临时智;
                else
                    return 临时智 * (1 + 智力赋予.Level / 10m);
            }
        }
        #endregion

        public override string ToString()
        {
            return Name + " " + 顺序值.ToString();
        }
    }
}
