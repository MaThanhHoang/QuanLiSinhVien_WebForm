using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace quanlythongtinSV
{
    public partial class SearchSV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_sv();
                load_khoa();
                load_khoahoc();
            }
            
        }
        public void load_sv()
        {
            string sql = "select masinhvien,tensinhvien,ngaysinh,gioitinh,diachi,SDT,tinhtrang.mota,lop.tenlop from sinhvien inner join lop on sinhvien.malop = lop.malop inner join tinhtrang on sinhvien.matinhtrang =tinhtrang.matinhtrang";
            grid_seacrhSV.DataSource = Connect.getTable(sql);
            grid_seacrhSV.DataBind();
        }
        public void load_khoa()
        {
            string sql = "select * from khoa";
            dr_khoa.DataSource = Connect.getTable(sql);
            dr_khoa.DataValueField = "makhoa";
            dr_khoa.DataTextField = "tenkhoa";
            dr_khoa.DataBind();
        }
        public void load_khoahoc()
        {
            string sql = "select * from khoahoc";
            dr_khoahoc.DataSource = Connect.getTable(sql);
            dr_khoahoc.DataValueField = "makhoahoc";
            dr_khoahoc.DataTextField = "namhoc";
            dr_khoahoc.DataBind();
        }
        
        protected void dr_khoa_SelectedIndexChanged(object sender, EventArgs e)
        {       
                string sql = "select * from chuyennganh where makhoa ='" + dr_khoa.SelectedValue + "'";
                dr_chuyennganh.DataSource = Connect.getTable(sql);
                dr_chuyennganh.DataValueField = "machuyennganh";
                dr_chuyennganh.DataTextField = "tenchuyennganh";
                dr_chuyennganh.DataBind();
                           
        }

        protected void dr_chuyennganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select * from lop where machuyennganh ='" + dr_chuyennganh.SelectedValue + "'and makhoahoc='" + dr_khoahoc.SelectedValue + "'";
            dr_lop.DataSource = Connect.getTable(sql);
            dr_lop.DataValueField = "malop";
            dr_lop.DataTextField = "tenlop";
            dr_lop.DataBind();
        }

        protected void btn_loc_Click(object sender, EventArgs e)
        {
            string sql ="";
            try
            {
                if (dr_lop.SelectedItem.Text == "All")
                {
                    sql = "select masinhvien,tensinhvien,ngaysinh,gioitinh,diachi,SDT,tinhtrang.mota,lop.tenlop from sinhvien inner join tinhtrang on sinhvien.matinhtrang = tinhtrang.matinhtrang inner join lop on sinhvien.malop = lop.malop inner join khoahoc on lop.makhoahoc = khoahoc.makhoahoc where lop.makhoahoc ='" + dr_khoahoc.SelectedValue + "' and lop.machuyennganh ='" + dr_chuyennganh.SelectedValue + "'";

                }
                else
                    sql = "select masinhvien,tensinhvien,ngaysinh,gioitinh,diachi,SDT,tinhtrang.mota,lop.tenlop from sinhvien inner join tinhtrang on sinhvien.matinhtrang = tinhtrang.matinhtrang inner join lop on sinhvien.malop = lop.malop inner join khoahoc on lop.makhoahoc = khoahoc.makhoahoc where sinhvien.malop = '" + dr_lop.SelectedValue + "'";
                grid_seacrhSV.DataSource = Connect.getTable(sql);
                grid_seacrhSV.DataBind();
            }
            catch { Response.Write("<script>alert('Thao tác thất bại');</script>"); }
        }

        protected void btn_tim_Click(object sender, EventArgs e)
        {
            string sql = "";
            if(dr_khoahoc.SelectedItem.Text=="Chọn khóa")
            {
                sql= "select masinhvien,tensinhvien,ngaysinh,gioitinh,diachi,SDT,tinhtrang.mota,lop.tenlop,khoahoc.namhoc from sinhvien inner join tinhtrang on sinhvien.matinhtrang = tinhtrang.matinhtrang inner join lop on sinhvien.malop = lop.malop inner join khoahoc on lop.makhoahoc = khoahoc.makhoahoc where (masinhvien like N'%" + txt_tim.Text + "%' or tensinhvien like N'%" + txt_tim.Text + "%') and lop.machuyennganh ='" + dr_chuyennganh.SelectedValue + "'";
            }
            else
            {
                sql= "select masinhvien,tensinhvien,ngaysinh,gioitinh,diachi,SDT,tinhtrang.mota,lop.tenlop,khoahoc.namhoc from sinhvien inner join tinhtrang on sinhvien.matinhtrang = tinhtrang.matinhtrang inner join lop on sinhvien.malop = lop.malop inner join khoahoc on lop.makhoahoc = khoahoc.makhoahoc where (masinhvien like N'%" + txt_tim.Text + "%' or tensinhvien like N'%" + txt_tim.Text + "%') and lop.machuyennganh ='" + dr_chuyennganh.SelectedValue + "' and khoahoc.makhoahoc ='" + dr_khoahoc.SelectedValue + "'";
            }
            grid_seacrhSV.DataSource = Connect.getTable(sql);
            grid_seacrhSV.DataBind();
        }

        protected void btn_export_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename = SV.xls");
            Response.ContentType = "application/excel";

            StringWriter stringwriter = new StringWriter();
            HtmlTextWriter htmlText = new HtmlTextWriter(stringwriter);

            grid_seacrhSV.RenderControl(htmlText);
            Response.Write(stringwriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        protected void dr_khoahoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select * from lop where machuyennganh ='" + dr_chuyennganh.SelectedValue + "' and makhoahoc='" + dr_khoahoc.SelectedValue + "'";
            dr_lop.DataSource = Connect.getTable(sql);
            dr_lop.DataValueField = "malop";
            dr_lop.DataTextField = "tenlop";
            dr_lop.DataBind();
            dr_lop.Items.Add("All");
        }
    }
}