using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using inventory_accounting_Library;
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
                case "find_Summ": text = "Без скидки"; break;
                case "find_Discount": text = "Скидка"; break;
                case "find_SummPurchase": text = "Сумма(Закуп.)"; break;
                case "find_SummDiscount": text = "Сумма"; break;
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


        private async void Find_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Products is null || !(sender is TextBox tbx) || !double.TryParse(tbx.Text, out double number))
                return;
            string text = tbx.Text;
            string name = tbx.Name;
            var item = await Task.Run(() => findItem(name, text));
            SelectItem(item);
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

        public Product findItem(string type, string text)
        {
            try
            {
                switch (type)
                {

                    case "Name": return this.Products.Find(x => x.Name.StartsWith(text, StringComparison.OrdinalIgnoreCase));
                    case "find_code":
                        {
                            //var tmp = this.Products.Where(x => x.Code.ToString().StartsWith(text, StringComparison.OrdinalIgnoreCase)).ToList();
                            //if (tmp.Count == 0)
                            //    return null;
                            //tmp.Sort((x, y) => x.Code.CompareTo(y.Code));
                            //return tmp.First();

                            List<Product> tmp = new List<Product>(this.Products);
                            tmp.Sort((x, y) => x.Code.CompareTo(y.Code));
                            var item = tmp.Find((x) => x.Code.ToString().StartsWith(text, StringComparison.OrdinalIgnoreCase));

                            if (item is null)
                                return null;
                            return item;
                        }
                    case "find_quantity":
                        {
                            //var tmp = this.Products.Where(x => x.Quantity.ToString().StartsWith(text, StringComparison.OrdinalIgnoreCase)).ToList();
                            //if (tmp.Count == 0)
                            //    return null;
                            //tmp.Sort((x, y) => x.Quantity.CompareTo(y.Quantity));
                            //return tmp.First();
                            List<Product> tmp = new List<Product>(this.Products);
                            tmp.Sort((x, y) => x.Quantity.CompareTo(y.Quantity));
                            var item = tmp.Find((x) => x.Quantity.ToString().StartsWith(text, StringComparison.OrdinalIgnoreCase));
                            if (item is null)
                                return null;
                            return item;
                        }
                    case "find_purchasePrice":
                        {
                            //var tmp = this.Products.Where(x => x.PurchasePrice.ToString().StartsWith(text, StringComparison.OrdinalIgnoreCase)).ToList();
                            //if (tmp.Count == 0)
                            //    return null;
                            //tmp.Sort((x, y) => x.PurchasePrice.CompareTo(y.PurchasePrice));
                            //return tmp.First();
                            List<Product> tmp = new List<Product>(this.Products);
                            tmp.Sort((x, y) => x.PurchasePrice.CompareTo(y.PurchasePrice));
                            var item = tmp.Find((x) => x.PurchasePrice.ToString().StartsWith(text, StringComparison.OrdinalIgnoreCase));
                            if (item is null)
                                return null;
                            return item;
                        }
                    case "find_salePrice":
                        {
                            //var tmp = this.Products.Where(x => x.SalePrice.ToString().StartsWith(text, StringComparison.OrdinalIgnoreCase)).ToList();
                            //if (tmp.Count == 0)
                            //    return null;
                            //tmp.Sort((x, y) => x.SalePrice.CompareTo(y.SalePrice));
                            //return tmp.First();
                            List<Product> tmp = new List<Product>(this.Products);
                            tmp.Sort((x, y) => x.SalePrice.CompareTo(y.SalePrice));
                            var item = tmp.Find((x) => x.SalePrice.ToString().StartsWith(text, StringComparison.OrdinalIgnoreCase));
                            if (item is null)
                                return null;
                            return item;
                        }
                    case "find_Summ":
                        {
                            //var tmp = this.Products.Where(x => x.Summ.ToString().StartsWith(text, StringComparison.OrdinalIgnoreCase)).ToList();
                            //if (tmp.Count == 0)
                            //    return null;
                            //tmp.Sort((x, y) => x.Summ.CompareTo(y.Summ));
                            //return tmp.First();
                            List<Product> tmp = new List<Product>(this.Products);
                            tmp.Sort((x, y) => x.Summ.CompareTo(y.Summ));
                            var item = tmp.Find((x) => x.Summ.ToString().StartsWith(text, StringComparison.OrdinalIgnoreCase));
                            if (item is null)
                                return null;
                            return item;
                        }
                    case "find_Discount":
                        {
                            //var tmp = this.Products.Where(x => x.Discount.ToString().StartsWith(text, StringComparison.OrdinalIgnoreCase)).ToList();
                            //if (tmp.Count == 0)
                            //    return null;
                            //tmp.Sort((x, y) => x.Discount.CompareTo(y.Discount));
                            //return tmp.First();
                            List<Product> tmp = new List<Product>(this.Products);
                            tmp.Sort((x, y) => x.Discount.CompareTo(y.Discount));
                            var item = tmp.Find((x) => x.Discount.ToString().StartsWith(text, StringComparison.OrdinalIgnoreCase));
                            if (item is null)
                                return null;
                            return item;
                        }
                    case "find_SummPurchase":
                        {
                            //var tmp = this.Products.Where(x => x.SummPurchase.ToString().StartsWith(text, StringComparison.OrdinalIgnoreCase)).ToList();
                            //if (tmp.Count == 0)
                            //    return null;
                            //tmp.Sort((x, y) => x.SummPurchase.CompareTo(y.SummPurchase));
                            //return tmp.First();
                            List<Product> tmp = new List<Product>(this.Products);
                            tmp.Sort((x, y) => x.SummPurchase.CompareTo(y.SummPurchase));
                            var item = tmp.Find((x) => x.SummPurchase.ToString().StartsWith(text, StringComparison.OrdinalIgnoreCase));
                            if (item is null)
                                return null;
                            return item;
                        }
                    case "find_SummDiscount":
                        {
                            //var tmp = this.Products.Where(x => x.SummDiscount.ToString().StartsWith(text, StringComparison.OrdinalIgnoreCase)).ToList();
                            //if (tmp.Count == 0)
                            //    return null;
                            //tmp.Sort((x, y) => x.SummDiscount.CompareTo(y.SummDiscount));
                            //return tmp.First();
                            List<Product> tmp = new List<Product>(this.Products);
                            tmp.Sort((x, y) => x.SummDiscount.CompareTo(y.SummDiscount));
                            var item = tmp.Find((x) => x.SummDiscount.ToString().StartsWith(text, StringComparison.OrdinalIgnoreCase));
                            if (item is null)
                                return null;
                            return item;
                        }

                }
            }
            catch (Exception ex)
            {
                string writePath = "log.txt";
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(ex.Message);
                }
            }
            return null;
        }


    }
}
