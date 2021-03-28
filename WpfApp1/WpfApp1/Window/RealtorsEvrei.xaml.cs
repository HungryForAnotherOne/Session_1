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
using WpfApp1.Model;

namespace WpfApp1.Window
{
    /// <summary>
    /// Логика взаимодействия для RealtorsEvrei.xaml
    /// </summary>
    public partial class RealtorsEvrei
    {
        CoFatckEntities coFatckEntities = new CoFatckEntities();
        public RealtorsEvrei()
        {
            InitializeComponent();
            Realtors.ItemsSource = coFatckEntities.Realtor.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddRedactForRealtor addForRealtor = new AddRedactForRealtor();
            addForRealtor.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Realtors.SelectedItems.Count > 0)
            {
                Realtor realtors = (Realtor)Realtors.SelectedItems[0];
                coFatckEntities.Realtor.Remove(realtors);
                coFatckEntities.SaveChanges();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            coFatckEntities.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            Realtors.ItemsSource = coFatckEntities.Realtor.ToList();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Realtors.SelectedItems.Count > 0)
            {
                Realtor realtors = (Realtor)Realtors.SelectedItems[0];
                AddRedactForRealtor redactForRealtor = new AddRedactForRealtor(realtors);
                redactForRealtor.Show();
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
