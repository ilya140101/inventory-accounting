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
        public Sales(List<Product> Products, Database database)
        {
            InitializeComponent();
            this.Products = Products;
            this.database = database;
            table.setList(Products);
            table.table.Columns[3].Visibility = Visibility.Collapsed;
            table.find_purchasePrice.Visibility = Visibility.Collapsed;
        }

        private void selection_Click(object sender, RoutedEventArgs e)
        {
            if (this.selectionWindow == null)
            {
                selectionWindow = new SelectionWindow(database.Products);
                selectionWindow.Show();
            }
            else
                selectionWindow.Focus();
            
            this.selectionWindow.Closing += (Nomenclature, args) => {
                if(this.selectionWindow.flag)
                Products.AddRange(this.selectionWindow.AddProducts);
                table.table.Items.Refresh();
                this.selectionWindow = null;
                };
        }
    }
}
