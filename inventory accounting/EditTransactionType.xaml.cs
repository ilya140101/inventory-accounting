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
    /// Логика взаимодействия для EditTransactionType.xaml
    /// </summary>
    public partial class EditTransactionType : Window
    {
        Database database;
        public EditTransactionType(Database database, Report report)
        {
            InitializeComponent();
            switch (report.ReportType)
            {
                case Database.Reports.RKO: table.ItemsSource = database.RKO_Types;break;
                case Database.Reports.PKO: table.ItemsSource = database.PKO_Types; break;
                default: table.ItemsSource = new List<Transaction_Type>();break;
            }
            
            this.database = database;
        }      

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
