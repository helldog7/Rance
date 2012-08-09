using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Rance
{
    public partial class Team : INotifyPropertyChanged
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

        public string Member
        {
            get
            {
                var list = (from r in this.TeamRole
                            select r.Role);
                StringBuilder sb = new StringBuilder();
                foreach (var item in list)
                    sb.Append(string.Format("{0} ", item.Name));

                return sb.ToString();
            }
        }

        private bool isInnerSetting = false;

        private Role _第一排前列;
        public Role 第一排前列
        {
            get
            {
                return _第一排前列;
            }
            set
            {
                if (_第一排前列 != value)
                {
                    _第一排前列 = value;
                    SendPropertyChanged("第一排前列");
                    if (isInnerSetting)
                        return;
                    isInnerSetting = true;

                    if (object.Equals(第一排中列, value))
                        第一排中列 = null;
                    if (object.Equals(第一排后列, value))
                        第一排后列 = null;
                    if (object.Equals(第二排前列, value))
                        第二排前列 = null;
                    if (object.Equals(第二排中列, value))
                        第二排中列 = null;
                    if (object.Equals(第二排后列, value))
                        第二排后列 = null;
                    if (object.Equals(第三排前列, value))
                        第三排前列 = null;
                    if (object.Equals(第三排中列, value))
                        第三排中列 = null;
                    if (object.Equals(第三排后列, value))
                        第三排后列 = null;

                    isInnerSetting = false;
                }
            }
        }

        private Role _第一排中列;
        public Role 第一排中列
        {
            get
            {
                return _第一排中列;
            }
            set
            {
                if (_第一排中列 != value)
                {
                    _第一排中列 = value;
                    SendPropertyChanged("第一排中列");
                    if (isInnerSetting)
                        return;
                    isInnerSetting = true;

                    if (object.Equals(第一排前列, value))
                        第一排前列 = null;
                    if (object.Equals(第一排后列, value))
                        第一排后列 = null;
                    if (object.Equals(第二排前列, value))
                        第二排前列 = null;
                    if (object.Equals(第二排中列, value))
                        第二排中列 = null;
                    if (object.Equals(第二排后列, value))
                        第二排后列 = null;
                    if (object.Equals(第三排前列, value))
                        第三排前列 = null;
                    if (object.Equals(第三排中列, value))
                        第三排中列 = null;
                    if (object.Equals(第三排后列, value))
                        第三排后列 = null;

                    isInnerSetting = false;
                }
            }
        }

        private Role _第一排后列;
        public Role 第一排后列
        {
            get
            {
                return _第一排后列;
            }
            set
            {
                if (_第一排后列 != value)
                {
                    _第一排后列 = value;
                    SendPropertyChanged("第一排后列");
                    if (isInnerSetting)
                        return;
                    isInnerSetting = true;

                    if (object.Equals(第一排中列, value))
                        第一排中列 = null;
                    if (object.Equals(第一排前列, value))
                        第一排前列 = null;
                    if (object.Equals(第二排前列, value))
                        第二排前列 = null;
                    if (object.Equals(第二排中列, value))
                        第二排中列 = null;
                    if (object.Equals(第二排后列, value))
                        第二排后列 = null;
                    if (object.Equals(第三排前列, value))
                        第三排前列 = null;
                    if (object.Equals(第三排中列, value))
                        第三排中列 = null;
                    if (object.Equals(第三排后列, value))
                        第三排后列 = null;

                    isInnerSetting = false;
                }
            }
        }

        private Role _第二排前列;
        public Role 第二排前列
        {
            get
            {
                return _第二排前列;
            }
            set
            {
                if (_第二排前列 != value)
                {
                    _第二排前列 = value;
                    SendPropertyChanged("第二排前列");
                    if (isInnerSetting)
                        return;
                    isInnerSetting = true;

                    if (object.Equals(第一排前列, value))
                        第一排前列 = null;
                    if (object.Equals(第一排中列, value))
                        第一排中列 = null;
                    if (object.Equals(第一排后列, value))
                        第一排后列 = null;
                    if (object.Equals(第二排中列, value))
                        第二排中列 = null;
                    if (object.Equals(第二排后列, value))
                        第二排后列 = null;
                    if (object.Equals(第三排前列, value))
                        第三排前列 = null;
                    if (object.Equals(第三排中列, value))
                        第三排中列 = null;
                    if (object.Equals(第三排后列, value))
                        第三排后列 = null;

                    isInnerSetting = false;
                }
            }
        }

        private Role _第二排中列;
        public Role 第二排中列
        {
            get
            {
                return _第二排中列;
            }
            set
            {
                if (_第二排中列 != value)
                {
                    _第二排中列 = value;
                    SendPropertyChanged("第二排中列");
                    if (isInnerSetting)
                        return;
                    isInnerSetting = true;

                    if (object.Equals(第一排前列, value))
                        第一排前列 = null;
                    if (object.Equals(第一排中列, value))
                        第一排中列 = null;
                    if (object.Equals(第一排后列, value))
                        第一排后列 = null;
                    if (object.Equals(第二排前列, value))
                        第二排前列 = null;
                    if (object.Equals(第二排后列, value))
                        第二排后列 = null;
                    if (object.Equals(第三排前列, value))
                        第三排前列 = null;
                    if (object.Equals(第三排中列, value))
                        第三排中列 = null;
                    if (object.Equals(第三排后列, value))
                        第三排后列 = null;

                    isInnerSetting = false;
                }
            }
        }

        private Role _第二排后列;
        public Role 第二排后列
        {
            get
            {
                return _第二排后列;
            }
            set
            {
                if (_第二排后列 != value)
                {
                    _第二排后列 = value;
                    SendPropertyChanged("第二排后列");
                    if (isInnerSetting)
                        return;
                    isInnerSetting = true;

                    if (object.Equals(第一排中列, value))
                        第一排中列 = null;
                    if (object.Equals(第一排前列, value))
                        第一排前列 = null;
                    if (object.Equals(第一排后列, value))
                        第一排后列 = null;
                    if (object.Equals(第二排前列, value))
                        第二排前列 = null;
                    if (object.Equals(第二排中列, value))
                        第二排中列 = null;
                    if (object.Equals(第三排前列, value))
                        第三排前列 = null;
                    if (object.Equals(第三排中列, value))
                        第三排中列 = null;
                    if (object.Equals(第三排后列, value))
                        第三排后列 = null;

                    isInnerSetting = false;
                }
            }
        }

        private Role _第三排前列;
        public Role 第三排前列
        {
            get
            {
                return _第三排前列;
            }
            set
            {
                if (_第三排前列 != value)
                {
                    _第三排前列 = value;
                    SendPropertyChanged("第三排前列");
                    if (isInnerSetting)
                        return;
                    isInnerSetting = true;

                    if (object.Equals(第一排前列, value))
                        第一排前列 = null;
                    if (object.Equals(第一排中列, value))
                        第一排中列 = null;
                    if (object.Equals(第一排后列, value))
                        第一排后列 = null;
                    if (object.Equals(第二排前列, value))
                        第二排前列 = null;
                    if (object.Equals(第二排中列, value))
                        第二排中列 = null;
                    if (object.Equals(第二排后列, value))
                        第二排后列 = null;
                    if (object.Equals(第三排中列, value))
                        第三排中列 = null;
                    if (object.Equals(第三排后列, value))
                        第三排后列 = null;

                    isInnerSetting = false;
                }
            }
        }

        private Role _第三排中列;
        public Role 第三排中列
        {
            get
            {
                return _第三排中列;
            }
            set
            {
                if (_第三排中列 != value)
                {
                    _第三排中列 = value;
                    SendPropertyChanged("第三排中列");
                    if (isInnerSetting)
                        return;
                    isInnerSetting = true;

                    if (object.Equals(第一排前列, value))
                        第一排前列 = null;
                    if (object.Equals(第一排中列, value))
                        第一排中列 = null;
                    if (object.Equals(第一排后列, value))
                        第一排后列 = null;
                    if (object.Equals(第二排前列, value))
                        第二排前列 = null;
                    if (object.Equals(第二排中列, value))
                        第二排中列 = null;
                    if (object.Equals(第二排后列, value))
                        第二排后列 = null;
                    if (object.Equals(第三排前列, value))
                        第三排前列 = null;
                    if (object.Equals(第三排后列, value))
                        第三排后列 = null;

                    isInnerSetting = false;
                }
            }
        }

        private Role _第三排后列;
        public Role 第三排后列
        {
            get
            {
                return _第三排后列;
            }
            set
            {
                if (_第三排后列 != value)
                {
                    _第三排后列 = value;
                    SendPropertyChanged("第三排后列");
                    if (isInnerSetting)
                        return;
                    isInnerSetting = true;

                    if (object.Equals(第一排中列, value))
                        第一排中列 = null;
                    if (object.Equals(第一排前列, value))
                        第一排前列 = null;
                    if (object.Equals(第一排后列, value))
                        第一排后列 = null;
                    if (object.Equals(第二排前列, value))
                        第二排前列 = null;
                    if (object.Equals(第二排中列, value))
                        第二排中列 = null;
                    if (object.Equals(第二排后列, value))
                        第二排后列 = null;
                    if (object.Equals(第三排前列, value))
                        第三排前列 = null;
                    if (object.Equals(第三排中列, value))
                        第三排中列 = null;

                    isInnerSetting = false;
                }
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
