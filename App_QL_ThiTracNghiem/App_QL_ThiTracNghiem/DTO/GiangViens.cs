using App_QL_ThiTracNghiem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace App_QL_ThiTracNghiem.DTO
{
    public class GiangViens
    {
		public string MaGV { get; set; }
        public string MatKhau { get; set; }
        public string TenGV { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string QueQuan { get; set; }
        public string HocVi { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string MaKhoa { get; set; }
        public string MaChucVu { get; set; }

    }
}