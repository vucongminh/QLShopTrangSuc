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
    public partial class frmCompany : Form
    {
        public frmCompany()
        {
            InitializeComponent();
        }

        string temp;

        public void LoadListView()
        {
            listView1.Items.Clear();
            sqlQuery sql = new sqlQuery();
            DataTable dt = sql.LayDuLieu("Select * from company");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem((i + 1).ToString());
                item.SubItems.Add(dt.Rows[i][0].ToString());
                item.SubItems.Add(dt.Rows[i][1].ToString());
                listView1.Items.Add(item);
            }
        }

        private void frmCompany_Load_1(object sender, EventArgs e)
        {
            LoadListView();
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            int row = this.listView1.SelectedItems[0].Index;
            txtMa.Text = this.listView1.Items[row].SubItems[1].Text;
            txtTen.Text = this.listView1.Items[row].SubItems[2].Text;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMa.Text != "")
                {
                    DialogResult result;
                    result = MessageBox.Show("BẠN CÓ MUỐN XÓA CÔNG TY NÀY KHÔNG?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string[] name = { "@id" };
                        string[] value = { temp };
                        sqlQuery sql = new sqlQuery();
                        sql.update("DELETE_CT", name, value, 1);
                        MessageBox.Show("Xóa thành công .");
                        listView1.Items.Clear();
                        LoadListView();
                    }
                }
                else { MessageBox.Show("Hãy chọn một công ty bạn muốn thao tác !!", "Warning"); }
            }
            catch
            {

            }

        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMa.Text != "")
                {
                    DialogResult result;
                    result = MessageBox.Show("BẠN CÓ MUỐN THÊM CÔNG TY NÀY KHÔNG?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string[] name = { "@id", "@name" };
                        string[] value = { txtMa.Text, txtTen.Text};
                        sqlQuery sql = new sqlQuery();
                        sql.update("ADD_CT", name, value, 2);
                        MessageBox.Show("THÊM MỚI CÔNG TY THÀNH CÔNG !", "");

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
                    result = MessageBox.Show("BẠN CÓ MUỐN SỬA THÔNG TIN CÔNG TY NÀY KHÔNG?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string[] name = { "@MaBanDau", "@id", "@name" };
                        string[] value = { temp, txtMa.Text, txtTen.Text };
                        sqlQuery sql = new sqlQuery();
                        sql.update("UPDATE_CT", name, value, 3);
                        MessageBox.Show("Cập nhật thành công");
                        listView1.Items.Clear();
                        LoadListView();
                    }
                }
                else { MessageBox.Show("Hãy chọn một công ty bạn muốn thao tác !!", "Thông tin"); }
            }
            catch
            {
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
