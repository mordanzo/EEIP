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
        private int month;
        private double investment;
        private double cashFlow;
        private string result;
        public PaybackPeriodPage()
        {
            InitializeComponent();
        }

        private void onCalculate(object sender, RoutedEventArgs e)
        {
            try
            {
                investment = Convert.ToDouble(tbInvest.Text);
                investment = investment * month;
                cashFlow = Convert.ToDouble(tbCashFlow.Text);

                if (investment < cashFlow)
                {
                    MessageBox.Show("Вложения должны быть больше, чем поступления!");
                }
                else
                {
                    double sum = cashFlow;
                    double interval = cashFlow;
                    double paybackPeriod = 0;
                    for (int i = 1; i < month; i++)
                    {
                        interval = interval + cashFlow;
                        sum = interval + sum;
                    }

                    paybackPeriod = Math.Round(double.Parse(tbInvest.Text) / cashFlow);

                    switch (paybackPeriod)
                    {
                        case 0:
                            result = "Меньше месяца";
                            break;
                        case 1:
                            result = "Один месяц";
                            break;
                        case 2:
                            result = "Два месяца";
                            break;
                        case 3:
                            result = "Три месяца";
                            break;
                        case 4:
                            result = "Четыре месяца";
                            break;
                        case 5:
                            result = "Пять месяцев";
                            break;
                        case 6:
                            result = "Шесть месяцев";
                            break;
                        case 7:
                            result = "Семь месяцев";
                            break;
                        case 8:
                            result = "Восемь месяцев";
                            break;
                        case 9:
                            result = "Девять месяцев";
                            break;
                        case 10:
                            result = "Десять месяцев";
                            break;
                        case 11:
                            result = "Одиннадцать месяцев";
                            break;
                        case 12:
                            result = "Один год";
                            break;
                    }

                    if (paybackPeriod > 12)
                    {
                        result = "Больше года";
                    }
                    MessageBox.Show("Рассчёт выполнен!");

                    try
                    {
                        PaybackPeriod payback = new PaybackPeriod()
                        {
                            Month = month,
                            Investment = investment,
                            CashFlow = cashFlow,
                            Result = result,
                        };
                        using (SQLiteConnection connection = new SQLiteConnection(App.dbPath))
                        {
                            connection.CreateTable<PaybackPeriod>();
                            connection.Insert(payback);
                        }

                        LastActivity lastActivity = new LastActivity()
                        {
                            ActivityId = payback.Id,
                            ActivityType = 1,
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
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Вы ввели символ! Пожалуйста,введите цифрy");
            }
        }

        private void onClearPage(object sender, RoutedEventArgs e)
        {
            tbCashFlow.Text = "";
            tbInvest.Text = "";
            monthComboBox.SelectedIndex = 0;
            itogPP.Text = "";
        }

        private void monthComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            month = monthComboBox.SelectedIndex + 1;
        }
    }
}
