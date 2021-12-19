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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CCL.Security;
using ViewModel;

namespace PopulationApp
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void SingInButton_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text != "Login" && Password.Text != "Password")
            {
                string login = Login.Text;
                string password = Password.Text;
                User thisUser = new User(login, password);
                try
                {
                    Autentification autentification = new Autentification(thisUser);
                    if (autentification.GetAccessLevel() == 1)
                    {
                        AdminWindow adminWindow = new AdminWindow(autentification);
                        //this.Close();
                        //this.Content = new Page1();
                        adminWindow.Show();
                    }
                    else if (autentification.GetAccessLevel() == 2)
                    {
                        //AnaliticWindow analiticWindow = new AnaliticWindow(autentification);
                        //this.Close();
                        //analiticWindow.Show();
                    }
                    else
                    {

                    }
                }
                catch (AutentificationExeption exception)
                {
                    AAA.Text = exception.Message;
                }

            }
            else
            {
                AAA.Text = "Задано невірний логін або пароль";
            }
            //throw new NotImplementedException();
        }

    }
}
