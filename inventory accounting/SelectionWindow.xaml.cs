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
    /// Логика взаимодействия для SelectionWindow.xaml
    /// </summary>
    public partial class SelectionWindow : Window
    {
        List<Product> Products;
        public double Summ { get; set; }
        public bool flag = false;        
        public List<Product> AddProducts;
        public SelectionWindow(List<Product> Products)
        {
            InitializeComponent();
            this.Products = Products;
            Summ = 0;
            Summ_TextBox.DataContext = Summ;
            Summ_TextBox.Text = Summ.ToString();
            AddProducts = new List<Product>();
            settings();
            this.Closing += SelectionWindow_Closing;

        }

        private void SelectionWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
        }

        private void settings()
        {           
            Selection.find_selection.setList(Products);
            Selection.find_selection.DClick += select;
            Selection.selection.KeyDeleted += deleted;
            Selection.selection.setList(AddProducts);     
        }
        public void deleted(Object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                if (MessageBox.Show("Вы действительно хотите удалить элемент из таблицы?", "", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    var item = (sender as DataGridCell).DataContext as Product;
                    Summ -= item.SummDiscount;
                    AddProducts.Remove(item);
                    Summ_TextBox.Text = Summ.ToString();
                    Selection.selection.table.Items.Refresh();
                }
            }
             
            

        }

       
        public async void select(Object sender, RoutedEventArgs e)
        {

            SelectingQuantity selecting = new SelectingQuantity((sender as DataGridCell).DataContext as Product);
            selecting.ShowDialog();
            if (selecting.flag)
            {
                int code = selecting.item.Code;
                int index = await Task.Run(()=>AddProducts.FindIndex(x => x.Code == selecting.item.Code));
                if (index == -1)
                    AddProducts.Add(selecting.item);
                else
                    AddProducts[index] += selecting.item;
                Summ += selecting.item.SummDiscount;
                Summ_TextBox.Text = Summ.ToString();
            }
            Selection.selection.table.Items.Refresh();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            flag = true;
            this.Close();
        }
    }
}
