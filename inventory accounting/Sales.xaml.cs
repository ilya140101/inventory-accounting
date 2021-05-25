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
    /// Логика взаимодействия для Sales.xaml
    /// </summary>
    public partial class Sales : Window
    {
        SelectionWindow selectionWindow;
        List<Product> Products;
        Database database;
        DateTime date;
        private double Summ { get; set; }
        public Sales(List<Product> Products, Database database, DateTime date)
        {
            InitializeComponent();
            this.Title = "Отчет продаж за " + date.ToShortDateString();
            BigTable.setList(Products, database, date,Database.Reports.Sales);

        }


    }
}
