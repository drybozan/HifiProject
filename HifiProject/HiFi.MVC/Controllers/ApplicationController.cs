using HiFi.Dto;
using HiFi.Dto.Dtos;
using HiFi.MVC.Filter;
using HiFi.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HiFi.MVC.Controllers
{
    [LogAction]
    [Authorize]
    public class ApplicationController : Controller
    {
        private ApplicationService applicationService = new ApplicationService();
        private MemberService memberService = new MemberService();
        // GET: Application

        //Başvurular ekranını döndürür.
        [HttpGet]
        public ActionResult Application()
        {       
          
            return View();
        }

        //Başvurları tablodan çeker ve başvurular ekranına gönderir.
        [HttpGet]
        public JsonResult GetAllApplications()
        {
            var app = applicationService.GetAllApplications();
            var apps = app.Where(x => x.IsDelete == null).ToList();
            return Json(apps, JsonRequestBehavior.AllowGet);
        }

       
       
        //Admin tarafından başvurusu onaylanan kullanıcının id siden tüm bilgilerini çeker. 
        //Başvuru onayı aldıktan sonra bir şifre gönderilir mail ile kullanıcıya.
        //Başvuru tablosundan kullanıcı bilgileri alınır üye tablosuna kaydedilir ve son olarak başvuru tablosundan ilgili id'li başvuru silinir.
        public void Accept(int id)
        {
            var appDto = applicationService.GetSingleApplication(id);
            applicationService.SendMailPassword(appDto.Mail);
            var takePassword = applicationService.GetSingleApplication(id);
            MemberDto member = new MemberDto();
            member.MemberName = appDto.AppName;
            member.MemberSurname = appDto.AppSurname;
            member.Username = appDto.Username;
            member.MemberPhone = appDto.Phone;
            member.Mail = appDto.Mail;
            member.EntryDate = DateTime.Now;
            member.UserType = 1;
            member.MemberActive = true;
            member.Password = takePassword.Password;
            member.PasswordDuration = takePassword.PasswordDuration;


            memberService.AddMember(member);
            applicationService.DeleteApplication(appDto.AppId);
       
        }

        //Admin tarafından başvurusu kabul edilmeyen başvurular isDelete flagı true yapılır ve kullanıcya bilgi mesajı gönderilir.
        public void DeleteApplication(int id)
        {
            var model = applicationService.GetSingleApplication(id);
            applicationService.SendMailInfo(model.Mail);
            applicationService.DeleteApplication(id);
        }


    }
}