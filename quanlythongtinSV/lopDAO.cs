using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace quanlythongtinSV
{
    public class lopDAO
    {
        public static SqlCommand cmd;
        public static int check(quanlyLop lop)
        {
            string sql = @"select count(*) from lop where malop = @malop ";
            Connect.OpenConnection();
            cmd = new SqlCommand(sql, Connect.conn);
            cmd.Parameters.AddWithValue("@malop", lop.get_malop);
            int sl = (int)cmd.ExecuteScalar();
            Connect.CloseConnection();
            return sl;
        }
        public static void insert(quanlyLop lop)
        {
            string sql = @"insert into lop values(@malop,@tenlop,@machuyennganh,@makhoahoc)";
            Connect.OpenConnection();
            cmd = new SqlCommand(sql, Connect.conn);
            cmd.Parameters.AddWithValue("@malop",lop.get_malop);
            cmd.Parameters.AddWithValue("@tenlop", lop.get_tenlop);
            cmd.Parameters.AddWithValue("@machuyennganh", lop.get_machuyennganh);
            cmd.Parameters.AddWithValue("@makhoahoc", lop.get_makhoahoc);
            cmd.ExecuteNonQuery();
            Connect.CloseConnection();
        }
        public static void update(quanlyLop lop)
        {
            string sql = @"update lop set tenlop=@tenlop,machuyennganh=@machuyennganh,makhoahoc=@makhoahoc where malop=@malop";
            Connect.OpenConnection();
            cmd = new SqlCommand(sql, Connect.conn);
            cmd.Parameters.AddWithValue("@malop", lop.get_malop);
            cmd.Parameters.AddWithValue("@tenlop", lop.get_tenlop);
            cmd.Parameters.AddWithValue("@machuyennganh", lop.get_machuyennganh);
            cmd.Parameters.AddWithValue("@makhoahoc", lop.get_makhoahoc);
            cmd.ExecuteNonQuery();
            Connect.CloseConnection();
        }
        public static void delete(string malop)
        {
            string sql = @"delete from lop where malop=@malop";
            Connect.OpenConnection();
            cmd = new SqlCommand(sql, Connect.conn);
            cmd.Parameters.AddWithValue("@malop", malop);
            cmd.ExecuteNonQuery();
            Connect.CloseConnection();
        }
    }
}