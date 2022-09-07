using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiFi.Dto;

namespace HiFi.Services.Services
{
    public class SetupComponentService
    {
        WebApiService<SetupComponentDto> was = new WebApiService<SetupComponentDto>();
        private string method = "setupcomponentapi";

        //Bütün setupcomponent tablosunu çeker.
        public List<SetupComponentDto> GetAllSetupComponents()
        {
            return was.Get(method+"/get");
        }

        //Verilen id değerine sahip setupcomponent verisini çeker.
        public SetupComponentDto GetSingleSetupComponent(int id)
        {
            var setupComp = was.GetId(method + "/get", id);
            return setupComp;
        }

        //Verilen id değerine sahip setupcomponent verisini veritabanından siler.
        public void DeleteSetupComponent(int id)
        {
            was.Delete(method+"/delete", id);
        }

        //Yeni setupcomponent ekler.
        public void AddSetupComponent(SetupComponentDto value)
        {
            was.Post(method+"/post", value);
        }

        //Verilen id değerine sahip setupcomponent verisini günceller.
        public void UpdateSetupComponent(int id, SetupComponentDto value)
        {
            was.Put(method+"/put", id, value);
        }

        //Verilen setupId değerine sahip setupComponent verilerini çeker.
        public List<SetupComponentDto> GetAllComponentBySetupId(int id)
        {
            string meth = method + "/GetComponentBySetupId";
            return was.GetSpecial(meth, id);
        }

        //Verilen memberId değerine sahip setupComponent verilerini çeker.
        public List<SetupComponentDto> GetAllComponentByMemberId(int id)
        {
            string meth = method + "/GetComponentByMemberId";
            return was.GetSpecial(meth, id);
        }
    }
}
