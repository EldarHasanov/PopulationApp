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
using ViewModel;

namespace PopulationApp
{
    /// <summary>
    /// Логика взаимодействия для AnaliticWindow.xaml
    /// </summary>
    public partial class AnaliticWindow : Window
    {
        public AnaliticWindow(Autentification thisUser)
        {
            InitializeComponent();
        }
        private void Button_Click_Exsit(object sender, RoutedEventArgs e)
        {
            MainWindow neWindow = new MainWindow();
            this.Close();
            neWindow.Show();
        }
    }
}
