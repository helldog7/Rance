using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rance
{
    /// <summary>
    /// Us_Role.xaml 的交互逻辑
    /// </summary>
    public partial class Us_Role : UserControl
    {
        private UI角色 _角色;
        public UI角色 角色
        {
            get { return _角色; }
            set { _角色 = value; this.DataContext = value; }
        }
        public Us_Role()
        {
            InitializeComponent();
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (DataContext != null)
                this.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
