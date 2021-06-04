using System.Windows;
using inventory_accounting_Library;
namespace inventory_accounting
{
    /// <summary>
    /// Логика взаимодействия для Entrance.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {

        public Report report { get; set; }
        public ReportWindow(Database database, Report report)
        {
            InitializeComponent();
            this.report = report;
            string text = string.Empty;
            switch (report.ReportType)
            {
                case Database.Reports.Entrance: text = "Поступление за "; Icon = database.Entrance_Image; break;
                case Database.Reports.Sales: text = "Отчет продаж за "; Icon = database.Sales_Image; break;
                case Database.Reports.Debiting: text = "Списание за "; Icon = database.Debiting_Image; break;
            }
            this.Title = text;

            this.Title += report.Date.ToShortDateString();
            BigTable.setList(database, report);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double _height = SystemParameters.PrimaryScreenHeight;
            double _width = SystemParameters.PrimaryScreenWidth;
            //this.BigTable.table.Height = 0.75 * Height;
            //this.Height = 0.75 *_height;
            //this.Width=0.75*_width;
        }
    }
}
