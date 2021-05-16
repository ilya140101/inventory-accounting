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
        public bool flag = false;        
        public List<Product> AddProducts;
        public SelectionWindow(List<Product> Products)
        {
            InitializeComponent();
            this.Products = Products;
            AddProducts = new List<Product>();
            settings();

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
                    AddProducts.Remove(item);
                    Selection.selection.table.Items.Refresh();
                }
            }
             
            

        }
        public void select(Object sender, RoutedEventArgs e)
        {
                  
           SelectingQuantity selecting = new SelectingQuantity((sender as DataGridCell).DataContext as Product);
            selecting.ShowDialog();
            if (selecting.flag)
                AddProducts.Add(selecting.item);           
            Selection.selection.table.Items.Refresh();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            flag = true;
            this.Close();
        }
    }
}
