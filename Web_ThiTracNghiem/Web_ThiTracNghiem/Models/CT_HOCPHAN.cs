//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web_ThiTracNghiem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CT_HOCPHAN
    {
        public string MALOPHOCPHAN { get; set; }
        public string MASV { get; set; }
        public string MAHOCPHAN { get; set; }
        public string MAGV { get; set; }
        public Nullable<int> THU { get; set; }
        public string TIET { get; set; }
        public string PHONG { get; set; }
        public Nullable<System.DateTime> NGAYBD { get; set; }
        public Nullable<System.DateTime> NGAYKT { get; set; }
    
        public virtual HOCPHAN HOCPHAN { get; set; }
        public virtual SINHVIEN SINHVIEN { get; set; }
    }
}
