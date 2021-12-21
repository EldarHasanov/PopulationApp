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
    /// Логика взаимодействия для ShowStatisticPage.xaml
    /// </summary>
    public partial class ShowStatisticPage : Page
    {
        private Autentification ThisUser;

        private ReceiveRegions recevedReg;
        private ReceiveLocalitys receiveLoc;
        private ReciveDistrict reciveDis;
        public ShowStatisticPage(Autentification thisUser)
        {
            InitializeComponent();
            ThisUser = thisUser;
            Type.Items.Add("Статистика по крїні");
            Type.Items.Add("Статистика по області");
            Type.Items.Add("Статистика по місту");
        }

        private void Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            recevedReg = new ReceiveRegions(0);
            //receved.
            if (Type.SelectedIndex == 0)
            {
                Reg.Items.Clear();
                Loc.Items.Clear();
            }
            else
            {
                Reg.Items.Clear();
                Loc.Items.Clear();
                //Reg.Items.Add();
                foreach (var regs in recevedReg.regionList)
                {
                    //Reg.Items.Add((int) regs.RegionId);

                    Reg.Items.Add(regs.Name);
                }

                /*Reg.Items.Clear();
                Loc.Items.Clear();
                Reg.Items.Add("Оберіть значення");
                foreach (var regs in recevedReg.regionList)
                {
                    Reg.Items.Insert((int) regs.RegionId, regs.Name);
                    //Reg.Items.Insert((int)regs.RegionId, regs.Name);
                }*/
            }
        }


        private void Loc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            if (Type.SelectedIndex >= 2 && Reg.SelectedIndex >= 0 && Loc.SelectedIndex >= 0)
            {
                //reciveDis = new ReciveDistrict(receiveLoc.LocalityList[Loc.SelectedIndex].LocalityId);
                reciveDis = new ReciveDistrict(receiveLoc.LocalityList[Loc.SelectedIndex].LocalityId);
                //Dis.Items.Clear();

                //Loc.Items.Add("Оберіть значення");


                foreach (var dist in reciveDis.districtList)
                {
                    Loc.Items.Add(dist.Name);
                }
            }
            else
            {
                //Dis.Items.Clear();
            }
        }

        private void Region_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            
            if (Type.SelectedIndex >= 1 && Reg.SelectedIndex >= 0)
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
            StatisticWindow sw;
            switch (Type.SelectedIndex)
            {
                case 0:
                    sw = new StatisticWindow(recevedReg.regionList);
                    sw.Show();
                    break;
                case 1:
                    sw = new StatisticWindow(receiveLoc.LocalityList);
                    sw.Show();
                    break;
                case 2:
                    sw = new StatisticWindow(reciveDis.districtList);
                    sw.Show();
                    break;
            }
        }
    }
}
