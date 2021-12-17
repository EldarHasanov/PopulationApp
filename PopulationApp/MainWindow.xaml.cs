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
            Region ABC = new Region();
            AAA.Text = ABC.Name;
            User BBB = new Admin();
            User CCC = new Analyst();
            User DDD = new Interviewer();


            using (DBContext db = new DBContext())
            {;
                db.users.AddRange(BBB,CCC,DDD);
                db.SaveChanges();
            }
        }
    }
}
