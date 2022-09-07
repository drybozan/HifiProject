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
    public class LogApiController : ApiController
    {
        LogApiService lg=new LogApiService();

        //parçalı log tablosunu listeler.
     
        public string Get(int pageNumber, int pageSize)
        {
            return lg.GetAllLogs(pageNumber, pageSize);
        }

        public string Get()
        {
            return lg.GetAllLogs();
        }

        //Veritabanındaki gönderilen id'ye ait veri listeler.

        public string Get(int id)
        {
            return lg.GetLogById(id);
        }

        //Veritabanına gönderilen veriyi ekler.
        // POST api/<controller>
        [HttpPost]
        public void Post(LogDto value)
        {
            lg.AddLog(value);
        }

        //Gönderilen id değerine sahip veriyi günceller.
        // PUT api/<controller>/5
        public void Put(int id, LogDto value)
        {
            lg.UpdateLog(id,value);
        }
        //Veritabanındaki gönderilen id değerine sahip veriyi siler.
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            lg.DeleteLog(id);
        }
    }
}