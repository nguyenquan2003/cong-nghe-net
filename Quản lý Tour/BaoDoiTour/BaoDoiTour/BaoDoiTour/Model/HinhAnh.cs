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
    
    public partial class HinhAnh
    {
        public string MaHinhAnh { get; set; }
        public string MaTour { get; set; }
        public string DuongDan { get; set; }
        public string NoiDungAnh { get; set; }
    
        public virtual Tour Tour { get; set; }
    }
}
