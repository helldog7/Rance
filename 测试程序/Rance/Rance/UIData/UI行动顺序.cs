using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance
{
    public class UI行动顺序 : UIObject
    {
        private UI角色 _行动者1;
        public UI角色 行动者1
        {
            get { return _行动者1; }
            set
            {
                if (_行动者1 != value) { _行动者1 = value; SendPropertyChanged("行动者1"); }
            }
        }

        private UI角色 _行动者2;
        public UI角色 行动者2
        {
            get { return _行动者2; }
            set
            {
                if (_行动者2 != value) { _行动者2 = value; SendPropertyChanged("行动者2"); }
            }
        }

        private UI角色 _行动者3;
        public UI角色 行动者3
        {
            get { return _行动者3; }
            set
            {
                if (_行动者3 != value) { _行动者3 = value; SendPropertyChanged("行动者3"); }
            }
        }

        private UI角色 _行动者4;
        public UI角色 行动者4
        {
            get { return _行动者4; }
            set
            {
                if (_行动者4 != value) { _行动者4 = value; SendPropertyChanged("行动者4"); }
            }
        }

        private UI角色 _行动者5;
        public UI角色 行动者5
        {
            get { return _行动者5; }
            set
            {
                if (_行动者5 != value) { _行动者5 = value; SendPropertyChanged("行动者5"); }
            }
        }

        private UI角色 _行动者6;
        public UI角色 行动者6
        {
            get { return _行动者6; }
            set
            {
                if (_行动者6 != value) { _行动者6 = value; SendPropertyChanged("行动者6"); }
            }
        }
    }
}
