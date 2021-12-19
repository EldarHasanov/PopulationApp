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
using ViewModel;

namespace PopulationApp.WindowOfCommonFeatures
{
    /// <summary>
    /// Логика взаимодействия для ChangePasswordPage.xaml
    /// </summary>
    public partial class ChangePasswordPage : Page
    {
        private Autentification ThisUser;
        public ChangePasswordPage(Autentification thisUser)
        {
            InitializeComponent();
            ThisUser = thisUser;
            AAA.Text = "Ви хочете змінити пароль користувача";
        }

        private void SingUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (OldPass1.Text == OldPass2.Text && OldPass1.Text != NewPass.Text)
            {
                ChangePassword changePassword = new ChangePassword(ThisUser, NewPass.Text);
                try
                {
                    ThisUser = changePassword.Change(OldPass1.Text);
                }
                catch (ChangePasswordException exception)
                {
                    AAA.Text = exception.Message;
                }
                
            }
            else
            {
                AAA.Text = "Something wrong";
            }
        }
    }
}
