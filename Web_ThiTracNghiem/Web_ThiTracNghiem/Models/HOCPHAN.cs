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
    
    public partial class HOCPHAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOCPHAN()
        {
            this.CATHIs = new HashSet<CATHI>();
            this.CAUHOIs = new HashSet<CAUHOI>();
            this.CT_HOCPHAN = new HashSet<CT_HOCPHAN>();
            this.CT_NGANHANGCAUHOI = new HashSet<CT_NGANHANGCAUHOI>();
            this.DETHIs = new HashSet<DETHI>();
            this.NGANHANGCAUHOI_DADUYET = new HashSet<NGANHANGCAUHOI_DADUYET>();
            this.GIANGVIENs = new HashSet<GIANGVIEN>();
        }
    
        public string MAHOCPHAN { get; set; }
        public string TENHOCPHAN { get; set; }
        public Nullable<int> SOTC { get; set; }
        public Nullable<int> SOTIET_LT { get; set; }
        public Nullable<int> SOTIET_TH { get; set; }
        public string MAKHOA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CATHI> CATHIs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAUHOI> CAUHOIs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HOCPHAN> CT_HOCPHAN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_NGANHANGCAUHOI> CT_NGANHANGCAUHOI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETHI> DETHIs { get; set; }
        public virtual KHOA KHOA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NGANHANGCAUHOI_DADUYET> NGANHANGCAUHOI_DADUYET { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIANGVIEN> GIANGVIENs { get; set; }
    }
}