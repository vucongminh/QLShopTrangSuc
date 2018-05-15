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
    public partial class frmColor : Form
    {
        public frmColor()
        {
            InitializeComponent();
        }

        public void LoadListView1()
        {
            listView1.Items.Clear();
            sqlQuery sql = new sqlQuery();
            DataTable dt = sql.LayDuLieu("Select name from color");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem((i + 1).ToString());
                item.SubItems.Add(dt.Rows[i][0].ToString());
                listView1.Items.Add(item);
            }
        }

        private void frmColor_Load(object sender, EventArgs e)
        {
            LoadListView1();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                DialogResult result;
                result = MessageBox.Show("BẠN CÓ MUỐN THÊM COLOR NÀY KHÔNG?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    sqlQuery truyVan = new sqlQuery();

                    string[] name = { "@name" };
                    string[] value = { txtName.Text };
                    sqlQuery sql = new sqlQuery();
                    sql.add("ADD_Color", name, value, 1);
                    MessageBox.Show("THÊM COLOR THÀNH CÔNG !", "");

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
                result = MessageBox.Show("BẠN CÓ MUỐN SỬA THÔNG TIN COLOR NÀY KHÔNG?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string[] name = { "@id", "@name" };
                    string[] value = { Color_id.ToString(), txtName.Text};
                    sqlQuery truyVan = new sqlQuery();
                    truyVan.add("UPDATE_Color", name, value, 2);
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
                result = MessageBox.Show("BẠN CÓ MUỐN XÓA COLOR NÀY KHÔNG?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {


                    string[] name = { "@id" };
                    string[] value = { Color_id.ToString() };
                    sqlQuery sql = new sqlQuery();
                    sql.add("DELETE_Color", name, value, 1);
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
            DataTable dtCol = truyVan.LayDuLieu("select * from color where name = N'" + txtName.Text + "'");
            Object idCol = "";
            foreach (DataRow rows in dtCol.Rows)
            {
                idCol = rows["id"];
            }

            Color_id = Int32.Parse(idCol.ToString());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public static int Color_id;

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                frmColorProduct cp = new frmColorProduct();
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
                DataTable dt = sql.LayDuLieu("Select name from color where " +
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
