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
using HiFi.EF.Models;

namespace HiFi.Api.Controllers
{
    public class MemberApiController : ApiController
    {
        MemberApiService ms = new MemberApiService();

        //Bütün member tablosunu listeler.
        // GET api/<controller>
        public string Get()
        {
            return ms.GetAllMembers();
        }

    
        // GET api/<controller>/5
        public string Get(int id)
        {
            return ms.GetMemberById(id);
        }

        //Veritabanına gönderilen veriyi ekler.
        //POST api/<controller>
        public void Post(MemberDto newMember)
        {
            ms.AddMember(newMember);
        }

        public void UploadProfilePicture(int id)
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                string path = HttpContext.Current.Server.MapPath("~/Uploads/Profile/");
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
                    var filePath = Path.Combine(path,fNAme + fExt);
                    //int i = 1;
                    //while (File.Exists(filePath))
                    //{
                    //    filePath = Path.Combine(path, fNAme + "_" + i + fExt);
                    //    i++;
                    //}
                    postedFile.SaveAs(filePath);
                    ms.UploadProfilePicture(id,fNAme+fExt);
                }
            }
        }
        //Gönderilen id değerine sahip veriyi günceller.
        // PUT api/<controller>/5
        public void Put(int id, MemberDto value)
        {
            ms.UpdateMember(id,value);
        }

        //Veritabanındaki gönderilen id değerine sahip veriyi siler.
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            ms.DeleteMember(id);
        }

        [Route("api/MemberApi/SendMail")]
        [HttpPost]
        public string SendMail([FromBody]string name)
        {
           return ms.SendMailPassword(name);
        }
    }
}