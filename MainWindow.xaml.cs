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

namespace The_Oracle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PunDatabase punDb;

        public MainWindow()
        {
            InitializeComponent();
            punDb = new PunDatabase();
            //imgCrystalBall.Source =;
        }

        private void btnOpenDev_Click(object sender, RoutedEventArgs e)
        {
            
            punDb.Open(database_target.DEV);
        }

        private void btnCloseDev_Click(object sender, RoutedEventArgs e)
        {
            punDb.Close();
        }

        private void btnFetchAPun_Click(object sender, RoutedEventArgs e)
        {
            PunEntry[] entries = punDb.FetchByQuality(0, 3);

            tbxPunDisplay.Text = entries[(new Random()).Next(0, entries.Length - 1)].Text;
        }

        private void btnMarkUsed_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
