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
            if (reports == Database.Reports.Entrance)
                this.Title = "Поступление за ";
            if (reports == Database.Reports.Sales)
                this.Title = "Отчет продаж за ";
            if (reports == Database.Reports.Debiting)
                this.Title = "Списание за ";

            this.Title += date.ToShortDateString();
            BigTable.setList(Products, database, date, reports);
        }
    }
}
