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
    /// RoleMgt.xaml 的交互逻辑
    /// </summary>
    public partial class RoleMgt : Window
    {
        public RoleMgt()
        {
            InitializeComponent();
            fresh();
        }

        private void fresh()
        {
            RanceEntities entites = new RanceEntities();
            var list = (from r in entites.Role
                        orderby r.Name
                        select r).ToList();
            this.grd_RoleMgt.ItemsSource = new ObservableCollection<Role>(list);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Role role = new Role();
            role.ID = Guid.NewGuid();
            Win_Role win = new Win_Role(role);

            RanceEntities entites = new RanceEntities();
            if (win.ShowDialog() == true)
            {
                

                entites.Role.AddObject(role);
                entites.SaveChanges();
                fresh();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Role role = this.grd_RoleMgt.SelectedItem as Role;
            if (role != null)
            {
                RanceEntities entites = new RanceEntities();
                role= (from r in entites.Role
                            where r.ID == role.ID
                            select r).SingleOrDefault();

                Win_Role win = new Win_Role(role);
                if (win.ShowDialog() == true)
                {
                    entites.SaveChanges();
                    fresh();
                }
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Role role = this.grd_RoleMgt.SelectedItem as Role;
            if (role != null)
            {
                RanceEntities entites = new RanceEntities();
                role= (from r in entites.Role
                            where r.ID == role.ID
                            select r).SingleOrDefault();

                entites.DeleteObject(role);

                entites.SaveChanges();
                fresh();
            }
        }
    }
}
