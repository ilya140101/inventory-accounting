using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
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
            this.Closing += MainWindow_Closing;
            database = new Database();
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            //if (MessageBox.Show("Вы действительно хотите закрыть программу?", "", MessageBoxButton.YesNo, MessageBoxImage.Stop) == MessageBoxResult.Yes)
            //{
            //    Application.Current.Shutdown();
            //}
            //else
            //    e.Cancel = true;
            database.myConnection.Close();
            Application.Current.Shutdown();

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //Запуск окна отчета
                //DateTime date = DateTime.Now;
                //Sales sales = new Sales(new List<Product>(), database, date);
                //sales.Show();

                DateTime date = DateTime.Now;
                Report report = new Report(new List<Product>(), database, date, Database.Reports.Entrance);
                report.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                database.myConnection.Open();
                string query = "DELETE FROM report";
                OleDbCommand command = new OleDbCommand(query, database.myConnection);
                await Task.Run(()=>command.ExecuteNonQuery());
                database.myConnection.Close();
                MessageBox.Show("Готово");
                
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
                    nomenclature = new Nomenclature(database.Products);
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                //Запуск окна отчета
                DateTime date = DateTime.Now;
                Report report = new Report(new List<Product>(), database, date, Database.Reports.Sales);
                report.Show();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DateTime date = DateTime.Now;
            Report report = new Report(new List<Product>(), database, date, Database.Reports.Debiting);
            report.Show();
        }
    }
}
