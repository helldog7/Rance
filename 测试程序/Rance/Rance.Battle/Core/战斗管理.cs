using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rance.Tools;

namespace Rance.Battle
{
    public class 战斗管理
    {
        private 战场 teamA战场;

        public 战场 Get战场(bool isTeamA)
        {
            if (isTeamA)
                return teamA战场;
            else
                return teamA战场.反转();
        }

        public static 角色 Create(string name, string 兵种, int 攻, int 防, int 智, int 速, int 行动点, int 兵力, int 最大兵力, int 排, int 列, string 基础攻击技能, string 技能1, string 技能2, string 被动技能, string 特殊技能)
        {
            角色 角色 = new 角色()
            {
                Name = name,
                攻 = 攻,
                临时攻 = 攻,
                防 = 防,
                临时防 = 防,
                速 = 速,
                临时速 = 速,
                智 = 智,
                临时智 = 智,
                行动点 = 行动点,
                最大行动点 = 行动点,
                兵力 = 兵力,
                最大兵力 = 最大兵力,
                排 = 排,
                列 = 列
            };
            switch (兵种)
            {
                case "剑士":
                    角色.兵种 = Battle.兵种.剑士;
                    break;
                case "盾兵":
                    角色.兵种 = Battle.兵种.盾兵;
                    break;
                case "火枪":
                    角色.兵种 = Battle.兵种.火枪;
                    break;
                case "和尚":
                    角色.兵种 = Battle.兵种.和尚;
                    break;
                case "忍者":
                    角色.兵种 = Battle.兵种.忍者;
                    break;
                case "军师":
                    角色.兵种 = Battle.兵种.军师;
                    break;
                case "弓兵":
                    角色.兵种 = Battle.兵种.弓兵;
                    break;
                case "炮兵":
                    角色.兵种 = Battle.兵种.炮兵;
                    break;
                case "骑兵":
                    角色.兵种 = Battle.兵种.骑兵;
                    break;
                case "阴阳":
                    角色.兵种 = Battle.兵种.阴阳;
                    break;
                case "巫女":
                    角色.兵种 = Battle.兵种.巫女;
                    break;
            }

            if (!string.IsNullOrEmpty(基础攻击技能))
                角色.基础攻击技能 = create技能(基础攻击技能) as 主动技能;
            if (!string.IsNullOrEmpty(技能1))
                角色.技能1 = create技能(技能1) as 主动技能;
            if (!string.IsNullOrEmpty(技能2))
                角色.技能2 = create技能(技能2) as 主动技能;
            if (!string.IsNullOrEmpty(被动技能))
                角色.被动技能 = create技能(被动技能) as 被动技能;
            if (!string.IsNullOrEmpty(特殊技能))
                角色.特殊技能 = create技能(特殊技能) as 主动技能;

            角色.待机 = 待机.Instance;


            return 角色;
        }

        private static 技能 create技能(string 技能名)
        {
            Type type = Type.GetType("Rance.Battle." + 技能名);
            return MethodCaller.CreateInstance(type) as 技能;
        }

