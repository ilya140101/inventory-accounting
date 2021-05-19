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
            table.KeyDeleted += deleted;
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

            this.selectionWindow.Closing += async (Nomenclature, args) =>
            {
                if (this.selectionWindow.flag==false)
                {
                    var tmp = MessageBox.Show("Перенести отобранные позиции в отчет?", "", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                    if (tmp == MessageBoxResult.Yes)
                    {
                        this.selectionWindow.flag = true;
                    }
                    if (tmp == MessageBoxResult.Cancel)
                    {
                        args.Cancel = true;
                        return;
                    }
                    
                }
                if (this.selectionWindow.flag == true)
                    foreach (Product item in this.selectionWindow.AddProducts)
                    {
                        int index;
                        int code = item.Code;
                        index = await Task.Run(() => Products.FindIndex(x => x.Code == code));
                        if (index == -1)
                            Products.Add(item);
                        else
                            Products[index] += item;
                    }
               

                table.table.Items.Refresh();
                this.selectionWindow = null;
            };
        }
        public void deleted(Object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                if (MessageBox.Show("Вы действительно хотите удалить элемент из таблицы?", "", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    var item = (sender as DataGridCell).DataContext as Product;
                    Products.Remove(item);
                    table.table.Items.Refresh();
                }
            }
        }
    }
}
