using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace quanlythongtinSV
{
    public class quanlySV
    {
        private string masv;
        private string hoten;
        private DateTime ngaysinh;
        private string gioitinh;
        private string diachi;
        private string sdt;
        private string matinhtrang;
        private string malop;
        public quanlySV(string masv,string hoten, DateTime ngaysinh, string gioitinh, string diachi, string sdt, string matinhtrang, string malop)
        {
            this.masv = masv;
            this.hoten = hoten;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.diachi = diachi;
            this.sdt = sdt;
            this.matinhtrang = matinhtrang;
           
            this.malop = malop;
        }
        public string get_masv { get { return masv; } set { masv = value; } }
        public string get_hoten { get { return hoten; } set { hoten = value; } }
        public DateTime get_ngaysinh { get { return ngaysinh; } set { ngaysinh = value; } }
        public string get_gioitinh { get { return gioitinh; } set { gioitinh = value; } }
        public string get_diachi { get { return diachi; } set { diachi = value; } }
        public string get_sdt { get { return sdt; } set { sdt = value; } }
        public string get_matinhtrang { get { return matinhtrang; } set {matinhtrang= value; } }
        
        public string get_malop { get { return malop; } set { malop = value; } }
    }
}