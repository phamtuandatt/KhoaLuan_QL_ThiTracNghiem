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
    
    public partial class CT_CATHI
    {
        public int MACATHI { get; set; }
        public string MASV { get; set; }
        public string TENSV { get; set; }
    
        public virtual CATHI CATHI { get; set; }
        public virtual SINHVIEN SINHVIEN { get; set; }
    }
}
