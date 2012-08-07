using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 攻击之阵 : 战斗开始被动技能
    {
        public override void Excute(技能环境 环境)
        {
            foreach (var 角色 in 环境.战场.己方角色List)
            {
                var 赋予 = new 赋予()
                {
                    Level = 1,
                    是否单回合 = false
                };
                角色.攻击赋予 = 赋予;

                环境.ResultList.Add(new 赋予结果()
                {
                    赋予 = 赋予,
                    技能 = this,
                    Type = "攻击",
                    角色1 = 环境.施放者,
                    角色2 = 角色,
                });
            }
        }
    }

    public class 攻击之阵2 : 战斗开始被动技能
    {
        public override void Excute(技能环境 环境)
        {
            foreach (var 角色 in 环境.战场.己方角色List)
            {
                var 赋予 = new 赋予()
                {
                    Level = 2,
                    是否单回合 = false
                };
                角色.攻击赋予 = 赋予;

                环境.ResultList.Add(new 赋予结果()
                {
                    赋予 = 赋予,
                    技能 = this,
                    Type = "攻击",
                    角色1 = 环境.施放者,
                    角色2 = 角色,
                });
            }
        }
    }

    public class 防御之阵 : 战斗开始被动技能
    {
        public override void Excute(技能环境 环境)
        {
            foreach (var 角色 in 环境.战场.己方角色List)
            {
                var 赋予 = new 赋予()
                {
                    Level = 1,
                    是否单回合 = false
                };
                角色.防御赋予 = 赋予;

                环境.ResultList.Add(new 赋予结果()
                {
                    赋予 = 赋予,
                    技能 = this,
                    Type = "防御",
                    角色1 = 环境.施放者,
                    角色2 = 角色,
                });
            }
        }
    }

    public class 防御之阵2 : 战斗开始被动技能
    {
        public override void Excute(技能环境 环境)
        {
            foreach (var 角色 in 环境.战场.己方角色List)
            {
                var 赋予 = new 赋予()
                {
                    Level = 2,
                    是否单回合 = false
                };
                角色.防御赋予 = 赋予;

                环境.ResultList.Add(new 赋予结果()
                {
                    赋予 = 赋予,
                    技能 = this,
                    Type = "防御",
                    角色1 = 环境.施放者,
                    角色2 = 角色,
                });
            }
        }
    }

    public class 速度之阵 : 战斗开始被动技能
    {
        public override void Excute(技能环境 环境)
        {
            foreach (var 角色 in 环境.战场.己方角色List)
            {
                var 赋予 = new 赋予()
                {
                    Level = 1,
                    是否单回合 = false
                };
                角色.速度赋予 = 赋予;

                环境.ResultList.Add(new 赋予结果()
                {
                    赋予 = 赋予,
                    技能 = this,
                    Type = "速度",
                    角色1 = 环境.施放者,
                    角色2 = 角色,
                });
            }
        }
    }

    public class 速度之阵2 : 战斗开始被动技能
    {
        public override void Excute(技能环境 环境)
        {
            foreach (var 角色 in 环境.战场.己方角色List)
            {
                var 赋予 = new 赋予()
                {
                    Level = 2,
                    是否单回合 = false
                };
                角色.速度赋予 = 赋予;

                环境.ResultList.Add(new 赋予结果()
                {
                    赋予 = 赋予,
                    技能 = this,
                    Type = "速度",
                    角色1 = 环境.施放者,
                    角色2 = 角色,
                });
            }
        }
    }

    public class 智力之阵 : 战斗开始被动技能
    {
        public override void Excute(技能环境 环境)
        {
            foreach (var 角色 in 环境.战场.己方角色List)
            {
                var 赋予 = new 赋予()
                {
                    Level = 1,
                    是否单回合 = false
                };
                角色.智力赋予 = 赋予;

                环境.ResultList.Add(new 赋予结果()
                {
                    赋予 = 赋予,
                    技能 = this,
                    Type = "智力",
                    角色1 = 环境.施放者,
                    角色2 = 角色,
                });
            }
        }
    }

    public class 智力之阵2 : 战斗开始被动技能
    {
        public override void Excute(技能环境 环境)
        {
            foreach (var 角色 in 环境.战场.己方角色List)
            {
                var 赋予 = new 赋予()
                {
                    Level = 2,
                    是否单回合 = false
                };
                角色.智力赋予 = 赋予;

                环境.ResultList.Add(new 赋予结果()
                {
                    赋予 = 赋予,
                    技能 = this,
                    Type = "攻击",
                    角色1 = 环境.施放者,
                    角色2 = 角色,
                });
            }
        }
    }
}
