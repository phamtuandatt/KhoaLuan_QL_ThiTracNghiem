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
    using System.ComponentModel.DataAnnotations;

    public partial class CT_BAITHI
    {
        [Display(Name = "Ma bai thi")]
        public int MABAITHI { get; set; }

        [Display(Name = "Ma cau hoi")]
        public int MACAUHOI { get; set; }

        [Display(Name = "Cau tra loi")]
        public string CAUTRALOI { get; set; }
    }
}
