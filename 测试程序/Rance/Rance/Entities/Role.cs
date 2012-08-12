using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Rance
{
    public partial class Role : INotifyPropertyChanged
    {
        #region PropertyChange

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Role))
                return false;

            Role role = obj as Role;
            return role.ID == ID;
        }

        public string 基础攻击技能Text 
        {
            get 
            {
                return 基础攻击技能;
            }
            set 
            {
                if (value == null)
                    value = "";
                基础攻击技能 = value;
            }
        }

        public string 被动技能Text
        {
            get
            {
                return 被动技能;
            }
            set
            {
                if (value == null)
                    value = "";
                被动技能 = value;
            }
        }

        public string 技能1Text
        {
            get
            {
                return 技能1;
            }
            set
            {
                if (value == null)
                    value = "";
                技能1 = value;
            }
        }

        public string 技能2Text
        {
            get
            {
                return 技能2;
            }
            set
            {
                if (value == null)
                    value = "";
                技能2 = value;
            }
        }
    }
}
