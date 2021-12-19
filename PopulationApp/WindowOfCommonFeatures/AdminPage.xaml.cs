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

namespace PopulationApp.WindowOfCommonFeatures
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        User newUser;
        public AdminPage(Autentification thisUser)
        {
            InitializeComponent();
            AAA.Text = "Ви авторизувалися як: " + thisUser.GetName();
            newUser = new User();
        }
        private void SingUpButton_Click(object sender, RoutedEventArgs e)
        {
            uint accLev;
            if ((bool)RBAdmin.IsChecked)
            {
                accLev = 1;
            }
            else if ((bool)RBAnalitic.IsChecked)
            {
                accLev = 2;
            }
            else
            {
                accLev = 3;
            }

            try
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Ви збираєтесь додати користувача : " + UserName.Text + " Ви впевнені?", "Новий користувач",
                    System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    Registration register = new Registration(Email.Text, Password.Text, UserName.Text, accLev);
                    register.addUserToDataBase();
                }
            }
            catch (ExistExeption exception)
            {
                AAA.Text = exception.Message;
            }

        }
    }
}
