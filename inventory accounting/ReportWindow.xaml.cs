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
    /// Логика взаимодействия для Entrance.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        Database database;
        public ReportWindow( Database database, Report report)
        {
            InitializeComponent();
            this.database = database;
            if (report.ReportType == Database.Reports.Entrance)
            {
                this.Title = "Поступление за ";
               
            }
            if (report.ReportType == Database.Reports.Sales)
                this.Title = "Отчет продаж за ";
            if (report.ReportType == Database.Reports.Debiting)
                this.Title = "Списание за ";

            this.Title += report.Date.ToShortDateString();
            BigTable.setList(database,report);

            switch (report.ReportType)
            {
                case Database.Reports.Sales: Icon = database.Sales_Image;break;
                case Database.Reports.Entrance: Icon = database.Entrance_Image;break;
                case Database.Reports.Debiting: Icon = database.Debiting_Image;break;
            }


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
