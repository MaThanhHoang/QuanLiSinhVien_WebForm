using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace quanlythongtinSV
{
    public partial class searchGV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_gv();
                load_khoa();
            }
        }
        public void load_gv()
        {
            string sql = "select magiangvien,tengiangvien,hocvi,giangvien.SDT,khoa.tenkhoa from giangvien inner join khoa on giangvien.makhoa = khoa.makhoa ";
            grid_searchGV.DataSource = Connect.getTable(sql);
            grid_searchGV.DataBind();
        }
        public void load_khoa()
        {
            string sql = "select * from khoa";
            dr_khoa.DataSource = Connect.getTable(sql);
            dr_khoa.DataValueField = "makhoa";
            dr_khoa.DataTextField = "tenkhoa";
            dr_khoa.DataBind();
        }
        protected void btn_loc_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select magiangvien,tengiangvien,hocvi,giangvien.SDT,khoa.tenkhoa from giangvien inner join khoa on giangvien.makhoa = khoa.makhoa where giangvien.makhoa = '" + dr_khoa.SelectedValue + "' ";
                grid_searchGV.DataSource = Connect.getTable(sql);
                grid_searchGV.DataBind();
            }
            catch { Response.Write("<script>alert('Thao tác thất bại');</script>"); }
        }

        protected void btn_tim_Click(object sender, EventArgs e)
        {
            string sql = "";
            if(dr_khoa.SelectedItem.Text == "Chọn khoa")
            {
                sql = "select magiangvien,tengiangvien,hocvi,giangvien.SDT,khoa.tenkhoa from giangvien inner join khoa on giangvien.makhoa = khoa.makhoa where (giangvien.magiangvien like N'%" + txt_tim.Text + "%' or giangvien.tengiangvien like N'%" + txt_tim.Text + "%') ";
            }
            else
            {
                sql = "select magiangvien,tengiangvien,hocvi,giangvien.SDT,khoa.tenkhoa from giangvien inner join khoa on giangvien.makhoa = khoa.makhoa where (giangvien.magiangvien like N'%" + txt_tim.Text + "%' or giangvien.tengiangvien like N'%" + txt_tim.Text + "%') and giangvien.makhoa ='" + dr_khoa.SelectedValue + "' ";
            }
            grid_searchGV.DataSource = Connect.getTable(sql);
            grid_searchGV.DataBind();
        }

        protected void btn_export_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename = GV.xls");
            Response.ContentType = "application/excel";

            StringWriter stringwriter = new StringWriter();
            HtmlTextWriter htmlText = new HtmlTextWriter(stringwriter);

            grid_searchGV.RenderControl(htmlText);
            Response.Write(stringwriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}