        public void Init(队伍 teamA, 队伍 teamB, 战地类型 战地类型)
        {
            teamA战场 = new 战场();
            teamA战场.当前回合 = 1;
            teamA战场.最大回合数 = 30;
            teamA战场.己方角色List = teamA.成员List;
            foreach (var 角色 in teamA.成员List)
                角色.IsTeamA = true;
            teamA战场.敌方角色List = teamB.成员List;
            foreach (var 角色 in teamB.成员List)
                角色.IsTeamA = false;
            teamA战场.己方队伍名称 = teamA.Name;
            teamA战场.敌方队伍名称 = teamB.Name;
            switch (战地类型)
            {
                case Battle.战地类型.野战:
                    teamA战场.战场修正 = 0;
                    teamA战场.战果 = 0;
                    break;
                case Battle.战地类型.防守_城市:
                    teamA战场.战场修正 = 20;
                    teamA战场.战果 = 500;
                    break;
                case Battle.战地类型.防守_小镇:
                    teamA战场.战场修正 = 12;
                    teamA战场.战果 = 200;
                    break;
                case Battle.战地类型.防守_山寨:
                    teamA战场.战场修正 = 4;
                    teamA战场.战果 = 0;
                    break;
                case Battle.战地类型.进攻_城市:
                    teamA战场.战场修正 = -20;
                    teamA战场.战果 = -500;
                    break;
                case Battle.战地类型.进攻_小镇:
                    teamA战场.战场修正 = -12;
                    teamA战场.战果 = -200;
                    break;
                case Battle.战地类型.进攻_山寨:
                    teamA战场.战场修正 = -4;
                    teamA战场.战果 = 0;
                    break;
            }

            List<角色> list = new List<角色>(teamA.成员List);
            list.AddRange(teamB.成员List);
            teamA战场.行动顺序 = new 行动顺序();
            teamA战场.行动顺序.初始化行动表(list);

            foreach (var 角色 in teamA战场.己方角色List)
            {
                if (角色.被动技能 != null && 角色.被动技能 is 战斗开始被动技能)
                {
                    战斗开始被动技能 战斗开始被动技能 = (战斗开始被动技能)角色.被动技能;
                    技能环境 技能环境 = createEnvironment(角色, true, new List<角色>() { 角色 });
                    战斗开始被动技能.Excute(技能环境);
                }

                if (角色.特殊技能 != null && 角色.特殊技能 is 战斗开始被动技能)
                {
                    战斗开始被动技能 战斗开始被动技能 = (战斗开始被动技能)角色.特殊技能;
                    技能环境 技能环境 = createEnvironment(角色, true, new List<角色>() { 角色 });
                    战斗开始被动技能.Excute(技能环境);
                }
            }

            foreach (var 角色 in teamA战场.敌方角色List)
            {
                if (角色.被动技能 != null && 角色.被动技能 is 战斗开始被动技能)
                {
                    战斗开始被动技能 战斗开始被动技能 = (战斗开始被动技能)角色.被动技能;
                    技能环境 技能环境 = createEnvironment(角色, false, new List<角色>() { 角色 });
                    战斗开始被动技能.Excute(技能环境);
                }

                if (角色.特殊技能 != null && 角色.特殊技能 is 战斗开始被动技能)
                {
                    战斗开始被动技能 战斗开始被动技能 = (战斗开始被动技能)角色.特殊技能;
                    技能环境 技能环境 = createEnvironment(角色, false, new List<角色>() { 角色 });
                    战斗开始被动技能.Excute(技能环境);
                }
            }
        }

        private 技能环境 createEnvironment(角色 施法者, bool isTeamA, List<角色> targetList)
        {
            技能环境 技能环境 = new 技能环境()
            {
                施放者 = 施法者,
                目标List = targetList,
                IsTeamA = isTeamA,
                战场 = isTeamA ? teamA战场 : teamA战场.反转()
            };

            return 技能环境;
        }

        public 行动者 GetNextRole()
        {
            if (this.teamA战场.IsEnd)
                throw new Exception("战斗已经结束");
            角色 角色 = this.teamA战场.行动顺序.List[0];
            行动者 行动者 = new 行动者()
            {
                角色 = 角色,
                IsTeamA = teamA战场.己方角色List.Contains(角色)
            };
            return 行动者;
        }

