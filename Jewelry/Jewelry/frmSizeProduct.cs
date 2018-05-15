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
    public partial class frmSizeProduct : Form
    {
        public frmSizeProduct()
        {
            InitializeComponent();
        }

        private void frmSizeProduct_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            sqlQuery sql = new sqlQuery();
            DataTable dt = sql.LayDuLieu("Select name, price, quantity, companyName, typeName from product where id in (" +
                "select idProduct from detail_size where idSize = " + frmSize.Size_id + ")");
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
    }
}
