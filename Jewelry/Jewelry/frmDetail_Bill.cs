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
    public partial class frmDetail_Bill : Form
    {
        string idBill;
        public frmDetail_Bill(string _idBill)
        {
            idBill = _idBill;
            InitializeComponent();
        }

        private void frmDetail_Bill_Load(object sender, EventArgs e)
        {
            gv_detailBill_Load();
            lbl_Load();

        }

        private void lbl_Load()
        {
            sqlQuery truyVan = new sqlQuery();
            DataTable td = truyVan.LayDuLieu("Select * from bill where id=" + idBill + "");
            lblTen.Text = td.Rows[0][3].ToString();
            lblPhone.Text = td.Rows[0][2].ToString();
            lblEmail.Text = td.Rows[0][4].ToString();
            lblDC.Text = td.Rows[0][1].ToString();

        }

        private void gv_detailBill_Load()
        {
            sqlQuery truyVan = new sqlQuery();
            DataTable td = truyVan.LayDuLieu("Select p.name,c.name,s.name,d.quantity,d.price from product as p,detail_bill as d,color as c,size as s where idBill=" + idBill + " and p.id=d.idBill and c.id=d.idColor and s.id=d.idSize ");
            gv_detailBill.DataSource = td;
            gv_detailBill.Columns[0].HeaderText = "Tên sẩn phẩm";
            gv_detailBill.Columns[1].HeaderText = "Màu săc";
            gv_detailBill.Columns[2].HeaderText = "Size";
            gv_detailBill.Columns[3].HeaderText = "Số lượng";
            gv_detailBill.Columns[4].HeaderText = "Tổng tiền";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
