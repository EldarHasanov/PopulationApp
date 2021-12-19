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
    /// Логика взаимодействия для StatisticPage.xaml
    /// </summary>
    public partial class StatisticPage : Page
    {
        private Autentification ThisUser;
        public StatisticPage(Autentification thisUser)
        {
            InitializeComponent();
            ThisUser = thisUser;
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            Statistic.Content = new AddingPage(ThisUser);
            //Statistic.Content = new ChangePasswordPage(ThisUser);
        }
        private void Button_Click_SeeStatistic(object sender, RoutedEventArgs e)
        {
            //Statistic.Content = new ChangePasswordPage(ThisUser);
        }
    }
}
