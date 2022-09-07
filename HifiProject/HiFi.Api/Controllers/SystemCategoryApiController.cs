using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HiFi.Api.Services;
using HiFi.Dto;

namespace HiFi.Api.Controllers
{
    public class SystemCategoryApiController : ApiController
    {
        SystemCategoryApiService scs=new SystemCategoryApiService();

        //Bütün SystemCategory tablosunu listeler.
        // GET api/<controller>
        public string Get()
        {
            return scs.GetAllCategories();
        }

        //Veritabanındaki gönderilen id'ye ait veri listelenir.
        // GET api/<controller>/5
        public string Get(int id)
        {
            return scs.GetCategoriesById(id);
        }

        //Veritabanına gönderilen veriyi ekler.
        // POST api/<controller>
        public void Post(SystemCategoryDto value)
        {
            scs.AddCategories(value);
        }

        //Gönderilen id değerine sahip veriyi günceller.
        // PUT api/<controller>/5
        public void Put(int id, SystemCategoryDto value)
        {
            scs.UpdateCategories(id,value);
        }

        //Veritabanındaki gönderilen id değerine sahip veriyi siler.
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            scs.DeleteCategories(id);
        }
    }
}