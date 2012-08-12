using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 战场
    {
        public string 己方队伍名称 { get; set; }
        public string 敌方队伍名称 { get; set; }

        public int 最大回合数 { get; set; }
        public int 当前回合 { get; set; }

        //以TeamA为标准，+1000为最大，-1000最小
        public int 战果 { get; set; }

        //以TeamA为标准，+20为最大，-20最小
        public int 战场修正 { get; set; }

        public 行动顺序 行动顺序 { get; set; }

        public List<角色> 己方角色List = new List<角色>();
        public List<角色> 敌方角色List = new List<角色>();

        public int 己方收获金钱 { get; set; }
        public int 敌方收获金钱 { get; set; }

        public bool IsEnd { get; set; }

        private 战场 inner战场;

        public 战场 反转() 
        {
            if (inner战场 == null)
            {
                inner战场 = new 战场();
                inner战场.己方队伍名称 = 敌方队伍名称;
                inner战场.敌方队伍名称 = 己方队伍名称;
                inner战场.己方角色List = 敌方角色List;
                inner战场.敌方角色List = 己方角色List;
            }
            inner战场.当前回合 = 当前回合;
            inner战场.最大回合数 = 最大回合数;
            inner战场.战果 = 0 - 战果;
            inner战场.战场修正 = 0 - 战场修正;
            inner战场.行动顺序 = 行动顺序;
            return inner战场;
        }

        public void 反转Save()
        {
            this.当前回合 = inner战场.当前回合;
            this.战果 = 0 - inner战场.战果;
            this.战场修正 = 0 - inner战场.战场修正;
            this.行动顺序 = inner战场.行动顺序;
        }
    }
}
