using System.Windows;
using System.Windows.Controls;
using inventory_accounting_Library;
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
                selection.find_SummPurchase.Visibility = Visibility.Collapsed;
                selection.find_purchasePrice.Visibility = Visibility.Collapsed;
                
            }
            if (reports == Database.Reports.Entrance || reports==Database.Reports.Debiting)
            {
                selection.table.Columns[5].Visibility = Visibility.Collapsed;
                selection.table.Columns[6].Visibility = Visibility.Collapsed;
                selection.find_Discount.Visibility = Visibility.Collapsed;
                selection.find_Summ.Visibility = Visibility.Collapsed;
            }

            find_selection.table.Columns[5].Visibility = Visibility.Collapsed;       
            find_selection.table.Columns[6].Visibility = Visibility.Collapsed;
            find_selection.table.Columns[7].Visibility = Visibility.Collapsed;
            find_selection.table.Columns[8].Visibility = Visibility.Collapsed;
            find_selection.find_Discount.Visibility = Visibility.Collapsed;
            find_selection.find_Summ.Visibility = Visibility.Collapsed;
            find_selection.find_SummDiscount.Visibility = Visibility.Collapsed;          
            find_selection.find_SummPurchase.Visibility = Visibility.Collapsed;

            selection.table.Columns[2].Header = "Кол-во";
            selection.table.FontSize = 16;

           
        }

        
    }
}
