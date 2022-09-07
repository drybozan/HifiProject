using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HiFi.Dto;
using Newtonsoft.Json;

namespace HiFi.Services.Services
{
    public class MemberService
    {
        WebApiService<MemberDto> was = new WebApiService<MemberDto>();
        private string method = "memberapi";

        //Bütün member tablosunu çeker.
        public List<MemberDto> GetAllMembers()
        {
            return was.Get(method+"/get");
        }

        //Verilen id değerine sahip member verisini çeker.
        public MemberDto GetSingleMember(int id)
        {
            var member = was.GetId(method + "/get", id);
            return member;
        }

        //Verilen id değerine sahip member verisini veritabanından siler.
        public void DeleteMember(int id)
        {
            was.Delete(method+"/delete", id);
        }

        //Yeni member ekler.
        public void AddMember(MemberDto value)
        {
            was.Post(method+"/post", value);
        }

        //Verilen id değerine sahip member verisini günceller.
        public void UpdateMember(int id, MemberDto value)
        {
            was.Put(method+"/put", id, value);
        }

        public void UploadPicture(HttpPostedFileBase file, int id)
        {
            method = method + "/UploadProfilePicture";
            was.UploadFile(method,id,file);
        }


        public string SendMailPassword(string mail)
        {
            return was.GetMailFeedback(method+ "/SendMail", mail);
        }
    }
}
