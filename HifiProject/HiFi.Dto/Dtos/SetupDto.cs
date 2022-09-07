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
    public class SetupDto
    {
        /// <summary> Eşleyini; setupTBL = "setupId" </summary>
        [Display(Name = "Setup Id")]
        public int SetupId { get; set; }

        /// <summary> Eşleyini; setupTBL = "memberId" </summary>
        [Display(Name = "Üye Id")]
        [Required]
        public Nullable<int> MemberId { get; set; }

        /// <summary> Eşleyini; setupTBL = "setupName" </summary>
        [Display(Name = "Setup Adı")]
        [Required]
        [MaxLength(100, ErrorMessage = "Bu alana en fazla 100 karakter yazılabilir")]
        public string SetupName { get; set; }

        /// <summary> Eşleyini; setupTBL = "setupActive" </summary>
        [Display(Name = "Setup Aktiflik")]
        [Required]
        public Nullable<bool> SetupActive { get; set; }

        /// <summary> Eşleyini; setupTBL = "setupDetail" </summary>
        [Display(Name = "Setup Detay")]
        [Required]
        public string SetupDetail { get; set; }


    }
    public class SetupProfile : Profile
    {
        public SetupProfile()
        {
            //Dto içerisindeki varlıkları veritabanı içerisindeki varlıklar ile eşler.
            CreateMap<setupTBL, SetupDto>()
                .ForMember(d => d.SetupId, o => o.MapFrom(s => s.setupId))
                .ForMember(d => d.MemberId, o => o.MapFrom(s => s.memberId))
                .ForMember(s => s.SetupName, o => o.MapFrom(d => d.setupName))
                .ForMember(s => s.SetupActive, o => o.MapFrom(d => d.setupActive))
                .ForMember(s => s.SetupDetail, o => o.MapFrom(d => d.setupDetail))
                .ReverseMap()
                .ForMember(s => s.setupId, o => o.MapFrom(d => d.SetupId))
                .ForMember(s => s.memberId, o => o.MapFrom(d => d.MemberId))
                .ForMember(s => s.setupName, o => o.MapFrom(d => d.SetupName))
                .ForMember(s => s.setupActive, o => o.MapFrom(d => d.SetupActive))
                .ForMember(s => s.setupDetail, o => o.MapFrom(d => d.SetupDetail))
                ;
            ;


        }
    }
}
