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
            MessageText.Text = "Ви хочете змінити пароль користувача";
        }

        private void SingUpButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (OldPass1.Password == OldPass2.Password && OldPass1.Password != NewPass.Password)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Ви збираєтесь змінита пароль користувачу: " + ThisUser.GetName() + " Ви впевнені?", "Зміна паролю", 
                    System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    ChangePassword changePassword = new ChangePassword(ThisUser, NewPass.Password);
                    try
                    {
                        ThisUser = changePassword.Change(OldPass1.Password);
                        MessageText.Text = "Пароль успішно змінено!";
                    }
                    catch (ChangePasswordException exception) 
                    {
                        MessageText.Text = exception.Message;
                    }
                }
                    

            }
            else if (OldPass1.Password != OldPass2.Password)
            {
                MessageText.Text = "Старі паролі не співпадають.";
            }
            else
            {
                MessageText.Text = "Новий пароль не може бути таким-же як і старий.";
            }
        }
    }
}
