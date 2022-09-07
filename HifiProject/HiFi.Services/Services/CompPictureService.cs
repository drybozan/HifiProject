using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HiFi.Dto;
using HiFi.Dto.Dtos;

namespace HiFi.Services.Services
{
    public class CompPictureService
    {
        WebApiService<CompPictureDto> was = new WebApiService<CompPictureDto>();
        private string method = "comppictureapi";

        //Bütün compPicture tablosunu çeker.
        public List<CompPictureDto> GetAllCompPictures()
        {
            return was.Get(method);
        }

        //Verilen id değerine sahip compPicture verisini çeker.
        public CompPictureDto GetSingleCompPicture(int id)
        {
            var compPic = was.GetId(method + "/get", id);
            return compPic;
        }

        //Verilen id değerine sahip compPicture verisini veritabanından siler.
        public void DeleteCompPicture(int id)
        {
            was.Delete(method, id);
        }

        //Yeni compPicture ekler.
        public void AddCompPicture(HttpPostedFileBase[] files, int id)
        {
            foreach (var item  in files)
            {
                was.UploadFile(method+"/post", id, item);
            }
            
        }

        //Verilen id değerine sahip compPicture verisini günceller.
        public void UpdateCompPicture(int id, HttpPostedFileBase file)
        {
            was.UploadFile(method + "/Update", id, file);
        }

        //Verilen compId değerine sahip compPicture verilerini çeker.
        public List<CompPictureDto> GetAllCompPicturesByCompId(int id)
        {
            string meth = method + "/GetCompPicByCompId";
            return was.GetSpecial(meth, id);
        }
    }
}
