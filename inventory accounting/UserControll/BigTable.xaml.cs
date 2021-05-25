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
    /// Логика взаимодействия для BigTable.xaml
    /// </summary>
    public partial class BigTable : UserControl
    {
        SelectionWindow selectionWindow;
        List<Product> Products;
        Database database;
        DateTime date;
        Database.Reports reports;
        private double Summ { get; set; }
        public BigTable()
        {
            InitializeComponent();

        }
        public void setList(List<Product> Products, Database database, DateTime date, Database.Reports reports)
        {
            this.Products = Products;
            this.Products = Products;
            this.database = database;
            this.date = date;
            this.reports = reports;
            table.setList(Products);
            table.table.Columns[2].Header = "Кол-во";

            if (reports == Database.Reports.Sales)
            {
                table.table.Columns[3].Visibility = Visibility.Collapsed;
                table.find_purchasePrice.Visibility = Visibility.Collapsed;
            }
            if (reports == Database.Reports.Entrance || reports == Database.Reports.Debiting)
            {
                table.table.Columns[5].Visibility = Visibility.Collapsed;
                table.table.Columns[6].Visibility = Visibility.Collapsed;
            }
            table.KeyDeleted += deleted;
            calculatingSumm();
            Summ_TextBlock.Text = Summ.ToString();
        }
        public void calculatingSumm()
        {
            Summ = 0;
            for (int i = 0; i < Products.Count; i++)
                if (reports == Database.Reports.Sales)
                    Summ += Products[i].SummDiscount;
                else
                    Summ += Products[i].SummPurchase;
        }

        private void selection_Click(object sender, RoutedEventArgs e)
        {
            if (this.selectionWindow == null)
            {
                selectionWindow = new SelectionWindow(database.Products, reports);
                selectionWindow.Show();
                this.selectionWindow.Closing += SelectionWindow_Closing;
            }
            else
                selectionWindow.Focus();
        }

        private async void SelectionWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.selectionWindow.flag == false && this.selectionWindow.AddProducts.Count != 0)
            {
                var tmp = MessageBox.Show("Перенести отобранные позиции в отчет?", "", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (tmp == MessageBoxResult.Yes)
                {
                    this.selectionWindow.flag = true;
                }
                if (tmp == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }

            }
            if (this.selectionWindow.flag == true)
            {
                try
                {
                    database.myConnection.Open();
                    foreach (Product item in this.selectionWindow.AddProducts)
                    {
                        int index;
                        int code = item.Code;
                        index = await Task.Run(() => Products.FindIndex(x => x.Code == code));
                        if (index == -1)
                        {
                            Products.Add(item);
                            database.addReport(item, date, reports);
                        }
                        else
                        {
                            Products[index] += item;
                            Products[index].PurchasePrice = item.PurchasePrice;
                            Products[index].SalePrice = item.SalePrice;
                            database.updateReport(Products[index], date, reports, item.Quantity);
                        }

                    }
                    calculatingSumm();
                    Summ_TextBlock.Text = Summ.ToString();
                }
                finally
                {
                    database.myConnection.Close();
                }

            }
            table.table.Items.Refresh();
            table.table.Items.SortDescriptions.Clear();
            this.selectionWindow = null;
        }

        public void deleted(Object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                if (MessageBox.Show("Вы действительно хотите удалить элемент из таблицы?", "", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    var item = (sender as DataGridCell).DataContext as Product;
                    try
                    {
                        database.myConnection.Open();
                        database.deleteReport(item, date, Database.Reports.Sales);
                    }
                    finally
                    {
                        database.myConnection.Close();
                    }
                    Products.Remove(item);
                    calculatingSumm();
                    Summ_TextBlock.Text = Summ.ToString();
                    table.table.Items.Refresh();
                    table.table.Items.SortDescriptions.Clear();
                }
            }
        }
    }
}


