using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для AddNewReport.xaml
    /// </summary>
    public partial class AddNewReport : Window
    {
        public bool flag = false;
        public AddNewReport()
        {
            InitializeComponent();

            comboBox.ItemsSource = Enum.GetValues(typeof(Database.Reports)).Cast<Enum>()
    .Select(value => new
    {
        (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
        value
    });
            comboBox.DisplayMemberPath = "Description";
            comboBox.SelectedValuePath = "Value";
            datePicker.SelectedDate = DateTime.Now;            
        }
        

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Нужно выбрать тип отчета", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            flag = true;
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            flag = false;
            Close();
        }
    }

}
