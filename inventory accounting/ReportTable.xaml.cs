using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using inventory_accounting_Library;
namespace inventory_accounting
{
    /// <summary>
    /// Логика взаимодействия для ReportTable.xaml
    /// </summary>
    public partial class ReportTable : Window
    {
        private Database database;
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
            (sender as ReportWindow).report.Products.Clear();
            update();
        }
        private void update()
        {
            table.Items.Refresh();
            table.Items.SortDescriptions.Clear();
        }
        private void AddNewReport_Click(object sender, RoutedEventArgs e)
        {
            AddNewReport addNewReport = new AddNewReport();
            addNewReport.ShowDialog();
            if (addNewReport.flag)
            {
                Report report = new Report(database.nextNumber(), addNewReport.datePicker.SelectedDate.Value, (Database.Reports)addNewReport.comboBox.SelectedIndex, 0);
                database.Report.Add(report);
                database.addNewReport(database.Report.Last());
                database.Report.Sort((x, y) => x.Date.CompareTo(y.Date));
                table.ScrollIntoView(report);
                table.SelectedItem = report;
                update();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Row_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                if (MessageBox.Show("Вы действительно хотите удалить отчет?", "", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    var item = (sender as DataGridCell).DataContext as Report;
                    try
                    {
                        List<Product> list = database.GetProducts(item.Number);
                        database.myConnection.Open();
                        foreach (Product product in list)
                            database.deleteReport(product, item.Number, item.ReportType);
                        database.deleteReport(item);
                    }
                    catch (Exception ex)
                    {
                        string writePath = "log.txt";
                        using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                        {
                            sw.WriteLine(ex.Message);
                        }
                    }
                    finally
                    {
                        database.myConnection.Close();
                    }
                    database.Report.Remove(item);
                    update();
                }
            }
        }
    }
}
