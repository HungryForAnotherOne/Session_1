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
    /// Логика взаимодействия для AddRedactForRealtor.xaml
    /// </summary>
    public partial class AddRedactForRealtor 
    {
        Realtor _realtor = new Realtor();
        CoFatckEntities coFatckEntities = new CoFatckEntities();


        public AddRedactForRealtor()
        {
            InitializeComponent();
        }
        public AddRedactForRealtor(Realtor realtor)
        {
            InitializeComponent();
            Surname.Text = realtor.Surname;
            Name.Text = realtor.Name;
            MiddleName.Text = realtor.MiddleName;
            ShareOfTheCommission.Text = realtor.ShareOfTheCommission.ToString();
            _realtor.Id = realtor.Id;
        }
        private bool Check()
        {
            StringBuilder error = new StringBuilder();
            if (Surname.Text == "")
            {
                error.AppendLine("Введите Фамилию");
            }
            if (Name.Text == "")
            {
                error.AppendLine("Введите Имя");
            }
            if (MiddleName.Text == "")
            {
                error.AppendLine("Введите Отчество");
            }
            if (int.Parse(ShareOfTheCommission.Text) <= 0 )
            {
                error.AppendLine("Доля от 0 до 100");
            }
            if (int.Parse(ShareOfTheCommission.Text) >= 100)
            {
                error.AppendLine("Доля от 0 до 100");
            }
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return false;
            }
            else
            {
                return true;
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Check())
            {

                try
                {
                    if (_realtor.Id == 0)
                    {
                        _realtor.Surname = Surname.Text;
                        _realtor.Name = Name.Text;
                        _realtor.MiddleName = MiddleName.Text;
                        _realtor.ShareOfTheCommission = int.Parse(ShareOfTheCommission.Text);
                        coFatckEntities.Realtor.Add(_realtor);
                    }
                    else
                    {
                        Realtor tempRealtor = coFatckEntities.Realtor.FirstOrDefault(u => u.Id == _realtor.Id);
                        tempRealtor.Surname = Surname.Text;
                        tempRealtor.Name = Name.Text;
                        tempRealtor.MiddleName = MiddleName.Text;
                        tempRealtor.ShareOfTheCommission = int.Parse(ShareOfTheCommission.Text);
                    }
                    coFatckEntities.SaveChanges();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

   
   }
}
    

