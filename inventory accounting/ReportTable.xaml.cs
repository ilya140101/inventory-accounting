using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
namespace inventory_accounting
{
    /// <summary>
    /// Логика взаимодействия для ReportTable.xaml
    /// </summary>
    public partial class ReportTable : Window
    {
        private Database database;
        private List<Report> Reports { get; set; }
        private DateTime LeftDate { get; set; }
        private DateTime RightDate { get; set; }
        public ReportTable(Database database)
        {
            InitializeComponent();
            this.Icon = new BitmapImage(new Uri("../../Images/books.png", UriKind.Relative));
            this.database = database;
            createDate();


        }
        private void createDate()
        {
            DateTime now = DateTime.Now;
            LeftDate = new DateTime(now.Year, now.Month, 1);
            RightDate = now;
            ChangeDate();
        }
        private async void ChangeDate()
        {
            Title = "Общий журнал документов (" + LeftDate.ToShortDateString() + "-" + RightDate.ToShortDateString() + ")";
            await Task.Run(() => Reports = database.GetReport(LeftDate, RightDate));
            table.ItemsSource = Reports;
        }
        private void Row_DoubleClick(object sender, RoutedEventArgs e)
        {
            if (!((sender as DataGridCell).DataContext is Report item))
                return;

            if (item.ReportType == Database.Reports.RKO)
            {
                RKO_Window RKO = new RKO_Window(database, item);
                RKO.Owner = this;
                RKO.Show();
                RKO.Closing += RKO_Closing;
            }
            else
            {
                item.Products = database.GetProducts(item.Number);
                ReportWindow reportWindow = new ReportWindow(database, item);
                reportWindow.Show();
                reportWindow.Closing += ReportWindow_Closing;
            }
        }

        private void RKO_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if ((sender as RKO_Window ).flag == true)
            {
                Report report = (sender as RKO_Window).report;
                database.updateReport(report);
                report.ReportTypeString = "РКО" + "(" + report.Type.Type + ")";
                update();
            }
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
                if (report.Date <= RightDate && report.Date >= LeftDate)
                    Reports.Add(report);
                update();
                table.ScrollIntoView(report);
                table.SelectedItem = report;

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
                    Reports.Remove(item);
                    update();
                }
            }
        }

        private void DateInterval_Click(object sender, RoutedEventArgs e)
        {
            DateInterval dateInterval = new DateInterval(LeftDate, RightDate);
            dateInterval.Owner = this;
            if (dateInterval.ShowDialog() == false)
                return;

            LeftDate = (DateTime)dateInterval.LeftDate.SelectedDate;
            RightDate = (DateTime)dateInterval.RightDate.SelectedDate;
            ChangeDate();

        }
    }
}