        public List<ActionResult> Action(角色 角色, string action, List<角色> targetList)
        {
            if (this.teamA战场.行动顺序.List[0] != 角色)
                throw new Exception("不是这个角色的行动轮");

            角色.临时攻 = 角色.攻;
            角色.临时防 = 角色.防;
            角色.临时速 = 角色.速;
            角色.临时智 = 角色.智;

            技能环境 技能环境 = createEnvironment(角色, teamA战场.己方角色List.Contains(角色), targetList);

            if (角色.基础攻击技能 != null && 角色.基础攻击技能.Name == action)
            {
                角色.基础攻击技能.Excute(技能环境);
                角色.行动点 -= 角色.基础攻击技能.消耗行动点;
            }
            if (角色.技能1 != null)
            {
                if (角色.技能1.Name == action)
                {
                    角色.技能1.Excute(技能环境);
                    角色.行动点 -= 角色.技能1.消耗行动点;
                }
                else if (角色.技能1 is 准备技能)
                {
                    准备技能 准备技能 = (准备技能)角色.技能1;
                    if (准备技能.准备后执行技能.Name == action)
                    {
                        准备技能.准备后执行技能.Excute(技能环境);

                        准备技能.准备技能目标List = null;
                        准备技能.准备后执行技能 = null;
                    }
                }
            }
            if (角色.技能2 != null)
            {
                if (角色.技能2.Name == action)
                {
                    角色.技能2.Excute(技能环境);
                    角色.行动点 -= 角色.技能2.消耗行动点;
                }
                else if (角色.技能2 is 准备技能)
                {
                    准备技能 准备技能 = (准备技能)角色.技能2;
                    if (准备技能.准备后执行技能.Name == action)
                    {
                        准备技能.准备后执行技能.Excute(技能环境);

                        准备技能.准备技能目标List = null;
                        准备技能.准备后执行技能 = null;
                    }
                }
            }
            if (角色.特殊技能 != null && 角色.特殊技能.Name == action)
            {
                if (角色.特殊技能 is 主动技能)
                {
                    主动技能 技能 = (主动技能)角色.特殊技能;
                    技能.Excute(技能环境);
                    角色.行动点 -= 技能.消耗行动点;
                }
            }
            if (action == "待机")
            {
                角色.待机.Excute(技能环境);
                角色.行动点 -= 角色.待机.消耗行动点;
            }

            if (角色.行动点 < 0)
                角色.行动点 = 0;
            if (teamA战场.战果 > 常量.最大战果)
                teamA战场.战果 = 常量.最大战果;
            if (teamA战场.战果 < 常量.最小战果)
                teamA战场.战果 = 常量.最小战果;
            if (teamA战场.战场修正 > 常量.最大战场修正)
                teamA战场.战场修正 = 常量.最大战场修正;
            if (teamA战场.战场修正 < 常量.最小战场修正)
                teamA战场.战场修正 = 常量.最小战场修正;

            foreach (var 效果 in 角色.效果List.ToArray())
            {
                if (效果.持续类型 == 持续类型.一回合)
                {
                    if (效果.回合数 == 0)
                        效果.回合数++;
                    else if (效果.回合数 == 1)
                        角色.效果List.Remove(效果);
                }
            }

            if (角色.行动点 == 0)
                角色.是否完结 = true;

            if (teamA战场.当前回合 >= teamA战场.最大回合数)
            {
                teamA战场.当前回合 = teamA战场.最大回合数;
                teamA战场.IsEnd = true;
            }

            foreach (var 效果 in 角色.效果List)
            {
                if (效果 is 自己回合结束效果)
                {
                    自己回合结束效果 自己回合结束效果 = (自己回合结束效果)效果;
                    自己回合结束效果.Excute(角色, 技能环境);
                }
            }

            bool isAllDead = true;
            foreach (var item in teamA战场.己方角色List)
            {
                if (!item.是否败走)
                {
                    isAllDead = false;
                    foreach (var 效果 in item.效果List)
                    {
                        if (效果 is 回合结束效果 && !(效果 is 自己回合结束效果))
                        {
                            回合结束效果 回合结束效果 = (回合结束效果)效果;
                            回合结束效果.Excute(item,技能环境);
                        }
                    }
                    break;
                }
            }
            if (isAllDead)
                teamA战场.IsEnd = true;
            else
            {
                isAllDead = true;
                foreach (var item in teamA战场.敌方角色List)
                {
                    if (!item.是否败走)
                    {
                        isAllDead = false;
                        foreach (var 效果 in item.效果List)
                        {
                            if (效果 is 回合结束效果 && !(效果 is 自己回合结束效果))
                            {
                                回合结束效果 回合结束效果 = (回合结束效果)效果;
                                回合结束效果.Excute(item, 技能环境);
                            }
                        }
                        break;
                    }
                }

                if (isAllDead)
                    teamA战场.IsEnd = true;
            }

            技能环境.战场.当前回合++;
            if (teamA战场.当前回合 >= teamA战场.最大回合数)
                teamA战场.IsEnd = true;

            if (teamA战场.行动顺序.List.Count == 0)
                teamA战场.IsEnd = true;

            if (!teamA战场.己方角色List.Contains(角色))
                teamA战场.反转Save();


            return 技能环境.ResultList;
        }

