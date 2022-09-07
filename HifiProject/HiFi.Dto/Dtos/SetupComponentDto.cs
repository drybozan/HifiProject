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
    public class SetupComponentDto
    {
        /// <summary> Eşleyini; setupComponentTBL = "compId" </summary>
        [Display(Name = "Setup Component Id")]
        public int CompId { get; set; }

        /// <summary> Eşleyini; setupComponentTBL = "memberId" </summary>
        [Display(Name = "Üye Id")]
        [Required]
        public Nullable<int> MemberId { get; set; }

        /// <summary> Eşleyini; setupComponentTBL = "setupId" </summary>
        [Display(Name = "Setup Id")]
        [Required]
        public Nullable<int> SetupId { get; set; }

        /// <summary> Eşleyini; setupComponentTBL = "compDetail" </summary>
        [Display(Name = "Component Detay")]
        [Required]
        public string CompDetail { get; set; }


        /// <summary> Eşleyini; setupComponentTBL = "ctgId" </summary>
        [Display(Name = "System Kategori Id")]
        [Required]
        public Nullable<int> CtgId { get; set; }

        [Display(Name = "Kategori Adı")]
        public string categoryName { get; set; }

        [Display(Name = "Setup Adı")]
        public string SetupName { get; set; }
    }
    public class SetupComponentProfile : Profile
    {
        public SetupComponentProfile()
        {
            //Dto içerisindeki varlıkları veritabanı içerisindeki varlıklar ile eşler.
            CreateMap<setupComponentTBL, SetupComponentDto>()
                .ForMember(d => d.CompId, o => o.MapFrom(s => s.compId))
                .ForMember(d => d.MemberId, o => o.MapFrom(s => s.memberId))
                .ForMember(s => s.SetupId, o => o.MapFrom(d => d.setupId))
                .ForMember(s => s.CompDetail, o => o.MapFrom(d => d.compDetail))
                .ForMember(s => s.CtgId, o => o.MapFrom(d => d.ctgId))
                .ForMember(s => s.categoryName, o => o.MapFrom(d => d.systemCategoryTBL.ctgName))
                .ForMember(s => s.SetupName, o => o.MapFrom(d => d.setupTBL.setupName))
                .ReverseMap()
                .ForMember(s => s.compId, o => o.MapFrom(d => d.CompId))
                .ForMember(s => s.memberId, o => o.MapFrom(d => d.MemberId))
                .ForMember(s => s.setupId, o => o.MapFrom(d => d.SetupId))
                .ForMember(s => s.compDetail, o => o.MapFrom(d => d.CompDetail))
                .ForMember(s => s.ctgId, o => o.MapFrom(d => d.CtgId))
                .ForMember(d => d.systemCategoryTBL, o => o.Ignore())
                .ForMember(d => d.setupTBL, o => o.Ignore())
                ;
            ;

        }
    }
}
