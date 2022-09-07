using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using HiFi.EF.Models;

namespace HiFi.Dto
{
    public class MemberDto 
    {
        /// <summary> Eşleyini; memberTBL = "memberId" </summary>
        [Display(Name = "Üye Id")]
        public int MemberId { get; set; }
        /// <summary> Eşleyini; memberTBL = "name" </summary>
        [Display(Name = "Üye Adı")]
        [Required]
        [MaxLength(100, ErrorMessage = "Bu alana en fazla 100 karakter yazılabilir")]
        public string MemberName { get; set; }

        /// <summary> Eşleyini; memberTBL = "surname" </summary>
        [Display(Name = "Üye Soyadı")]
        [Required]
        [MaxLength(100, ErrorMessage = "Bu alana en fazla 100 karakter yazılabilir")]
        public string MemberSurname { get; set; }

        /// <summary> Eşleyini; memberTBL = "phone" </summary>
        [Display(Name = "Telefon No")]
        [Required]
        [MaxLength(15, ErrorMessage = "Bu alana en fazla 15 karakter yazılabilir")]
        public string MemberPhone { get; set; }

        /// <summary> Eşleyini; memberTBL = "memberActive" </summary>
        [Display(Name = "Üyelik Aktifliği")]
        [Required]
        public Nullable<bool> MemberActive { get; set; }

        /// <summary> Eşleyini; memberTBL = "entryDate" </summary>
        [Display(Name = "Üyelik Tarihi")]
        [Required]
        public Nullable<System.DateTime> EntryDate { get; set; }

        /// <summary> Eşleyini; memberTBL = "userType" </summary>
        [Display(Name = "KullanıcıTipi")]
        [Required]
        public Nullable<int> UserType { get; set; }

        /// <summary> Eşleyini; memberTBL = "username" </summary>
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adınızı giriniz")]
        [MaxLength(50, ErrorMessage = "Bu alana en fazla 50 karakter yazılabilir")]
        public string Username { get; set; }

        /// <summary> Eşleyini; memberTBL = "password" </summary>
        [Display(Name = "Şifre")]
        [Required]
        [MaxLength(30, ErrorMessage = "Bu alana en fazla 30 karakter yazılabilir")]
        public string Password { get; set; }

        /// <summary> Eşleyini; memberTBL = "mail" </summary>
        [Display(Name = "Email")]
        [Required]
        [MaxLength(100, ErrorMessage = "Bu alana en fazla 100 karakter yazılabilir")]
        public string Mail { get; set; }

        /// <summary> Eşleyini; memberTBL = "entryDate" </summary>
        [Display(Name = "Şifre Son Geçerlilik Tarihi")]
        [Required]
        public Nullable<System.DateTime> PasswordDuration { get; set; }

        /// <summary> Eşleyini; memberTBL = "profilePicture" </summary>
        [Display(Name = "Profil Fotoğrafı")]
        [Required]
        public string ProfilePicture { get; set; }

        /// <summary> Eşleyini; memberTBL = "profileDetail" </summary>
        [Display(Name = "Üye Hakkında")]
        [Required]
        public string ProfileDetail { get; set; }
    }

    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            //Dto içerisindeki varlıkları veritabanı içerisindeki varlıklar ile eşler.
            CreateMap<memberTBL, MemberDto>()
                .ForMember(d => d.MemberId, o => o.MapFrom(s => s.memberId))
                .ForMember(d => d.MemberName, o => o.MapFrom(s => s.name))
                .ForMember(d => d.MemberSurname, o => o.MapFrom(s => s.surname))
                .ForMember(d => d.MemberPhone, o => o.MapFrom(s => s.phone))
                .ForMember(d => d.MemberActive, o => o.MapFrom(s => s.memberActive))
                .ForMember(d => d.EntryDate, o => o.MapFrom(s => s.entryDate))
                .ForMember(d => d.UserType, o => o.MapFrom(s => s.userType))
                .ForMember(d => d.Username, o => o.MapFrom(s => s.username))
                .ForMember(d => d.Password, o => o.MapFrom(s => s.password))
                .ForMember(d => d.Mail, o => o.MapFrom(s => s.mail))
                .ForMember(d => d.PasswordDuration, o => o.MapFrom(s => s.passwordDuration))
                .ForMember(d => d.ProfilePicture, o => o.MapFrom(s => s.profilePicture))
                .ForMember(d => d.ProfileDetail, o => o.MapFrom(s => s.profileDetail))
                .ReverseMap()
                .ForMember(s => s.memberId, o => o.MapFrom(d => d.MemberId))
                .ForMember(s => s.name, o => o.MapFrom(d => d.MemberName))
                .ForMember(s => s.surname, o => o.MapFrom(d => d.MemberSurname))
                .ForMember(s => s.phone, o => o.MapFrom(d => d.MemberPhone))
                .ForMember(s => s.memberActive, o => o.MapFrom(d => d.MemberActive))
                .ForMember(s => s.entryDate, o => o.MapFrom(d => d.EntryDate))
                .ForMember(d => d.userType, o => o.MapFrom(s => s.UserType))
                .ForMember(d => d.username, o => o.MapFrom(s => s.Username))
                .ForMember(d => d.password, o => o.MapFrom(s => s.Password))
                .ForMember(d => d.mail, o => o.MapFrom(s => s.Mail))
                .ForMember(d => d.passwordDuration, o => o.MapFrom(s => s.PasswordDuration))
                .ForMember(d => d.profilePicture, o => o.MapFrom(s => s.ProfilePicture))
                .ForMember(d => d.profileDetail, o => o.MapFrom(s => s.ProfileDetail))
                ;
            ;
        }
    }
}
