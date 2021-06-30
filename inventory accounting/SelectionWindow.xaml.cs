using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace inventory_accounting
{
    /// <summary>
    /// Логика взаимодействия для SelectionWindow.xaml
    /// </summary>
    public partial class SelectionWindow : Window
    {

        Database database;

        public double Summ { get; set; }
        public bool flag = false;
        public List<Product> AddProducts;
        public Database.Reports reports;
        public SelectionWindow(Database database, Database.Reports reports)
        {
            InitializeComponent();

            this.reports = reports;
            this.database = database;

            if (reports == Database.Reports.Entrance)
                Menu.Visibility = Visibility.Visible;
            Summ = 0;
            Summ_TextBox.DataContext = Summ;
            AddProducts = new List<Product>();
            settings();
            update();
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
                Selection.find_selection.table.Items.Refresh();
                Selection.find_selection.table.ScrollIntoView(addNewItem.item);
                Selection.find_selection.table.SelectedItem = addNewItem.item;
            }
        }


        private void settings()
        {
            Selection.find_selection.setList(database.Products);
            Selection.find_selection.DClick += select;
            Selection.selection.KeyDeleted += deleted;
            Selection.selection.setList(AddProducts);

            Selection.settings(reports);
        }
        private void update()
        {
            calculatingSumm();
            Summ_TextBox.Text = Summ.ToString();
            Selection.selection.table.Items.Refresh();
            Selection.selection.table.Items.SortDescriptions.Clear();
        }
        public void deleted(Object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                if (MessageBox.Show("Вы действительно хотите удалить элемент из таблицы?", "", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    var item = (sender as DataGridCell).DataContext as Product;
                    AddProducts.Remove(item);
                    update();
                }
            }
        }
        public void calculatingSumm()
        {
            Summ = 0;
            for (int i = 0; i < AddProducts.Count; i++)
                if (reports == Database.Reports.Sales)
                    Summ += AddProducts[i].SummDiscount;
                else
                    Summ += AddProducts[i].SummPurchase;
        }

        public async void select(Object sender, RoutedEventArgs e)
        {
            if (reports == Database.Reports.Sales || reports == Database.Reports.Debiting)
            {
                SelectingQuantity selecting = new SelectingQuantity((sender as DataGridCell).DataContext as Product);
                if (reports == Database.Reports.Debiting)
                {
                    selecting.Discount_text.Visibility = Visibility.Collapsed;
                    selecting.Discount.Visibility = Visibility.Collapsed;
                    selecting.Summ.Visibility = Visibility.Collapsed;
                    selecting.Summ_text.Visibility = Visibility.Collapsed;
                }
                selecting.ShowDialog();
                if (selecting.flag)
                {
                    int code = selecting.item.Code;
                    int index = await Task.Run(() => AddProducts.FindIndex(x => x.Code == selecting.item.Code));
                    if (index == -1)
                        AddProducts.Add(selecting.item);
                    else
                        AddProducts[index] += selecting.item;
                }

            }
            if (reports == Database.Reports.Entrance)
            {
                SelectingPrice selecting = new SelectingPrice((sender as DataGridCell).DataContext as Product);
                selecting.ShowDialog();
                if (selecting.flag)
                {
                    int code = selecting.item.Code;
                    int index = await Task.Run(() => AddProducts.FindIndex(x => x.Code == selecting.item.Code));
                    if (index == -1)
                        AddProducts.Add(selecting.item);
                    else
                    {
                        AddProducts[index] += selecting.item;
                        AddProducts[index].PurchasePrice = selecting.item.PurchasePrice;
                        AddProducts[index].SalePrice = selecting.item.SalePrice;
                    }
                }
            }
            update();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            flag = true;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double _height = SystemParameters.PrimaryScreenHeight;
            double _width = SystemParameters.PrimaryScreenWidth;
            //this.Height = 0.75 * _height;
            //this.Width = 0.75 * _width;
        }
    }
}
