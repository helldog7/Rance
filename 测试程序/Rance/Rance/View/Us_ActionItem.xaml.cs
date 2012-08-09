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
    /// Us_ActionItem.xaml 的交互逻辑
    /// </summary>
    public partial class Us_ActionItem : UserControl
    {
        public Us_ActionItem()
        {
            InitializeComponent();
        }

        private UI角色 _角色;
        public UI角色 角色
        {
            get { return _角色; }
            set
            {
                _角色 = value;
                if (_角色 == null)
                {
                    this.Visibility = System.Windows.Visibility.Collapsed;
                }
                else
                {
                    this.Visibility = System.Windows.Visibility.Visible;
                    if (_角色.IsTeamA)
                        this.Background = new SolidColorBrush(Colors.Red);
                    else
                        this.Background = new SolidColorBrush(Colors.Blue);

                    this.DataContext = value;
                }
            }
        }
    }
}
