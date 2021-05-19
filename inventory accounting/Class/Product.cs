﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace inventory_accounting 
{
    public class Product 
    {
         

        
        public Product(int code, string name, double quantity, double purchasePrice, double salePrice, double discount=0)
        {
            this.Code = code;
            this.Name = name;
            this.Quantity = quantity;
            this.PurchasePrice = purchasePrice;
            this.SalePrice = salePrice;
            this.Summ = salePrice * quantity;
            this.Discount = discount;
            this.SummDiscount = Summ - Discount;
           
        }

        public static Product operator +(Product a, Product b)
        {
            a.Quantity += b.Quantity;
            a.Summ += b.Summ;
            a.Discount += b.Discount;
            a.SummDiscount += b.SummDiscount;
            return a;
        }
        public int Code { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double PurchasePrice { get; set ; }
        public double SalePrice { get ; set ; }
        public double Summ { get; set; }
        public double SummDiscount { get; set; }
        public double Discount { get; set; }

    }
}