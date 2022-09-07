using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HiFi.Api.Services;
using HiFi.Dto.Dtos;

namespace HiFi.Api.Controllers
{
    public class ApplicationApiController : ApiController
    {
        ApplicationApiService aser = new ApplicationApiService();

        //Bütün application tablosunu listeler.
        // GET api/<controller>

        public string Get()
        {
            return aser.GetAllApplication();
        }

        //Veritabanındaki gönderilen id'ye ait veri listeler.
        // GET api/<controller>/5
        public string Get(int id)
        {
            return aser.GetApplicationById(id);
        }

        //Veritabanına gönderilen veriyi ekler.
        // POST api/<controller>
        public void Post(ApplicationDto newApp)
        {
            aser.AddApplication(newApp);
        }

        //Gönderilen id değerine sahip veriyi günceller.
        // PUT api/<controller>/5
        public void Put(int id, ApplicationDto value)
        {
            aser.UpdateApplication(id, value);
        }

        //Veritabanındaki gönderilen id değerine sahip veriyi siler.
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            aser.DeleteApplication(id);
        }

        //Yeni üyeye random oluşturulmuş bir şifreyi mail atar.
        [Route("api/ApplicationApi/SendMail")]
        [HttpPost]
        public string SendMail([FromBody] string name)
        {
            return aser.SendMailPassword(name);
        }

        //Üyelik reddedildiğine dair mail yollar.
        [Route("api/ApplicationApi/SendMailInfo")]
        [HttpPost]
        public string SendMailInfo([FromBody] string name)
        {
            return aser.SendMailInfo(name);
        }

        //Üyelik başvurusuna dair mail yollar.
        [Route("api/ApplicationApi/SendMailApp")]
        [HttpPost]
        public string SendMailApp([FromBody] string name)
        {
            return aser.SendMailApp(name);
        }
    }
}