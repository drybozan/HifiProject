using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using HiFi.EF.Models;

namespace HiFi.Dto.Dtos
{
    public class CompPictureDto
    {
        /// <summary> Eşleyini; compPictureTBL = "compPicId" </summary>
        [Display(Name = "Component Fotoğraf Id")]
        public int CompPicId { get; set; }

        /// <summary> Eşleyini; compPictureTBL = "compId" </summary>
        [Display(Name = "Component Id")]
        [Required]
        public Nullable<int> CompId { get; set; }

        /// <summary> Eşleyini; compPictureTBL = "compPicture" </summary>
        [Display(Name = "Component Fotoğraf")]
        [Required]
        public string CompPicture { get; set; }

    }
    public class CompPictureProfile : Profile
    {
        public CompPictureProfile()
        {
            //Dto içerisindeki varlıkları veritabanı içerisindeki varlıklar ile eşler.
            CreateMap<compPictureTBL, CompPictureDto>()
                .ForMember(d => d.CompId, o => o.MapFrom(s => s.compId))
                .ForMember(d => d.CompPicId, o => o.MapFrom(s => s.compPicId))
                .ForMember(d => d.CompPicture, o => o.MapFrom(s => s.compPicture))

                .ReverseMap()
                .ForMember(s => s.compId, o => o.MapFrom(d => d.CompId))
                .ForMember(s => s.compPicId, o => o.MapFrom(d => d.CompPicId))
                .ForMember(s => s.compPicture, o => o.MapFrom(d => d.CompPicture));


            


        }
    }
}


