using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HiFi.Dto;

namespace HiFi.MVC.ViewModels
{
    public class SettingsSetupPictureViewModel
    {
        public SetupPictureDto SetupPictures { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}