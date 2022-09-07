using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HiFi.Dto;

namespace HiFi.MVC.ViewModels
{
    public class SingleComponentVievModel
    {
        public SetupComponentDto SetupComponents { get; set; }
        public HttpPostedFileBase[] Files { get; set; }
    }
}