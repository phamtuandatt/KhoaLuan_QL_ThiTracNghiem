using App_QL_ThiTracNghiem.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QL_ThiTracNghiem.DTO
{
    public class SinhViens
    {
		public string MaSV { get; set; }
        public string MatKhau { get; set; }
        public string TenSV { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Email { get; set; }
        public string Sdt { get; set; }
        public string DiaChi { get; set; }
        public string QueQuan { get; set; }
        public string HocPhi { get; set; }
        public string MaLop { get; set; }
    }
}
