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

        public Database database;
        public List<Product> Products;
        public Nomenclature(Database database)
        {
            InitializeComponent();
            this.database = database;
            Products = database.Products;
            table.ItemsSource = Products;
        }
        private void Find_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tbx)
                tbx.Text = string.Empty;
        }
        private void Find_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!(sender is TextBox tbx))
                return;
            string text = string.Empty;
            switch (tbx.Name)
            {
                case "find_code": text = "Код"; break;
                case "find_name": text = "Наименование"; break;
                case "find_quantity": text = "Количество"; break;
                case "find_salePrice": text = "Розница"; break;
                case "find_purchasePrice": text = "Закупка"; break;
            }
            tbx.Text = text;
        }

        private void SelectItem(Product item)
        {
            if (item is null)
                return;
            table.SelectedItem = item;
            table.ScrollIntoView(item);
        }




        private async void Find_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (database is null || !(sender is TextBox tbx) || string.IsNullOrWhiteSpace(tbx.Text))
                return;
            string text = tbx.Text;
            var item = await Task.Run(() => database.findItem("Name", text));
            if (item is null)
                return;
            SelectItem(item);
        }

        private async void Find_code_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (database is null || !(sender is TextBox tbx) || !int.TryParse(tbx.Text, out int number))
                return;
            string text = tbx.Text;            
            var item = await Task.Run(() =>database.findItem("Code", text) );           
            SelectItem(item);
        }


        private async void Find_quantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (database is null || !(sender is TextBox tbx) || !double.TryParse(tbx.Text, out double number))
                return;
            string text = tbx.Text;
            var item = await Task.Run(() => database.findItem("Quantity", text));            
            SelectItem(item);
        }

        private async void Find_purchasePrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (database is null || !(sender is TextBox tbx) || !double.TryParse(tbx.Text, out double number))
                return;
            string text = tbx.Text;
            var item = await Task.Run(() => database.findItem("PurchasePrice", text));
           SelectItem(item);
        }

        private async void Find_salePrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (database is null || !(sender is TextBox tbx) || !double.TryParse(tbx.Text, out double number))
                return;
            string text = tbx.Text;
            var item = await Task.Run(() => database.findItem("SalePrice", text));          
            SelectItem(item);
        }
    }
}
