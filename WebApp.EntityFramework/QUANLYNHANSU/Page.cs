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
    
    public partial class Page
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Page()
        {
            this.Menus = new HashSet<Menu>();
            this.User_Page = new HashSet<User_Page>();
        }
    
        public int Id { get; set; }
        public string Code { get; set; }
        public string Info { get; set; }
        public string Controler { get; set; }
        public string Action { get; set; }
        public string UserCreate { get; set; }
        public string UserFullnameCreate { get; set; }
        public Nullable<System.DateTime> DatetimeCreate { get; set; }
        public string UserUpdate { get; set; }
        public string UserFullnameUpdate { get; set; }
        public Nullable<System.DateTime> DatetimeUpdate { get; set; }
        public Nullable<bool> isDelete { get; set; }
        public string UserDelete { get; set; }
        public string UserFullnameDelete { get; set; }
        public Nullable<System.DateTime> DatetimeDelete { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Menu> Menus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Page> User_Page { get; set; }
    }
}