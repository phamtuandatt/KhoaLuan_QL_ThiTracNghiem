using App_QL_ThiTracNghiem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QL_ThiTracNghiem.DTO
{
    public class Khoa
    {
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public int SoLuongGiangVien { get; set; }
        public int SoLuongMonHoc { get; set; }
        public int SoNganhDaoTao { get; set; }
    }
}