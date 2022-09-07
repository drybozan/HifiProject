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
    public class SetupApiController : ApiController
    {
        SetupService ss=new SetupService();

        //Bütün setup tablosunu listeler.
        // GET api/<controller>
        public string Get()
        {
            return ss.GetAllSetups();
        }

        //Veritabanındaki gönderilen id'ye ait veri listelenir.
        // GET api/<controller>/5
        public string Get(int id)
        {
            return ss.GetSetupById(id);
        }

        //Veritabanına gönderilen veriyi ekler.
        // POST api/<controller>
        public void Post(SetupDto newSetup)
        {
            ss.AddSetup(newSetup);
        }

        //Gönderilen id değerine sahip veriyi günceller.
        // PUT api/<controller>/5
        public void Put(int id, SetupDto value)
        {
            ss.UpdateSetup(id,value);
        }

        //Veritabanındaki gönderilen id değerine sahip veriyi siler.
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            ss.DeleteSetup(id);
        }

        //Veritabanından gönderilen CompId'ye sahip veriler listelenir.
        // GET api/<controller>/GetSetupByMemberId/5
        public string GetSetupByMemberId(int id)
        {
            return ss.GetSetupByMemberId(id);
        }
    }
}