using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
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
using DAL;
using DAL.Entity;
using CCL.Security.Identify;
using MySql.Data.MySqlClient;

namespace PopulationApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*Region ABC = new Region();
            AAA.Text = ABC.Name;
            User BBB = new Admin();
            User CCC = new Analyst();
            User DDD = new Interviewer();


            using (DBContext db = new DBContext())
            {
                db.users.AddRange(BBB,CCC,DDD);
                db.SaveChanges();
            }*/
        }

        private void SingInButton_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text != "Login" && Password.Text != "Password")
            {
                string login = Login.Text;
                string password = Password.Text;
                using (DBContext db = new DBContext())
                {
                    ValueTask<User> ThisUser = db.users.FindAsync(login);
                    User thisUser = ThisUser.Result;
                    //int hash = String.GetHashCode(Password.Text);
                    Hash encr = new Hash();
                    int hash = encr.GetFNV1aHashCode(Password.Text);
                    if (thisUser.Password == hash.ToString())
                    {
                        //AAA.Text = "Ви авторизувалися як: " + thisUser.UserName;
                        if (thisUser.AccessLevel == 1)
                        {
                            AdminWindow adminWindow = new AdminWindow(thisUser);
                            this.Close();
                            adminWindow.Show();
                        }
                    }
                    else
                    {
                        AAA.Text = "Задано невірний логін або пароль";
                    }
                    
                    //AAA.Text = thisUser.ToString();
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
