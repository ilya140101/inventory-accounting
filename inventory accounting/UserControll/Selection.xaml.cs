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
    /// Логика взаимодействия для Selection.xaml
    /// </summary>
    public partial class Selection : UserControl
    {
        public Selection()
        {
            InitializeComponent();
            settings();
        }
        private void settings()
        {
            find_selection.table.Columns[3].Visibility = Visibility.Collapsed;
            find_selection.table.Columns[5].Visibility = Visibility.Collapsed;
            find_selection.table.Columns[6].Visibility = Visibility.Collapsed;
            find_selection.table.Columns[7].Visibility = Visibility.Collapsed;
            find_selection.find_purchasePrice.Visibility = Visibility.Collapsed;          

            selection.table.Columns[3].Visibility = Visibility.Collapsed;
            selection.table.Columns[2].Header = "Кол-во";
            selection.find_purchasePrice.Visibility = Visibility.Collapsed;
            selection.table.FontSize = 16;
            
            //for (int i = 0; i < selection.table.Columns.Count; i++)
            //    selection.table.Columns[i].Width = DataGridLength.Auto;
        }
    }
}
