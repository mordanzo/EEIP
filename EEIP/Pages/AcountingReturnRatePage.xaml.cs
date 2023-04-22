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
    /// Interaction logic for ROIPage.xaml
    /// </summary>
    public partial class AccountingReturnRatePage : UserControl
    {
        private int month;
        private double investment;
        private List<double> cashFlow = new List<double>();
        private string result;
        private double sum;
        private int numOfMonth = 0;

        public AccountingReturnRatePage()
        {
            InitializeComponent();
        }
        private void onCalculate(object sender, RoutedEventArgs e)
        {
            try
            {
                investment = Convert.ToDouble(tbInvest.Text);
                result = Math.Round((sum / investment) * 10).ToString()+"%";

                MessageBox.Show("Рассчёт выполнен!");

                try
                {
                    AccountingReturnRate accountingRR = new AccountingReturnRate()
                    {
                        Month = month,
                        Investment = investment,
                        CashFlow = string.Join(",",cashFlow),
                        Result = result,
                    };
                    using (SQLiteConnection connection = new SQLiteConnection(App.dbPath))
                    {
                        connection.CreateTable<AccountingReturnRate>();
                        connection.Insert(accountingRR);
                        
                    };

                    LastActivity lastActivity = new LastActivity()
                    {
                        ActivityId = accountingRR.Id,
                        ActivityType = 2,
                    };
                    using (SQLiteConnection connection = new SQLiteConnection(App.dbPath))
                    {
                        connection.CreateTable<LastActivity>();
                        connection.Insert(lastActivity);
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось сохранить результаты!");
                }

                itogPP.Text = result;
            }
                catch (System.FormatException)
            {
                MessageBox.Show("Проверьте данные, которые были введены!");
            }
        }

        private void onClearPage(object sender, RoutedEventArgs e)
        {
            tbCashFlow.Text = "";
            tbCashFlow.IsEnabled = true;
            lbSum.Content = "";
            lbSucces.Content = "";
            cashFlow.Clear();
            tbInvest.Text = "";
            monthComboBox.SelectedIndex = 0;
            monthComboBox.IsEnabled = true;
            itogPP.Text = "";
            lbMonth.Content = "";
        }

        private void monthComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            month = monthComboBox.SelectedIndex + 1;
        }

        private void onNextMonth(object sender, RoutedEventArgs e)
        {
            monthComboBox.IsEnabled = false;
            numOfMonth += 1;
            cashFlow.Add(Convert.ToDouble(tbCashFlow.Text));
            sum = sum + Convert.ToDouble(tbCashFlow.Text);

            tbCashFlow.Focus();
            lbMonth.Content = numOfMonth.ToString();
            lbSum.Content = sum.ToString();
            tbCashFlow.Text = "";
            lbSucces.Content = "Успешно добавлены!";

            if (cashFlow.Count >= month)
            {
                tbCashFlow.IsEnabled = false;
                btnCashFlow.IsEnabled = false;

                btnCalculate.IsEnabled = true;
                lbSucces.Content = "Все данные успешно записаны!";
            }
        }


        private void tbCashFlow_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbCashFlow.Text != "")
            {
                btnCashFlow.IsEnabled = true;
            } else
            {
                btnCashFlow.IsEnabled = false;
            }
        }
    }
}
