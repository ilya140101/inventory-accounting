using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Diagnostics;
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
        public ReportTable reportTable;

        public MainWindow()
        {
            InitializeComponent();
            this.Closing += MainWindow_Closing;
            try
            {
                database = new Database();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите закрыть программу?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else
                e.Cancel = true;
           

        }

        private  void loadingBase_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                OpenFileDialog OPF = new OpenFileDialog();
                Loading loading = new Loading();
                OPF.Filter = "Excel Worksheets|*.xls*";
                if (OPF.ShowDialog() == true)
                {
                    try
                    {
                        loading.Show();
                        if ((sender as MenuItem).Name == "Old")
                             database.makeDataBase(OPF.FileName);
                        else
                            database.createNewDataBase(OPF.FileName);  
                        string path = System.Reflection.Assembly.GetExecutingAssembly().Location;                       
                        Process.Start(path);                      
                        Process.GetCurrentProcess().Kill();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      

      
        private void Nomenclature_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }




        private void Report_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.reportTable == null)
                {
                    reportTable = new ReportTable(database);
                    reportTable.Show();
                }
                else
                    reportTable.Focus();
                this.reportTable.Closing += (ReportTable, args) => this.reportTable = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
