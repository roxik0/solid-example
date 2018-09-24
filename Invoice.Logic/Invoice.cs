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
      
        public void AddInvoiceItem(InvoiceItem invoiceItem)
        {
            this.Items.Add(invoiceItem);
        }

        

        public override string ToString()
        {
            return base.ToString();
        }
    }
    public static class InvoiceDiscountExtension
    {
        public static void CalculateDiscounts(this Invoice inv, decimal pct)
        {
            foreach (var item in inv.Items)
            {
                item.SinglePrice *= 1 - (pct / 100);
            }
        }
    }
    public class ExportToString
    {
        public static string PrintToString(Invoice invoice)
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

            foreach (var item in invoice.Items)
            {
                str.Append($"{item.Good.Name}".PadLeft(20, '.'));
                str.Append($"{item.Quantity}".PadLeft(10, '.'));
                str.Append($"{item.SinglePrice * item.Quantity}".PadLeft(10, '.'));
                str.AppendLine();
            }
            str.Append('_', line_size);
            str.AppendLine();

            return str.ToString();
        }

    }
    public class InvoiceMathOperations
    {
        
        public static string SumAll(Invoice invoice)
        {
            return $"{invoice.Items.Select(c => c.Quantity * c.SinglePrice).Sum()} ";
        }
    }
    public class FileOperations
    {
        public void SaveToFile(Invoice item)
        {
            //Here save to file
        }

    }
}
