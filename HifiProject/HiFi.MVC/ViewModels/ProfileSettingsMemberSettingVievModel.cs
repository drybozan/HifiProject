using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HiFi.Dto;

namespace HiFi.MVC.ViewModels
{
    public class ProfileSettingsMemberSettingVievModel
    {
        public MemberDto memberdtos { get; set; }

        [Display(Name = "Eski Şifre")]
        [MaxLength(30, ErrorMessage = "Bu alana en fazla 30 karakter yazılabilir")]
        public string oldPassword { get; set; }

        [Display(Name = "Yeni Şifre")]
        [MaxLength(30, ErrorMessage = "Bu alana en fazla 30 karakter yazılabilir")]
        public string newPassword1 { get; set; }

        [Display(Name = "Yeni Şifre")]
        [MaxLength(30, ErrorMessage = "Bu alana en fazla 30 karakter yazılabilir")]
        public string newPassword2 { get; set; }
    }
}