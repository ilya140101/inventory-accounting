using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_accounting
{
    public class Transaction_Type
    {
        public string Type { get; set; }
        public Transaction_Type(string type)
        {
            Type = type;
        }
        public Transaction_Type()
        {

        }
    }
}
