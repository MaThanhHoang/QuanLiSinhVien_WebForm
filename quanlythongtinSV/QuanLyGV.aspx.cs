using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace quanlythongtinSV
{
    public partial class QuanLyGV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_giangvien();
                load_khoa();
            }
        }
        public void load_giangvien()
        {
            string sql = "select * from giangvien";
            grid_gv.DataSource = Connect.getTable(sql);
            grid_gv.DataBind();
        }
        public void load_khoa()
        {
            string sql = "select * from khoa where makhoa not in('CK')";
            dr_khoa.DataSource = Connect.getTable(sql);
            dr_khoa.DataValueField = "makhoa";
            dr_khoa.DataTextField = "tenkhoa";
            dr_khoa.DataBind();
        }
        public void clear()
        {
            txt_magv.ReadOnly = false;
            lbl_thongbao.ForeColor = System.Drawing.Color.Black;
            lbl_thongbao.Text = "";
            txt_magv.Text = txt_tengv.Text = txt_hocvi.Text = txt_sdt.Text = "";
            txt_magv.Focus();
        }
        private quanlyGV get_thongtin()
        {
            string text = string.Empty;
            quanlyGV gv = new quanlyGV(txt_magv.Text,txt_tengv.Text,txt_hocvi.Text,txt_sdt.Text,dr_khoa.SelectedValue);
            return gv;
        }
        protected void btn_lammoi_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void btn_capnhat_Click(object sender, EventArgs e)
        {
            quanlyGV gv = get_thongtin();
            if (txt_magv.Text == "" || txt_tengv.Text == "" || txt_hocvi.Text == "" || txt_sdt.Text == "")
            {
                lbl_thongbao.ForeColor = System.Drawing.Color.Red;
                lbl_thongbao.Text = "Thông tin bạn điền chưa đầy đủ!";
            }
            else if (GiaoVienDAO.check(gv) == 0)
            {
                try
                {
                    GiaoVienDAO.insert(gv);
                    load_giangvien();
                    clear();
                    lbl_thongbao.ForeColor = System.Drawing.Color.Blue;
                  
                    lbl_thongbao.Text = "Thêm vào thành công";
                }
                catch { lbl_thongbao.Text = "Thêm vào thất bại"; }
            }
            else
            {
                lbl_thongbao.ForeColor = System.Drawing.Color.Red;
                lbl_thongbao.Text = "Mã giáo viên này đã tồn tại";
            }
        }

        protected void btn_xoa_Click(object sender, EventArgs e)
        {
            string magv = (sender as Button).CommandArgument;
            GiaoVienDAO.delete(magv);
            load_giangvien();
        }

        protected void grid_gv_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_magv.Text = HttpUtility.HtmlDecode( grid_gv.SelectedRow.Cells[2].Text);
            txt_tengv.Text = HttpUtility.HtmlDecode( grid_gv.SelectedRow.Cells[3].Text);
            txt_hocvi.Text = HttpUtility.HtmlDecode(grid_gv.SelectedRow.Cells[4].Text);
            txt_sdt.Text = HttpUtility.HtmlDecode(grid_gv.SelectedRow.Cells[5].Text);
            dr_khoa.SelectedValue = HttpUtility.HtmlDecode(grid_gv.SelectedRow.Cells[6].Text);
            txt_magv.ReadOnly = true;

        }

        protected void btn_sua_Click(object sender, EventArgs e)
        {
            quanlyGV gv = get_thongtin();
            try
            {
                GiaoVienDAO.update(gv);
                load_giangvien();
                clear();
                lbl_thongbao.ForeColor = System.Drawing.Color.Blue;
                lbl_thongbao.Text = "Cập nhật thành công";
            }
            catch { lbl_thongbao.Text = "Cập nhật thất bại"; }
        }

        protected void btn_tim_Click(object sender, EventArgs e)
        {
            string sql = "select * from giangvien where magiangvien like N'%" + txt_tim.Text + "%' or tengiangvien like N'%" + txt_tim.Text + "%'";
            grid_gv.DataSource = Connect.getTable(sql);
            grid_gv.DataBind();
        }
    }
}