using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using inventory_accounting_Library;

namespace inventory_accounting
{
    /// <summary>
    /// Логика взаимодействия для AddNewItem.xaml
    /// </summary>
    public partial class AddNewItem : Window
    {
        public Product item;
        public Database database;
        public bool flag = false;
        public AddNewItem(Database database)
        {
            InitializeComponent();
            this.database = database;
            Profit.Text = "100,00%";
            Random random = new Random();
            int code = random.Next(0,100000);
            while(database.Products.FindIndex((x)=>x.Code==code)!=-1)
                code = random.Next(0, 100000);
            Code.Text = code.ToString();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            flag = false;
            this.Close();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regexCode = new Regex("[^0-9]+");
            Regex regex = new Regex("[^0-9,]+");
            if ((sender as TextBox).Name == "Code")
                e.Handled = regexCode.IsMatch(e.Text);
            else
                e.Handled = regex.IsMatch(e.Text);
        }
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(Code.Text) || string.IsNullOrWhiteSpace(Name.Text) || string.IsNullOrWhiteSpace(Purchase.Text) || string.IsNullOrWhiteSpace(Sale.Text) || string.IsNullOrWhiteSpace(Profit.Text))
            {
                MessageBox.Show("Нужно заполнить все поля!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (database.Products.FindIndex((x)=>x.Code==Convert.ToInt32(Code.Text) || x.Name==Name.Text)!=-1)
            {
                MessageBox.Show("Элемент с таким кодом/именем уже существует!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            item = new Product(Convert.ToInt32(Code.Text), Name.Text, 0, Convert.ToDouble(Purchase.Text), Convert.ToDouble(Sale.Text));
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
            if (!(sender is TextBox tbx) || string.IsNullOrWhiteSpace(Purchase.Text) || !Sale.IsFocused)
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
            if ( !(sender is TextBox tbx) || !Profit.IsFocused || Profit.Text.StartsWith("%"))
                return;
            if (string.IsNullOrWhiteSpace(tbx.Text))
            {
                Sale.Text = "0";
                return;
            }
            string text = Profit.Text;

            if (string.IsNullOrWhiteSpace(Sale.Text) || string.IsNullOrWhiteSpace(Purchase.Text))
                return;

            Sale.Text = String.Format("{0:0.00}", (Convert.ToDouble(Purchase.Text) * (1 + Convert.ToDouble(Profit.Text.Replace("%", "")) / 100)));

        }

        private void Purchase_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(sender is TextBox tbx) || !(Profit is TextBox))
                return;
            if (string.IsNullOrWhiteSpace(tbx.Text) || string.IsNullOrWhiteSpace(Profit.Text))
            {
                Sale.Text = "0";
                return;
            }
            
            string text = tbx.Text;
            double purchase = Convert.ToDouble(Purchase.Text);
            double profit = Convert.ToDouble(Profit.Text.Replace("%", ""));
            Sale.Text = String.Format("{0:0.00}", (purchase *(1+profit/100)));
           
        }

        private void NewLostFocus(object sender, RoutedEventArgs e)
        {
            if (!(sender is TextBox tbx))
                return;

            if (string.IsNullOrWhiteSpace(tbx.Text))
                tbx.Text = "0";
        }
    }
}
