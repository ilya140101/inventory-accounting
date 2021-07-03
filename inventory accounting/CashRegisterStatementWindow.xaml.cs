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
    /// Логика взаимодействия для СashRegisterStatementWindow.xaml
    /// </summary>
    public partial class CashRegisterStatementWindow : Window
    {
        public CashRegisterStatementWindow(Database database, DateTime left, DateTime right)
        {
            InitializeComponent();
            Title += database.getIntervalDateString(left, right);
            table.ItemsSource = database.GetCashRegisterStatement(left, right);
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
