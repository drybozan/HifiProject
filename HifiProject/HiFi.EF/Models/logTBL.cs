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
    
    public partial class logTBL
    {
        public int logId { get; set; }
        public Nullable<int> memberId { get; set; }
        public string logUsername { get; set; }
        public string logActivity { get; set; }
        public Nullable<System.DateTime> logDate { get; set; }
        public string ipAddress { get; set; }
    
        public virtual memberTBL memberTBL { get; set; }
    }
}