using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiFi.Dto;
using HiFi.Dto.Dtos;

namespace HiFi.Services.Services
{
    public class ApplicationService
    {
        WebApiService<ApplicationDto> was = new WebApiService<ApplicationDto>();
        private string method = "applicationapi";

        //Bütün application tablosunu çeker.
        public List<ApplicationDto> GetAllApplications()
        {
            return was.Get(method+"/get");
        }

        //Verilen id değerine sahip application verisini çeker.
        public ApplicationDto GetSingleApplication(int id)
        {
            var application = was.GetId(method+"/get", id);
            return application;
        }

        //Verilen id değerine sahip application verisini veritabanından siler.
        public void DeleteApplication(int id)
        {
            was.Delete(method+"/delete", id);
        }

        //Yeni application ekler.
        public void AddApplication(ApplicationDto value)
        {
            was.Post(method+"/post", value);
        }

        //Verilen id değerine sahip application verisini günceller.
        public void UpdateApplication(int id, ApplicationDto value)
        {
            was.Put(method+"/put", id, value);
        }
        public string SendMailPassword(string mail)
        {
            return was.GetMailFeedback(method + "/SendMail", mail);
        }

        public string SendMailInfo(string mail)
        {
            return was.GetMailFeedback(method + "/SendMailInfo", mail);
        }

        public string SendMailApp(string mail)
        {
            return was.GetMailFeedback(method + "/SendMailApp", mail);
        }
    }
}

