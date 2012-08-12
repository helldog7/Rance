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

namespace Rance.View
{
    /// <summary>
    /// UI_RoleInfo.xaml 的交互逻辑
    /// </summary>
    public partial class UI_RoleInfo : UserControl
    {
        public UI_RoleInfo()
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
    }
}
