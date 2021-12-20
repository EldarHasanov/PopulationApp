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
using DAL;
using DAL.Entity;

namespace PopulationApp.WindowOfCommonFeatures
{
    /// <summary>
    /// Логика взаимодействия для StatisticWindow.xaml
    /// </summary>
    public partial class StatisticWindow : Window
    {
        public StatisticWindow(List<Region> regions)
        {
            InitializeComponent();
            MainData.ItemsSource = regions;
        }
        public StatisticWindow(List<Locality> localities)
        {
            InitializeComponent();
            MainData.ItemsSource = localities;
        }
        public StatisticWindow(List<District> districts)
        {
            InitializeComponent();
            MainData.ItemsSource = districts;
        }
    }
}
