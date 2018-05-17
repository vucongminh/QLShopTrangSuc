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

namespace Jewelry
{
    public partial class frmSize : Form
    {
        public frmSize()
        {
            InitializeComponent();
        }

        public void LoadListView1()
        {
            listView1.Items.Clear();
            sqlQuery sql = new sqlQuery();
            DataTable dt = sql.LayDuLieu("Select name from size");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem((i + 1).ToString());
                item.SubItems.Add(dt.Rows[i][0].ToString());
                listView1.Items.Add(item);
            }
        }

        private void frmSize_Load(object sender, EventArgs e)
        {
            LoadListView1();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                DialogResult result;
                result = MessageBox.Show("BẠN CÓ MUỐN THÊM SIZE NÀY KHÔNG?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    sqlQuery truyVan = new sqlQuery();

                    string[] name = { "@name" };
                    string[] value = { txtName.Text };
                    sqlQuery sql = new sqlQuery();
                    sql.update("ADD_Size", name, value, 1);
                    MessageBox.Show("THÊM SIZE THÀNH CÔNG !", "");

                    LoadListView1();
                }
            }
            else
            {
                MessageBox.Show("Mời kiểm tra lại !", "THÔNG BÁO");
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (txtName.Text != "")
            {

                DialogResult result;
                result = MessageBox.Show("BẠN CÓ MUỐN SỬA THÔNG TIN SIZE NÀY KHÔNG?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string[] name = { "@id", "@name" };
                    string[] value = { Size_id.ToString(), txtName.Text };
                    sqlQuery truyVan = new sqlQuery();
                    truyVan.update("UPDATE_Size", name, value, 2);
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
                result = MessageBox.Show("BẠN CÓ MUỐN XÓA SIZE NÀY KHÔNG?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {


                    string[] name = { "@id" };
                    string[] value = { Size_id.ToString() };
                    sqlQuery sql = new sqlQuery();
                    sql.update("DELETE_Size", name, value, 1);
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

            sqlQuery truyVan = new sqlQuery();
            DataTable dtCol = truyVan.LayDuLieu("select * from size where name = N'" + txtName.Text + "'");
            Object idCol = "";
            foreach (DataRow rows in dtCol.Rows)
            {
                idCol = rows["id"];
            }

            Size_id = Int32.Parse(idCol.ToString());
        }

        public static int Size_id;

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                frmSizeProduct cp = new frmSizeProduct();
                cp.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            String search = txtSearch.Text;

            if (search.Trim() != "")
            {
                listView1.Items.Clear();
                sqlQuery sql = new sqlQuery();
                DataTable dt = sql.LayDuLieu("Select name from size where " +
                    "name like N'%" + search + "%'");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem((i + 1).ToString());
                    item.SubItems.Add(dt.Rows[i][0].ToString());
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
