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

namespace Rance
{
    /// <summary>
    /// Win_Team.xaml 的交互逻辑
    /// </summary>
    public partial class Win_Team : Window
    {
        public Win_Team(Team team)
        {
            InitializeComponent();
            RanceEntities entites = new RanceEntities();
            var roleList = (from r in entites.Role
                            orderby r.Name
                            select r).ToList();
            this.cmb第二排后列.ItemsSource = this.cmb第二排前列.ItemsSource = this.cmb第二排中列.ItemsSource = this.cmb第三排后列.ItemsSource = this.cmb第三排中列.ItemsSource = this.cmb第三排前列.ItemsSource = this.cmb第一排后列.ItemsSource = this.cmb第一排前列.ItemsSource = this.cmb第一排中列.ItemsSource = roleList;

            Team = team;
            this.DataContext = team;
        }

        public Team Team { get; set; }

        private void btnCofirm_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
