using EEIP.Pages;
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

namespace EEIP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HomePage homePage = new HomePage();
        PaybackPeriodPage paybackPeriodPage = new PaybackPeriodPage();
        AccountingReturnRatePage ARRPage = new AccountingReturnRatePage();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void onPaybackPeriodPage(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(paybackPeriodPage);
        }

        private void onROIPage(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(ARRPage);
        }

        private void onHomePage(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(homePage);
        }
    }
}
