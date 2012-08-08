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
    /// Win_Role.xaml 的交互逻辑
    /// </summary>
    public partial class Win_Role : Window
    {
        public Role Role { get; set; }

        public Win_Role(Role role)
        {
            Role = role;
            this.DataContext = role;
            InitializeComponent();

            List<string> 兵种List = new List<string>() { "盾兵", "剑士", "弓兵", "和尚", "忍者", "巫女", "骑兵", "军师", "火枪", "阴阳师", "骑兵", "炮兵" };
            cmb兵种.ItemsSource = 兵种List;
        }

        private void cmb兵种_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmb兵种.SelectedItem.ToString())
            {
                case "盾兵":
                    cmb基础攻击技能.ItemsSource = new List<string>() { "盾兵攻击", "盾兵攻击2", "盾兵攻击3" };
                    cmb技能1.ItemsSource = new List<string>() { "", "枪袭", "枪袭2", "仇恨之击", "掠夺" };
                    cmb技能2.ItemsSource = new List<string>() { "", "守护战友", "守护战友2", "全体守护战友", "全体守护战友2" };
                    cmb被动技能.ItemsSource = new List<string>() { "", "攻击运", "防御运", "速度运", "智力运", "团结力", "反击强化", "反击强化2", "初期防御2", "初期全体防御" };
                    txt特殊技能.Text = "初期防御";
                    break;
                case "剑士":
                    cmb基础攻击技能.ItemsSource = new List<string>() { "剑士攻击", "剑士攻击2", "剑士攻击3" };
                    cmb技能1.ItemsSource = new List<string>() { "", "武将突击", "全军突击", "全军突击2", "大声突击", "迂回攻击" };
                    cmb技能2.ItemsSource = new List<string>() { "", "怒", "怒2" };
                    cmb被动技能.ItemsSource = new List<string>() { "", "攻击运", "防御运", "速度运", "智力运", "团结力" };
                    break;
                case "忍者":
                    cmb基础攻击技能.ItemsSource = new List<string>() { "手里剑", "手里剑2", "手里剑3" };
                    cmb技能1.ItemsSource = new List<string>() { "", "暗杀", "暗杀2", "穿越手里剑", "音速手里剑" };
                    cmb技能2.ItemsSource = new List<string>() { "", "穿梭阵地", "穿梭阵地2", "穿梭阵地", "遁术", "遁术2" };
                    cmb被动技能.ItemsSource = new List<string>() { "", "攻击运", "防御运", "速度运", "智力运" };
                    break;
                case "弓兵":
                    cmb基础攻击技能.ItemsSource = new List<string>() { "弓箭射击", "弓箭射击2", "弓箭射击3", "阻击盾兵", "阻击剑士" };
                    cmb技能1.ItemsSource = new List<string>() { "", "全体射击", "全体射击2", "贯通射击", "贯通射击2", "疾风点破" };
                    cmb技能2.ItemsSource = new List<string>() { "" };
                    cmb被动技能.ItemsSource = new List<string>() { "", "攻击运", "防御运", "速度运", "智力运" };
                    break;
                case "军师":
                    cmb基础攻击技能.ItemsSource = new List<string>() { "弓箭射击", "弓箭射击2", "弓箭射击3" };
                    cmb技能1.ItemsSource = new List<string>() { "", "全军战术", "全军战术2", "全军战术3", "单军战术", "单军战术2" };
                    cmb技能2.ItemsSource = new List<string>() { "", "战术解除", "战术解除2", "单体战术解除", "伪报", "伪报2", "时间经过", "时间经过2" };
                    cmb被动技能.ItemsSource = new List<string>() { "", "攻击之阵", "攻击之阵2", "防御之阵", "防御之阵2", "速度之阵", "速度之阵2", "智力之阵", "智力之阵2", "延长战", "延长战2", "短期战", "短期战2", "初期战果" };
                    break;
                case "巫女":
                    cmb基础攻击技能.ItemsSource = new List<string>() { "弓箭射击", "弓箭射击2", "弓箭射击3" };
                    cmb技能1.ItemsSource = new List<string>() { "", "巫女之岚", "巫女之岚2" };
                    cmb技能2.ItemsSource = new List<string>() { "", "治愈之风", "治愈之风2", "治愈之雾" };
                    cmb被动技能.ItemsSource = new List<string>() { "", "巫女祝福", "巫女守护" };
                    break;
                case "僧兵":
                    cmb基础攻击技能.ItemsSource = new List<string>() { "僧兵攻击", "僧兵攻击2", "僧兵攻击3", "怪物散退" };
                    cmb技能1.ItemsSource = new List<string>() { "" };
                    cmb技能2.ItemsSource = new List<string>() { "", "防御解除", "防御解除2", "生机转换", "生机转换2" };
                    cmb被动技能.ItemsSource = new List<string>() { "", "攻击运", "防御运", "速度运", "智力运", "天神庇佑", "天神庇佑2", "苦行", "苦行2" };
                    break;
                case "火枪":
                    cmb基础攻击技能.ItemsSource = new List<string>() { "火枪射击", "火枪射击2", "火枪射击3", "火枪阻击" };
                    cmb技能1.ItemsSource = new List<string>() { "" };
                    cmb技能2.ItemsSource = new List<string>() { "" };
                    cmb被动技能.ItemsSource = new List<string>() { "" };
                    break;
                case "阴阳师":
                    cmb基础攻击技能.ItemsSource = new List<string>() { "召唤", "召唤2", "召唤3" };
                    cmb技能1.ItemsSource = new List<string>() { "", "上级召唤", "上级召唤2", "鬼召唤", "鬼召唤2" };
                    cmb技能2.ItemsSource = new List<string>() { "", "阴阳护盾", "全体阴阳护盾" };
                    cmb被动技能.ItemsSource = new List<string>() { "" };
                    break;
                case "骑兵":
                    cmb基础攻击技能.ItemsSource = new List<string>() { "骑兵冲锋", "骑兵冲锋2", "骑兵冲锋3" };
                    cmb技能1.ItemsSource = new List<string>() { "" };
                    cmb技能2.ItemsSource = new List<string>() { "" };
                    cmb被动技能.ItemsSource = new List<string>() { "" };
                    break;
                case "炮轰":
                    cmb基础攻击技能.ItemsSource = new List<string>() { "炮兵", "炮兵2", "炮兵3" };
                    cmb技能1.ItemsSource = new List<string>() { "" };
                    cmb技能2.ItemsSource = new List<string>() { "" };
                    cmb被动技能.ItemsSource = new List<string>() { "" };
                    break;
            }
        }

        private void btnCofirm_Click(object sender, RoutedEventArgs e)
        {
            if (Role.基础攻击技能 == null)
            {
                MessageBox.Show("请选择基础攻击技能");
                return;
            }

            if (Role.技能1 == null)
                Role.技能1 = "";
            if (Role.技能2 == null)
                Role.技能2 = "";
            if (Role.被动技能 == null)
                Role.被动技能 = "";
            if (Role.特殊技能 == null)
                Role.特殊技能 = "";

            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
