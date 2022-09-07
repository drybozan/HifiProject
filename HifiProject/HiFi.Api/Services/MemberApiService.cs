using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http.Results;
using AutoMapper.QueryableExtensions;
using HiFi.Dto;
using HiFi.EF.Models;
using HiFi.Repository;
using Newtonsoft.Json;
using HiFi.Common;
using MainProject.Scripts;


namespace HiFi.Api.Services
{
    public class MemberApiService
    {
        private static HiFiDBEntities _dbContext = new HiFiDBEntities();
        private EFUnitOfWork _uow = new EFUnitOfWork(_dbContext);

        //Bütün member tablosunu döndürür.
        public string GetAllMembers()
        {
            var members = _uow.MembersTemplate.GetAll().ProjectTo<MemberDto>().ToList();
            return JsonConvert.SerializeObject(members);
        }

        //Verilen id değerine sahip member verisini veritabanında bulur ve döndürür.
        public string GetMemberById(int id)
        {
            var member = _uow.MembersTemplate.GetById(id).MapTo<MemberDto>();
            return JsonConvert.SerializeObject(member);
        }

        //Verilen id değerine sahip member verisini veritabanından siler.
        public void DeleteMember(int id)
        {
            _uow.MembersTemplate.Delete(id);
            _uow.SaveChanges();
        }

        //Yeni member ekler.
        public void AddMember(MemberDto newMember)
        {
            var mappedMember = newMember.MapTo<memberTBL>();
            _uow.MembersTemplate.Add(mappedMember);
            _uow.SaveChanges();
        }

        //Verilen id değerine sahip member verisini günceller.
        public void UpdateMember(int id, MemberDto newMember)
        {
            var member = _uow.MembersTemplate.GetById(id).MapTo<MemberDto>();
            if (member != null)
            {
                var mapped = newMember.MapTo<memberTBL>();
                _uow.MembersTemplate.Update(mapped);
                _uow.SaveChanges();
            }
        }

        //POST
        public void UploadProfilePicture(int id,string filePath)
        {
            var mbr = _uow.MembersTemplate.GetById(id).MapTo<MemberDto>();
            mbr.ProfilePicture = filePath;
            var mappedMember = mbr.MapTo<memberTBL>();
            _uow.MembersTemplate.Update(mappedMember);
            _uow.SaveChanges();

        }
        //Gelen mail adresini kontrol eder eğer varsa yeni şifre yollar ve başarıyla yollandı dönüşünü verir yoksa başarısız dönüşünü verir.
        public string SendMailPassword(object mail)
        {
            var email = _uow.MembersTemplate.Get(x => x.mail == mail.ToString()).MapTo<MemberDto>();
            if (email != null)
            {
                Guid randomkey = Guid.NewGuid(); //32 karakterli kodu ürettik
                string Password = randomkey.ToString().Substring(0, 6); /// 6 haneli keyi password için aldık"
                Mail sender = new Mail();
                sender.sendMail(mail.ToString(), "Yeni Şifre", "Yeni Şifrenizle giriş yapabilirsiniz.\n Şifre : " + Password);
                email.Password = Password;
                UpdateMember(email.MemberId, email);
                return JsonConvert.SerializeObject("Yeni şifreniz email adresinize yollandı.");
            }
            else
            {
                return JsonConvert.SerializeObject("Kayıtlı email adresi bulunamadı.");
            }
        }
    }
}