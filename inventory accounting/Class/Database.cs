using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Media.Imaging;
using Excel = Microsoft.Office.Interop.Excel;
using inventory_accounting;
using System.IO;


namespace inventory_accounting
{
    public class Database
    {
        public enum Reports
        {
            [Description("Отчет продаж")]
            Sales,
            [Description("Поступление")]
            Entrance,
            [Description("Списание")]
            Debiting,
            [Description("РКО")]
            RKO
        }


        private Excel.Application excelapp;
        private Excel.Sheets excelsheets;
        private Excel.Worksheet excelworksheet;
        private Excel.Workbooks excelappworkbooks;
        private Excel.Workbook excelappworkbook;
        private Excel.Range excelcells1;
        private Excel.Range excelcells2;
        private Excel.Range excelcells3;
        private Excel.Range excelcells4;
        private Excel.Range excelcells5;

        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=../../DataBase/DataBase.mdb;";
        public OleDbConnection myConnection;

        public List<Product> Products { get; set; }
        public List<Report> Report { get; set; }
        public List<RKO_Type> RKO_Types { get; set;}

        public BitmapImage Sales_Image;
        public BitmapImage Entrance_Image;
        public BitmapImage Debiting_Image;
        public BitmapImage RKO_Image;

        public void createNewDataBase(string path)
        {
            myConnection.Open();
            string query = "DELETE FROM products";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            Products = new List<Product>();
            myConnection.Close();
            makeDataBase(path);

        }
        public void makeDataBase(string path)
        {
            myConnection.Open();
            excelapp = new Excel.Application();
            excelappworkbooks = excelapp.Workbooks;
            excelappworkbook = excelapp.Workbooks.Open(path);
            excelsheets = excelappworkbook.Worksheets;
            excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
            try
            {
                for (int i = 1; ; i++)
                {
                    try
                    {
                        excelcells1 = (Excel.Range)excelworksheet.Cells[i, 1];
                        excelcells2 = (Excel.Range)excelworksheet.Cells[i, 2];
                        excelcells3 = (Excel.Range)excelworksheet.Cells[i, 3];
                        excelcells4 = (Excel.Range)excelworksheet.Cells[i, 4];
                        excelcells5 = (Excel.Range)excelworksheet.Cells[i, 5];
                        if (excelcells1.Value2 == null)
                            break;
                        if (Convert.ToString(excelcells3.Value2) == " ")
                            excelcells3.Value2 = 0;
                        if (excelcells4.Value2 is string || excelcells5.Value2 is string)
                        {
                            excelcells4.Value2 = 0;
                            excelcells5.Value2 = 0;
                        }
                        string query = "INSERT INTO products (Code, n_name, Quantity, PurchasePrice,SalePrice ) VALUES (@Code, @n_name,@Quantity, @PurchasePrice,@SalePrice)";

                        OleDbCommand command = new OleDbCommand(query, myConnection);

                        command.Parameters.AddWithValue("Code", excelcells1.Value2);
                        command.Parameters.AddWithValue("n_name", excelcells2.Value2);
                        command.Parameters.AddWithValue("Quantity", excelcells3.Value2);
                        command.Parameters.AddWithValue("PurchasePrice", excelcells4.Value2);
                        command.Parameters.AddWithValue("SalePrice", excelcells5.Value2);
                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        string writePath = "log.txt";
                        using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                        {
                            sw.WriteLine(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string writePath = "log.txt";
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(ex.Message);
                }
            }
            finally
            {
                excelappworkbook.Save();
                excelapp.Quit();
                myConnection.Close();
            }
        }
        public Database()
        {
            try
            {
                Products = new List<Product>();
                Report = new List<Report>();
                RKO_Types = new List<RKO_Type>();
                myConnection = new OleDbConnection(connectString);
                myConnection.Open();
                loading();
                myConnection.Close();
                Products.Sort((x, y) => x.Name.CompareTo(y.Name));
                Report.Sort((x, y) => x.Date.CompareTo(y.Date));
            }
            catch (Exception ex)
            {
                string writePath = "log.txt";
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(ex.Message);
                }
            }
            finally
            {
                myConnection.Close();
            }
        }
        public int nextNumber()
        {
            if (Report.Count == 0)
                return 1;
            return Report.Max(item => item.Number) + 1;
        }
        public List<Product> GetProducts(int number)
        {
            List<Product> list = new List<Product>();
            myConnection.Open();

            string query = "SELECT * FROM report WHERE NumberN=@NumberN";

            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.Parameters.AddWithValue("NumberN", number);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
                list.Add(new Product(Convert.ToInt32(reader[0]), reader[1].ToString(), Convert.ToDouble(reader[2]), Convert.ToDouble(reader[3]), Convert.ToDouble(reader[4])));

            reader.Close();

            myConnection.Close();
            return list;
        }
        public List<Report> GetReport(DateTime leftDate, DateTime rightDate)
        {
            try
            {
                return Report.Where((x) =>x.Date>=leftDate && rightDate>= x.Date).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public void loading()
        {
            loadingProducts();
            Sales_Image = new BitmapImage(new Uri("Images/Sales.png", UriKind.Relative));
            Entrance_Image = new BitmapImage(new Uri("Images/Entrance.png", UriKind.Relative));
            Debiting_Image = new BitmapImage(new Uri("Images/Debiting.png", UriKind.Relative));
            RKO_Image = new BitmapImage(new Uri("Images/RKO.png", UriKind.Relative));

            loadingReport();
            loadingMoneyType();
           
        }
        public void loadingProducts()
        {
            string query = "SELECT * FROM products ";

            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
                Products.Add(new Product(Convert.ToInt32(reader[0]), reader[1].ToString(), Convert.ToDouble(reader[2]), Convert.ToDouble(reader[3]), Convert.ToDouble(reader[4])));

            reader.Close();
        }
        public void loadingReport()
        {
            string query = "SELECT * FROM AllReport ";

            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            BitmapImage img = null;
            while (reader.Read())
            {
                Report.Add(new Report(Convert.ToInt32(reader[0]),
                    Convert.ToDateTime(reader[1]),
                    (Database.Reports)Enum.Parse(typeof(Database.Reports), reader[2].ToString()),
                    Convert.ToDouble(reader[3]), new RKO_Type(reader[4].ToString())));


                switch (Report.Last().ReportType)
                {
                    case Reports.Debiting: img = Debiting_Image; break;
                    case Reports.Sales: img = Sales_Image; break;
                    case Reports.Entrance: img = Entrance_Image; break;
                    case Reports.RKO: img = RKO_Image; break;
                }
                Report.Last().Image = img;
            }
            reader.Close();
        }
        public void loadingMoneyType()
        {
            string query = "SELECT * FROM MoneyType ";

            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();          
            while (reader.Read())
            {
                RKO_Types.Add(new RKO_Type((reader.GetString(0))));
                //Console.WriteLine(reader.GetString(0));
            }
            reader.Close();
        }

        public void addNewReport(Report item)
        {
            BitmapImage img = null;
            myConnection.Open();
            string query = "INSERT INTO AllReport (NumberN, DateT, ReportType, Summ) VALUES (@NumberN, @DateT,@ReportType,@Summ)";

            OleDbCommand command = new OleDbCommand(query, myConnection);

            command.Parameters.AddWithValue("NumberN", item.Number);
            command.Parameters.AddWithValue("DateT", item.Date.ToShortDateString());
            command.Parameters.AddWithValue("ReportType", item.ReportType.ToString());
            command.Parameters.AddWithValue("Summ", item.Summ);
            

            command.ExecuteNonQuery();
            myConnection.Close();
            switch (item.ReportType)
            {
                case Reports.Debiting: img = Debiting_Image; break;
                case Reports.Sales: img = Sales_Image; break;
                case Reports.Entrance: img = Entrance_Image; break;
                case Reports.RKO: img = RKO_Image; break;
            }
            item.Image = img;
        }
        public void addNewItem(Product item)
        {
            myConnection.Open();
            string query = "INSERT INTO products (Code, n_name, Quantity, PurchasePrice,SalePrice ) VALUES (@Code, @n_name,@Quantity, @PurchasePrice,@SalePrice)";

            OleDbCommand command = new OleDbCommand(query, myConnection);

            command.Parameters.AddWithValue("Code", item.Code);
            command.Parameters.AddWithValue("n_name", item.Name);
            command.Parameters.AddWithValue("Quantity", item.Quantity);
            command.Parameters.AddWithValue("PurchasePrice", item.PurchasePrice);
            command.Parameters.AddWithValue("SalePrice", item.SalePrice);

            command.ExecuteNonQuery();
            myConnection.Close();
        }
        public void addReport(Product item, int number, Reports ReportType)
        {
            string query = "INSERT INTO report (NumberN, Code, n_name, Quantity, PurchasePrice,SalePrice, Discount, Summ) VALUES (NumberN, @Code, @n_name, @Quantity, @PurchasePrice,@SalePrice, @Discount, @Summ)";

            try
            {
                OleDbCommand command = new OleDbCommand(query, myConnection);

                command.Parameters.AddWithValue("NumberN", number);
                command.Parameters.AddWithValue("Code", item.Code);
                command.Parameters.AddWithValue("n_name", item.Name);
                command.Parameters.AddWithValue("Quantity", item.Quantity);
                command.Parameters.AddWithValue("PurchasePrice", item.PurchasePrice);
                command.Parameters.AddWithValue("SalePrice", item.SalePrice);
                command.Parameters.AddWithValue("Discount", item.Discount);
                command.Parameters.AddWithValue("Summ", item.SummDiscount);

                command.ExecuteNonQuery();
                updateItem(item, ReportType, false, item.Quantity);
            }
            catch (Exception ex)
            {
                string writePath = "log.txt";
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(ex.Message);
                }
            }

        }

        public void updateReport(Product item, int number, Reports ReportType, double quantity)
        {
            string query = "UPDATE report SET Quantity=@Quantity, PurchasePrice=@PurchasePrice, SalePrice=@SalePrice, Discount=@Discount, Summ=@Summ WHERE NumberN=@NumberN AND Code=@Code";
            try
            {
                OleDbCommand command = new OleDbCommand(query, myConnection);

                command.Parameters.AddWithValue("Quantity", item.Quantity);
                command.Parameters.AddWithValue("PurchasePrice", item.PurchasePrice);
                command.Parameters.AddWithValue("SalePrice", item.SalePrice);
                command.Parameters.AddWithValue("Discount", item.Discount);
                command.Parameters.AddWithValue("Summ", item.SummDiscount);
                command.Parameters.AddWithValue("NumberN", number);
                command.Parameters.AddWithValue("Code", item.Code);

                command.ExecuteNonQuery();
                updateItem(item, ReportType, false, quantity);
            }
            catch (Exception ex)
            {
                string writePath = "log.txt";
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(ex.Message);
                }
            }
        }
        public void updateItem(Product item, Reports ReportType, bool deleted = false, double quantity = 0)
        {
            try
            {
                string query = "UPDATE products SET Quantity=@Quantity, PurchasePrice=@PurchasePrice, SalePrice=@SalePrice  WHERE Code=@Code";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                int index = this.Products.FindIndex((x) => x.Code == item.Code);

                Products[index].PurchasePrice = item.PurchasePrice;
                Products[index].SalePrice = item.SalePrice;
                if (!deleted && ReportType == Reports.Sales || !deleted && ReportType == Reports.Debiting || deleted && ReportType == Reports.Entrance)
                    Products[index].Quantity -= quantity;
                else
                    Products[index].Quantity += quantity;
                command.Parameters.AddWithValue("Quantity", Products[index].Quantity);
                command.Parameters.AddWithValue("PurchasePrice", Products[index].PurchasePrice);
                command.Parameters.AddWithValue("SalePrice", Products[index].SalePrice);
                command.Parameters.AddWithValue("Code", item.Code);
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                string writePath = "log.txt";
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(ex.Message);
                }
            }
        }
        public void updateSumm(Report report)
        {

            myConnection.Open();
            string query = "UPDATE AllReport SET Summ=@Summ WHERE NumberN=@NumberN";
            try
            {
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.Parameters.AddWithValue("Summ", report.Summ);
                command.Parameters.AddWithValue("NumberN", report.Number);

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                string writePath = "log.txt";
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(ex.Message);
                }
            }
            finally
            {
                myConnection.Close();
            }
        }
        public void updateReport(Report report)
        {
            myConnection.Open();
            string query = "UPDATE AllReport SET Summ=@Summ, RKO_Type=@RKO_Type WHERE NumberN=@NumberN";
            try
            {
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.Parameters.AddWithValue("Summ", report.Summ);
                command.Parameters.AddWithValue("RKO_Type", report.Type.Type);
                command.Parameters.AddWithValue("NumberN", report.Number);

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                string writePath = "log.txt";
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(ex.Message);
                }
            }
            finally
            {
                myConnection.Close();
            }
        }
        public void deleteReport(Report report)
        {
            string query = "DELETE FROM AllReport WHERE NumberN=@NumberN";
            try
            {
                OleDbCommand command = new OleDbCommand(query, myConnection);

                command.Parameters.AddWithValue("NumberN", report.Number);
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                string writePath = "log.txt";
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(ex.Message);
                }
            }
        }
        public void deleteReport(Product item, int number, Reports ReportType)
        {
            string query = "DELETE FROM report WHERE NumberN=@NumberN AND Code=@Code";
            try
            {
                OleDbCommand command = new OleDbCommand(query, myConnection);

                command.Parameters.AddWithValue("NumberN", number);
                command.Parameters.AddWithValue("Code", item.Code);

                command.ExecuteNonQuery();
                updateItem(item, ReportType, true, item.Quantity);
            }
            catch (Exception ex)
            {
                string writePath = "log.txt";
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(ex.Message);
                }
            }
        }
    }
}
