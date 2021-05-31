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
using System.Windows.Shapes;

namespace inventory_accounting
{
    /// <summary>
    /// Логика взаимодействия для ReportTable.xaml
    /// </summary>
    public partial class ReportTable : Window
    {
        Database database;
        public ReportTable(Database database)
        {
            InitializeComponent();
            this.Icon = new BitmapImage(new Uri("../../Images/books.png", UriKind.Relative));
            this.database = database;
            table.ItemsSource = database.Report;
        }
        private void Row_DoubleClick(object sender, RoutedEventArgs e)
        {
            if (!((sender as DataGridCell).DataContext is Report item))
                return;

            item.Products = database.GetProducts(item.Number);
            ReportWindow reportWindow = new ReportWindow(database, item);
            reportWindow.Show(); 

            reportWindow.Closing += ReportWindow_Closing;
           
        }

        private void ReportWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            table.Items.Refresh();
        }

        private void Row_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void AddNewReport_Click(object sender, RoutedEventArgs e)
        {
            AddNewReport addNewReport = new AddNewReport();
            addNewReport.ShowDialog();
            if (addNewReport.flag)
            {
                database.Report.Add(new Report(database.nextNumber(), addNewReport.datePicker.SelectedDate.Value, (Database.Reports)addNewReport.comboBox.SelectedIndex, 0));
                database.addNewReport(database.Report.Last());               
                database.Report.Sort((x, y) => x.Date.CompareTo(y.Date));
                table.Items.Refresh();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
