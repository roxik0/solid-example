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
            str.Append('_',line_size);
            str.AppendLine();
            str.Append("Towar".PadLeft(20,'.'));
            str.Append("Ilość".PadLeft(10, '.'));
            str.Append("Cena".PadLeft(10, '.'));
            str.AppendLine();
            str.Append('_', line_size);
            str.AppendLine();

            foreach (var item in Items)
            {
                str.Append($"{item.Good.Name}".PadLeft(20, '.'));
                str.Append($"{item.Quantity}".PadLeft(10, '.'));
                if (Currency.EUR == Currency)
                {
                    str.Append($"{item.Price*4.01m}".PadLeft(10, '.'));
                }
                else
                {
                    str.Append($"{item.Price}".PadLeft(10, '.'));
                    s
                }
                str.AppendLine();
            }
            str.Append('_', line_size);
            str.AppendLine();

            return str.ToString();
        }

        public string SumAll()
        {
            if (Currency==Currency.PLN) {
                return $"{Items.Select(c=>c.Price).Sum()} zł";
            }
            if (Currency == Currency.EUR)
            {
                return $"{Items.Select(c => c.Price*4.01m).Sum()} zł";
            }
            return "0 PLN";
        }

        public void AddInvoiceItem(InvoiceItem invoiceItem)
        {
            this.Items.Add(invoiceItem);
        }
    }
    public enum Currency
    {
        PLN,
        EUR,
    }
}
