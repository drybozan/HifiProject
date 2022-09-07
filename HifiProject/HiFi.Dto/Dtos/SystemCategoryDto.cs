using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HiFi.EF.Models;

namespace HiFi.Dto
{
    public class SystemCategoryDto
    {
        /// <summary> Eşleyini; systemCategoryTBL = "ctgId" </summary>
        [Display(Name = "Kategori Id")]
        public int CtgId { get; set; }

        /// <summary> Eşleyini; systemCategoryTBL = "ctgName" </summary>
        [Display(Name = "Kategori Adı")]
        [Required]
        [MaxLength(100, ErrorMessage = "Bu alana en fazla 100 karakter yazılabilir")]
        public string CtgName { get; set; }

    }

    public class SystemCategoryProfile : Profile
    {
        public SystemCategoryProfile()
        {
            //Dto içerisindeki varlıkları veritabanı içerisindeki varlıklar ile eşler.
            CreateMap<systemCategoryTBL, SystemCategoryDto>()
                .ForMember(d => d.CtgId, o => o.MapFrom(s => s.ctgId))
                .ForMember(d => d.CtgName, o => o.MapFrom(s => s.ctgName))
                .ReverseMap()
                .ForMember(s => s.ctgId, o => o.MapFrom(d => d.CtgId))
                .ForMember(s => s.ctgName, o => o.MapFrom(d => d.CtgName))
                ;

        }
    }
}
