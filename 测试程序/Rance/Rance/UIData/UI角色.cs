using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rance.Battle;

namespace Rance
{
    public class UI角色:UIObject
    {
        public UI战斗 UI战斗;

        public string Name { get; set; }
        public int 攻 { get; set; }
        public int 防 { get; set; }
        public int 智 { get; set; }
        public int 速 { get; set; }
        public int 最大行动点 { get; set; }
        public int 最大兵力 { get; set; }
        public int 排 { get; set; }
        public int 列 { get; set; }
        public bool IsTeamA { get; set; }

        public 角色 角色 { get; set; }

        private int _行动点;
        public int 行动点 
        {
            get { return _行动点; }
            set 
            {
                if (_行动点 != value) { _行动点 = value; SendPropertyChanged("行动点"); SendPropertyChanged("行动力Text"); SendPropertyChanged("State"); }
            }
        }

        public string 行动力Text { get { return string.Format("{0}/{1}", 行动点, 最大行动点); } }

        private int _兵力;
        public int 兵力
        {
            get { return _兵力; }
            set
            {
                if (_兵力 != value) { _兵力 = value; SendPropertyChanged("兵力"); SendPropertyChanged("兵力Text"); }
            }
        }

        public string 兵力Text { get { return string.Format("{0}/{1}", 兵力, 最大兵力); } }

        private int _守护率;
        public int 守护率
        {
            get { return _守护率; }
            set
            {
                if (_守护率 != value) { _守护率 = value; SendPropertyChanged("守护率"); SendPropertyChanged("守护Text"); }
            }
        }

        private int _全体守护率;
        public int 全体守护率
        {
            get { return _全体守护率; }
            set
            {
                if (_全体守护率 != value) { _全体守护率 = value; SendPropertyChanged("全体守护率"); SendPropertyChanged("守护Text"); }
            }
        }

        private bool _护盾;
        public bool 护盾
        {
            get { return _护盾; }
            set
            {
                if (_护盾 != value) { _护盾 = value; SendPropertyChanged("护盾"); }
            }
        }

        private bool _攻赋予;
        public bool 攻赋予
        {
            get { return _攻赋予; }
            set
            {
                if (_攻赋予 != value) { _攻赋予 = value; SendPropertyChanged("攻赋予"); }
            }
        }

        private bool _防赋予;
        public bool 防赋予
        {
            get { return _防赋予; }
            set
            {
                if (_防赋予 != value) { _防赋予 = value; SendPropertyChanged("_防赋予"); }
            }
        }

        private bool _速赋予;
        public bool 速赋予
        {
            get { return _速赋予; }
            set
            {
                if (_速赋予 != value) { _速赋予 = value; SendPropertyChanged("速赋予"); }
            }
        }

        private bool _智赋予;
        public bool 智赋予
        {
            get { return _智赋予; }
            set
            {
                if (_智赋予 != value) { _智赋予 = value; SendPropertyChanged("智赋予"); }
            }
        }

        private bool _败退;
        public bool 败退
        {
            get { return _败退; }
            set
            {
                if (_败退 != value) { _败退 = value; SendPropertyChanged("败退"); SendPropertyChanged("State"); }
            }
        }

        private bool _准备;
        public bool 准备
        {
            get { return _准备; }
            set
            {
                if (_准备 != value) { _准备 = value; SendPropertyChanged("准备"); SendPropertyChanged("State"); }
            }
        }

        private bool _行动中;
        public bool 行动中
        {
            get { return _行动中; }
            set
            {
                if (_行动中 != value) { _行动中 = value; SendPropertyChanged("行动中"); }
            }
        }

        private bool _选择中;
        public bool 选择中
        {
            get { return _选择中; }
            set
            {
                if (_选择中 != value) { _选择中 = value; SendPropertyChanged("选择中"); }
            }
        }

        public string State 
        {
            get 
            {
                if (败退)
                    return "败退";
                if(行动点 == 0)
                    return "行动完结";
                if (准备) 
                    return "准备中";

                return "";
            }
        }

        public string 守护Text
        {
            get 
            {
                if (守护率 > 0)
                    return string.Format("守护率:{0}", 守护率);
                if(全体守护率 > 0)
                    return string.Format("守护率:{0}", 守护率);

                return "";
            }
        }

        public List<UI技能> 技能List = new List<UI技能>();
    }
}
