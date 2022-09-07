using HiFi.Dto;
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
    public class MemberforAdminController : Controller
    {
        private MemberService ms = new MemberService();

        //admin için kullanıcıları listeleyecek ekranı döndürür.
        public ActionResult GetAllMembers()
        {
           
            return View();
        }

        //listelenecek üyeleri tablodan çeker ve view tarafında listelenir.
        [HttpGet]
        public JsonResult GetMembers()
        {
            var members = ms.GetAllMembers();
            return Json(members, JsonRequestBehavior.AllowGet);
        }

        // Admin, üye bilgilerini düzenlemek istediği kullanıcıyı seçer id ile tüm bilgileri modal üzerine aktarılır.
        [HttpGet]
        public PartialViewResult UpdateMember(int id)
        {
            MemberDto member = ms.GetSingleMember(id);
            return PartialView(member);
        }

        //Admin, düzenlediği bilgileri modal üzerinden datayı buraya gönderir ve tabloya kaydedilir.
        [HttpPost]
        public PartialViewResult UpdateMember(MemberDto memberDto)
        {
            int id = memberDto.MemberId;
            ms.UpdateMember(id, memberDto);
            return PartialView("GetAllMembers");
        }

        // Silinecek üyeler id ile gönderilir ve tablodan silinir.
        public void DeleteMember(int id)
        {
            ms.DeleteMember(id);
        }

    }
}
