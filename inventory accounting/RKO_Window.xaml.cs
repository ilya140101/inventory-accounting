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
    /// Логика взаимодействия для RKO_Window.xaml
    /// </summary>
    public partial class RKO_Window : Window
    {
        public Database database;
        public Report report;
        public bool flag = false;
        public RKO_Window(Database database, Report report)
        {
            InitializeComponent();
            this.database = database;
            this.report = report;
            this.Title = "Расходный кассовый ордер (" + report.DateString + ")";
            this.Summ.Text = report.Summ.ToString();
            comboBox.ItemsSource = database.RKO_Types;
            comboBox.DisplayMemberPath = "Type";
            if (!(report.Type is null))
                comboBox.SelectedItem = database.RKO_Types.Find((x) => x.Type == report.Type.Type);
            Icon = database.RKO_Image;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Нужно выбрать тип списания", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Summ.Text == "" || Convert.ToDouble(Summ.Text)<=0)
            {
                MessageBox.Show("Нужно ввести сумму", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            flag = true;
            report.Summ = Convert.ToDouble(Summ.Text);
            report.Type = database.RKO_Types.Find((x) => x.Type == comboBox.Text);
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

    }
}
