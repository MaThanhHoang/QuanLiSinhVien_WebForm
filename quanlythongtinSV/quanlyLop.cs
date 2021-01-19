using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace quanlythongtinSV
{
    public class quanlyLop
    {
        private string malop;
        private string tenlop;
        private string machuyennganh;
        private int makhoahoc;
        public quanlyLop(string malop, string tenlop, string machuyennganh, int makhoahoc)
        {
            this.malop = malop;
            this.tenlop = tenlop;
            this.machuyennganh = machuyennganh;
            this.makhoahoc = makhoahoc;
        }
        public string get_malop { get { return malop; } set { malop = value; } }
        public string get_tenlop { get { return tenlop; } set { tenlop= value; } }
        public string get_machuyennganh { get { return machuyennganh; } set { machuyennganh = value; } }
        public int get_makhoahoc { get { return makhoahoc; } set { makhoahoc = value; } }
    }
}