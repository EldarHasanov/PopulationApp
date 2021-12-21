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
using ViewModel;

namespace PopulationApp.WindowOfCommonFeatures
{
    /// <summary>
    /// Логика взаимодействия для StatisticWindow.xaml
    /// </summary>
    public partial class StatisticWindow : Window
    {
        private List<View> viewForTable = new List<View>();

        public StatisticWindow(List<Region> regions)
        {
            InitializeComponent();
            foreach (var reg in regions)
            {
                viewForTable.Add(new View(reg));
            }

            MainData.ItemsSource = viewForTable;
            
        }
        public StatisticWindow(List<Locality> localities)
        {
            InitializeComponent();
            foreach (var loc in localities)
            {
                viewForTable.Add(new View(loc));
            }
            MainData.ItemsSource = viewForTable;
        }
        public StatisticWindow(List<District> districts)
        {
            InitializeComponent();
            foreach (var dis in districts)
            {

                viewForTable.Add(new View(dis));
            }
            MainData.ItemsSource = viewForTable;
        }
    }
}
