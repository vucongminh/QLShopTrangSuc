using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Jewelry.Class
{
    class sqlQuery
    {
        public static SqlConnection con;
        //public static bool isLoginSuccess;
        //Properties.Settings st = new DataAccessLayer.Properties.Settings();    
        //public static string ConnectionString2 = @"server ='VTF-PC' ;database ='QLCQSVN' ;User ID=sa;password=vtf;Integrated Security = false";//;Integrated Security = false
        public static string ConnectionString = @"Data Source=DESKTOP-TKBGRT5\SQLEXPRESS;Initial Catalog=Jewelry;Integrated Security=True";//;Integrated Security = false
        public sqlQuery()
        {
            try
            {
                if (con != null && con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                else if (con == null)
                {
                    con = new SqlConnection();
                    con.ConnectionString = ConnectionString;// DataAccessLayer.Properties.Settings.Default.ConnectionString; //st.ConnectionString
                    con.Open();
                }
            }
            catch (Exception)
            {
            }
        }
        public sqlQuery(String strConnect)
        {
            try
            {
                if (con != null)
                    con.Close();
                con = new SqlConnection();
                con.ConnectionString = strConnect;
                con.Open();
            }
            catch (Exception)
            {
                //throw;
            }
        }
        public sqlQuery(string MayChu, string KieuXacThuc, string TenCSDL, string TaiKhoan, string MatKhau)
        {
            string strConnect = "";
            if (KieuXacThuc == "SQL Server Authentication")
                strConnect = "server=" + MayChu + ";database=" + TenCSDL + ";User ID=" + TaiKhoan + ";password= " + MatKhau + " ;Integrated Security = false";
            else
                strConnect = "server =(local);database =" + TenCSDL + " ;Integrated Security = true";

            try
            {
                if (con != null)
                    con.Close();
                con = new SqlConnection();
                //DataAccessLayer.Properties.Settings.Default.ConnectionString = strConnect;
                ConnectionString = strConnect;
                con.ConnectionString = ConnectionString;
                con.Open();
            }
            catch (Exception ex)
            {
                // throw;
            }
        }

        public DataTable Get_table(string query)
        {
            //SqlCommand Command = new SqlCommand(query, con);
            SqlDataAdapter sqldataAdapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();

                sqldataAdapter.Fill(dt);//;, "CONFIG");

            }
            catch (Exception ex)
            {
                //throw;
            }
            return dt;
        }


        //xử lý dữ liệu
        public void Exe_Nonquery(string query)
        {

            try
            {

                SqlCommand sqlCommand = new SqlCommand(query, con);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // throw;
            }
        }

        // Hàm thực thi các câu lệnh: thêm, sữa, xóa. 
        public void ExecuteNoneQuery(string strCode)
        {
            // Trả vể số lượng bản ghi thực hiện được khi thực thi câu lệnh. 
            int ressult = 0;
            if (strCode != "")
            {
                // Mở kết nối trước khi sử dụng đối tượng sqlCommand. 
                if (con.State == ConnectionState.Closed)
                    con.Open();
                // Khởi tạo đối tượng sqlCommand. 
                SqlCommand sqlCommand = new SqlCommand(strCode, con);
                sqlCommand.CommandType = CommandType.Text;
                // Sổ bản ghi thực hiện được. 
                ressult = sqlCommand.ExecuteNonQuery();
                // 
                // Đóng kết nối. 
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

        }

        // Hàm thực thi các câu lệnh trả về 1 giá trị. 
        public string ExecuteScalarQuery(string strCode)
        {
            string result = "";
            // Mở kết nối. 
            if (con.State == ConnectionState.Closed)
                con.Open();
            // Khởi tạo đối tượng sqlCommand. 
            SqlCommand sqlCommand = new SqlCommand(strCode, con);
            sqlCommand.CommandType = CommandType.Text;
            result = sqlCommand.ExecuteScalar().ToString();
            if (con.State == ConnectionState.Open)
                con.Close();
            return result;
        }

        public DataTable LayDuLieu(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable LayDuLieu(string sql, string[] name, object[] value, int Nparameter)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < Nparameter; i++)
            {
                cmd.Parameters.AddWithValue(name[i], value[i]);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int update(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd.ExecuteNonQuery();
        }
        public int update(string sql, string[] name, object[] value, int Nparameter)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < Nparameter; i++)
            {
                cmd.Parameters.AddWithValue(name[i], value[i]);
            }
            return cmd.ExecuteNonQuery();
        }
    }
}
