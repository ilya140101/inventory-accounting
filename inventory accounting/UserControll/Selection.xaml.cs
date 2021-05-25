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
        }
        public void settings(Database.Reports reports)
        {

            if (reports == Database.Reports.Sales)
            {
                find_selection.table.Columns[3].Visibility = Visibility.Collapsed;               
                find_selection.find_purchasePrice.Visibility = Visibility.Collapsed;

                selection.table.Columns[3].Visibility = Visibility.Collapsed;               
                selection.table.Columns[7].Visibility = Visibility.Collapsed;               
                selection.find_purchasePrice.Visibility = Visibility.Collapsed;
                
            }
            if (reports == Database.Reports.Entrance || reports==Database.Reports.Debiting)
            {
                selection.table.Columns[5].Visibility = Visibility.Collapsed;
                selection.table.Columns[6].Visibility = Visibility.Collapsed;
            }

            find_selection.table.Columns[5].Visibility = Visibility.Collapsed;
            find_selection.table.Columns[6].Visibility = Visibility.Collapsed;
            find_selection.table.Columns[7].Visibility = Visibility.Collapsed;
            find_selection.table.Columns[8].Visibility = Visibility.Collapsed;
            selection.table.Columns[2].Header = "Кол-во";
            selection.table.FontSize = 16;

            //for (int i = 0; i < selection.table.Columns.Count; i++)
            //    selection.table.Columns[i].Width = DataGridLength.Auto;
        }

        
    }
}
