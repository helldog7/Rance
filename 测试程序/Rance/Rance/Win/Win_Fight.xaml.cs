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
                    ui角色.技能List.Add(new UI技能() { Name = 角色.基础攻击技能.Name, 行动点 = 角色.基础攻击技能.消耗行动点 });
                if (角色.技能1 != null)
                    ui角色.技能List.Add(new UI技能() { Name = 角色.技能1.Name, 行动点 = 角色.技能1.消耗行动点 });
                if (角色.技能2 != null)
                    ui角色.技能List.Add(new UI技能() { Name = 角色.技能2.Name, 行动点 = 角色.技能2.消耗行动点 });
                if (角色.待机 != null)
                    ui角色.技能List.Add(new UI技能() { Name = 角色.待机.Name, 行动点 = 角色.待机.消耗行动点 });

                copy(角色, ui角色);
                UI战斗.TeamAList.Add(ui角色);
            }

            foreach (var 角色 in 战场.敌方角色List)
            {
                UI角色 ui角色 = new UI角色();
                ui角色.角色 = 角色;
                ui角色.UI战斗 = UI战斗;
                ui角色.Name = 角色.Name;
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
                    ui角色.技能List.Add(new UI技能() { Name = 角色.基础攻击技能.Name, 行动点 = 角色.基础攻击技能.消耗行动点 });
                if (角色.技能1 != null)
                    ui角色.技能List.Add(new UI技能() { Name = 角色.技能1.Name, 行动点 = 角色.技能1.消耗行动点 });
                if (角色.技能2 != null)
                    ui角色.技能List.Add(new UI技能() { Name = 角色.技能2.Name, 行动点 = 角色.技能2.消耗行动点 });
                if (角色.待机 != null)
                    ui角色.技能List.Add(new UI技能() { Name = 角色.待机.Name, 行动点 = 角色.待机.消耗行动点 });

                copy(角色, ui角色);
                UI战斗.TeamBList.Add(ui角色);
            }

            UI战斗.行动顺序 = new UI行动顺序();
            copy(战场.行动顺序, UI战斗.行动顺序);

            return UI战斗;
        }

        private void copy(战场 战场, UI战斗 UI战斗)
        {
            UI战斗.当前回合 = 战场.当前回合;
            UI战斗.战果 = 战场.战果;
            UI战斗.战场修正 = 战场.战场修正;
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

        private void copy(行动顺序 行动顺序, UI行动顺序 UI行动顺序)
        {
            if (行动顺序.List.Count>0)
                UI行动顺序.行动者1 = new UI角色() { Name = 行动顺序.List[0].Name, IsTeamA = 行动顺序.List[0].IsTeamA };
            else
                UI行动顺序.行动者1 = null;

            if (行动顺序.List.Count > 1)
                UI行动顺序.行动者2 = new UI角色() { Name = 行动顺序.List[1].Name, IsTeamA = 行动顺序.List[1].IsTeamA };
            else
                UI行动顺序.行动者2 = null;

            if (行动顺序.List.Count > 2)
                UI行动顺序.行动者3 = new UI角色() { Name = 行动顺序.List[2].Name, IsTeamA = 行动顺序.List[2].IsTeamA };
            else
                UI行动顺序.行动者3 = null;

            if (行动顺序.List.Count > 3)
                UI行动顺序.行动者4 = new UI角色() { Name = 行动顺序.List[3].Name, IsTeamA = 行动顺序.List[3].IsTeamA };
            else
                UI行动顺序.行动者4 = null;

            if (行动顺序.List.Count > 4)
                UI行动顺序.行动者5 = new UI角色() { Name = 行动顺序.List[4].Name, IsTeamA = 行动顺序.List[4].IsTeamA };
            else
                UI行动顺序.行动者5 = null;

            if (行动顺序.List.Count > 5)
                UI行动顺序.行动者6 = new UI角色() { Name = 行动顺序.List[5].Name, IsTeamA = 行动顺序.List[5].IsTeamA };
            else
                UI行动顺序.行动者6 = null;

        }
    }
}
