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
    /// Логика взаимодействия для AddRedactForUser.xaml
    /// </summary>
    public partial class AddRedactForUser
    {
        Users _users = new Users();
        CoFatckEntities coFatckEntities = new CoFatckEntities();
        

        public AddRedactForUser()
        {
            InitializeComponent();
        }
        public AddRedactForUser(Users users)
        {
            InitializeComponent();
            Surname.Text = users.Surname;
            Name.Text = users.Name;
            MiddleName.Text = users.MiddleName;
            Number.Text = users.Number;
            Email.Text = users.Email;
            _users.Id = users.Id;
        }


        private bool Check()
        {
            StringBuilder error = new StringBuilder();
            if (Email.Text == "" && Number.Text == "")
            {
                error.Append("Введите телефон или Email");
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Check()) { 
}
                try
            {
                if (_users.Id == 0)
                {
                    _users.Surname = Surname.Text;
                    _users.Name = Name.Text;
                    _users.MiddleName = MiddleName.Text;
                    _users.Number = Number.Text;
                    _users.Email = Email.Text;
                    coFatckEntities.Users.Add(_users);
                }
                else
                {
                    Users tempUsers = coFatckEntities.Users.FirstOrDefault(u => u.Id==_users.Id);
                    tempUsers.Surname = Surname.Text;
                    tempUsers.Name = Name.Text;
                    tempUsers.MiddleName = MiddleName.Text;
                    tempUsers.Number = Number.Text;
                    tempUsers.Email = Email.Text;
                }
                coFatckEntities.SaveChanges();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
