using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace App_QL_ThiTracNghiem.DTO
{
    public class CT_HocPhans
    {
        public string MaLopHocPhan { get; set; }
        public string MaSV { get; set; }
        public string MaHocPhan { get; set; }
        public string MaGV { get; set; }
        public int Thu { get; set; }
        public string Tiet { get; set; }
        public string Phong { get; set; }
        public DateTime NgayBD { get; set; }
        public DateTime NgayKT { get; set; }
    }
}

