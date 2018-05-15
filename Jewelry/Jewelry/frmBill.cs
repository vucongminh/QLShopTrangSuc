using Jewelry.Class;
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
    public partial class frmBill : Form
    {
        public frmBill()
        {
            InitializeComponent();
        }

        private void frmBill_Load(object sender, EventArgs e)
        {
            sqlQuery truyVan = new sqlQuery();
            DataTable td = truyVan.LayDuLieu("Select * from Bill ");
            gridBill.DataSource = td;

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            buttonColumn.HeaderText = "Delete";
            buttonColumn.Name = "button";
            buttonColumn.Text = "Xóa";
            buttonColumn.UseColumnTextForButtonValue = true;
            buttonColumn.DefaultCellStyle.BackColor = Color.Red;
            gridBill.Columns.Add(buttonColumn);
        }

      
        private void gridBill_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string idBill = gridBill.Rows[e.RowIndex].Cells[1].Value.ToString(); // ô idBill có index=1, delete_index=0
                frmDetail_Bill frmDetail = new frmDetail_Bill(idBill);
                frmDetail.Show();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }
    }
}
