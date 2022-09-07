using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiFi.Dto;

namespace HiFi.Services.Services
{
    public class SetupService
    {
        WebApiService<SetupDto> was = new WebApiService<SetupDto>();
        private string method = "setupapi";

        //Bütün setup tablosunu çeker.
        public List<SetupDto> GetAllSetups()
        {
            return was.Get(method+"/get");
        }

        //Verilen id değerine sahip setup verisini çeker.
        public SetupDto GetSingleSetup(int id)
        {
            var setup = was.GetId(method + "/get", id);
            return setup;
        }

        //Verilen id değerine sahip setup verisini veritabanından siler.
        public void DeleteSetup(int id)
        {
            was.Delete(method+"/delete", id);
        }

        //Yeni setup ekler.
        public void AddSetup(SetupDto value)
        {
            was.Post(method+"/post", value);
        }

        //Verilen id değerine sahip setup verisini günceller.
        public void UpdateSetup(int id, SetupDto value)
        {
            was.Put(method+"/put", id, value);
        }

        //Verilen memberId değerine sahip setup verilerini döndürür.
        public List<SetupDto> GetAllSetupByMemberId(int id)
        {
            string meth = method + "/GetSetupByMemberId";
            return was.GetSpecial(meth, id);
        }
    }
}
