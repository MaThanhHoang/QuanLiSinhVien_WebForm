using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace quanlythongtinSV
{
    public partial class thongkeAD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_khoa();
                load_khoahoc();
            }
        }
        public void load_khoahoc()
        {
            string sql = "select DISTINCT * from khoahoc";
            dr_khoahoc.DataSource = Connect.getTable(sql);
            dr_khoahoc.DataValueField = "makhoahoc";
            dr_khoahoc.DataTextField = "namhoc";
            dr_khoahoc.DataBind();
            dr_khoahoc.Items.Add("All");
        }
        public void load_khoa()
        {
            string sql = "select * from khoa";
            dr_khoa.DataSource = Connect.getTable(sql);
            dr_khoa.DataValueField = "makhoa";
            dr_khoa.DataTextField = "tenkhoa";
            dr_khoa.DataBind();
        }
        protected void dr_khoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select * from chuyennganh where makhoa ='" + dr_khoa.SelectedValue + "'";
            dr_chuyennganh.DataSource = Connect.getTable(sql);
            dr_chuyennganh.DataValueField = "machuyennganh";
            dr_chuyennganh.DataTextField = "tenchuyennganh";
            dr_chuyennganh.DataBind();
        }

        protected void btn_thongke_Click(object sender, EventArgs e)
        {
            string sql = "";
            if(dr_khoahoc.SelectedItem.Text == "All")
            {
                sql = "select lop.tenlop as 'Tên lớp',count(case when tinhtrang.matinhtrang = 'CH' then 1 else null end) as 'Còn học',count(case when tinhtrang.matinhtrang = 'TN' then 1 else null end) as 'Tốt nghiệp',count(case when tinhtrang.matinhtrang = 'TH' then 1 else null end) as 'Thôi học' from sinhvien inner join tinhtrang on sinhvien.matinhtrang = tinhtrang.matinhtrang inner join lop on sinhvien.malop = lop.malop where lop.machuyennganh ='" + dr_chuyennganh.SelectedValue+"' group by lop.tenlop ";
            }
            else
            {
                sql = "select lop.tenlop as 'Tên lớp',count(case when tinhtrang.matinhtrang = 'CH' then 1 else null end) as 'Còn học',count(case when tinhtrang.matinhtrang = 'TN' then 1 else null end) as 'Tốt nghiệp',count(case when tinhtrang.matinhtrang = 'TH' then 1 else null end) as 'Thôi học' from sinhvien inner join tinhtrang on sinhvien.matinhtrang = tinhtrang.matinhtrang inner join lop on sinhvien.malop = lop.malop where lop.machuyennganh ='" + dr_chuyennganh.SelectedValue + "' and lop.makhoahoc = '"+dr_khoahoc.SelectedValue+"' group by lop.tenlop ";

            }
            grid_thongke.DataSource = Connect.getTable(sql);
            grid_thongke.DataBind();
           
        }
    }
}