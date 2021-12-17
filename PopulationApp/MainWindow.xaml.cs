﻿using System;
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
using DAL;
using DAL.Entity;
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
            Locality BBB = new Locality();
            District CCC = new District();


            using (DBContext db = new DBContext())
            {
                //db.regions.AddRange(ABC);
                //db.localitys.AddRange(BBB);
                db.districts.AddRange(CCC);
                db.SaveChanges();
            }
        }
    }
}
