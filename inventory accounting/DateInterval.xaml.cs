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
    /// Логика взаимодействия для DateInterval.xaml
    /// </summary>
    public partial class DateInterval : Window
    {
        public DateInterval(DateTime left, DateTime right)
        {
            DateTime now = DateTime.Now;
            InitializeComponent();
            LeftDate.SelectedDate = left;
            RightDate.SelectedDate = right;
           
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            
                if (DateTime.Compare((LeftDate.SelectedDate ?? DateTime.Now.AddDays(-30)), RightDate.SelectedDate ?? DateTime.Now) == 1)
                {
                    MessageBox.Show("Левая дата не может быть больше правой", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;                
                }
                DialogResult = true;           
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
