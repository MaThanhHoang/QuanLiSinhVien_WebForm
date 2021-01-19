using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace quanlythongtinSV
{
    public class SinhVienDAO
    {
        public static SqlCommand cmd;
        public static SqlDataReader rd;
        public static int check(quanlySV sv)
        {
            string sql = @"select count(*) from sinhvien where masinhvien = @msv ";
            Connect.OpenConnection();
            cmd = new SqlCommand(sql, Connect.conn);
            cmd.Parameters.AddWithValue("@msv", sv.get_masv);
            int sl = (int)cmd.ExecuteScalar();
            Connect.CloseConnection();
            return sl;
        }
        public static void insert(quanlySV sv)
        {
            string sql = @"insert into sinhvien values(@msv,@hoten,@ngaysinh,@gioitinh,@diachi,@sodt,@matinhtrang,@malop)";
            Connect.OpenConnection();
            cmd = new SqlCommand(sql, Connect.conn);
            cmd.Parameters.AddWithValue("@msv", sv.get_masv);
            cmd.Parameters.AddWithValue("@hoten", sv.get_hoten);
            cmd.Parameters.AddWithValue("@ngaysinh", sv.get_ngaysinh);
            cmd.Parameters.AddWithValue("@gioitinh", sv.get_gioitinh);
            cmd.Parameters.AddWithValue("@diachi", sv.get_diachi);
            cmd.Parameters.AddWithValue("@sodt", sv.get_sdt);
            cmd.Parameters.AddWithValue("@matinhtrang", sv.get_matinhtrang);
            cmd.Parameters.AddWithValue("@malop", sv.get_malop);
            cmd.ExecuteNonQuery();
            Connect.CloseConnection();
        }
        public static void update(quanlySV sv)
        {
            string sql = @"update sinhvien set tensinhvien = @hoten,ngaysinh = @ngaysinh,gioitinh = @gioitinh,diachi = @diachi,SDT = @sodt,matinhtrang=@matinhtrang,malop = @malop where masinhvien = @msv";
            Connect.OpenConnection();
            cmd = new SqlCommand(sql, Connect.conn);
            cmd.Parameters.AddWithValue("@hoten", sv.get_hoten);
            cmd.Parameters.AddWithValue("@ngaysinh", sv.get_ngaysinh);
            cmd.Parameters.AddWithValue("@gioitinh", sv.get_gioitinh);
            cmd.Parameters.AddWithValue("@diachi", sv.get_diachi);
            cmd.Parameters.AddWithValue("@sodt", sv.get_sdt);
            cmd.Parameters.AddWithValue("@matinhtrang", sv.get_matinhtrang);
            cmd.Parameters.AddWithValue("@malop", sv.get_malop);
            cmd.Parameters.AddWithValue("@msv", sv.get_masv);
            cmd.ExecuteNonQuery();
            Connect.CloseConnection();
        }
        public static void delete(string masinhvien)
        {
            string sql = @"delete from sinhvien where masinhvien=@masinhvien";
            Connect.OpenConnection();
            cmd = new SqlCommand(sql, Connect.conn);
            cmd.Parameters.AddWithValue("@masinhvien", masinhvien);
            cmd.ExecuteNonQuery();
            Connect.CloseConnection();
        }
        public static void delete_lopSV(string malop)
        {
            string sql = @"delete from sinhvien where malop=@malop";
            Connect.OpenConnection();
            cmd = new SqlCommand(sql, Connect.conn);
            cmd.Parameters.AddWithValue("@malop", malop);
            cmd.ExecuteNonQuery();
            Connect.CloseConnection();
        }
    }
}