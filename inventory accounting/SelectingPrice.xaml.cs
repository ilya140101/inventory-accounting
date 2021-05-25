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
    /// Логика взаимодействия для SelectingPrice.xaml
    /// </summary>

    public partial class SelectingPrice : Window
    {
        public Product item;
        public bool flag = false;
        public SelectingPrice(Product item)
        {
            InitializeComponent();
            this.item = item;
            Sale.Text = item.SalePrice.ToString();
            Count.Text = "1";
            Purchase.Text = item.PurchasePrice.ToString();
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



        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Count.Text))
                Button_Click(sender, e);
            item = new Product(item.Code, item.Name, Convert.ToDouble(Count.Text), Convert.ToDouble(Purchase.Text), Convert.ToDouble(Sale.Text));
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

        private void Sale_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (item is null || !(sender is TextBox tbx) || string.IsNullOrWhiteSpace(Purchase.Text) || !Sale.IsFocused)
                return;
            if (string.IsNullOrWhiteSpace(tbx.Text))
            {
                Profit.Text = "-100%";
                return;
            }
            string text = tbx.Text;
            double sale = Convert.ToDouble(Sale.Text);
            double purchase = Convert.ToDouble(Purchase.Text);
            Profit.Text = String.Format("{0:0.00}", ((sale - purchase) / purchase * 100)) + "%";

        }

        private void Profit_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (item is null || !(sender is TextBox tbx) || !Profit.IsFocused || Profit.Text.StartsWith("%"))
                return;
            if (string.IsNullOrWhiteSpace(tbx.Text))
            {
                Sale.Text = "0";
                return;
            }
            string text = Profit.Text;


            Sale.Text = String.Format("{0:0.00}", (Convert.ToDouble(Purchase.Text) * (1 + Convert.ToDouble(Profit.Text.Replace("%", "")) / 100)));

        }

        private void Purchase_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (item is null || !(sender is TextBox tbx))
                return;
            if (string.IsNullOrWhiteSpace(tbx.Text))
            {
                Sale.Text = "0";
                return;
            }
            string text = tbx.Text;
            double purchase = Convert.ToDouble(Purchase.Text);
            Sale.Text = String.Format("{0:0.00}", (purchase * (1 + (item.SalePrice - item.PurchasePrice) / item.PurchasePrice)));
            Profit.Text = String.Format("{0:0.00}", ((item.SalePrice - item.PurchasePrice) / item.PurchasePrice * 100)) + "%";
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
