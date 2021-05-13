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
        public Nomenclature(Database database)
        {
            InitializeComponent();
            this.database = database;
            tableSettings();
            addingEvents();

        }
        private void tableSettings()
        {

            table.IsReadOnly = true;
            table.CanUserAddRows = false;
            table.CanUserDeleteRows = false;
            table.AutoGenerateColumns = false;
            table.ItemsSource = database.Products;
        }
        private void addingEvents()
        {
            find_code.GotFocus += Find_GotFocus;
            find_name.GotFocus += Find_GotFocus;
            find_quantity.GotFocus += Find_GotFocus;
            find_salePrice.GotFocus += Find_GotFocus;
            find_purchasePrice.GotFocus += Find_GotFocus;

            find_code.LostFocus += Find_LostFocus;
            find_name.LostFocus += Find_LostFocus;
            find_quantity.LostFocus += Find_LostFocus;
            find_salePrice.LostFocus += Find_LostFocus;
            find_purchasePrice.LostFocus += Find_LostFocus;
        }



        private void Find_GotFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Name == "find_code")
                find_code.Text = "";
            if ((sender as TextBox).Name == "find_name")
                find_name.Text = "";
            if ((sender as TextBox).Name == "find_quantity")
                find_quantity.Text = "";
            if ((sender as TextBox).Name == "find_salePrice")
                find_salePrice.Text = "";
            if ((sender as TextBox).Name == "find_purchasePrice")
                find_purchasePrice.Text = "";

        }

        private void Find_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!(sender is TextBox tbx))
                return;
            string text = null;
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

        //private  void Find_name_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (find_name == null || database == null)
        //        return;
        //    var tmp = database.Products.Where(x => x.Name.StartsWith(find_name.Text, StringComparison.OrdinalIgnoreCase)).ToList();
        //    if (tmp.Count == 0)
        //    {
        //        return;
        //    }
        //    table.ScrollIntoView(tmp[0]);
        //    table.SelectedIndex = table.Items.IndexOf(tmp[0]);
        //}
        private void Find_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (database is null || !(sender is TextBox tbx) || string.IsNullOrWhiteSpace(tbx.Text))
                return;
            var item = database.Products.Find(x => x.Name.StartsWith(tbx.Text, StringComparison.OrdinalIgnoreCase));
            if (item is null)
                return;
            table.SelectedIndex = database.Products.IndexOf(item);
            table.ScrollIntoView(item); 
        }

        private void Find_code_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (find_code == null || database == null)
                    return;
                var tmp = database.Products.Where(x => x.Code.ToString().StartsWith(find_code.Text, StringComparison.OrdinalIgnoreCase)).ToList();

                if (tmp.Count == 0)
                {
                    return;
                }
                tmp.Sort((x, y) => x.Code.CompareTo(y.Code));
                table.ScrollIntoView(tmp[0]);
                table.SelectedIndex = table.Items.IndexOf(tmp[0]);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        private void Find_quantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (find_quantity == null || database == null)
                return;
            var tmp = database.Products.Where(x => x.Quantity.ToString().StartsWith(find_quantity.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            if (tmp.Count == 0) return;
            tmp.Sort((x, y) => x.Quantity.CompareTo(y.Quantity));
            table.ScrollIntoView(tmp[0]);
            table.SelectedIndex = table.Items.IndexOf(tmp[0]);
        }

        private void Find_purchasePrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (find_purchasePrice == null || database == null)
                return;
            var tmp = database.Products.Where(x => x.PurchasePrice.ToString().StartsWith(find_purchasePrice.Text, StringComparison.OrdinalIgnoreCase)).ToList();

            if (tmp.Count == 0)
            {
                return;
            }
            tmp.Sort((x, y) => x.PurchasePrice.CompareTo(y.PurchasePrice));
            table.ScrollIntoView(tmp[0]);
            table.SelectedIndex = table.Items.IndexOf(tmp[0]);
        }

        private void Find_salePrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (find_salePrice == null || database == null)
                return;
            var tmp = database.Products.Where(x => x.SalePrice.ToString().StartsWith(find_salePrice.Text, StringComparison.OrdinalIgnoreCase)).ToList();

            if (tmp.Count == 0)
            {
                return;
            }
            tmp.Sort((x, y) => x.SalePrice.CompareTo(y.SalePrice));
            table.ScrollIntoView(tmp[0]);
            table.SelectedIndex = table.Items.IndexOf(tmp[0]);
        }
    }
}
