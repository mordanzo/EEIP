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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl
    {
        List<LastActivity> lastActivities;
        List<PaybackPeriod> paybackPeriods;
        List<AccountingReturnRate> accountingReturnRates;

        public HomePage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    paybackPeriods = connection.Table<PaybackPeriod>().OrderBy(c => c.Id).ToList();
                    accountingReturnRates = connection.Table<AccountingReturnRate>().OrderBy(c => c.Id).ToList();
                    lastActivities = connection.Table<LastActivity>().OrderBy(l => l.Id).ToList();

                    foreach (var item in lastActivities)
                    {
                        if (item.ActivityType == 1)
                        {
                            foreach (var obj in paybackPeriods)
                            {
                                if (item.ActivityId == obj.Id)
                                {
                                    Border border = new Border
                                    {
                                        BorderBrush = Brushes.Gainsboro,
                                        BorderThickness = new Thickness(0, 1, 0, 0),
                                        Margin = new Thickness(0, 5, 0, 5),
                                    };
                                    Border borderSecond = new Border
                                    {
                                        BorderBrush = Brushes.Gainsboro,
                                        BorderThickness = new Thickness(0, 1, 0, 0),
                                        Margin = new Thickness(0, 5, 0, 5),
                                    };
                                    TextBlock tbPP = new TextBlock
                                    {
                                        Text = "Рассчёт срока окупаемости",
                                        FontSize = 20,
                                        MinHeight = 30,
                                    };
                                    TextBlock tbMonth = new TextBlock
                                    {
                                        Text = "Период(кол-во месяцев): " + obj.Month.ToString(),
                                    };
                                    TextBlock tbInevst = new TextBlock
                                    {
                                        Text = "Вложения: " + obj.Investment.ToString(),
                                    };
                                    TextBlock tbCashFlow = new TextBlock
                                    {
                                        Text = "Денежный поток: " + obj.CashFlow.ToString(),
                                    };
                                    TextBlock tbResultPP = new TextBlock
                                    {
                                        Text = "Срок окупаемости: " + obj.Result,
                                    };

                                    spLastActivity.Children.Add(border);
                                    spLastActivity.Children.Add(tbPP);
                                    spLastActivity.Children.Add(tbMonth);
                                    spLastActivity.Children.Add(tbInevst);
                                    spLastActivity.Children.Add(tbCashFlow);
                                    spLastActivity.Children.Add(tbResultPP);
                                    spLastActivity.Children.Add(borderSecond);
                                }
                            }
                        }
                        else if (item.ActivityType == 2)
                        {
                            foreach (var obj in accountingReturnRates)
                            {
                                if (item.ActivityId == obj.Id)
                                {
                                    Border border = new Border
                                    {
                                        BorderBrush = Brushes.Gainsboro,
                                        BorderThickness = new Thickness(0, 1, 0, 0),
                                        Margin = new Thickness(0, 5, 0, 5),
                                    };
                                    Border borderSecond = new Border
                                    {
                                        BorderBrush = Brushes.Gainsboro,
                                        BorderThickness = new Thickness(0, 1, 0, 0),
                                        Margin = new Thickness(0, 5, 0, 5),
                                    };
                                    TextBlock tbPP = new TextBlock
                                    {
                                        Text = "Рентабельность инвестиций",
                                        FontSize = 20,
                                        MinHeight = 30,
                                    };
                                    TextBlock tbMonth = new TextBlock
                                    {
                                        Text = "Период(кол-во месяцев): " + obj.Month.ToString(),
                                    };
                                    TextBlock tbInevst = new TextBlock
                                    {
                                        Text = "Вложения: " + obj.Investment.ToString(),
                                    };
                                    TextBlock tbCashFlow = new TextBlock
                                    {
                                        Text = "Денежный поток: " + obj.CashFlow.ToString(),
                                    };
                                    TextBlock tbResultPP = new TextBlock
                                    {
                                        Text = "Коэффициент рентабельности: " + obj.Result,
                                    };

                                    spLastActivity.Children.Add(border);
                                    spLastActivity.Children.Add(tbPP);
                                    spLastActivity.Children.Add(tbMonth);
                                    spLastActivity.Children.Add(tbInevst);
                                    spLastActivity.Children.Add(tbCashFlow);
                                    spLastActivity.Children.Add(tbResultPP);
                                    spLastActivity.Children.Add(borderSecond);
                                }

                            }
                        }
                    }                    
                }
                catch (Exception err)
                {
                    MessageBox.Show("Не удалось вывести записи!\n" + err.Message);
                }
            }
        }
    }
}

