using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для SelectingQuantity.xaml
    /// </summary>
    public partial class SelectingQuantity : Window
    {
        public Product item;       
        public bool flag=false;
        public SelectingQuantity(Product item)
        {
            InitializeComponent();
            this.item = item;
            SalePrice.Text = item.SalePrice.ToString();
            Count.Text = "1";
            Summ.Text= item.SalePrice.ToString();
            Name.Text = item.Name;
            Count.Focus();
            Count.SelectAll();
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            flag = false;
            this.Close();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Count_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (item is null || !(sender is TextBox tbx) || string.IsNullOrWhiteSpace(tbx.Text))
                return;
            string text = tbx.Text;
            Summ.Text = (Convert.ToDouble(text)*item.SalePrice).ToString();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            item = new Product(item.Code, item.Name, Convert.ToDouble(Count.Text), item.PurchasePrice, item.SalePrice);
            flag = true;
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                OK_Click(sender, e);
            if (e.Key == Key.Escape)
                Button_Click(sender, e);
        }
    }
}




