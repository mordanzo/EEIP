using EEIP.Models;
using SQLite;
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

namespace EEIP.Pages
{
    /// <summary>
    /// Interaction logic for PaybackPeriodPage.xaml
    /// </summary>
    public partial class PaybackPeriodPage : UserControl
    {
        List<PaybackPeriod> pp;
        public PaybackPeriodPage()
        {
            InitializeComponent();
            ReadDatabase();
        }
        void ReadDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.dbPath))
            {
                connection.CreateTable<PaybackPeriod>();

                pp = connection.Table<PaybackPeriod>().ToList().OrderBy(c => c.Id).ToList();
            }
        }

        private void onSelectMonth_Click(object sender, RoutedEventArgs e)
        {
            ReadDatabase();
        }

        private void onCalculate(object sender, RoutedEventArgs e)
        {

        }

        private void onClearPage(object sender, RoutedEventArgs e)
        {

        }
    }
}
