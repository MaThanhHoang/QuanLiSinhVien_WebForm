using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace quanlythongtinSV
{
    public partial class thongke : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_tinhtrang();
            }
        }
        public void load_tinhtrang()
        {
            string sql = "select * from tinhtrang";
            dr_tinhtrang.DataSource = Connect.getTable(sql);
            dr_tinhtrang.DataValueField = "matinhtrang";
            dr_tinhtrang.DataTextField = "mota";
            dr_tinhtrang.DataBind();
        }
        public void load_sv()
        {
            string sql = "select masinhvien,tensinhvien,ngaysinh,gioitinh,diachi,SDT,tinhtrang.mota,lop.tenlop from sinhvien inner join tinhtrang on sinhvien.matinhtrang = tinhtrang.matinhtrang inner join lop on sinhvien.malop = lop.malop where tinhtrang.matinhtrang ='"+dr_tinhtrang.SelectedValue+"'";
            grid_tinhtrangSV.DataSource = Connect.getTable(sql);
            grid_tinhtrangSV.DataBind();
        }
        protected void btn_tinhtrang_Click(object sender, EventArgs e)
        {
            load_sv();
        }

        protected void btn_export_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename = tinhtrangSV.xls");
            Response.ContentType = "application/excel";

            StringWriter stringwriter = new StringWriter();
            HtmlTextWriter htmlText = new HtmlTextWriter(stringwriter);

            grid_tinhtrangSV.RenderControl(htmlText);
            Response.Write(stringwriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}