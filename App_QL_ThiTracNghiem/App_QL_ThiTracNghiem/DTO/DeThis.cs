using App_QL_ThiTracNghiem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QL_ThiTracNghiem.DTO
{
    public class DeThis
    {
        public int MaDeThi { get; set; }
        public string MaHocPhan { get; set; }
        public DateTime NgayTao { get; set; }
        public int TGLamBai { get; set; }
        public int SLCauHoi { get; set; }
        public byte TinhTrang { get; set; }
    }
}