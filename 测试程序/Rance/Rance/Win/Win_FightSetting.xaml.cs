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
    /// FightSetting.xaml 的交互逻辑
    /// </summary>
    public partial class FightSetting : Window
    {
        private UIFightSetting uiFightSetting = new UIFightSetting();

        public FightSetting()
        {
            InitializeComponent();

            RanceEntities entities = new RanceEntities();
            var list = (from t in entities.Team
                        orderby t.Name
                        select t).ToList();
            this.cmbTeamA.ItemsSource = this.cmbTeamB.ItemsSource = list;
            this.cmbType.ItemsSource = new List<战地类型>() { 战地类型.野战, 战地类型.进攻_山寨, 战地类型.进攻_小镇, 战地类型.进攻_城市, 战地类型.防守_山寨, 战地类型.防守_小镇, 战地类型.防守_城市 };
            this.DataContext = uiFightSetting;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (uiFightSetting.TeamA == null)
            {
                MessageBox.Show("请选择队伍1");
                return;
            }
            if (uiFightSetting.TeamB == null)
            {
                MessageBox.Show("请选择队伍2");
                return;
            }
            //if (uiFightSetting.Type == null)
            //{
            //    MessageBox.Show("请选择战场类型");
            //    return;
            //}

            Win_Fight win = new Win_Fight(uiFightSetting);
            win.ShowDialog();
        }
    }
}
