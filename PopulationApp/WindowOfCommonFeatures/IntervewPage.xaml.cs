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
    /// Логика взаимодействия для IntervewPage.xaml
    /// </summary>
    public partial class IntervewPage : Page
    {
        private Autentification ThisUser;

        private ReceiveRegions recevedReg;
        private ReceiveLocalitys receiveLoc;
        private ReciveDistrict reciveDis;

        public IntervewPage(Autentification thisUser)
        {
            InitializeComponent();
            ThisUser = thisUser;
            recevedReg = new ReceiveRegions(0);
            Educ.Items.Add("Технічна");
            Educ.Items.Add("Гуманітарна");

            foreach (var regs in recevedReg.regionList)
            {
                //Reg.Items.Add((int) regs.RegionId);

                Reg.Items.Add(regs.Name);
            }
        }

        private void Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }


        private void Loc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            reciveDis = new ReciveDistrict(receiveLoc.LocalityList[Loc.SelectedIndex].LocalityId);
            if (Reg.SelectedIndex >= 0 && Loc.SelectedIndex >= 0)
            {
                reciveDis = new ReciveDistrict(receiveLoc.LocalityList[Loc.SelectedIndex].LocalityId);
                //Dis.Items.Clear();

                //Loc.Items.Add("Оберіть значення");


                foreach (var dist in reciveDis.districtList)
                {
                    Dis.Items.Add(dist.Name);
                }
            }
            else
            {
                //Dis.Items.Clear();
            }
        }

        private void Region_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if (Reg.SelectedIndex >= 0)
            {
                receiveLoc = new ReceiveLocalitys(recevedReg.regionList[Reg.SelectedIndex].RegionId);
                Loc.Items.Clear();

                //Loc.Items.Add("Оберіть значення");


                foreach (var locs in receiveLoc.LocalityList)
                {
                    Loc.Items.Add(locs.Name);
                }
            }
            else
            {
                Loc.Items.Clear();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (Dis.SelectedIndex >= 0)
            {
                UpdateDistrict update = new UpdateDistrict(recevedReg.regionList[Reg.SelectedIndex],
                    receiveLoc.LocalityList[Loc.SelectedIndex], reciveDis.districtList[Dis.SelectedIndex]);
                var isNumeric = double.TryParse(Age.Text, out double realAge);
                if ((bool)EducetedC.IsChecked && Educ.SelectedIndex >= 0 && isNumeric)
                {
                    //update.DoUpdate((bool)ManC.IsChecked, Content.ToDouble Age.Text,);
                    update.DoUpdate((bool)ManC.IsChecked, realAge, (bool)SkoolC.IsChecked, true, (Educ.SelectedIndex + 1));
                    MessegeBox.Text = "Данні введено";
                }
                else if (!(bool)EducetedC.IsChecked && isNumeric)
                {
                    update.DoUpdate((bool)ManC.IsChecked, realAge, (bool)SkoolC.IsChecked, false);
                    MessegeBox.Text = "Данні введено";
                }
                else
                {
                    MessegeBox.Text = "Введіть коректні данні";
                }
            }
        }
    }
}
