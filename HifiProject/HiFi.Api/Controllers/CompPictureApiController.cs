using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using HiFi.Api.Services;
using HiFi.Dto.Dtos;

namespace HiFi.Api.Controllers
{
    public class CompPictureApiController : ApiController
    {
        CompPictureApiService cps=new CompPictureApiService();

        //Bütün compPicture tablosunu listeler.
        // GET api/<controller>
        public string Get()
        {
            return cps.GetAllCompPictures();
        }

        //Veritabanındaki gönderilen id'ye ait veri listeler.
        // GET api/<controller>/5
        public string Get(int id)
        {
            return cps.GetCompPictureById(id);
        }

        //Veritabanına gönderilen veriyi ekler.
        // POST api/<controller>
        //public void Post(CompPictureDto compPictureDto)
        //{
        //    cps.AddCompPicture(compPictureDto);
        //}

        //resim için
        public void Post(int id)
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                string path = HttpContext.Current.Server.MapPath("~/Uploads/CompPictures/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    string dir = Path.GetDirectoryName(postedFile.FileName);
                    string fNAme = Guid.NewGuid().ToString();
                    //string fNAme = Path.GetFileNameWithoutExtension(postedFile.FileName);
                    string fExt = Path.GetExtension(postedFile.FileName);
                    var filePath = Path.Combine(path, fNAme + fExt);
                    //int i = 1;
                    //while (File.Exists(filePath))
                    //{
                    //    filePath = Path.Combine(path, fNAme + "_" + i + fExt);
                    //    i++;
                    //}
                    postedFile.SaveAs(filePath);
                    cps.AddCompPicture(id, fNAme + fExt);
                }
            }
        }

        //Gönderilen id değerine sahip veriyi günceller.
        // PUT api/<controller>/5
        public void Update(int id, CompPictureDto value)
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                string path = HttpContext.Current.Server.MapPath("~/Uploads/SetupPictures");
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    string fNAme = Guid.NewGuid().ToString();
                    string fExt = Path.GetExtension(postedFile.FileName);
                    var filePath = Path.Combine(path, fNAme + fExt);
                    postedFile.SaveAs(filePath);
                    cps.UpdateCompPicture(id, fNAme + fExt, path);
                }
            }
        }

        //Veritabanındaki gönderilen id değerine sahip veriyi siler.
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            cps.DeleteCompPicture(id);
        }

        //Veritabanından gönderilen CompId'ye sahip veriler listelenir.
        // GET api/<controller>/GetCompPicByCompId/5
        public string GetCompPicByCompId(int id)
        {
            return cps.GetCompPicturesByCompId(id);
        }

     
    }
}