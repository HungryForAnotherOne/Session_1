using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using WpfApp1.Model;

namespace WpfApp1.Window
{
    /// <summary>
    /// Логика взаимодействия для UsersLol.xaml
    /// </summary>
    public partial class UsersLol
    {
        CoFatckEntities coFatckEntities = new CoFatckEntities();
        public UsersLol()
        {
            InitializeComponent();
            Swalow.ItemsSource = coFatckEntities.Users.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddRedactForUser addForUser = new AddRedactForUser();
            addForUser.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Swalow.SelectedItems.Count > 0)
            {
                Users users = (Users)Swalow.SelectedItems[0];
                coFatckEntities.Users.Remove(users);
                coFatckEntities.SaveChanges();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            coFatckEntities.ChangeTracker.Entries().ToList().ForEach(p=>p.Reload());
            Swalow.ItemsSource = coFatckEntities.Users.ToList();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Swalow.SelectedItems.Count > 0)
            {
                Users users = (Users)Swalow.SelectedItems[0];
                AddRedactForUser redactForUser = new AddRedactForUser(users);
                redactForUser.Show();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

    }

 
}
