using System;
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
    public class SetupPictureDto
    {
        /// <summary> Eşleyini; setupPictureTBL = "setupPicId" </summary>
        [Display(Name = "Setup Fotoğraf Id")]
        public int SetupPicId { get; set; }

        /// <summary> Eşleyini; setupPictureTBL = "setupId" </summary>
        [Display(Name = "Setup  Id")]
        [Required]
        public Nullable<int> SetupId { get; set; }

        /// <summary> Eşleyini; setupPictureTBL = "setupPicture" </summary>
        [Display(Name = "Setup Fotoğraf")]
        [Required]
        public string SetupPicture { get; set; }

    }

    public class SetupPictureProfile : Profile
    {
        public SetupPictureProfile()
        {
            //Dto içerisindeki varlıkları veritabanı içerisindeki varlıklar ile eşler.
            CreateMap<setupPictureTBL, SetupPictureDto>()
                .ForMember(d => d.SetupPicId, o => o.MapFrom(s => s.setupPicId))
                .ForMember(d => d.SetupId, o => o.MapFrom(s => s.setupId))
                .ForMember(s => s.SetupPicture, o => o.MapFrom(d => d.setupPicture))
                .ReverseMap()
                .ForMember(s => s.setupPicId, o => o.MapFrom(d => d.SetupPicId))
                .ForMember(s => s.setupId, o => o.MapFrom(d => d.SetupId))
                .ForMember(s => s.setupPicture, o => o.MapFrom(d => d.SetupPicture))
                ;
            ;
        }


    }
}
