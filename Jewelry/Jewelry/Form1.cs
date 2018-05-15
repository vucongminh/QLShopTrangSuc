using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewelry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        { // Size
            flowLayoutPanel3.Controls.Clear();
            frmSize frm = new frmSize();
            frm.TopLevel = false;
            flowLayoutPanel3.Controls.Add(frm);
            frm.Size = flowLayoutPanel3.Size;
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        { // Product
            flowLayoutPanel3.Controls.Clear();
            frmProduct frm = new frmProduct();
            frm.TopLevel = false;
            flowLayoutPanel3.Controls.Add(frm);
            frm.Size = flowLayoutPanel3.Size;
            frm.Show();
        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        { // Bill
            flowLayoutPanel3.Controls.Clear();
            frmBill frm = new frmBill();
            frm.TopLevel = false;
            flowLayoutPanel3.Controls.Add(frm);
            frm.Size = flowLayoutPanel3.Size;          
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        { // Color
            flowLayoutPanel3.Controls.Clear();
            frmColor frm = new frmColor();
            frm.TopLevel = false;
            flowLayoutPanel3.Controls.Add(frm);
            frm.Size = flowLayoutPanel3.Size;
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        { // Type
            flowLayoutPanel3.Controls.Clear();
            frmType frm = new frmType();
            frm.TopLevel = false;
            flowLayoutPanel3.Controls.Add(frm);
            frm.Size = flowLayoutPanel3.Size;
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        { // Company
            flowLayoutPanel3.Controls.Clear();
            frmCompany frm = new frmCompany();
            frm.TopLevel = false;
            flowLayoutPanel3.Controls.Add(frm);
            frm.Size = flowLayoutPanel3.Size;
            frm.Show();
        }
    }
}
