using System;
using System.Windows;
using System.Windows.Media.Imaging;
using inventory_accounting_Library;

namespace inventory_accounting
{
    /// <summary>
    /// Логика взаимодействия для Nomenclature.xaml
    /// </summary>
    public partial class Nomenclature : Window
    {
        private Database database;
        public Nomenclature(Database database)
        {
            InitializeComponent();
            this.database = database;
            settings();
        }
        private void settings()
        {
            table.setList(database.Products);
            table.table.Columns[5].Visibility = Visibility.Collapsed;
            table.table.Columns[6].Visibility = Visibility.Collapsed;
            table.table.Columns[7].Visibility = Visibility.Collapsed;
            table.table.Columns[8].Visibility = Visibility.Collapsed;
            table.find_Summ.Visibility = Visibility.Collapsed;
            table.find_Discount.Visibility = Visibility.Collapsed;
            table.find_SummDiscount.Visibility = Visibility.Collapsed;
            table.find_SummPurchase.Visibility = Visibility.Collapsed;
            this.Icon = new BitmapImage(new Uri("../../Images/nom.png", UriKind.Relative));
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddNewItem addNewItem = new AddNewItem(database);
            addNewItem.ShowDialog();
            if (addNewItem.flag)
            {
                database.addNewItem(addNewItem.item);
                database.Products.Add(addNewItem.item);
                database.Products.Sort((x, y) => x.Name.CompareTo(y.Name));
                table.table.Items.Refresh();
                table.table.ScrollIntoView(addNewItem.item);
                table.table.SelectedItem = addNewItem.item;
            }
        }
    }
}
