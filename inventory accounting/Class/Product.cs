
namespace inventory_accounting
{
    public class Product
    {
        private double purchasePrice;
        private double salePrice;
        public Product(int code, string name, double quantity, double purchasePrice, double salePrice, double discount = 0)
        {
            this.Code = code;
            this.Name = name;
            this.Quantity = quantity;
            this.PurchasePrice = purchasePrice;
            this.SalePrice = salePrice;
            this.Summ = salePrice * quantity;
            this.Discount = discount;
            this.SummDiscount = Summ - Discount;
            this.SummPurchase = purchasePrice * Quantity;
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
        public double PurchasePrice
        {
            get
            {
                return purchasePrice;
            }
            set
            {
                purchasePrice = value;
                Summ = salePrice * Quantity;
                SummDiscount = salePrice * Quantity - Discount;
                SummPurchase = purchasePrice * Quantity;
            }
        }
        public double SalePrice
        {
            get
            {
                return salePrice;
            }
            set
            {
                salePrice = value;
                Summ = salePrice * Quantity;
                SummDiscount = salePrice * Quantity - Discount;
            }
        }
        public double Summ { get; set; }
        public double SummDiscount { get; set; }
        public double Discount { get; set; }
        public double SummPurchase { get; set; }
    }
}
