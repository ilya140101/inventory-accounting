using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace inventory_accounting
{
    /// <summary>
    /// Логика взаимодействия для SelectingQuantity.xaml
    /// </summary>
    public partial class SelectingQuantity : Window
    {
        public Product item;
        public bool flag = false;
        public SelectingQuantity(Product item)
        {
            InitializeComponent();
            this.item = item;
            SalePrice.Text = item.SalePrice.ToString();
            Count.Text = "1";
            Summ.Text = item.SalePrice.ToString();
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
            Summ.Text = (Convert.ToDouble(text) * item.SalePrice - Convert.ToDouble(Discount.Text)).ToString();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Count.Text))
                Button_Click(sender, e);
            if (Convert.ToDouble(Count.Text) > item.Quantity)
            {
                MessageBox.Show("Кол-во товара не может привышать остаток на складе.", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            item = new Product(item.Code, item.Name, Convert.ToDouble(Count.Text), item.PurchasePrice, item.SalePrice, Convert.ToDouble(Discount.Text));
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

        private void Discount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (item is null || !(sender is TextBox tbx))
                return;
            if (string.IsNullOrWhiteSpace(tbx.Text))
            {
                Summ.Text = (Convert.ToDouble(Count.Text) * item.SalePrice).ToString();
                return;
            }
            string text = tbx.Text;
            Summ.Text = (Convert.ToDouble(Count.Text) * item.SalePrice - Convert.ToDouble(text)).ToString();
        }

        private void Summ_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (item is null || !(sender is TextBox tbx))
                return;
            if (string.IsNullOrWhiteSpace(tbx.Text))
            {
                Discount.Text = (Convert.ToDouble(Count.Text) * item.SalePrice).ToString();
                return;
            }
            string text = tbx.Text;
            Discount.Text = (Convert.ToDouble(Count.Text) * item.SalePrice - Convert.ToDouble(text)).ToString();
        }

        private void NewLostFocus(object sender, RoutedEventArgs e)
        {
            if (item is null || !(sender is TextBox tbx))
                return;
            if (string.IsNullOrWhiteSpace(tbx.Text))
                tbx.Text = "0";
        }
    }
}




