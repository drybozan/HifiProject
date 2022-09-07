using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using AutoMapper.QueryableExtensions;
using HiFi.Common;
using HiFi.Dto;
using HiFi.Dto.Dtos;
using HiFi.EF.Models;
using HiFi.Repository;
using MainProject.Scripts;
using Newtonsoft.Json;

namespace HiFi.Api.Services
{
    public class ApplicationApiService
    {
        private static HiFiDBEntities _dbContext = new HiFiDBEntities();
        private EFUnitOfWork _uow = new EFUnitOfWork(_dbContext);

        //Bütün başvuru tablosunu döndürür.
        public string GetAllApplication()
        {
            var apps = _uow.ApplicationTemplate.GetAll().ProjectTo<ApplicationDto>().ToList();
            return JsonConvert.SerializeObject(apps);
        }

        //Verilen id değerine sahip başvuru verisini veritabanında bulur ve döndürür.
        public string GetApplicationById(int id)
        {
            var app = _uow.ApplicationTemplate.GetById(id).MapTo<ApplicationDto>();
            return JsonConvert.SerializeObject(app);
        }

        //Verilen id değerine sahip başvuru verisini veritabanından siler.
        public void DeleteApplication(int id)
        {


            _uow.ApplicationTemplate.Delete(id);
            _uow.SaveChanges();
        }

        //Yeni başvuru ekler.
        public void AddApplication(ApplicationDto app)
        {
            var mappedApp = app.MapTo<applicationTBL>();
            _uow.ApplicationTemplate.Add(mappedApp);
            _uow.SaveChanges();
        }

        //Verilen id değerine sahip başvuru verisini günceller.
        public void UpdateApplication(int id, ApplicationDto appDto)
        {
            var app = _uow.ApplicationTemplate.GetById(id).MapTo<ApplicationDto>();
            if (app != null)
            {
                var mapped = appDto.MapTo<applicationTBL>();
                _uow.ApplicationTemplate.Update(mapped);
                _uow.SaveChanges();
            }
        }

        //Verilen mail adresine random oluşturulan şifreyi yollar.
        public string SendMailPassword(object mail)
        {
            var email = _uow.ApplicationTemplate.Get(x => x.mail == mail.ToString()).MapTo<ApplicationDto>();
            if (email != null)
            {
                Guid randomkey = Guid.NewGuid(); //32 karakterli kodu ürettik
                string Password = randomkey.ToString().Substring(0, 6); /// 6 haneli keyi password için aldık"
                Mail sender = new Mail();
                sender.sendMail(mail.ToString(), "Şifre Bildirimi", "Sitemize üye olduğunuz için teşekkürler. Size verdiğimiz şifre ile giriş yapabilirsiniz.\n Şifre : " + Password);
                email.Password = Password;
                email.PasswordDuration = DateTime.Now.AddMonths(3); /// şifre kullanım süresini 3 ay olarak güncelledik
                UpdateApplication(email.AppId, email);
                return JsonConvert.SerializeObject("Yeni şifreniz email adresinize yollandı.");
            }
            else
            {
                return JsonConvert.SerializeObject("Kayıtlı email adresi bulunamadı.");
            }
        }

        //Verilen mail adresine başvurunun reddini bildirir.
        public string SendMailInfo(object mail)
        {
            var email = _uow.ApplicationTemplate.Get(x => x.mail == mail.ToString()).MapTo<ApplicationDto>();
            if (email != null)
            {
                Mail sender = new Mail();
                sender.sendMail(mail.ToString(), "Üyelik Bildirimi", "Sitemize üye olma talebiniz reddedilmiştir. Sağlıklı günler dileriz.");

                return JsonConvert.SerializeObject("Bilgilendirme maili yollandı.");
            }
            else
            {
                return JsonConvert.SerializeObject("Kayıtlı email adresi bulunamadı.");
            }
        }

        //Verilen mail adresine başvurunun alındığını mail atar.
        public string SendMailApp(object mail)
        {
            var email = _uow.ApplicationTemplate.Get(x => x.mail == mail.ToString()).MapTo<ApplicationDto>();
            var member = _uow.MembersTemplate.Get(x => x.mail == mail.ToString()).MapTo<MemberDto>();
            if (member != null)
            {
                return JsonConvert.SerializeObject("Bu mail adresine kayıtlı üye mevcuttur.");
            }
            else if (email != null)
            {
                return JsonConvert.SerializeObject("Bu mail adresine kayıtlı başvuru mevcuttur.");
            }
            else
            {
                Mail sender = new Mail();
                sender.sendMail(mail.ToString(), "Üyelik Bildirimi", "Sitemize üye olma talebiniz alınmıştır. Başvurunuz en kısa sürede değerlendirilecektir.");
                return JsonConvert.SerializeObject("success");
            }
        }
    }
}