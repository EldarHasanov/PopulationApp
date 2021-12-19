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
using ViewModel;

namespace PopulationApp.WindowOfCommonFeatures
{
    /// <summary>
    /// Логика взаимодействия для CommonFeatureWindow.xaml
    /// </summary>
    public partial class CommonFeatureWindow : Window
    {
        private Autentification ThisUser;
        public CommonFeatureWindow(Autentification thisUser)
        {
            InitializeComponent();
            ThisUser = thisUser;
            UpdateWindow();
        }

        private void UpdateWindow()
        {
            if (ThisUser.GetAccessLevel() == 1)
            {
                Main.Content = new AdminPage(ThisUser);
            }
            else
            {

            }
        }

        private void Button_Click_Exsit(object sender, RoutedEventArgs e)
        {
            MainWindow neWindow = new MainWindow();
            this.Close();
            neWindow.Show();
        }

        private void Button_Click_Change(object sender, RoutedEventArgs e)
        {
            Main.Content = new ChangePasswordPage(ThisUser);
        }

        private void Button_Click_Main(object sender, RoutedEventArgs e)
        {
            UpdateWindow();
        }
    }
}
