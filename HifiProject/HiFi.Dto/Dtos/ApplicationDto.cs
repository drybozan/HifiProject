using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using HiFi.EF.Models;

namespace HiFi.Dto.Dtos
{
    public class ApplicationDto
    {
        /// <summary> Eşleyini; applicationTBL = "appId" </summary>
        [Display(Name = "Başvuru Id")]
        public int AppId { get; set; }

        /// <summary> Eşleyini; applicationTBL = "name" </summary>
        [Display(Name = "Ad")]
        [Required]
        [MaxLength(100, ErrorMessage = "Bu alana en fazla 100 karakter yazılabilir")]
        public string AppName { get; set; }

        /// <summary> Eşleyini; applicationTBL = "surname" </summary>
        [Display(Name = "Soyad")]
        [Required]
        [MaxLength(100, ErrorMessage = "Bu alana en fazla 100 karakter yazılabilir")]
        public string AppSurname { get; set; }

        /// <summary> Eşleyini; applicationTBL = "phone" </summary>
        [Display(Name = "Telefon No")]
        [Required]
        [MaxLength(15, ErrorMessage = "Bu alana en fazla 15 karakter yazılabilir")]
        public string Phone { get; set; }

        /// <summary> Eşleyini; applicationTBL = "memberActive" </summary>
        [Display(Name = "Aktiflik")]
        [Required]
        public Nullable<bool> MemberActive { get; set; }

        /// <summary> Eşleyini; applicationTBL = "applicationDate" </summary>
        [Display(Name = "Başvuru Tarihi")]
        [Required]
        public Nullable<System.DateTime> applicationDate { get; set; }

        /// <summary> Eşleyini; applicationTBL = "userType" </summary>
        [Display(Name = "Kullanıcı Tipi")]
        [Required]
        public Nullable<int> UserType { get; set; }

        /// <summary> Eşleyini; applicationTBL = "username" </summary>
        [Display(Name = "Kullanıcı Adı")]
        [Required]
        [MaxLength(50, ErrorMessage = "Bu alana en fazla 50 karakter yazılabilir")]
        public string Username { get; set; }

        /// <summary> Eşleyini; applicationTBL = "password" </summary>
        [Display(Name = "Kullanıcı Şifre")]
        [Required]
        [MaxLength(30, ErrorMessage = "Bu alana en fazla 30 karakter yazılabilir")]
        public string Password { get; set; }

        /// <summary> Eşleyini; applicationTBL = "mail" </summary>
        [Display(Name = "Kullanıcı Email")]
        [Required]
        [MaxLength(100, ErrorMessage = "Bu alana en fazla 100 karakter yazılabilir")]
        public string Mail { get; set; }

        /// <summary> Eşleyini; applicationTBL = "passwordDuration" </summary>
        [Display(Name = "Şifre Son Geçerlilik Tarihi")]
        [Required]
        public Nullable<System.DateTime> PasswordDuration { get; set; }

        /// <summary> Eşleyini; applicationTBL = "profilePicture" </summary>
        [Display(Name = "Profil Fotoğrafı")]
        [Required]
        public string ProfilePicture { get; set; }

        /// <summary> Eşleyini; applicationTBL = "profileDetail" </summary>
        [Display(Name = "Kullanıcı Hakkında")]
        [Required]
        public string ProfileDetail { get; set; }

        public Nullable<bool> IsDelete { get; set; }
    }
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            //Dto içerisindeki varlıkları veritabanı içerisindeki varlıklar ile eşler.
            CreateMap<applicationTBL, ApplicationDto>()
                .ForMember(d => d.AppId, o => o.MapFrom(s => s.appId))
                .ForMember(d => d.AppName, o => o.MapFrom(s => s.name))
                .ForMember(d => d.AppSurname, o => o.MapFrom(s => s.surname))
                .ForMember(d => d.Phone, o => o.MapFrom(s => s.phone))
                .ForMember(d => d.MemberActive, o => o.MapFrom(s => s.memberActive))
                .ForMember(d => d.applicationDate, o => o.MapFrom(s => s.applicationDate))
                .ForMember(d => d.UserType, o => o.MapFrom(s => s.userType))
                .ForMember(d => d.Username, o => o.MapFrom(s => s.username))
                .ForMember(d => d.Password, o => o.MapFrom(s => s.password))
                .ForMember(d => d.Mail, o => o.MapFrom(s => s.mail))
                .ForMember(d => d.PasswordDuration, o => o.MapFrom(s => s.passwordDuration))
                .ForMember(d => d.ProfilePicture, o => o.MapFrom(s => s.profilePicture))
                .ForMember(d => d.ProfileDetail, o => o.MapFrom(s => s.profileDetail))
                .ForMember(d => d.IsDelete, o => o.MapFrom(s => s.isDelete))
                .ReverseMap()
                .ForMember(s => s.appId, o => o.MapFrom(d => d.AppId))
                .ForMember(s => s.name, o => o.MapFrom(d => d.AppName))
                .ForMember(s => s.surname, o => o.MapFrom(d => d.AppSurname))
                .ForMember(s => s.phone, o => o.MapFrom(d => d.Phone))
                .ForMember(s => s.memberActive, o => o.MapFrom(d => d.MemberActive))
                .ForMember(s => s.applicationDate, o => o.MapFrom(d => d.applicationDate))
                .ForMember(d => d.userType, o => o.MapFrom(s => s.UserType))
                .ForMember(d => d.username, o => o.MapFrom(s => s.Username))
                .ForMember(d => d.password, o => o.MapFrom(s => s.Password))
                .ForMember(d => d.mail, o => o.MapFrom(s => s.Mail))
                .ForMember(d => d.passwordDuration, o => o.MapFrom(s => s.PasswordDuration))
                .ForMember(d => d.profilePicture, o => o.MapFrom(s => s.ProfilePicture))
                .ForMember(d => d.profileDetail, o => o.MapFrom(s => s.ProfileDetail))
                .ForMember(d => d.isDelete, o => o.MapFrom(s => s.IsDelete))
                ;
            ;
        }
    }
}
