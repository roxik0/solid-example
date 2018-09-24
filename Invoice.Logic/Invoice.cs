using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakturownik.Logic
{
    public class Invoice
    {
        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();

        public Currency Currency { get; set; }
        public string PrintToString()
        {
            int line_size = 40;
            StringBuilder str = new StringBuilder();
            str.Append('_', line_size);
            str.AppendLine();
            str.Append("Towar".PadLeft(20, '.'));
            str.Append("Ilość".PadLeft(10, '.'));
            str.Append("Cena".PadLeft(10, '.'));
            str.AppendLine();
            str.Append('_', line_size);
            str.AppendLine();

            foreach (var item in Items)
            {
                str.Append($"{item.Good.Name}".PadLeft(20, '.'));
                str.Append($"{item.Quantity}".PadLeft(10, '.'));
                str.Append($"{item.Price * RateTable.Rates[Currency]}".PadLeft(10, '.'));
                str.AppendLine();
            }
            str.Append('_', line_size);
            str.AppendLine();

            return str.ToString();
        }

        public string SumAll()
        {
            return $"{Items.Select(c => c.Price*RateTable.Rates[Currency]).Sum()}";
        }

        public void AddInvoiceItem(InvoiceItem invoiceItem)
        {
            this.Items.Add(invoiceItem);
        }
    }
    public enum Currency
    {
        PLN = 0,
        EUR = 1,
        CNY = 2,
    }
    public static class RateTable{
        public static Dictionary<Currency, decimal> Rates = new List<KeyValuePair<Currency, decimal>>() {
            new KeyValuePair<Currency, decimal>(Currency.PLN,1.0m),
            new KeyValuePair<Currency, decimal>(Currency.EUR,4.30m),
            new KeyValuePair<Currency, decimal>(Currency.CNY,0.53m),
        }.ToDictionary(c => c.Key, c => c.Value);
    }
}
