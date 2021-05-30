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
        Database database;
        public Nomenclature(Database database)
        {
            InitializeComponent();
            this.database = database;
            table.setList(database.Products);
            table.table.Columns[5].Visibility = Visibility.Collapsed;
            table.table.Columns[6].Visibility = Visibility.Collapsed;
            table.table.Columns[7].Visibility = Visibility.Collapsed;
            table.table.Columns[8].Visibility = Visibility.Collapsed;

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
