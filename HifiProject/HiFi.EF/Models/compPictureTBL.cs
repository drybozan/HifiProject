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
    
    public partial class compPictureTBL
    {
        public int compPicId { get; set; }
        public Nullable<int> compId { get; set; }
        public string compPicture { get; set; }
    
        public virtual setupComponentTBL setupComponentTBL { get; set; }
        public virtual compPictureTBL compPictureTBL1 { get; set; }
        public virtual compPictureTBL compPictureTBL2 { get; set; }
    }
}
