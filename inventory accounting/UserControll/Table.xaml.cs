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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace inventory_accounting
{
    /// <summary>
    /// Логика взаимодействия для Table.xaml
    /// </summary>
    public partial class Table : UserControl
    {
        public List<Product> Products;
        public event RoutedEventHandler DClick;
        public event KeyEventHandler KeyDeleted;
        public Table()
        {
            InitializeComponent();
           
          
            
        }
        private void Row_DoubleClick(object sender, RoutedEventArgs e)
        {
            try
            {
                DClick(sender, e);
            }
            catch
            {

            }
        }
       
        private void Row_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
               KeyDeleted(sender, e);
            }
            catch
            {

            }
        }
        public void setList(List<Product> Products)
        {
            table.ItemsSource = Products;
            this.Products = Products;
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
            if (Products is null || !(sender is TextBox tbx) || string.IsNullOrWhiteSpace(tbx.Text))
                return;
            string text = tbx.Text;
            var item = await Task.Run(() => findItem("Name", text));
            if (item is null)
                return;
            SelectItem(item);
        }

        private async void Find_code_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Products is null || !(sender is TextBox tbx) || !int.TryParse(tbx.Text, out int number))
                return;
            string text = tbx.Text;
            var item = await Task.Run(() => findItem("Code", text));
            SelectItem(item);
        }


        private async void Find_quantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Products is null || !(sender is TextBox tbx) || !double.TryParse(tbx.Text, out double number))
                return;
            string text = tbx.Text;
            var item = await Task.Run(() => findItem("Quantity", text));
            SelectItem(item);
        }

        private async void Find_purchasePrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Products is null || !(sender is TextBox tbx) || !double.TryParse(tbx.Text, out double number))
                return;
            string text = tbx.Text;
            var item = await Task.Run(() => findItem("PurchasePrice", text));
            SelectItem(item);
        }

        private async void Find_salePrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Products is null || !(sender is TextBox tbx) || !double.TryParse(tbx.Text, out double number))
                return;
            string text = tbx.Text;
            var item = await Task.Run(() => findItem("SalePrice", text));
            SelectItem(item);
        }
        public Product findItem(string type, string text)
        {
            try
            {
                switch (type)
                {

                    case "Name": return this.Products.Find(x => x.Name.StartsWith(text, StringComparison.OrdinalIgnoreCase));
                    case "Code":
                        {
                            var tmp = this.Products.Where(x => x.Code.ToString().StartsWith(text, StringComparison.OrdinalIgnoreCase)).ToList();
                            if (tmp.Count == 0)
                                return null;
                            tmp.Sort((x, y) => x.Code.CompareTo(y.Code));
                            return tmp.First();
                        }
                    case "Quantity":
                        {
                            var tmp = this.Products.Where(x => x.Quantity.ToString().StartsWith(text, StringComparison.OrdinalIgnoreCase)).ToList();
                            if (tmp.Count == 0)
                                return null;
                            tmp.Sort((x, y) => x.Quantity.CompareTo(y.Quantity));
                            return tmp.First();
                        }
                    case "PurchasePrice":
                        {
                            var tmp = this.Products.Where(x => x.PurchasePrice.ToString().StartsWith(text, StringComparison.OrdinalIgnoreCase)).ToList();
                            if (tmp.Count == 0)
                                return null;
                            tmp.Sort((x, y) => x.PurchasePrice.CompareTo(y.PurchasePrice));
                            return tmp.First();
                        }
                    case "SalePrice":
                        {
                            var tmp = this.Products.Where(x => x.SalePrice.ToString().StartsWith(text, StringComparison.OrdinalIgnoreCase)).ToList();
                            if (tmp.Count == 0)
                                return null;
                            tmp.Sort((x, y) => x.SalePrice.CompareTo(y.SalePrice));
                            return tmp.First();
                        }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        private void table_Sorting(object sender, DataGridSortingEventArgs e)
        {
            //table.Items.Refresh();
        }
    }
}
