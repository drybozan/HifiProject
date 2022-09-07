using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiFi.Dto;
using HiFi.Dto.ModelForJson;

namespace HiFi.Services.Services
{
    public class LogService
    {
        WebApiService<LogDto> was = new WebApiService<LogDto>();
        WebApiService<LogModel> wasf = new WebApiService<LogModel>();
        private string method = "logapi";

        //Bütün log tablosunu çeker.
        public LogModel GetAllLogs(int pageNumber, int pageSize)
        {
            return wasf.Get(method + "/get", pageNumber, pageSize);
        }
        public List<LogDto> GetAllLogs()
        {
            return was.Get(method + "/get");
        }

        //Verilen id değerine sahip log verisini çeker.
        public LogDto GetSingleLog(int id)
        {
            var log = was.GetId(method+"/get", id);
            return log;
        }

        //Verilen id değerine sahip log verisini veritabanından siler.
        public void DeleteLog(int id)
        {
            was.Delete(method +"/delete", id);
        }

        //Yeni log ekler.
        public void AddLog(LogDto value)
        {
            was.Post(method+"/post", value);
        }

        //Verilen id değerine sahip log verisini günceller.
        public void UpdateLog(int id, LogDto value)
        {
            was.Put(method+"/put", id, value);
        }
    }
}
