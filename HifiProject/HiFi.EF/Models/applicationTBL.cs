//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HiFi.EF.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class applicationTBL
    {
        public int appId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }
        public Nullable<bool> memberActive { get; set; }
        public Nullable<System.DateTime> applicationDate { get; set; }
        public Nullable<int> userType { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string mail { get; set; }
        public Nullable<System.DateTime> passwordDuration { get; set; }
        public string profilePicture { get; set; }
        public string profileDetail { get; set; }
        public Nullable<bool> isDelete { get; set; }
    }
}
