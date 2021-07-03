using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.IO;
using System.Collections.Generic;

namespace inventory_accounting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Database database { get; set; }
        public Nomenclature nomenclature { get; set; }
        public ReportTable reportTable { get; set; }
        public Loading loading { get; set; }
        private DateTime LeftDate { get; set; }
        private DateTime RightDate { get; set; }
        private string path;
        private bool addNew;//true- новая БД, false- добавление к старой 
       
        public MainWindow()
        {
            InitializeComponent();
            string path = @"../../Manual.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                Manual.Text = sr.ReadToEnd();
            }

            this.Icon = new BitmapImage(new Uri("../../Images/icon.ico", UriKind.Relative));

            this.Closing += MainWindow_Closing;
            try
            {
                database = new Database();
            }
            catch (Exception ex)
            {
                string writePath = "log.txt";
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(ex.StackTrace);
                }
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
                OPF.InitialDirectory =Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(),"../../../Excel"));
                loading = new Loading();
                OPF.Filter = "Excel Worksheets|*.xls*";
                if (OPF.ShowDialog() == true)
                {
                    loading.Show();
                    path = OPF.FileName;
                    addNew = !((sender as MenuItem).Name == "Old");
                    using (BackgroundWorker worker = new BackgroundWorker())
                    {
                        worker.WorkerReportsProgress = true;
                        worker.DoWork += worker_DoWork;
                        worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
                        worker.RunWorkerAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                string writePath = "log.txt";
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(ex.StackTrace);
                }
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            database = new Database();
            loading.Close();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!addNew)
                database.makeDataBase(path);
            else
                database.createNewDataBase(path);
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
                {
                    nomenclature.WindowState = WindowState.Normal;
                    nomenclature.Focus();
                }
                this.nomenclature.Closing += (Nomenclature, args) => this.nomenclature = null;
            }
            catch (Exception ex)
            {
                string writePath = "log.txt";
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(ex.StackTrace);
                }
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
                    reportTable.Activate();
                this.reportTable.Closing += (ReportTable, args) => this.reportTable = null;
            }
            catch (Exception ex)
            {
                string writePath = "log.txt";
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(ex.StackTrace);
                }
            }
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void CashRegisterStatementItem_Click(object sender, RoutedEventArgs e)
        {
            DateTime now = DateTime.Now;
            LeftDate = new DateTime(now.Year, now.Month, 1);
            RightDate = now;
            DateInterval dateInterval = new DateInterval(LeftDate, RightDate);
            dateInterval.Owner = this;
            if (dateInterval.ShowDialog() != true)
                return;
            CashRegisterStatementWindow window = new CashRegisterStatementWindow(database, dateInterval.LeftDate.SelectedDate.Value, dateInterval.RightDate.SelectedDate.Value);
            window.Show();
        }
    }
}
