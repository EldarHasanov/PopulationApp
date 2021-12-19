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
        private ReceiveLocalitys receiveLoc;
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
            switch (Type.SelectedIndex)
            {
                case 0:
                    new AddRegInBd(Name.Text);
                    break;
                case 1:
                    if (Reg.SelectedIndex > 0)
                    {
                        new AddLocInBd(Name.Text, (uint)Reg.SelectedIndex);
                    }
                    else
                    {
                        MessegeBox.Text = "Оберіть існуючий регіон";
                    }
                    break;
                case 2:
                    if (Reg.SelectedIndex > 0 && Loc.SelectedIndex >= 0)
                    {
                        new AddDisInBd(Name.Text, receiveLoc.LocalityList[Loc.SelectedIndex].LocalityId);
                    }
                    else
                    {
                        MessegeBox.Text = "Оберіть існуючий регіон і населений пункт";
                    }
                    break;
            }
        }

        private void Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ReceiveRegions recevedReg = new ReceiveRegions(0);
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
                Reg.Items.Add("Оберіть значення");
                foreach (var regs in recevedReg.regionList)
                {
                    //Reg.Items.Add((int) regs.RegionId);

                    Reg.Items.Insert((int) regs.RegionId, regs.Name);
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

        }

        private void Region_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

            if (Type.SelectedIndex == 2 && Reg.SelectedIndex > 0)
            {
                receiveLoc = new ReceiveLocalitys((uint)Reg.SelectedIndex);
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
    }
}
