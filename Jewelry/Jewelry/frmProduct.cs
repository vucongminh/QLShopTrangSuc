using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jewelry.Class;
using System.Collections;

namespace Jewelry
{
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
        }

        public void LoadListView1()
        {
            listView1.Items.Clear();
            sqlQuery sql = new sqlQuery();
            DataTable dt = sql.LayDuLieu("Select name, price, quantity, companyName, typeName from product");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem((i + 1).ToString());
                item.SubItems.Add(dt.Rows[i][0].ToString());
                item.SubItems.Add(dt.Rows[i][1].ToString());
                item.SubItems.Add(dt.Rows[i][2].ToString());
                item.SubItems.Add(dt.Rows[i][3].ToString());
                item.SubItems.Add(dt.Rows[i][4].ToString());
                listView1.Items.Add(item);
            }
        }

        public void LoadCompanyType()
        {
            sqlQuery truyVanDL = new sqlQuery();
            DataTable dt = truyVanDL.LayDuLieu("select * from company");
            ArrayList arLH = new ArrayList();

            foreach (DataRow row in dt.Rows)
            {
                arLH.Add(row["name"]);
            }

            txtCompany.DataSource = arLH;

            DataTable dtT = truyVanDL.LayDuLieu("select * from type");
            ArrayList arLHT = new ArrayList();

            foreach (DataRow row in dtT.Rows)
            {
                arLHT.Add(row["name"]);
            }

            txtType.DataSource = arLHT;
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            LoadListView1();

            LoadCompanyType();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (txtName.Text != "")
            {
                DialogResult result;
                result = MessageBox.Show("BẠN CÓ MUỐN THÊM PRODUCT NÀY KHÔNG?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    sqlQuery truyVan = new sqlQuery();

                    DataTable dtCom = truyVan.LayDuLieu("select * from company where name = N'" + txtCompany.Text + "'");
                    Object idCom = "";
                    foreach (DataRow row in dtCom.Rows)
                    {
                        idCom = row["id"];
                    }

                    DataTable dtTyp = truyVan.LayDuLieu("select * from type where name = N'" + txtType.Text + "'");
                    Object idTyp = "";
                    foreach (DataRow row in dtTyp.Rows)
                    {
                        idTyp = row["id"];
                    }

                    string[] name = { "@name", "@price", "@quantity", "@idType", "@idCompany" };
                    string[] value = { txtName.Text, txtPrice.Text, txtQuantity.Text, idTyp.ToString(), idCom.ToString() };
                    sqlQuery sql = new sqlQuery();
                    sql.update("ADD_Product", name, value, 5);
                    MessageBox.Show("THÊM Product THÀNH CÔNG !", "");

                    LoadListView1();
                }
            }
            else
            {
                MessageBox.Show("Mời kiểm tra lại !", "THÔNG BÁO");
            }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Bạn đã nhập đủ các trường cần thiết chưa??", "Warning");
            //}
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (txtName.Text != "")
            {

                DialogResult result;
                result = MessageBox.Show("BẠN CÓ MUỐN SỬA THÔNG TIN PRODUCT NÀY KHÔNG?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    sqlQuery truyVan = new sqlQuery();

                    DataTable dtCom = truyVan.LayDuLieu("select * from company where name = N'" + txtCompany.Text + "'");
                    Object idCom = "";
                    foreach (DataRow row in dtCom.Rows)
                    {
                        idCom = row["id"];
                    }

                    DataTable dtTyp = truyVan.LayDuLieu("select * from type where name = N'" + txtType.Text + "'");
                    Object idTyp = "";
                    foreach (DataRow row in dtTyp.Rows)
                    {
                        idTyp = row["id"];
                    }

                    DataTable dtPro = truyVan.LayDuLieu("select * from product where name = N'" + txtName.Text + "'");
                    Object idPro = "";
                    foreach (DataRow row in dtPro.Rows)
                    {
                        idPro = row["id"];
                    }



                    string[] name = { "@id", "@name", "@price", "@quantity", "@idType", "@idCompany" };
                    string[] value = { idPro.ToString(), txtName.Text, txtPrice.Text, txtQuantity.Text, idTyp.ToString(), idCom.ToString() };
                    sqlQuery sql = new sqlQuery();
                    sql.update("UPDATE_Product", name, value, 6);
                    MessageBox.Show("Cập nhật thành công");
                    listView1.Items.Clear();
                    LoadListView1();
                }
            }
            else { MessageBox.Show("Hãy chọn một nhân viên bạn muốn thao tác !!", "Warning"); }
            //}
            //catch (Exception)
            //{

            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                DialogResult result;
                result = MessageBox.Show("BẠN CÓ MUỐN XÓA PRODUCT NÀY KHÔNG?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    sqlQuery truyVan = new sqlQuery();
                    DataTable dtPro = truyVan.LayDuLieu("select * from product where name = N'" + txtName.Text + "'");
                    Object idPro = "";
                    foreach (DataRow row in dtPro.Rows)
                    {
                        idPro = row["id"];
                    }


                    string[] name = { "@id" };
                    string[] value = { idPro.ToString() };
                    sqlQuery sql = new sqlQuery();
                    sql.update("DELETE_Product", name, value, 1);
                    MessageBox.Show("Xóa thành công .");
                    listView1.Items.Clear();
                    LoadListView1();
                }
            }
            else { MessageBox.Show("Hãy chọn một hàng hóa bạn muốn thao tác !!", "Warning"); }
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            int row = this.listView1.SelectedItems[0].Index;
            txtName.Text = listView1.Items[row].SubItems[1].Text;
            txtPrice.Text = this.listView1.Items[row].SubItems[2].Text;
            txtQuantity.Text = this.listView1.Items[row].SubItems[3].Text;

            sqlQuery truyVanDL = new sqlQuery();
            DataTable dt = truyVanDL.LayDuLieu("select * from company");
            ArrayList arLH = new ArrayList();
            foreach (DataRow rowT in dt.Rows)
            {
                if (rowT["name"].Equals(listView1.Items[row].SubItems[4].Text))
                {
                    arLH.Insert(0, rowT["name"]);
                }
                else
                {
                    arLH.Add(rowT["name"]);
                }
            }
            txtCompany.DataSource = arLH;

            DataTable dtTyp = truyVanDL.LayDuLieu("select * from type");
            ArrayList arLHTyp = new ArrayList();
            foreach (DataRow rowT in dtTyp.Rows)
            {
                if (rowT["name"].Equals(listView1.Items[row].SubItems[5].Text))
                {
                    arLHTyp.Insert(0, rowT["name"]);
                }
                else
                {
                    arLHTyp.Add(rowT["name"]);
                }
            }
            txtType.DataSource = arLHTyp;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            String search = txtSearch.Text.Trim();

            if (search != "")
            {
                listView1.Items.Clear();
                sqlQuery sql = new sqlQuery();
                DataTable dt = sql.LayDuLieu("Select name, price, quantity, companyName, typeName from product where " +
                    "name like N'%" + search + "%'");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem((i + 1).ToString());
                    item.SubItems.Add(dt.Rows[i][0].ToString());
                    item.SubItems.Add(dt.Rows[i][1].ToString());
                    item.SubItems.Add(dt.Rows[i][2].ToString());
                    item.SubItems.Add(dt.Rows[i][3].ToString());
                    item.SubItems.Add(dt.Rows[i][4].ToString());
                    listView1.Items.Add(item);
                }
            }
            else
            {
                LoadListView1();
            }

        }
    }
}
