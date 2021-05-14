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
using inventory_accounting;
using Microsoft.Win32;


namespace inventory_accounting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Database database;
        public Nomenclature nomenclature;
        public MainWindow()
        {
            InitializeComponent();
            database = new Database();
        }


       

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog OPF = new OpenFileDialog();
                OPF.Filter = "Excel Worksheets|*.xls*";
                if (OPF.ShowDialog() == true)
                {

                    try
                    {
                        database.makeDataBase(OPF.FileName);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

           
        }

        private void Nomenclature_Click(object sender, RoutedEventArgs e)
        {
            if (this.nomenclature == null)
            {
                nomenclature = new Nomenclature(database);
                nomenclature.Show();
            }
            else
                nomenclature.Focus();
            this.nomenclature.Closing += (Nomenclature, args) => this.nomenclature = null;
          
        }
    }
}
