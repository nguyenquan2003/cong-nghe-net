//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaoDoiTour.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class DanhGia
    {
        public string MaDanhGia { get; set; }
        public string MaTour { get; set; }
        public string MaKH { get; set; }
        public Nullable<int> DanhGia1 { get; set; }
        public string BinhLuan { get; set; }
        public Nullable<System.DateTime> NgayDanhGia { get; set; }
    
        public virtual KhachHang KhachHang { get; set; }
        public virtual Tour Tour { get; set; }
    }
}
