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

        #region 计算

        public virtual decimal Get基础伤害(角色 角色1, 角色 角色2)
        {
            if (物理系)
                return 角色1.实际兵力 * 角色1.兵种.攻 * 伤害系数;
            else
                return 角色1.实际兵力 * 角色1.兵种.智 * 0.7m * 伤害系数;
        }

        public virtual decimal Get兵种减伤(角色 角色)
        {
            if (物理系)
                return 常量.兵种减伤系数 / (常量.兵种减伤系数 + 角色.兵种.防);
            else
                return 常量.兵种减伤系数 / (常量.兵种减伤系数 + 角色.兵种.智);
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
            return Convert.ToInt32(伤害 * (1 + temp / 100m));
        }

        public virtual int 单角色伤害结算(角色 角色1, 角色 角色2)
        {
            var 基础伤害 = Get基础伤害(角色1, 角色2);
            var 兵种减伤 = Get兵种减伤(角色2);
            var 武将加成 = Get武将加成(角色1, 角色2);

            return 计算最终伤害(基础伤害 * 兵种减伤 * 武将加成);
        }

        public int 结算战果(int 伤害, 角色 角色)
        {
            return Convert.ToInt32(Convert.ToDecimal(伤害) / 角色.最大兵力 * 100);
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

        public virtual void Excute(技能环境 环境)
        {
            var total战果 = 0;

            foreach (var target in 环境.目标List)
            {
                var 目标 = target;

                if (this.可被守护)
                {
                    Random r = new Random(DateTime.Now.Millisecond);
                    var 守护List = get守护List(环境.战场.敌方角色List, target);
                    foreach (var 守护者 in 守护List)
                    {
                        int value = r.Next(1,101);
                        if (守护者.守护率 > 0)
                        {
                            if (守护者.守护率 > value)
                            {
                                目标 = 守护者;
                                守护者.守护率 -= 40;
                                break;
                            }
                        }
                        else
                        {
                            if (守护者.守护率 > value)
                            {
                                目标 = 守护者;
                                守护者.全体守护率 -= 40;
                                break;
                            }
                        }
                    }
                }

                //结算主动攻击
                var 伤害 = 单角色伤害结算(环境.施放者, target);
                if (目标.兵力 < 伤害)
                    伤害 = 目标.兵力;

                var 战果 = 结算战果(伤害,target);
                total战果 += 战果;

                目标.兵力 -= 伤害;
                if (目标.兵力 == 0)
                    目标.是否败走 = true;

                //结算打断
                if (target.准备技能 != null)
                {
                    Random r = new Random(DateTime.Now.Millisecond);
                    int value = r.Next(1, 101);
                    if (value <= this.打断系数)
                    {
                        环境.战场.行动顺序.打断(target);
                    }
                }
                //结算反击
                else if (this.能否被反击 && 目标.兵种.能否反击 && !目标.是否败走)
                {
                    伤害 = Convert.ToInt32(单角色伤害结算(目标, 环境.施放者) * 常量.反击比率);
                    if (环境.施放者.兵力 < 伤害)
                        伤害 = 环境.施放者.兵力;

                    战果 = 结算战果(伤害, 环境.施放者);
                    total战果 -= 战果;

                    环境.施放者.兵力 -= 伤害;
                    if (环境.施放者.兵力 == 0)
                    {
                        环境.施放者.是否败走 = true;
                        break;
                    }
                }
            }

            //结算反击
        }

        #endregion

        
    }
}
