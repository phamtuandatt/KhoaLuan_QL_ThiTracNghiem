using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_ThiTracNghiem.Models;

namespace Web_ThiTracNghiem.Models
{
    public class CaThiModel
    {
        public int MACATHI { get; set; }
        public string MAHOCPHAN { get; set; }
        public string TENHOCPHAN { get; set; }
        public string MADECON { get; set; }
        public DateTime? NGAYTHI { get; set; }
        public string PHONGTHI { get; set; }
        public string GIOLAMBAI { get; set; }
    }
}
