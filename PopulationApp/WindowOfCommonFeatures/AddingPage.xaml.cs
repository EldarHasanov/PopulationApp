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
    /// Логика взаимодействия для AddingPage.xaml
    /// </summary>
    public partial class AddingPage : Page
    {
        private Autentification ThisUser;
        public AddingPage(Autentification thisUser)
        {
            InitializeComponent();
            ThisUser = thisUser;
            Type.Items.Add("Область");
            Type.Items.Add("Місто");
            Type.Items.Add("Район");
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (Type.SelectedIndex)
            {
                case 0:

                    break;
                case 1:
                    ReceiveRegions receved = new ReceiveRegions(1);
                    foreach (var regs in receved.regionList)
                    {
                        Reg.Items.Insert((int)regs.RegionId, regs.Name);
                    }
                    break;
                case 2:
                    break;
            }
        }

        private void Loc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Region_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
