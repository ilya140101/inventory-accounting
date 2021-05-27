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
    public partial class Report : Window
    {
        public Report(List<Product> Products, Database database, DateTime date, Database.Reports reports)
        {
            InitializeComponent();
            //double _height = SystemParameters.PrimaryScreenHeight;
            //double _width = SystemParameters.PrimaryScreenWidth;
            //this.Height = 0.7 * _height;
            //this.Width = 0.7 * _width;
            if (reports == Database.Reports.Entrance)
                this.Title = "Поступление за ";
            if (reports == Database.Reports.Sales)
                this.Title = "Отчет продаж за ";
            if (reports == Database.Reports.Debiting)
                this.Title = "Списание за ";

            this.Title += date.ToShortDateString();
            BigTable.setList(Products, database, date, reports);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double _height = SystemParameters.PrimaryScreenHeight;
            double _width = SystemParameters.PrimaryScreenWidth;
            //this.BigTable.table.Height = 0.75 * Height;
            this.Height = 0.75 *_height;
            this.Width=0.75*_width;
        }
    }
}
