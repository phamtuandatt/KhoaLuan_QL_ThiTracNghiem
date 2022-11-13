using App_QL_ThiTracNghiem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_QL_ThiTracNghiem.DTO
{
    public class CaThis
    {
        public int MaCaThi { get; set; }
        public string MaHocPhan { get; set; }
        public string MaDeThi { get; set; }
        public DateTime NgayThi { get; set; }
        public string GioLamBai { get; set; }
        public byte TinhTrang { get; set; }
    }
}
