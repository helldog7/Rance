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
        public Us_Role()
        {
            InitializeComponent();
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (DataContext != null)
                this.mainGrid.Visibility = System.Windows.Visibility.Visible;
            else
                this.mainGrid.Visibility = System.Windows.Visibility.Hidden;
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            if (DataContext != null)
            {
                UI角色 ui角色 = (UI角色)DataContext;
                ui角色.UI战斗.Select角色 = ui角色;
            }
        }
    }
}
