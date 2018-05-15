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
    public partial class frmType : Form
    {
        public frmType()
        {
            InitializeComponent();
        }

        string temp;

        public void LoadListView()
        {
            listView1.Items.Clear();
            sqlQuery sql = new sqlQuery();
            DataTable dt = sql.LayDuLieu("Select * from type");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem((i + 1).ToString());
                item.SubItems.Add(dt.Rows[i][0].ToString());
                item.SubItems.Add(dt.Rows[i][1].ToString());
                listView1.Items.Add(item);
            }
        }

        private void frmType_Load(object sender, EventArgs e)
        {
            LoadListView();
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            int row = this.listView1.SelectedItems[0].Index;
            temp = this.listView1.Items[row].SubItems[1].Text;
            txtMa.Text = this.listView1.Items[row].SubItems[1].Text;
            txtTen.Text = this.listView1.Items[row].SubItems[2].Text;
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMa.Text != "")
                {
                    DialogResult result;
                    result = MessageBox.Show("BẠN CÓ MUỐN THÊM LOẠI SẢN PHẨM NÀY KHÔNG?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string[] name = { "@id", "@name" };
                        string[] value = { txtMa.Text, txtTen.Text };
                        sqlQuery sql = new sqlQuery();
                        sql.update("ADD_TYPE", name, value, 2);
                        MessageBox.Show("THÊM MỚI LOẠI SẢN PHẨM THÀNH CÔNG !", "");

                        LoadListView();
                    }
                }
                else
                {
                    MessageBox.Show("Mời kiểm tra lại !", "THÔNG BÁO");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn đã nhập đủ các trường cần thiết chưa??", "Warning");
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMa.Text != "")
                {
                    DialogResult result;
                    result = MessageBox.Show("BẠN CÓ MUỐN SỬA THÔNG TIN LOẠI SẢN PHẨM NÀY KHÔNG?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string[] name = { "@MaBanDau", "@id", "@name" };
                        string[] value = { temp, txtMa.Text, txtTen.Text };
                        sqlQuery sql = new sqlQuery();
                        sql.update("UPDATE_TYPE", name, value, 3);
                        MessageBox.Show("Cập nhật thành công");
                        listView1.Items.Clear();
                        LoadListView();
                    }
                }
                else { MessageBox.Show("Hãy chọn một loại sản phẩm bạn muốn thao tác !!", "Thông tin"); }
            }
            catch
            {
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMa.Text != "")
                {
                    DialogResult result;
                    result = MessageBox.Show("BẠN CÓ MUỐN XÓA LOẠI SẢN PHẨM NÀY KHÔNG?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string[] name = { "@id" };
                        string[] value = { temp };
                        sqlQuery sql = new sqlQuery();
                        sql.update("DELETE_TYPE", name, value, 1);
                        MessageBox.Show("Xóa thành công .");
                        listView1.Items.Clear();
                        LoadListView();
                    }
                }
                else { MessageBox.Show("Hãy chọn một loại sản phẩm bạn muốn thao tác !!", "Warning"); }
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
