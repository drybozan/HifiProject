using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HiFi.Dto;

namespace HiFi.Services.Services
{
    public class SetupPictureService
    {
        WebApiService<SetupPictureDto> was = new WebApiService<SetupPictureDto>();
        private string method = "setuppictureapi";

        //Bütün setuppicture tablosunu çeker.
        public List<SetupPictureDto> GetAllSetupPictures()
        {
            return was.Get(method);
        }

        public List<SetupPictureDto> GetSetupPicturesBySetupId(int id)
        {
            string meth = method + "/GetSetupPictureBySetupId";
            return was.GetSpecial(meth, id);
        }
        //Verilen id değerine sahip setuppicture verisini çeker.
        public SetupPictureDto GetSingleSetupPicture(int id)
        {
            var setupPicture = was.GetId(method+"/get", id);
            return setupPicture;
        }

        //Verilen id değerine sahip setuppicture verisini veritabanından siler.
        public void DeleteSetupPicture(int id)
        {
            was.Delete(method+"/delete", id);
        }

        //Yeni setuppicture ekler.
        public void AddSetupPicture(HttpPostedFileBase[] files, int id)
        {
            foreach (var item in files)
            {
                was.UploadFile(method + "/post", id, item);
            }
        }

        //Verilen id değerine sahip setuppicture verisini günceller.
        public void UpdateSetupPicture(int id, HttpPostedFileBase file)
        {
            was.UploadFile(method+ "/Update", id,file);
        }
    }
}

