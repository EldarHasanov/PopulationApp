using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
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
using PopulationApp.WindowOfCommonFeatures;
using ViewModel;

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
            //NavigationService.Navigate(new Page1());
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
                        CommonFeatureWindow commonFeatureWindow = new CommonFeatureWindow(autentification);
                        this.Close();
                        commonFeatureWindow.Show();
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
