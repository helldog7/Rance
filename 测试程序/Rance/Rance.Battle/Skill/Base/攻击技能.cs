using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rance.Battle
{
    public class 攻击技能:主动技能
    {
        public bool 可被守护 { get; set; }
        public decimal 伤害系数 = 1m;
        public int 打断系数 = 100;
        public bool 物理系 { get; set; }
        public bool 能否被反击 { get; set; }

        #region 计算

        public virtual decimal Get基础伤害(角色 角色1, 角色 角色2)
        {
            if (物理系)
                return 角色1.实际兵力 * 角色1.兵种.攻 * 伤害系数;
            else
                return 角色1.实际兵力 * 角色1.兵种.智 * 0.7m * 伤害系数;
        }

        public virtual decimal Get兵种减伤(角色 角色,int 战场修正)
        {
            if (物理系)
                return 常量.兵种减伤系数 / (常量.兵种减伤系数 + 角色.兵种.防 * (100 - 战场修正)/100);
            else
                return 常量.兵种减伤系数 / (常量.兵种减伤系数 + 角色.兵种.智 * (100 - 战场修正) / 100);
        }

        public virtual decimal Get武将加成(角色 角色1, 角色 角色2)
        {
            if (物理系)
            {
                var result = (角色1.实际攻 - 角色2.实际防) * 常量.武将减伤系数 + 1m;
                if (result < -1m)
                    result = -1m;

                return result;
            }
            else
            {
                var result = (角色1.实际智 - 角色2.实际智) * 常量.武将减伤系数 + 1m;
                if (result < -1m)
                    result = -1m;

                return result;
            }
        }

        public virtual int 计算最终伤害(decimal 伤害)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int temp = r.Next(-5, 6);
            return Convert.ToInt32(伤害 * (1 + temp / 100m) );
        }

        public virtual int 单角色伤害结算(角色 角色1, 角色 角色2,bool 是否反击,int 战场修正)
        {
            var 基础伤害 = Get基础伤害(角色1, 角色2);
            var 兵种减伤 = Get兵种减伤(角色2, 战场修正);
            var 武将加成 = Get武将加成(角色1, 角色2);

            int 伤害 = 计算最终伤害(基础伤害 * 兵种减伤 * 武将加成);
            foreach (效果 效果 in 角色1.效果List.ToArray())
            {
                if (!(效果 is 伤害结算效果))
                    continue;
                伤害结算效果 伤害结算效果 = (伤害结算效果)效果;
                伤害 = 伤害结算效果.Excute(角色1, 角色2, 伤害, 是否反击);
                if (伤害结算效果.持续类型 == 持续类型.一次)
                    角色1.效果List.Remove(伤害结算效果);
            }

            foreach (效果 效果 in 角色2.效果List.ToArray())
            {
                if (!(效果 is 被伤害结算效果))
                    continue;
                被伤害结算效果 被伤害结算效果 = (被伤害结算效果)效果;
                伤害 = 被伤害结算效果.Excute(角色1, 角色2, 伤害);
                if (被伤害结算效果.持续类型 == 持续类型.一次)
                    角色2.效果List.Remove(被伤害结算效果);
            }
            return 伤害;
        }

        public virtual int 结算战果(int 伤害, 角色 角色)
        {
            var i1 = Convert.ToInt32(Convert.ToDecimal(伤害) / 角色.最大兵力 * 100);
            var i2 = 0;
            if (角色.是否败走)
                i2 = 200;
            return i1 + i2;
        }

        private List<角色> get守护List(List<角色> list, 角色 角色)
        {
            List<角色> resultList = new List<角色>();
            var temp = (from q in list
                        where q.守护率 > 0 &&
                              q.列 == 角色.列 &&
                              q != 角色
                        orderby q.排
                        select q);
            resultList.AddRange(temp);
            temp = (from q in list
                        where q.全体守护率 > 0 &&
                              q.列 != 角色.列 &&
                              q != 角色
                        orderby q.列, q.排
                        select q);
            resultList.AddRange(temp);

            return resultList;
        }

        public override void Excute(技能环境 环境)
        {
            base.Excute(环境);
            var total战果 = 0;

            foreach (var target in 环境.目标List)
            {
                攻击结果 攻击结果 = new Battle.攻击结果()
                {
                    角色1 = 环境.施放者,
                    角色2 = target,
                    攻击技能 = this,
                };
                环境.ResultList.Add(攻击结果);

                var 目标 = target;

                if (this.可被守护)
                {
                    var 守护List = get守护List(环境.战场.敌方角色List, target);
                    foreach (var 守护者 in 守护List)
                    {
                        if (守护者.守护率 > 0)
                        {

                            if (Roll.Hit(守护者.守护率))
                            {
                                目标 = 守护者;
                                守护者.守护率 -= 40;
                                攻击结果.守护角色 = 守护者;
                                break;
                            }
                        }
                        else
                        {
                            if (Roll.Hit(守护者.守护率))
                            {
                                目标 = 守护者;
                                守护者.全体守护率 -= 40;
                                攻击结果.守护角色 = 守护者;
                                break;
                            }
                        }
                    }
                }

                //结算主动攻击
                var 伤害 = 单角色伤害结算(环境.施放者, target,false,环境.战场.战场修正);
                if (目标.兵力 < 伤害)
                    伤害 = 目标.兵力;
                攻击结果.伤害 = 伤害;

                if (目标.护盾)
                {
                    伤害 = 0;
                    目标.护盾 = false;
                    攻击结果.是否被护盾抵挡 = true;
                }

                if (目标.兵力 <= 伤害)
                {
                    目标.是否败走 = true;
                    攻击结果.是否败退 = true;
                }

                var 战果 = 结算战果(伤害, 目标);
                total战果 += 战果;
                攻击结果.战果 = 战果;


                //结算打断
                if (target.准备技能 != null)
                {
                    if (Roll.Hit(打断系数))
                    {
                        环境.战场.行动顺序.打断(target);
                        攻击结果.是否打断 = true;
                    }
                }
                //结算反击
                else if (this.能否被反击 && 目标.兵种.能否反击)
                {
                    反击结果 反击结果 = new Battle.反击结果() 
                    {
                        角色1 = 目标,
                        角色2 = 环境.施放者,
                    };
                    环境.ResultList.Add(反击结果);

                    var 反击伤害 = Convert.ToInt32(单角色伤害结算(目标, 环境.施放者, true, 环境.战场.战场修正) * 常量.反击比率);
                    if (环境.施放者.兵力 < 反击伤害)
                        反击伤害 = 环境.施放者.兵力;
                    反击结果.伤害 = 伤害;

                    if (环境.施放者.护盾)
                    {
                        伤害 = 0;
                        环境.施放者.护盾 = false;
                        反击结果.是否被护盾抵挡 = true;
                    }

                    战果 = 结算战果(反击伤害, 环境.施放者);
                    total战果 -= 战果;
                    反击结果.战果 = 战果;

                    环境.施放者.兵力 -= 反击伤害;
                    if (环境.施放者.兵力 == 0)
                    {
                        环境.施放者.是否败走 = true;
                        反击结果.是否败退 = true;
                        break;
                    }
                }

                目标.兵力 -= 伤害;
               
            }

            环境.战场.行动顺序.行动(环境.施放者, this);
        }

        #endregion

        
    }
}
