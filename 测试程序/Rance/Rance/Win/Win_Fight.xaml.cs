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
    /// Win_Fight.xaml 的交互逻辑
    /// </summary>
    public partial class Win_Fight : Window
    {
        private 战斗管理 战斗管理;
        private UI战斗 UI战斗;
        public Win_Fight(UIFightSetting setting)
        {
            InitializeComponent();

            战斗管理 = new 战斗管理();
            战斗管理.Init(convert(setting.TeamA), convert(setting.TeamB), setting.Type);
            UI战斗 = create(战斗管理.Get战场(true));
            set行动者();
            this.DataContext = UI战斗;
        }

        private 队伍 convert(Team team)
        {
            队伍 队伍 = new 队伍();
            队伍.Name = team.Name;
            队伍.成员List = new List<角色>();
            foreach (var item in team.TeamRole)
            {
                Role role = item.Role;
                角色 角色 = 战斗管理.Create(role.Name.Trim(), role.兵种.Trim(), role.攻, role.防, role.智, role.速, role.行动点, role.兵力, role.兵力, item.排, item.列, role.基础攻击技能, role.技能1, role.技能2, role.被动技能, role.特殊技能);
                队伍.成员List.Add(角色);
            }

            return 队伍;
        }

        private UI战斗 create(战场 战场)
        {
            UI战斗 UI战斗 = new UI战斗();
            UI战斗.最大回合数 = 战场.最大回合数;
            UI战斗.TeamA = 战场.己方队伍名称;
            UI战斗.TeamB = 战场.敌方队伍名称;
            UI战斗.TeamAList = new List<UI角色>();
            UI战斗.TeamBList = new List<UI角色>();

            copy(战场, UI战斗);

            foreach (var 角色 in 战场.己方角色List)
            {
                UI角色 ui角色 = new UI角色();
                ui角色.角色 = 角色;
                ui角色.UI战斗 = UI战斗;
                ui角色.Name = 角色.Name;
                ui角色.兵种 = 角色.兵种.Name;
                ui角色.IsTeamA = true;
                ui角色.攻 = 角色.攻;
                ui角色.防 = 角色.防;
                ui角色.智 = 角色.智;
                ui角色.速 = 角色.速;
                ui角色.排 = 角色.排;
                ui角色.列 = 角色.列;
                if (角色.排 == 1 && 角色.列 == 1)
                    UI战斗.TeamA_1_1 = ui角色;
                else if (角色.排 == 1 && 角色.列 == 2)
                    UI战斗.TeamA_2_1 = ui角色;
                else if (角色.排 == 1 && 角色.列 == 3)
                    UI战斗.TeamA_3_1 = ui角色;
                else if (角色.排 == 2 && 角色.列 == 1)
                    UI战斗.TeamA_1_2 = ui角色;
                else if (角色.排 == 2 && 角色.列 == 2)
                    UI战斗.TeamA_2_2 = ui角色;
                else if (角色.排 == 2 && 角色.列 == 3)
                    UI战斗.TeamA_3_2 = ui角色;
                else if (角色.排 == 3 && 角色.列 == 1)
                    UI战斗.TeamA_1_3 = ui角色;
                else if (角色.排 == 3 && 角色.列 == 2)
                    UI战斗.TeamA_2_3 = ui角色;
                else if (角色.排 == 3 && 角色.列 == 3)
                    UI战斗.TeamA_3_3 = ui角色;

                ui角色.最大行动点 = 角色.最大行动点;
                ui角色.最大兵力 = 角色.最大兵力;

                if (角色.基础攻击技能 != null)
                    ui角色.技能List.Add(new UI技能() { Name = 角色.基础攻击技能.Name, 行动点 = 角色.基础攻击技能.消耗行动点, 技能目标 = 角色.基础攻击技能.技能目标 });
                if (角色.技能1 != null)
                    ui角色.技能List.Add(new UI技能() { Name = 角色.技能1.Name, 行动点 = 角色.技能1.消耗行动点, 技能目标 = 角色.技能1.技能目标 });
                if (角色.技能2 != null)
                    ui角色.技能List.Add(new UI技能() { Name = 角色.技能2.Name, 行动点 = 角色.技能2.消耗行动点, 技能目标 = 角色.技能2.技能目标 });
                if (角色.待机 != null)
                    ui角色.技能List.Add(new UI技能() { Name = 角色.待机.Name, 行动点 = 角色.待机.消耗行动点, 技能目标 = 角色.待机.技能目标 });

                copy(角色, ui角色);
                UI战斗.TeamAList.Add(ui角色);
            }

            foreach (var 角色 in 战场.敌方角色List)
            {
                UI角色 ui角色 = new UI角色();
                ui角色.角色 = 角色;
                ui角色.UI战斗 = UI战斗;
                ui角色.Name = 角色.Name;
                ui角色.兵种 = 角色.兵种.Name;
                ui角色.IsTeamA = false;
                ui角色.攻 = 角色.攻;
                ui角色.防 = 角色.防;
                ui角色.智 = 角色.智;
                ui角色.速 = 角色.速;
                ui角色.排 = 角色.排;
                ui角色.列 = 角色.列;
                if (角色.排 == 1 && 角色.列 == 1)
                    UI战斗.TeamB_1_1 = ui角色;
                else if (角色.排 == 1 && 角色.列 == 2)
                    UI战斗.TeamB_2_1 = ui角色;
                else if (角色.排 == 1 && 角色.列 == 3)
                    UI战斗.TeamB_3_1 = ui角色;
                else if (角色.排 == 2 && 角色.列 == 1)
                    UI战斗.TeamB_1_2 = ui角色;
                else if (角色.排 == 2 && 角色.列 == 2)
                    UI战斗.TeamB_2_2 = ui角色;
                else if (角色.排 == 2 && 角色.列 == 3)
                    UI战斗.TeamB_3_2 = ui角色;
                else if (角色.排 == 3 && 角色.列 == 1)
                    UI战斗.TeamB_1_3 = ui角色;
                else if (角色.排 == 3 && 角色.列 == 2)
                    UI战斗.TeamB_2_3 = ui角色;
                else if (角色.排 == 3 && 角色.列 == 3)
                    UI战斗.TeamB_3_3 = ui角色;

                ui角色.最大行动点 = 角色.最大行动点;
                ui角色.最大兵力 = 角色.最大兵力;

                if (角色.基础攻击技能 != null)
                    ui角色.技能List.Add(new UI技能() { Name = 角色.基础攻击技能.Name, 行动点 = 角色.基础攻击技能.消耗行动点, 技能目标 = 角色.基础攻击技能.技能目标 });
                if (角色.技能1 != null)
                    ui角色.技能List.Add(new UI技能() { Name = 角色.技能1.Name, 行动点 = 角色.技能1.消耗行动点, 技能目标 = 角色.技能1.技能目标 });
                if (角色.技能2 != null)
                    ui角色.技能List.Add(new UI技能() { Name = 角色.技能2.Name, 行动点 = 角色.技能2.消耗行动点, 技能目标 = 角色.技能2.技能目标 });
                if (角色.待机 != null)
                    ui角色.技能List.Add(new UI技能() { Name = 角色.待机.Name, 行动点 = 角色.待机.消耗行动点, 技能目标 = 角色.待机.技能目标 });

                copy(角色, ui角色);
                UI战斗.TeamBList.Add(ui角色);
            }

            UI战斗.行动顺序 = new UI行动顺序();
            copy(战场.行动顺序, UI战斗.行动顺序, UI战斗);

            return UI战斗;
        }

        private void set行动者()
        {
            IsSkilling = false;
            foreach(var 角色 in UI战斗.TeamAList)
                角色.行动中 = false;
            foreach (var 角色 in UI战斗.TeamBList)
                角色.行动中 = false;

            UI战斗.Current角色 = UI战斗.行动顺序.行动者1;
            UI战斗.Current角色.行动中 = true;

            btn取消.Visibility = System.Windows.Visibility.Hidden;

            if (UI战斗.Current角色.技能List.Count > 0)
            {
                btn技能1.Content = UI战斗.Current角色.技能List[0].ToString();
                btn技能1.DataContext = UI战斗.Current角色.技能List[0];
                btn技能1.IsEnabled = true;
                btn技能1.Visibility = System.Windows.Visibility.Visible;

                if (UI战斗.Current角色.技能List.Count > 1)
                {
                    btn技能2.Content = UI战斗.Current角色.技能List[1].ToString();
                    btn技能2.DataContext = UI战斗.Current角色.技能List[1];
                    btn技能2.IsEnabled = true;
                    btn技能2.Visibility = System.Windows.Visibility.Visible;

                    if (UI战斗.Current角色.技能List.Count > 2)
                    {
                        btn技能3.Content = UI战斗.Current角色.技能List[2].ToString();
                        btn技能3.DataContext = UI战斗.Current角色.技能List[2];
                        btn技能3.IsEnabled = true;
                        btn技能3.Visibility = System.Windows.Visibility.Visible;

                        if (UI战斗.Current角色.技能List.Count > 3)
                        {
                            btn技能4.Content = UI战斗.Current角色.技能List[3].ToString();
                            btn技能4.DataContext = UI战斗.Current角色.技能List[3];
                            btn技能4.IsEnabled = true;
                            btn技能4.Visibility = System.Windows.Visibility.Visible;
                        }
                        else
                        {
                            btn技能4.Visibility = System.Windows.Visibility.Hidden;

                            btn技能4.DataContext = null;
                        }
                    }
                    else
                    {
                        btn技能3.Visibility = System.Windows.Visibility.Hidden;
                        btn技能4.Visibility = System.Windows.Visibility.Hidden;

                        btn技能3.DataContext = null;
                        btn技能4.DataContext = null;
                    }
                }
                else
                {
                    btn技能2.Visibility = System.Windows.Visibility.Hidden;
                    btn技能3.Visibility = System.Windows.Visibility.Hidden;
                    btn技能4.Visibility = System.Windows.Visibility.Hidden;

                    btn技能2.DataContext = null;
                    btn技能3.DataContext = null;
                    btn技能4.DataContext = null;
                }
            }
            else
            {
                btn技能1.Visibility = System.Windows.Visibility.Hidden;
                btn技能2.Visibility = System.Windows.Visibility.Hidden;
                btn技能3.Visibility = System.Windows.Visibility.Hidden;
                btn技能4.Visibility = System.Windows.Visibility.Hidden;

                btn技能1.DataContext = null;
                btn技能2.DataContext = null;
                btn技能3.DataContext = null;
                btn技能4.DataContext = null;
            }
        }

        private void copy(战场 战场, UI战斗 UI战斗)
        {
            UI战斗.当前回合 = 战场.当前回合;
            UI战斗.战果 = 战场.战果;
            UI战斗.战场修正 = 战场.战场修正;
            UI战斗.是否结束 = 战场.IsEnd;
        }

        private void copy(角色 角色, UI角色 ui角色)
        {
            ui角色.败退 = 角色.是否败走;
            ui角色.兵力 = 角色.兵力;
            ui角色.攻赋予 = 角色.攻击赋予 != null;
            ui角色.防赋予 = 角色.防御赋予 != null;
            ui角色.速赋予 = 角色.速度赋予 != null;
            ui角色.智赋予 = 角色.智力赋予 != null;
            ui角色.行动点 = 角色.行动点;
            ui角色.守护率 = 角色.守护率;
            ui角色.全体守护率 = 角色.全体守护率;
            ui角色.护盾 = 角色.护盾;
            ui角色.准备 = 角色.是否准备;
        }

        private void copy(行动顺序 行动顺序, UI行动顺序 UI行动顺序, UI战斗 ui战斗)
        {
            if (行动顺序.List.Count > 0)
            {
                if (行动顺序.List[0].IsTeamA)
                    UI行动顺序.行动者1 = ui战斗.TeamAList.SingleOrDefault(m => m.角色 == 行动顺序.List[0]);
                else
                    UI行动顺序.行动者1 = ui战斗.TeamBList.SingleOrDefault(m => m.角色 == 行动顺序.List[0]);
            }
            else
                UI行动顺序.行动者1 = null;

            if (行动顺序.List.Count > 1)
            {
                if (行动顺序.List[1].IsTeamA)
                    UI行动顺序.行动者2 = ui战斗.TeamAList.SingleOrDefault(m => m.角色 == 行动顺序.List[1]);
                else
                    UI行动顺序.行动者2 = ui战斗.TeamBList.SingleOrDefault(m => m.角色 == 行动顺序.List[1]);
            }
            else
                UI行动顺序.行动者2 = null;

            if (行动顺序.List.Count > 2)
            {
                if (行动顺序.List[2].IsTeamA)
                    UI行动顺序.行动者3 = ui战斗.TeamAList.SingleOrDefault(m => m.角色 == 行动顺序.List[2]);
                else
                    UI行动顺序.行动者3 = ui战斗.TeamBList.SingleOrDefault(m => m.角色 == 行动顺序.List[2]);
            }
            else
                UI行动顺序.行动者3 = null;

            if (行动顺序.List.Count > 3)
            {
                if (行动顺序.List[3].IsTeamA)
                    UI行动顺序.行动者4 = ui战斗.TeamAList.SingleOrDefault(m => m.角色 == 行动顺序.List[3]);
                else
                    UI行动顺序.行动者4 = ui战斗.TeamBList.SingleOrDefault(m => m.角色 == 行动顺序.List[3]);
            }
            else
                UI行动顺序.行动者4 = null;

            if (行动顺序.List.Count > 4)
            {
                if (行动顺序.List[4].IsTeamA)
                    UI行动顺序.行动者5 = ui战斗.TeamAList.SingleOrDefault(m => m.角色 == 行动顺序.List[4]);
                else
                    UI行动顺序.行动者5 = ui战斗.TeamBList.SingleOrDefault(m => m.角色 == 行动顺序.List[4]);
            }
            else
                UI行动顺序.行动者5 = null;

            if (行动顺序.List.Count > 5)
            {
                if (行动顺序.List[5].IsTeamA)
                    UI行动顺序.行动者6 = ui战斗.TeamAList.SingleOrDefault(m => m.角色 == 行动顺序.List[5]);
                else
                    UI行动顺序.行动者6 = ui战斗.TeamBList.SingleOrDefault(m => m.角色 == 行动顺序.List[5]);
            }
            else
                UI行动顺序.行动者6 = null;

        }

        private bool IsSkilling = false;
        private UI技能 current技能;

        private void btn技能_Click(object sender, RoutedEventArgs e)
        {
            if (IsSkilling)
                return;
            IsSkilling = true;
            Button button = (Button)e.Source;
            current技能 = (UI技能)button.DataContext;

            if (btn技能1 != button)
                btn技能1.IsEnabled = false;
            if (btn技能2 != button)
                btn技能2.IsEnabled = false;
            if (btn技能3 != button)
                btn技能3.IsEnabled = false;
            if (btn技能4 != button)
                btn技能4.IsEnabled = false;

            btn取消.Visibility = System.Windows.Visibility.Visible;
        }

        private void btn取消_Click(object sender, RoutedEventArgs e)
        {
            IsSkilling = false;
            if (btn技能1.DataContext != null)
                btn技能1.IsEnabled = true;
            if (btn技能2.DataContext != null)
                btn技能2.IsEnabled = true;
            if (btn技能3.DataContext != null)
                btn技能3.IsEnabled = true;
            if (btn技能4.DataContext != null)
                btn技能4.IsEnabled = true;

            btn取消.Visibility = System.Windows.Visibility.Hidden;
        }

        private void us_Role_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!IsSkilling)
                return;
            Us_Role usRole = (Us_Role)e.Source;
            if (usRole.DataContext == null)
                return;
            UI角色 角色 = (UI角色)usRole.DataContext;
            if (角色.败退)
                return;

            if (UI战斗.Current角色.IsTeamA)
                teamA选择(角色);
            else
                teamB选择(角色);
        }

        private void teamA选择(UI角色 角色)
        {
            switch (current技能.技能目标)
            {
                case 技能目标.全体任一:
                    if (!角色.IsTeamA)
                        角色.选择中 = true;
                    break;
                case 技能目标.全体:
                    if (!角色.IsTeamA)
                    {
                        foreach (var item in UI战斗.TeamBList)
                            if (!item.败退)
                                item.选择中 = true;
                    }
                    break;
                case 技能目标.最前列任一:
                    if (!角色.IsTeamA)
                    {
                        if (角色.列 == 1)
                            角色.选择中 = true;
                        else if (角色.列 == 2)
                        {
                            if ((UI战斗.TeamB_1_1 == null || UI战斗.TeamB_1_1.败退) &&
                                (UI战斗.TeamB_2_1 == null || UI战斗.TeamB_2_1.败退) &&
                                (UI战斗.TeamB_3_1 == null || UI战斗.TeamB_3_1.败退))
                                角色.选择中 = true;
                        }
                        else
                        {
                            if ((UI战斗.TeamB_1_1 == null || UI战斗.TeamB_1_1.败退) &&
                                (UI战斗.TeamB_2_1 == null || UI战斗.TeamB_2_1.败退) &&
                                (UI战斗.TeamB_3_1 == null || UI战斗.TeamB_3_1.败退) &&
                                (UI战斗.TeamB_1_2 == null || UI战斗.TeamB_1_2.败退) &&
                                (UI战斗.TeamB_2_2 == null || UI战斗.TeamB_2_2.败退) &&
                                (UI战斗.TeamB_3_2 == null || UI战斗.TeamB_3_2.败退))
                                角色.选择中 = true;
                        }
                    }
                    break;
                case 技能目标.同排最前列:
                    if (!角色.IsTeamA)
                    {
                        var temp = (from u in UI战斗.TeamBList
                                    where u.排 == UI战斗.Current角色.排 &&
                                          !u.败退
                                    orderby u.列
                                    select u).FirstOrDefault();
                        if (角色 == temp)
                            角色.选择中 = true;
                    }
                    break;
                case 技能目标.同排全体:
                    if (!角色.IsTeamA && 角色.排 == UI战斗.Current角色.排)
                    {
                        var list = (from u in UI战斗.TeamBList
                                    where u.排 == UI战斗.Current角色.排 &&
                                          !u.败退
                                    select u).ToList();

                        foreach (var item in list)
                            item.选择中 = true;
                    }
                    break;
                case 技能目标.同排任一:
                    if (!角色.IsTeamA && 角色.排 == UI战斗.Current角色.排)
                        角色.选择中 = true;
                    break;
                case 技能目标.一排全体:
                    if (!角色.IsTeamA)
                    {
                        var list = (from u in UI战斗.TeamBList
                                    where u.排 == 角色.排 &&
                                          !u.败退
                                    select u).ToList();

                        foreach (var item in list)
                            item.选择中 = true;
                    }
                    break;
                case 技能目标.后二列任一:
                    if (!角色.IsTeamA && 角色.列 > 1)
                        角色.选择中 = true;
                    break;
                case 技能目标.己方全体:
                    if (角色.IsTeamA)
                    {
                        foreach (var item in UI战斗.TeamAList)
                            if (!item.败退)
                                item.选择中 = true;
                    }
                    break;
                case 技能目标.己方任一:
                    if (角色.IsTeamA && !角色.败退)
                        角色.选择中 = true;
                    break;
                case 技能目标.自己:
                    if (角色.IsTeamA)
                        UI战斗.Current角色.选择中 = true;
                    break;
            }
        }

        private void teamB选择(UI角色 角色)
        {
            switch (current技能.技能目标)
            {
                case 技能目标.全体任一:
                    if (角色.IsTeamA)
                        角色.选择中 = true;
                    break;
                case 技能目标.全体:
                    if (角色.IsTeamA)
                    {
                        foreach (var item in UI战斗.TeamAList)
                            if (!item.败退)
                                item.选择中 = true;
                    }
                    break;
                case 技能目标.最前列任一:
                    if (角色.IsTeamA)
                    {
                        if (角色.列 == 1)
                            角色.选择中 = true;
                        else if (角色.列 == 2)
                        {
                            if ((UI战斗.TeamA_1_1 == null || UI战斗.TeamA_1_1.败退) &&
                                (UI战斗.TeamA_2_1 == null || UI战斗.TeamA_2_1.败退) &&
                                (UI战斗.TeamA_3_1 == null || UI战斗.TeamA_3_1.败退))
                                角色.选择中 = true;
                        }
                        else
                        {
                            if ((UI战斗.TeamA_1_1 == null || UI战斗.TeamA_1_1.败退) &&
                                (UI战斗.TeamA_2_1 == null || UI战斗.TeamA_2_1.败退) &&
                                (UI战斗.TeamA_3_1 == null || UI战斗.TeamA_3_1.败退) &&
                                (UI战斗.TeamA_1_2 == null || UI战斗.TeamA_1_2.败退) &&
                                (UI战斗.TeamA_2_2 == null || UI战斗.TeamA_2_2.败退) &&
                                (UI战斗.TeamA_3_2 == null || UI战斗.TeamA_3_2.败退))
                                角色.选择中 = true;
                        }
                    }
                    break;
                case 技能目标.同排最前列:
                    if (角色.IsTeamA)
                    {
                        var temp = (from u in UI战斗.TeamAList
                                    where u.排 == UI战斗.Current角色.排 &&
                                          !u.败退
                                    orderby u.列
                                    select u).FirstOrDefault();
                        if (角色 == temp)
                            角色.选择中 = true;
                    }
                    break;
                case 技能目标.同排全体:
                    if (角色.IsTeamA && 角色.排 == UI战斗.Current角色.排)
                    {
                        var list = (from u in UI战斗.TeamAList
                                    where u.排 == UI战斗.Current角色.排 &&
                                          !u.败退
                                    select u).ToList();

                        foreach (var item in list)
                            item.选择中 = true;
                    }
                    break;
                case 技能目标.同排任一:
                    if (角色.IsTeamA && 角色.排 == UI战斗.Current角色.排)
                        角色.选择中 = true;
                    break;
                case 技能目标.一排全体:
                    if (角色.IsTeamA)
                    {
                        var list = (from u in UI战斗.TeamBList
                                    where u.排 == 角色.排 &&
                                          !u.败退
                                    select u).ToList();

                        foreach (var item in list)
                            item.选择中 = true;
                    }
                    break;
                case 技能目标.后二列任一:
                    if (角色.IsTeamA && 角色.列 > 1)
                        角色.选择中 = true;
                    break;
                case 技能目标.己方全体:
                    if (!角色.IsTeamA)
                    {
                        foreach (var item in UI战斗.TeamBList)
                            if (!item.败退)
                                item.选择中 = true;
                    }
                    break;
                case 技能目标.己方任一:
                    if (!角色.IsTeamA && !角色.败退)
                        角色.选择中 = true;
                    break;
                case 技能目标.自己:
                    if (!角色.IsTeamA)
                        UI战斗.Current角色.选择中 = true;
                    break;
            }
        }

        private void us_Role_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsSkilling)
                return;

            List<角色> list = (from t in UI战斗.TeamAList
                             where !t.败退 && t.选择中
                             orderby t.列
                             select t.角色).ToList();

            list.AddRange((from t in UI战斗.TeamBList
                           where !t.败退 && t.选择中
                           orderby t.列
                           select t.角色));

            if (list.Count == 0)
                return;

            var result = 战斗管理.Action(UI战斗.Current角色.角色, current技能.Name, list);
            show(result);

            copy(战斗管理.Get战场(true), UI战斗);
            copy(战斗管理.Get战场(true).行动顺序, UI战斗.行动顺序, UI战斗);

            foreach (var 角色 in UI战斗.TeamAList)
            {
                copy(角色.角色, 角色);
                角色.选择中 = false;
            }
            foreach (var 角色 in UI战斗.TeamBList)
            {
                copy(角色.角色, 角色);
                角色.选择中 = false;
            }

            if (UI战斗.是否结束)
                end();
            else
            {
                var next角色 = 战斗管理.Get战场(true).行动顺序.List[0];
                if (next角色.准备技能 != null)
                {
                    result = 战斗管理.Action(next角色, next角色.准备技能.Name, next角色.准备技能.准备技能目标List);
                    show(result);

                    copy(战斗管理.Get战场(true), UI战斗);
                    copy(战斗管理.Get战场(true).行动顺序, UI战斗.行动顺序, UI战斗);

                    foreach (var 角色 in UI战斗.TeamAList)
                        copy(角色.角色, 角色);
                    foreach (var 角色 in UI战斗.TeamBList)
                        copy(角色.角色, 角色);
                }

                set行动者();
            }
        }

        private void end()
        {
            Win_FightResult win = new Win_FightResult();
            win.UI战斗 = UI战斗;
            win.Win_Fight = this;

            win.战斗结果 = 战斗管理.战斗结算()[0];
            win.ShowDialog();
        }

        private void show(List<ActionResult> result)
        {
            for (int i = result.Count - 1; i >= 0; i--)
                lstResult.Items.Insert(0,result[i].ToString());
        }

        private void us_Role_MouseLeave(object sender, MouseEventArgs e)
        {
            clear选择();
        }

        private void clear选择()
        {
            foreach (var 角色 in UI战斗.TeamAList)
                角色.选择中 = false;
            foreach (var 角色 in UI战斗.TeamBList)
                角色.选择中 = false;
        }

        
    }
}
