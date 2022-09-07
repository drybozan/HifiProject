using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HiFi.Dto.Dtos;
using HiFi.EF.Models;

namespace HiFi.Dto
{
    public class LogDto
    {
        /// <summary> Eşleyini; logTBL = "logId" </summary>
        [Display(Name = "Log Id")]
        [Required]
        public int LogId { get; set; }

        /// <summary> Eşleyini; logTBL = "memberId" </summary>
        [Display(Name = "Üye Id")]
        [Required]
        public Nullable<int> MemberId { get; set; }

        /// <summary> Eşleyini; logTBL = "logUsername" </summary>
        [Display(Name = "Kullanıcı Adı")]
        [Required]
        [MaxLength(50, ErrorMessage = "Bu alana en fazla 100 karakter yazılabilir")]
        public string LogUsername { get; set; }

        /// <summary> Eşleyini; logTBL = "logActivity" </summary>
        [Display(Name = "Log Aktivite")]
        [Required]
        public string LogActivity { get; set; }

        /// <summary> Eşleyini; logTBL = "logDate" </summary>
        [Display(Name = "Log Tarihi")]
        [Required]
        public Nullable<System.DateTime> LogDate { get; set; }

        /// <summary> Eşleyini; logTBL = "ipAddress" </summary>
        [Display(Name = "IP Adresi")]
        [Required]
        [MaxLength(16, ErrorMessage = "Bu alana en fazla 16 karakter yazılabilir")]
        public string IpAddress { get; set; }

    }

    public class LogProfile : Profile
    {
        public LogProfile()
        {
            //Dto içerisindeki varlıkları veritabanı içerisindeki varlıklar ile eşler.
            CreateMap<logTBL, LogDto>()
                .ForMember(d => d.LogId, o => o.MapFrom(s => s.logId))
                .ForMember(d => d.IpAddress, o => o.MapFrom(s => s.ipAddress))
                .ForMember(d => d.LogActivity, o => o.MapFrom(s => s.logActivity))
                .ForMember(d => d.LogDate, o => o.MapFrom(s => s.logDate))
                .ForMember(d => d.LogUsername, o => o.MapFrom(s => s.logUsername))
                .ForMember(d => d.MemberId, o => o.MapFrom(s => s.memberId))
                

                .ReverseMap()
                .ForMember(s => s.logId, o => o.MapFrom(d => d.LogId))
                .ForMember(s => s.ipAddress, o => o.MapFrom(d => d.IpAddress))
                .ForMember(s => s.logActivity, o => o.MapFrom(d => d.LogActivity))
                .ForMember(s => s.logDate, o => o.MapFrom(d => d.LogDate))
                .ForMember(s => s.logUsername, o => o.MapFrom(d => d.LogUsername))
                .ForMember(s => s.memberId, o => o.MapFrom(d => d.MemberId));


            ;


        }
    }
}
