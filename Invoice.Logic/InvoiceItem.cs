namespace Fakturownik.Logic
{
    public class InvoiceItem
    {
        public Good Good { get;set;}
        public Currency Currency { get; set; }
        public decimal SinglePrice { get; set; }
        public decimal Quantity { get; set; }
        public virtual decimal Price => SinglePrice * Quantity * CurrencyManager.GetRate(Currency);
        public string GoodName => Good.Name;
    }
    public class LocalInvoiceItem:InvoiceItem
    {
      
        public override decimal Price => SinglePrice * Quantity;

    }

}