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
using System.Collections.ObjectModel;

namespace Rance
{
    /// <summary>
    /// TeamMgt.xaml 的交互逻辑
    /// </summary>
    public partial class TeamMgt : Window
    {
        public TeamMgt()
        {
            InitializeComponent();
            fresh();
        }

        private void fresh()
        {
            RanceEntities entites = new RanceEntities();
            var list = (from r in entites.Team
                        orderby r.Name
                        select r).ToList();
            this.grd_TeamMgt.ItemsSource = new ObservableCollection<Team>(list);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Team team = new Team();
            team.ID = Guid.NewGuid();
            Win_Team win = new Win_Team(team);

            RanceEntities entites = new RanceEntities();
            entites.Team.AddObject(team);
            if (win.ShowDialog() == true)
            {
                save(entites, team);
                fresh();
            }
        }

        private void save(RanceEntities entites, Team team) 
        {
            foreach (var item in team.TeamRole.ToArray())
                entites.DeleteObject(item);
            if (team.第一排前列 != null && team.第一排前列.ID != Guid.Empty)
            {
                TeamRole teamRole = new TeamRole()
                {
                    ID = Guid.NewGuid(),
                    RoleID = team.第一排前列.ID,
                    列 = 1,
                    排 = 1,
                    TeamID = team.ID,
                };
                entites.TeamRole.AddObject(teamRole);
            }
            if (team.第一排中列 != null && team.第一排中列.ID != Guid.Empty)
            {
                TeamRole teamRole = new TeamRole()
                {
                    ID = Guid.NewGuid(),
                    RoleID = team.第一排中列.ID,
                    列 = 2,
                    排 = 1,
                    TeamID = team.ID,
                };
                entites.TeamRole.AddObject(teamRole);
            }
            if (team.第一排后列 != null && team.第一排后列.ID != Guid.Empty)
            {
                TeamRole teamRole = new TeamRole()
                {
                    ID = Guid.NewGuid(),
                    RoleID = team.第一排后列.ID,
                    列 = 3,
                    排 = 1,
                    TeamID = team.ID,
                };
                entites.TeamRole.AddObject(teamRole);
            }
            if (team.第二排前列 != null && team.第二排前列.ID != Guid.Empty)
            {
                TeamRole teamRole = new TeamRole()
                {
                    ID = Guid.NewGuid(),
                    RoleID = team.第二排前列.ID,
                    列 = 1,
                    排 = 2,
                    TeamID = team.ID,
                };
                entites.TeamRole.AddObject(teamRole);
            }
            if (team.第二排中列 != null && team.第二排中列.ID != Guid.Empty)
            {
                TeamRole teamRole = new TeamRole()
                {
                    ID = Guid.NewGuid(),
                    RoleID = team.第二排中列.ID,
                    列 = 2,
                    排 = 2,
                    TeamID = team.ID,
                };
                entites.TeamRole.AddObject(teamRole);
            }
            if (team.第二排后列 != null && team.第二排后列.ID != Guid.Empty)
            {
                TeamRole teamRole = new TeamRole()
                {
                    ID = Guid.NewGuid(),
                    RoleID = team.第二排后列.ID,
                    列 = 3,
                    排 = 2,
                    TeamID = team.ID,
                };
                entites.TeamRole.AddObject(teamRole);
            }
            if (team.第三排前列 != null && team.第三排前列.ID != Guid.Empty)
            {
                TeamRole teamRole = new TeamRole()
                {
                    ID = Guid.NewGuid(),
                    RoleID = team.第三排前列.ID,
                    列 = 1,
                    排 = 3,
                    TeamID = team.ID,
                };
                entites.TeamRole.AddObject(teamRole);
            }
            if (team.第三排中列 != null && team.第三排中列.ID != Guid.Empty)
            {
                TeamRole teamRole = new TeamRole()
                {
                    ID = Guid.NewGuid(),
                    RoleID = team.第三排中列.ID,
                    列 = 2,
                    排 = 3,
                    TeamID = team.ID,
                };
                entites.TeamRole.AddObject(teamRole);
            }
            if (team.第三排后列 != null && team.第三排后列.ID != Guid.Empty)
            {
                TeamRole teamRole = new TeamRole()
                {
                    ID = Guid.NewGuid(),
                    RoleID = team.第三排后列.ID,
                    列 = 3,
                    排 = 3,
                    TeamID = team.ID,
                };
                entites.TeamRole.AddObject(teamRole);
            }
            entites.SaveChanges();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Team team = this.grd_TeamMgt.SelectedItem as Team;
            if (team != null)
            {
                RanceEntities entites = new RanceEntities();
                team = load(entites, team);

                Win_Team win = new Win_Team(team);
                if (win.ShowDialog() == true)
                {
                    save(entites, team);
                    fresh();
                }
            }
        }

        private Team load(RanceEntities entites, Team team) 
        {
            team = (from t in entites.Team
                    where t.ID == team.ID
                    select t).SingleOrDefault();

            foreach (var item in team.TeamRole)
            {
                if (item.排 == 1 && item.列 == 1)
                    team.第一排前列 = item.Role;
                if (item.排 == 1 && item.列 == 2)
                    team.第一排中列 = item.Role;
                if (item.排 == 1 && item.列 == 3)
                    team.第一排后列 = item.Role;
                if (item.排 == 2 && item.列 == 1)
                    team.第二排前列 = item.Role;
                if (item.排 == 2 && item.列 == 2)
                    team.第二排中列 = item.Role;
                if (item.排 == 2 && item.列 == 3)
                    team.第二排后列 = item.Role;
                if (item.排 == 3 && item.列 == 1)
                    team.第三排前列 = item.Role;
                if (item.排 == 3 && item.列 == 2)
                    team.第三排中列 = item.Role;
                if (item.排 == 3 && item.列 == 3)
                    team.第三排后列 = item.Role;
            }
            return team;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Team team = this.grd_TeamMgt.SelectedItem as Team;
            if (team != null)
            {
                RanceEntities entites = new RanceEntities();
                team = (from r in entites.Team
                        where r.ID == team.ID
                        select r).SingleOrDefault();

                foreach (var item in team.TeamRole.ToArray())
                    entites.DeleteObject(item);

                entites.DeleteObject(team);

                entites.SaveChanges();
                fresh();
            }
        }
    }
}
