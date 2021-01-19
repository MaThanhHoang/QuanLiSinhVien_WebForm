using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace quanlythongtinSV
{
    public class Connect
    {
        public static SqlConnection conn;
        public static SqlDataAdapter da;
        public static SqlDataReader rd;
        public static SqlConnection getStringConnect()
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["connectString"].ConnectionString;
            return conn;
        }
        public static void OpenConnection()
        {
            getStringConnect();
            try
            {
                conn.Open();
            }
            catch { }
        }
        public static void CloseConnection()
        {
            getStringConnect();
            conn.Close();
        }
        public static DataTable getTable(string sql)
        {
            DataTable dt = new DataTable();
            OpenConnection();
            da = new SqlDataAdapter(sql, getStringConnect());
            da.Fill(dt);
            CloseConnection();
            return dt;
        }
    }
}