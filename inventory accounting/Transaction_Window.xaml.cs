using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace inventory_accounting
{
    /// <summary>
    /// Логика взаимодействия для Transaction_Window.xaml
    /// </summary>
    public partial class Transaction_Window : Window
    {
        public Database database;
        public Report report;
        public bool flag = false;
        public Transaction_Window(Database database, Report report)
        {
            InitializeComponent();
            this.database = database;
            this.report = report;
            comboBox.DisplayMemberPath = "Type";
            if (report.ReportType == Database.Reports.RKO) // Расходный
            {
                this.Title = "Расходный кассовый ордер ";
                comboBox.ItemsSource = database.RKO_Types;
                Icon = database.RKO_Image;
                if (!(report.Type is null))
                    comboBox.SelectedItem = database.RKO_Types.Find((x) => x.Type == report.Type.Type);
            }
            else// приходный
            {
                this.Title = "Приходный кассовый ордер ";
                comboBox.ItemsSource = database.PKO_Types;
                Icon = database.PKO_Image;
                if (!(report.Type is null))
                    comboBox.SelectedItem = database.PKO_Types.Find((x) => x.Type == report.Type.Type);
            }
            Title += "(" + report.DateString + ")";
            this.Summ.Text = report.Summ.ToString();



        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Нужно выбрать тип транзакции", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Summ.Text == "" || Convert.ToDouble(Summ.Text) <= 0)
            {
                MessageBox.Show("Нужно ввести сумму", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            flag = true;
            report.Summ = Convert.ToDouble(Summ.Text);
            if (report.ReportType == Database.Reports.RKO)
                report.Type = database.RKO_Types.Find((x) => x == comboBox.SelectedItem);
            else
                report.Type = database.PKO_Types.Find((x) => x == comboBox.SelectedItem);
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            flag = false;
            Close();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            EditTransactionType editTransactionType = new EditTransactionType(database, report);
            editTransactionType.Owner = this;
            editTransactionType.ShowDialog();
            database.updateTransactionType(report);
            
        }
    }
}
