using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
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
           this.Icon = new BitmapImage(new Uri("../../Images/icon.ico", UriKind.Relative));
            
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

        private void loadingBase_Click(object sender, RoutedEventArgs e)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Process p = Process.Start("calc.exe");
            p.WaitForInputIdle();
        }

       
        private void MenuItem_Loaded(object sender, RoutedEventArgs e)
        {
            MyCalandar.DisplayDate = DateTime.Now;
        }
    }
}
