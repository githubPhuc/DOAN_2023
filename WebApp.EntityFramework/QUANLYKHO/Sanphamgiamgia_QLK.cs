//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ToolsApp.EntityFramework.QUANLYKHO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sanphamgiamgia_QLK
    {
        public int Id { get; set; }
        public Nullable<int> Idgiamgia_QLK { get; set; }
        public string Masp_QLK { get; set; }
    
        public virtual Giamgia_QLK Giamgia_QLK { get; set; }
        public virtual sanpham_QLK sanpham_QLK { get; set; }
    }
}
