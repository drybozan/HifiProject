using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using HiFi.Api.Services;
using HiFi.Dto;

namespace HiFi.Api.Controllers
{
    public class SetupPictureApiController : ApiController
    {
        SetupPictureApiService sps=new SetupPictureApiService();
        string path = HttpContext.Current.Server.MapPath("~/Uploads/SetupPictures");
        //Bütün SetupPicture tablosunu listeler.
        // GET api/<controller>
        // [HttpGet]
        public string Get()
        {
            return sps.GetAllSetupPictures();
        }

        //Veritabanındaki gönderilen id'ye ait veri listelenir.
        // GET api/<controller>/5
        public string Get(int id)
        {
            return sps.GetSetupPictureById(id);
        }

        //Veritabanına gönderilen veriyi ekler.
        // POST api/<controller>
        public void Post(int id)
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    string fNAme = Guid.NewGuid().ToString();
                    string fExt = Path.GetExtension(postedFile.FileName);
                    var filePath = Path.Combine(path, fNAme + fExt);
                    postedFile.SaveAs(filePath);
                    sps.AddSetupPicture(id, fNAme + fExt);
                }
            }
        }

        //Gönderilen id değerine sahip veriyi günceller.
        // PUT api/<controller>/5
        public void Update(int id)
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    string fNAme = Guid.NewGuid().ToString();
                    string fExt = Path.GetExtension(postedFile.FileName);
                    var filePath = Path.Combine(path, fNAme + fExt);
                    postedFile.SaveAs(filePath);
                    sps.UpdateSetupPicture(id, fNAme + fExt,path);
                }
            }
        }

        //Veritabanındaki gönderilen id değerine sahip veriyi siler.
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            sps.DeleteSetupPicture(id,path);
        }

        //Veritabanından gönderilen SetupId'ye sahip veriler listelenir.
        // GET api/<controller>/GetSetupPictureBySetupId/5
        //[HttpGet]
        public string GetSetupPictureBySetupId(int id)
        {
            return sps.GetSetupPicBySetupId(id);
        }
    }
}