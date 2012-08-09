using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance
{
    public class UI战斗:UIObject
    {
        public int 最大回合数 { get; set; }
        public UI行动顺序 行动顺序 { get; set; }

        private int _当前回合;
        public int 当前回合
        {
            get { return _当前回合; }
            set
            {
                if (_当前回合 != value) { _当前回合 = value; SendPropertyChanged("当前回合"); SendPropertyChanged("回合"); }
            }
        }

        public string 回合 
        {
            get 
            {
                return string.Format("{0}/{1}", 当前回合, 最大回合数);
            }
        }

        private int _战场修正;
        public int 战场修正
        {
            get { return _战场修正; }
            set
            {
                if (_战场修正 != value) { _战场修正 = value; SendPropertyChanged("战场修正");  }
            }
        }

        private int _战果;
        public int 战果
        {
            get { return _战果; }
            set
            {
                if (_战果 != value) { _战果 = value; SendPropertyChanged("战果"); }
            }
        }

        public string TeamA { get; set; }
        public string TeamB { get; set; }

        public List<UI角色> TeamAList;
        public List<UI角色> TeamBList;

        public UI角色 Current角色 { get; set; }

        #region Team A人物

        private UI角色 _teamA_1_1;
        public UI角色 TeamA_1_1
        {
            get { return _teamA_1_1; }
            set
            {
                if (_teamA_1_1 != value) { _teamA_1_1 = value; SendPropertyChanged("TeamA_1_1"); }
            }
        }

        private UI角色 _teamA_1_2;
        public UI角色 TeamA_1_2
        {
            get { return _teamA_1_2; }
            set
            {
                if (_teamA_1_2 != value) { _teamA_1_2 = value; SendPropertyChanged("TeamA_1_2"); }
            }
        }

        private UI角色 _teamA_1_3;
        public UI角色 TeamA_1_3
        {
            get { return _teamA_1_3; }
            set
            {
                if (_teamA_1_3 != value) { _teamA_1_3 = value; SendPropertyChanged("TeamA_1_3"); }
            }
        }

        private UI角色 _teamA_2_1;
        public UI角色 TeamA_2_1
        {
            get { return _teamA_2_1; }
            set
            {
                if (_teamA_2_1 != value) { _teamA_2_1 = value; SendPropertyChanged("TeamA_2_1"); }
            }
        }

        private UI角色 _teamA_2_2;
        public UI角色 TeamA_2_2
        {
            get { return _teamA_2_2; }
            set
            {
                if (_teamA_2_2 != value) { _teamA_2_2 = value; SendPropertyChanged("TeamA_2_2"); }
            }
        }

        private UI角色 _teamA_2_3;
        public UI角色 TeamA_2_3
        {
            get { return _teamA_2_3; }
            set
            {
                if (_teamA_2_3 != value) { _teamA_2_3 = value; SendPropertyChanged("TeamA_2_3"); }
            }
        }

        private UI角色 _teamA_3_1;
        public UI角色 TeamA_3_1
        {
            get { return _teamA_3_1; }
            set
            {
                if (_teamA_3_1 != value) { _teamA_3_1 = value; SendPropertyChanged("TeamA_3_1"); }
            }
        }

        private UI角色 _teamA_3_2;
        public UI角色 TeamA_3_2
        {
            get { return _teamA_3_2; }
            set
            {
                if (_teamA_3_2 != value) { _teamA_3_2 = value; SendPropertyChanged("TeamA_3_2"); }
            }
        }

        private UI角色 _teamA_3_3;
        public UI角色 TeamA_3_3
        {
            get { return _teamA_3_3; }
            set
            {
                if (_teamA_3_3 != value) { _teamA_3_3 = value; SendPropertyChanged("TeamA_3_3"); }
            }
        }

        #endregion

        #region Team B人物

        private UI角色 _teamB_1_1;
        public UI角色 TeamB_1_1
        {
            get { return _teamB_1_1; }
            set
            {
                if (_teamB_1_1 != value) { _teamB_1_1 = value; SendPropertyChanged("TeamB_1_1"); }
            }
        }

        private UI角色 _teamB_1_2;
        public UI角色 TeamB_1_2
        {
            get { return _teamB_1_2; }
            set
            {
                if (_teamB_1_2 != value) { _teamB_1_2 = value; SendPropertyChanged("TeamB_1_2"); }
            }
        }

        private UI角色 _teamB_1_3;
        public UI角色 TeamB_1_3
        {
            get { return _teamB_1_3; }
            set
            {
                if (_teamB_1_3 != value) { _teamB_1_3 = value; SendPropertyChanged("TeamB_1_3"); }
            }
        }

        private UI角色 _teamB_2_1;
        public UI角色 TeamB_2_1
        {
            get { return _teamB_2_1; }
            set
            {
                if (_teamB_2_1 != value) { _teamB_2_1 = value; SendPropertyChanged("TeamB_2_1"); }
            }
        }

        private UI角色 _teamB_2_2;
        public UI角色 TeamB_2_2
        {
            get { return _teamB_2_2; }
            set
            {
                if (_teamB_2_2 != value) { _teamB_2_2 = value; SendPropertyChanged("TeamB_2_2"); }
            }
        }

        private UI角色 _teamB_2_3;
        public UI角色 TeamB_2_3
        {
            get { return _teamB_2_3; }
            set
            {
                if (_teamB_2_3 != value) { _teamB_2_3 = value; SendPropertyChanged("TeamB_2_3"); }
            }
        }

        private UI角色 _teamB_3_1;
        public UI角色 TeamB_3_1
        {
            get { return _teamB_3_1; }
            set
            {
                if (_teamB_3_1 != value) { _teamB_3_1 = value; SendPropertyChanged("TeamB_3_1"); }
            }
        }

        private UI角色 _teamB_3_2;
        public UI角色 TeamB_3_2
        {
            get { return _teamB_3_2; }
            set
            {
                if (_teamB_3_2 != value) { _teamB_3_2 = value; SendPropertyChanged("TeamB_3_2"); }
            }
        }

        private UI角色 _teamB_3_3;
        public UI角色 TeamB_3_3
        {
            get { return _teamB_3_3; }
            set
            {
                if (_teamB_3_3 != value) { _teamB_3_3 = value; SendPropertyChanged("TeamB_3_3"); }
            }
        }

        #endregion
    }
}