        public List<战斗结果> 战斗结算()
        {
            if (!teamA战场.IsEnd)
                throw new Exception("战斗还没结束");

            战斗结果 teamA战斗结果 = new 战斗结果();
            战斗结果 teamB战斗结果 = new 战斗结果();

            bool isTeamA团灭 = true;
            bool isTeamB团灭 = true;
            bool isTeamAWin = false;
            foreach (var item in teamA战场.己方角色List)
            {
                if (!item.是否败走)
                {
                    isTeamA团灭 = false;
                    break;
                }
            }
            foreach (var item in teamA战场.敌方角色List)
            {
                if (!item.是否败走)
                {
                    isTeamB团灭 = false;
                    break;
                }
            }
            if (isTeamA团灭)
                isTeamAWin = false;
            else if (isTeamB团灭)
                isTeamAWin = true;
            else
                isTeamAWin = teamA战场.战果 > 0;

            teamA战斗结果.角色List = teamA战场.己方角色List;
            teamB战斗结果.角色List = teamA战场.敌方角色List;
            teamA战斗结果.回复兵力List = new List<int>();
            teamB战斗结果.回复兵力List = new List<int>();

            teamA战斗结果.Win = isTeamAWin;
            teamA战斗结果.角色List = teamA战场.己方角色List;
            foreach (var 角色 in teamA战场.己方角色List)
            {
                if (角色.是否败走)
                {
                    teamA战斗结果.回复兵力List.Add(0);
                    continue;
                }
                else
                {
                    int value = Convert.ToInt32(角色.最大兵力 * 常量.战斗后回复系数 / 100m);
                    if (value + 角色.兵力 > 角色.最大兵力)
                        value = 角色.最大兵力 - 角色.兵力;

                    teamA战斗结果.回复兵力List.Add(value);
                }
            }

            
            foreach (var 角色 in teamA战场.己方角色List)
            {
                if (!角色.是否败走)
                {
                    if (角色.被动技能 != null && 角色.被动技能 is 战斗结束被动技能)
                    {
                        战斗结束被动技能 战斗结束被动技能 = (战斗结束被动技能)角色.被动技能;
                        战斗结束被动技能.Excute(teamA战斗结果);
                    }

                    if (角色.特殊技能 != null && 角色.特殊技能 is 战斗结束被动技能)
                    {
                        战斗结束被动技能 战斗结束被动技能 = (战斗结束被动技能)角色.被动技能;
                        战斗结束被动技能.Excute(teamA战斗结果);
                    }
                }
            }

            teamB战斗结果.Win = !isTeamAWin;
            teamB战斗结果.角色List = teamA战场.敌方角色List;
            foreach (var 角色 in teamA战场.敌方角色List)
            {
                if (角色.是否败走)
                {
                    teamB战斗结果.回复兵力List.Add(0);
                    continue;
                }
                else
                {
                    int value = Convert.ToInt32(角色.最大兵力 * 常量.战斗后回复系数 / 100m);
                    if (value + 角色.兵力 > 角色.最大兵力)
                        value = 角色.最大兵力 - 角色.兵力;

                    teamB战斗结果.回复兵力List.Add(value);
                }
            }

            foreach (var 角色 in teamA战场.敌方角色List)
            {
                if (!角色.是否败走)
                {
                    if (角色.被动技能 != null && 角色.被动技能 is 战斗结束被动技能)
                    {
                        战斗结束被动技能 战斗结束被动技能 = (战斗结束被动技能)角色.被动技能;
                        战斗结束被动技能.Excute(teamB战斗结果);
                    }

                    if (角色.特殊技能 != null && 角色.特殊技能 is 战斗结束被动技能)
                    {
                        战斗结束被动技能 战斗结束被动技能 = (战斗结束被动技能)角色.被动技能;
                        战斗结束被动技能.Excute(teamB战斗结果);
                    }
                }
            }

            for (int i = 0; i < teamA战场.己方角色List.Count; i++)
                teamA战场.己方角色List[i].兵力 += teamA战斗结果.回复兵力List[i];

            for (int i = 0; i < teamA战场.敌方角色List.Count; i++)
                teamA战场.敌方角色List[i].兵力 += teamB战斗结果.回复兵力List[i];

            return new List<战斗结果>() { teamA战斗结果, teamB战斗结果 };
        }
    }
}
