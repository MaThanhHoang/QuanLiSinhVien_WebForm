using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace quanlythongtinSV
{
    public partial class quanlyLop1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_nganh();
                load_khoahoc();
                load_lop();
            }
        }
        public void load_nganh()
        {
            string sql = "select * from chuyennganh where machuyennganh not in('CN')";
            dr_nganh.DataSource = Connect.getTable(sql);
            dr_nganh.DataValueField = "machuyennganh";
            dr_nganh.DataTextField = "tenchuyennganh";
            dr_nganh.DataBind();
        }
        public void load_khoahoc()
        {
            string sql = "select * from khoahoc where makhoahoc not in(40)";
            dr_khoahoc.DataSource = Connect.getTable(sql);
            dr_khoahoc.DataValueField = "makhoahoc";
            dr_khoahoc.DataTextField = "makhoahoc";
            dr_khoahoc.DataBind();
        }
        public void load_lop()
        {
            string sql = "select * from lop";
            grid_lop.DataSource = Connect.getTable(sql);
            grid_lop.DataBind();
        }
        public void clear()
        {
            lb_thongbao.ForeColor = System.Drawing.Color.Black;
            lb_thongbao.Text = "";
            txt_malop.Text = txt_tenlop.Text = "";
            txt_malop.ReadOnly = false;
            txt_malop.Focus();
        }
        private quanlyLop get_thongtin()
        {
            quanlyLop lop = new quanlyLop(txt_malop.Text, txt_tenlop.Text, dr_nganh.SelectedValue,int.Parse(dr_khoahoc.SelectedValue));
            return lop;
        }
        protected void btn_capnhat_Click(object sender, EventArgs e)
        {
            quanlyLop lop = get_thongtin();
            if(txt_malop.Text =="" ||txt_tenlop.Text=="")
            {
                lb_thongbao.ForeColor= System.Drawing.Color.Red;
                lb_thongbao.Text = "Thông tin bạn điền chưa đầy đủ!";
            }
            else if (lopDAO.check(lop)==0)
            {
                try
                {
                    lopDAO.insert(lop);
                    load_lop();
                    lb_thongbao.ForeColor= System.Drawing.Color.Blue;
                    clear();
                    lb_thongbao.Text = "Thêm vào thành công";
                }
                catch {
                    lb_thongbao.ForeColor = System.Drawing.Color.Red;
                    lb_thongbao.Text = "Thêm vào thất bại!";
                }
            }
            else
            {
                lb_thongbao.ForeColor = System.Drawing.Color.Red;
                lb_thongbao.Text = "Mã lớp này đã tồn tại!";
            }
        }

        protected void grid_lop_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_malop.ReadOnly=true;
            txt_malop.Text = HttpUtility.HtmlDecode( grid_lop.SelectedRow.Cells[2].Text);
            txt_tenlop.Text = HttpUtility.HtmlDecode( grid_lop.SelectedRow.Cells[3].Text);
            dr_nganh.SelectedValue = HttpUtility.HtmlDecode( grid_lop.SelectedRow.Cells[4].Text);
            dr_khoahoc.SelectedValue = HttpUtility.HtmlDecode(grid_lop.SelectedRow.Cells[5].Text);
            txt_malop.ReadOnly = true;
        }
        
        protected void btn_lammoi_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void btn_xoa1_Click(object sender, EventArgs e)
        {
            string malop = (sender as Button).CommandArgument;
            SinhVienDAO.delete_lopSV(malop);
            lopDAO.delete(malop);
            load_lop();

        }

        protected void btn_Sua_Click(object sender, EventArgs e)
        {
            quanlyLop lop = get_thongtin();
            try
            {
                lopDAO.update(lop);
                load_lop();
                clear();
                lb_thongbao.ForeColor = System.Drawing.Color.Blue;
                lb_thongbao.Text = "Cập nhật thành công";
            }
            catch { lb_thongbao.Text = "Cập nhật thất bại"; }
        }

        protected void btn_tim_Click(object sender, EventArgs e)
        {
            string sql = "select * from lop where malop like N'%" + txt_tim.Text + "%' or tenlop like N'%" + txt_tim.Text + "%'";
            grid_lop.DataSource = Connect.getTable(sql);
            grid_lop.DataBind();
        }
    }
}