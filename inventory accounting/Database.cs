using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;


namespace inventory_accounting
{

    class Database
    {

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

        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DataBase.mdb;";

        private OleDbConnection myConnection;
        public void makeDataBase(string path)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            excelapp = new Excel.Application();
            excelappworkbooks = excelapp.Workbooks;
            excelappworkbook = excelapp.Workbooks.Open(path);
            excelsheets = excelappworkbook.Worksheets;
            excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);

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
                    Console.WriteLine(ex.Message);
                }
            }
            
            excelappworkbook.Save();
            excelapp.Quit();
            myConnection.Close();
           
        }
    }
}
