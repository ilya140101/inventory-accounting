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
    /// Логика взаимодействия для Nomenclature.xaml
    /// </summary>
    public partial class Nomenclature : Window
    {

        public Nomenclature(List<Product> Products)
        {
            InitializeComponent();          
            table.setList(Products);
            table.table.Columns[5].Visibility = Visibility.Collapsed;
            table.table.Columns[6].Visibility = Visibility.Collapsed;
            table.table.Columns[7].Visibility = Visibility.Collapsed;
            
        }
       

    }
}
