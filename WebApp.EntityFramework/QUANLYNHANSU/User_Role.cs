//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ToolsApp.EntityFramework.QUANLYNHANSU
{
    using System;
    using System.Collections.Generic;
    
    public partial class User_Role
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public string UserFullname { get; set; }
        public Nullable<int> RoleId { get; set; }
        public string RoleName { get; set; }
        public string UserCreate { get; set; }
        public string UserFullnameCreate { get; set; }
        public Nullable<System.DateTime> DatetimeCreate { get; set; }
        public string UserUpdate { get; set; }
        public string UserFullnameUpdate { get; set; }
        public Nullable<System.DateTime> DatetimeUpdate { get; set; }
    
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
