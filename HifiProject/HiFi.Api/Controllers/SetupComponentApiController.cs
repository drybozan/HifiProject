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
    public class SetupComponentApiController : ApiController
    {
        SetupComponentApiService scs=new SetupComponentApiService();

        //Bütün setupComponent tablosunu listeler.
        // GET api/<controller>
        public string Get()
        {
            return scs.GetAllSetupComps();
        }

        //Veritabanındaki gönderilen id'ye ait veri listelenir.
        // GET api/<controller>/5
        public string Get(int id)
        {
            return scs.GetSetupCompById(id);
        }

        //Veritabanına gönderilen veriyi ekler.
        // POST api/<controller>
        public void Post(SetupComponentDto value)
        {
            scs.AddSetupComp(value);
        }

        //Gönderilen id değerine sahip veriyi günceller.
        // PUT api/<controller>/5
        public void Put(int id, SetupComponentDto value)
        {
            scs.UpdateSetupComp(id,value);
        }

        //Veritabanındaki gönderilen id değerine sahip veriyi siler.
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            scs.DeleteSetupComp(id);
        }

        //Veritabanından gönderilen SetupId'ye sahip veriler listelenir.
        // GET api/<controller>/GetComponentBySetupId/5
        public string GetComponentBySetupId(int id)
        {
            return scs.GetSetupCompBySetupId(id);
        }

        //Veritabanından gönderilen MemberId'ye sahip veriler listelenir.
        // GET api/<controller>/GetComponentByMemberId/5
        public string GetComponentByMemberId(int id)
        {
            return scs.GetSetupCompByMemberId(id);
        }
    }
}