using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace quanlythongtinSV
{
    public class GiaoVienDAO
    {
        public static SqlCommand cmd;
        public static int check(quanlyGV gv)
        {
            string sql = @"select count(*) from giangvien where magiangvien = @magiangvien ";
            Connect.OpenConnection();
            cmd = new SqlCommand(sql, Connect.conn);
            cmd.Parameters.AddWithValue("@magiangvien", gv.get_magv);
            int sl = (int)cmd.ExecuteScalar();
            Connect.CloseConnection();
            return sl;
        }
        public static void insert(quanlyGV gv)
        {
            string sql = @"insert into giangvien values(@magv,@tengv,@hocvi,@sdt,@makhoa)";
            Connect.OpenConnection();
            cmd = new SqlCommand(sql, Connect.conn);
            cmd.Parameters.AddWithValue("@magv", gv.get_magv);
            cmd.Parameters.AddWithValue("@tengv", gv.get_tengv);
            cmd.Parameters.AddWithValue("@hocvi", gv.get_hocvi);
            cmd.Parameters.AddWithValue("@sdt", gv.get_sdt);
            cmd.Parameters.AddWithValue("@makhoa", gv.get_makhoa);
            cmd.ExecuteNonQuery();
            Connect.CloseConnection();
        }
        public static void update(quanlyGV gv)
        {
            string sql = @"update giangvien set tengiangvien=@tengv,hocvi=@hocvi,SDT=@sdt,makhoa=@makhoa where magiangvien=@magv";
            Connect.OpenConnection();
            cmd = new SqlCommand(sql, Connect.conn);
            cmd.Parameters.AddWithValue("@magv", gv.get_magv);
            cmd.Parameters.AddWithValue("@tengv", gv.get_tengv);
            cmd.Parameters.AddWithValue("@hocvi", gv.get_hocvi);
            cmd.Parameters.AddWithValue("@sdt", gv.get_sdt);
            cmd.Parameters.AddWithValue("@makhoa", gv.get_makhoa);
            cmd.ExecuteNonQuery();
            Connect.CloseConnection();
        }
        public static void delete(string magv)
        {
            string sql = @"delete from giangvien where magiangvien=@magv";
            Connect.OpenConnection();
            cmd = new SqlCommand(sql, Connect.conn);
            cmd.Parameters.AddWithValue("@magv", magv);
            cmd.ExecuteNonQuery();
            Connect.CloseConnection();
        }
    }
}