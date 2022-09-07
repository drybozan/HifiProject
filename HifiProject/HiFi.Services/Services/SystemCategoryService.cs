using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiFi.Dto;

namespace HiFi.Services.Services
{
    public class SystemCategoryService
    {
        WebApiService<SystemCategoryDto> was = new WebApiService<SystemCategoryDto>();
        private string method = "systemcategoryapi";

        //Bütün systemcategory tablosunu çeker.
        public List<SystemCategoryDto> GetAllSystemCategory()
        {
            return was.Get(method+"/get");
        }

        //Verilen id değerine sahip systemcategory verisini çeker.
        public SystemCategoryDto GetSingleSystemCategory(int id)
        {
            var category = was.GetId(method+"/get", id);
            return category;
        }

        //Verilen id değerine sahip systemcategory verisini veritabanından siler.
        public void DeleteSystemCategory(int id)
        {
            was.Delete(method+"/delete", id);
        }

        //Yeni systemcategory ekler.
        public void AddSystemCategory(SystemCategoryDto value)
        {
            was.Post(method+"/post", value);
        }

        //Verilen id değerine sahip systemcategory verisini günceller.
        public void UpdateSystemCategory(int id, SystemCategoryDto value)
        {
            was.Put(method+"/put", id, value);
        }
    }
}

