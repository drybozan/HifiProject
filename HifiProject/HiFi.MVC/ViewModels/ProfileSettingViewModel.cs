using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HiFi.Dto;

namespace HiFi.MVC.ViewModels
{
    public class ProfileSettingViewModel
    {
        public MemberDto MemberDtos { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}