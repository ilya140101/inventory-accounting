using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_accounting
{
    public class CashRegisterStatement
    {
        public DateTime Date { get; set; }
        public double InitialBalance { get; set; }
        public double FinalBalance { get; set; }
        public double Arrival { get; set; }
        public double Expenditure { get; set; }
        public string DateString { get; set; }

        public CashRegisterStatement(DateTime date, double initialBalance, double finalBalance, double arrival, double expenditure)
        {
            Date = date;
            DateString = date.ToShortDateString();
            InitialBalance = initialBalance;
            FinalBalance = finalBalance;
            Arrival = arrival;
            Expenditure = expenditure;
        }
    }
}
