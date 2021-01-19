using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;



namespace quanlythongtinSV
{
    public partial class QuanLySV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbl_ngaysinh.Text = DateTime.Now.Date.ToString();
                calender.Visible = false;
                load_lop();
                load_sinhvien();
            }
        }
        public void load_lop()
        {
            string sql = "select * from lop";
            dr_lop.DataSource = Connect.getTable(sql);
            dr_lop.DataValueField = "malop";
            dr_lop.DataTextField = "tenlop";
            dr_lop.DataBind();
        }
        public void load_sinhvien()
        {
            string sql = "select * from sinhvien order by masinhvien ASC";
            grid_SV.DataSource = Connect.getTable(sql);
            grid_SV.DataBind();
        }
        private quanlySV get_thongtin()
        {
            quanlySV sv = new quanlySV(txt_msv.Text, txt_hoten.Text,DateTime.Parse(lbl_ngaysinh.Text), list_RD.SelectedValue,txt_diachi.Text, txt_phone.Text,list_tinhtrang.SelectedValue, dr_lop.SelectedValue);
             return sv;
        }
        protected void btn_capnhat_Click(object sender, EventArgs e)
        {
            quanlySV sv = get_thongtin();
           
        
                if (txt_msv.Text == "" || txt_hoten.Text == "" || txt_diachi.Text == "" || txt_phone.Text == "")
                {
                    lb_thongbao.ForeColor = System.Drawing.Color.Red;
                    lb_thongbao.Text = "Thông tin bạn điền chưa đầy đủ!";
                }
                else if (SinhVienDAO.check(sv) == 0)
                {
                    try
                    {
                        SinhVienDAO.insert(sv);
                        load_sinhvien();
                        lb_thongbao.ForeColor = System.Drawing.Color.Blue;
                        clear();
                        lb_thongbao.Text = "Thêm vào thành công";
                    }
                    catch
                    {
                        lb_thongbao.ForeColor = System.Drawing.Color.Red;
                        lb_thongbao.Text = "Thêm vào thất bại!";
                    }
                }
                else
                {
                    lb_thongbao.ForeColor = System.Drawing.Color.Red;
                    lb_thongbao.Text = "Mã sinh viên này đã tồn tại!";
                }
        }

        protected void btn_xoa_Click(object sender, EventArgs e)
        {
            string masinhvien = (sender as Button).CommandArgument;
            SinhVienDAO.delete(masinhvien);
            load_sinhvien();
        }

        protected void grid_SV_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {
           
            int rowsint = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;        
            txt_msv.Text = HttpUtility.HtmlDecode(grid_SV.Rows[rowsint].Cells[2].Text);
            txt_hoten.Text = HttpUtility.HtmlDecode(grid_SV.Rows[rowsint].Cells[3].Text);
            lbl_ngaysinh.Text = HttpUtility.HtmlDecode(grid_SV.Rows[rowsint].Cells[4].Text);
            list_RD.SelectedValue = HttpUtility.HtmlDecode(grid_SV.Rows[rowsint].Cells[5].Text);
            txt_diachi.Text = HttpUtility.HtmlDecode(grid_SV.Rows[rowsint].Cells[6].Text);
            txt_phone.Text = HttpUtility.HtmlDecode(grid_SV.Rows[rowsint].Cells[7].Text);
            list_tinhtrang.SelectedValue = HttpUtility.HtmlDecode(grid_SV.Rows[rowsint].Cells[8].Text);
            dr_lop.SelectedValue = HttpUtility.HtmlDecode(grid_SV.Rows[rowsint].Cells[9].Text);
            txt_msv.ReadOnly = true;
        }

        protected void btn_up_Click(object sender, EventArgs e)
        {
            if (!upload_file.HasFile)
            {
                lb_thongbao.Text = "file chua duoc chon";
            }
            else
            {
               try
                {
                    string path = string.Concat(Server.MapPath("~/temp/" + upload_file.FileName));
                    upload_file.SaveAs(path);
                    string excelConnectString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0",path);
                    OleDbConnection connection = new OleDbConnection();
                    connection.ConnectionString = excelConnectString;
                    OleDbCommand oblcommand = new OleDbCommand("select * from [Sheet1$]", connection);
                    connection.Open();
                    OleDbDataReader read = oblcommand.ExecuteReader();

                    string sqlConnectString = @"Data Source=DESKTOP-82PINMA\MSSQLSERVER01;Initial Catalog=thongtinsinhvien;Integrated Security=True";
                    SqlBulkCopy bukcp = new SqlBulkCopy(sqlConnectString);
                    bukcp.DestinationTableName = "sinhvien";
                    bukcp.WriteToServer(read);
                    lb_thongbao.ForeColor= System.Drawing.Color.Blue;
                    lb_thongbao.Text = "Đổ dữ liệu thành công";
                    connection.Close();
                    load_sinhvien();
                }
                catch
                {
                    lb_thongbao.ForeColor= System.Drawing.Color.Red;
                    lb_thongbao.Text = "Lỗi đã xảy ra xin hãy kiểm tra lại!";
                }
            }
        }

        protected void btn_image_Click(object sender, ImageClickEventArgs e)
        {
            if (calender.Visible)
            {
                calender.Visible = false;
            }
            else
            {
                calender.Visible = true;
            }
        }

        protected void calender_SelectionChanged(object sender, EventArgs e)
        {
            lbl_ngaysinh.Text = calender.SelectedDate.ToString("d");
            calender.Visible = false;
        }
        public void clear()
        {
            txt_msv.ReadOnly = false;
            txt_msv.Text = txt_hoten.Text = txt_diachi.Text = txt_phone.Text = "";
            lbl_ngaysinh.Text = DateTime.Now.ToString();
            lb_thongbao.ForeColor = System.Drawing.Color.Black;
            lb_thongbao.Text = "";
            txt_msv.Focus();
        }
        protected void btn_lammoi_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void btn_sua_Click(object sender, EventArgs e)
        {
            quanlySV sv = get_thongtin();
            try
            {
                SinhVienDAO.update(sv);
                load_sinhvien();
                lb_thongbao.ForeColor = System.Drawing.Color.Blue;
                clear();
                lb_thongbao.Text = "Cập nhật thành công";      
            }
            catch
            {
                lb_thongbao.ForeColor = System.Drawing.Color.Red;
                lb_thongbao.Text = "Cập nhật thất bại!";
            }
        }

        protected void btn_tim_Click(object sender, EventArgs e)
        {
            string sql = "select * from sinhvien where masinhvien like N'%" + txt_tim.Text + "%' or tensinhvien like N'%" + txt_tim.Text + "%'";
            grid_SV.DataSource = Connect.getTable(sql);
            grid_SV.DataBind();
        }
    }
}