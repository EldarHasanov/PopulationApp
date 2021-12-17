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
using CCL.Security;
using DAL;

namespace PopulationApp
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {

        User newUser;
        public AdminWindow(User thisUser)
        {
            InitializeComponent();
            AAA.Text = "Ви авторизувалися як: " + thisUser.UserName;
            newUser = new User();
        }

        private void SingUpButton_Click(object sender, RoutedEventArgs e)
        {
            using (DBContext db = new DBContext())
            {
                if (db.users.FindAsync(Email.Text).Result == null)
                {
                    newUser.Email = Email.Text;
                    Hash encr = new Hash();
                    int hash = encr.GetFNV1aHashCode(Password.Text);
                    newUser.Password = hash.ToString();
                    newUser.UserName = UserName.Text;
                    if ((bool) RBAdmin.IsChecked)
                    {
                        newUser.AccessLevel = 1;
                    }
                    else if ((bool) RBAnalitic.IsChecked)
                    {
                        newUser.AccessLevel = 2;
                    }
                    else
                    {
                        newUser.AccessLevel = 3;
                    }

                    db.AddRange(newUser);
                    db.SaveChanges();
                }
            }
        }
    }
}
