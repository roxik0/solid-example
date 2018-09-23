namespace Fakturownik.Logic
{
    public class InvoiceItem
    {
        public Good Good { get;set;}
        public decimal SinglePrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price => SinglePrice * Quantity;
        public string GoodName => Good.Name;

       
    }
}