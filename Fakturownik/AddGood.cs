using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fakturownik.Logic;

namespace Fakturownik
{
    public partial class AddGood : Form
    {
        public AddGood()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(Logic.Good.GetAll());
        }

        public InvoiceItem InvoiceItem { get; internal set; } = new InvoiceItem();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InvoiceItem.Good = comboBox1.SelectedItem as Good;
            InvoiceItem.Quantity = Convert.ToDecimal( textBox1.Text);
            InvoiceItem.SinglePrice = Convert.ToDecimal(textBox2.Text);
        }
    }
}
