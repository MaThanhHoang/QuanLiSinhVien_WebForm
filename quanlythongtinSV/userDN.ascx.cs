using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace quanlythongtinSV
{
    public partial class userDN : System.Web.UI.UserControl
    {
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            lb_thongbao.Text = "";
        }

        protected void bt_dangnhap_Click(object sender, EventArgs e)
        {
            string sql = "select * from Member where taikhoan = '" + txttaikhoan.Text + "' and matkhau ='" + txtmatkhau.Text + "'";

            Connect.OpenConnection();
            cmd = new SqlCommand(sql, Connect.conn);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read() == true)
            {
                if (txttaikhoan.Text .Equals("Admin"))
                {
                    Response.Redirect("home.aspx");
                }
                else
                {
                    Response.Redirect("SearchSV.aspx");
                }
            }
            else
            {
                lb_thongbao.Text = "Tài khoảng hoặc mật khẩu không đúng";
                txttaikhoan.Text = "";
                txtmatkhau.Text = "";
            }
            Connect.CloseConnection();

        }
    }
}