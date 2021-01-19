using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace quanlythongtinSV
{
    public class quanlyGV
    {
        private string magv;
        private string tengv;
        private string hocvi;
        private string sdt;
        private string makhoa;
        public quanlyGV(string magv,string tengv,string hocvi,string sdt,string makhoa)
        {
            this.magv = magv;
            this.tengv = tengv;
            this.hocvi = hocvi;
            this.sdt = sdt;
            this.makhoa = makhoa;
        }
        public string get_magv { get { return magv; } set { magv = value; } }
        public string get_tengv { get { return tengv; } set { tengv = value; } }
        public string get_hocvi { get { return hocvi; } set { hocvi = value; } }
        public string get_sdt { get { return sdt; } set { sdt = value; } }
        public string get_makhoa { get { return makhoa; } set { makhoa = value; } }
    }
}