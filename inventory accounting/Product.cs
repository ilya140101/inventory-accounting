using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace inventory_accounting 
{
    class Product 
    {
        private int code;
        private string name;
        private double quantity;
        private double purchasePrice;
        private double salePrice;
       


        public Product(int code, string name, double quantity, double purchasePrice, double salePrice)
        {
            this.code = code;
            this.name = name;
            this.quantity = quantity;
            this.purchasePrice = purchasePrice;
            this.salePrice = salePrice;
           
        }

        public int Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public double Quantity { get => quantity; set => quantity = value; }
        public double PurchasePrice { get => purchasePrice; set => purchasePrice = value; }
        public double SalePrice { get => salePrice; set => salePrice = value; }
        
    }
}
