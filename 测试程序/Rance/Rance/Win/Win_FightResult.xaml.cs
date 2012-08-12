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
using System.Windows.Shapes;
using Rance.Battle;

namespace Rance
{
    /// <summary>
    /// Win_FightResult.xaml 的交互逻辑
    /// </summary>
    public partial class Win_FightResult : Window
    {
        public Win_Fight Win_Fight;
        public UI战斗 UI战斗;
        public 战斗结果 战斗结果 
        {
            set 
            {
                this.DataContext = value;
                if (value.Win)
                    lbl_Winner.Content = string.Format("红方 {0}", UI战斗.TeamA);
                else
                    lbl_Winner.Content = string.Format("蓝方 {0}", UI战斗.TeamB);

                for (int i = 0; i < value.角色List.Count; i++)
                {
                    lstResult.Items.Add(string.Format("{0} 回复 {1} 兵力", value.角色List[i].Name, value.回复兵力List[i]));
                }
            }
        }

        public Win_FightResult()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Win_Fight.Close();
        }
    }
}
