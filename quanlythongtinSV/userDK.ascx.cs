using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace quanlythongtinSV
{
    public partial class userDK : System.Web.UI.UserControl
    {
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            lb_thongbaodk.Text = "";
        }
        public int kiemtra(string ma, string str)
        {
            Connect.OpenConnection();
            string sql = string.Format(str, ma.Trim());
            cmd = new SqlCommand(sql, Connect.conn);
            int sl = (int)cmd.ExecuteScalar();
            Connect.CloseConnection();
            return sl;
        }
        protected void bt_dangky_Click(object sender, EventArgs e)
        {
            if (txttaikhoan.Text.Equals("Admin"))
            {
                lb_thongbaodk.Text = "Lỗi đã xảy ra";
            }
            else
            {

                if (kiemtra(txttaikhoan.Text, "select count(*) from Member where taikhoan = '{0}' ") == 0)
                {

                    if(txtmatkhau.Text== txtxacnhanmk.Text)
                    {
                        lb_thongbaodk.Text = "Đăng ký thành công";
                        Connect.OpenConnection();
                        string sql = @"insert into Member values('" + txttaikhoan.Text + "','" + txtmatkhau.Text + "','" + txtquequan.Text + "')";
                        SqlCommand cmd = new SqlCommand(sql, Connect.conn);
                        cmd.ExecuteNonQuery();
                        Connect.CloseConnection();
                        Response.Redirect("dangnhap.aspx");
                        // thông báo đăng ký thành công và chuyển về trang đăng nhập
                    }
                    else
                    {
                        lb_thongbaodk.Text = "Mật khẩu không khớp!";
                        txtxacnhanmk.Text = "";
                        txtxacnhanmk.Focus();
                    }
                }
                else
                {
                    lb_thongbaodk.Text = "Tên tài khoản đã tồn tại";
                    txttaikhoan.Text = "";
                    txtmatkhau.Text = "";
                    txtxacnhanmk.Text = "";
                    txtquequan.Text = "";
                }
            }
        }
    }
}