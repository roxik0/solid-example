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
    public partial class MainForm : Form
    {
        public Invoice currentInvoice { get; set; } = new Invoice();
        public MainForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new PrintForm(currentInvoice.PrintToString()).ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ptr = new AddGood();
            if (ptr.ShowDialog() == DialogResult.OK)
            {
                currentInvoice.AddInvoiceItem( ptr.InvoiceItem);
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = currentInvoice.Items;
            textBox1.Text = currentInvoice.SumAll();
        }
    }
}
