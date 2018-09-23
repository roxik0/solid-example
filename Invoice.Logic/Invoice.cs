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
                str.Append($"{item.SinglePrice*item.Quantity}".PadLeft(10, '.') );
                str.AppendLine();
            }
            str.Append('_', line_size);
            str.AppendLine();

            return str.ToString();
        }

        public string SumAll()
        {
            return $"{Items.Select(c=>c.Quantity*c.SinglePrice).Sum()} ";
        }

        public void AddInvoiceItem(InvoiceItem invoiceItem)
        {
            this.Items.Add(invoiceItem);
        }
    }
}
