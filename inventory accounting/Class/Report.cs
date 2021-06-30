using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows.Media.Imaging;
using inventory_accounting;

namespace inventory_accounting
{
   public class Report
    {
        public List<Product> Products { get; set; }
        public double Summ { get; set; }
        public Database.Reports ReportType { get; set; }
        public string ReportTypeString { get; set; }
        public string DateString { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }
        public BitmapImage Image { get; set; }
        public RKO_Type Type { get; set; }

        public Report(int number, DateTime date, Database.Reports report, double summ, RKO_Type type=null)
        {
            Number = number;
            Date = date;
            DateString = date.ToShortDateString();
            Type = type;
            switch (report)
            {
                case Database.Reports.Sales: ReportTypeString = "Отчет продаж"; break;
                case Database.Reports.Entrance: ReportTypeString = "Поступление"; break;
                case Database.Reports.Debiting: ReportTypeString = "Списание"; break;
                case Database.Reports.RKO: ReportTypeString = "РКО"; break;
            }
            if(!(type is null) && type.Type != "")
                ReportTypeString+= "(" + type.Type + ")";
            ReportType = report;
            Summ = summ;           
        }
    }
}
