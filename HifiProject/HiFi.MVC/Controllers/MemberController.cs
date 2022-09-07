using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HiFi.Dto;
using HiFi.MVC.Filter;
using HiFi.Services.Services;

namespace HiFi.MVC.Controllers
{
    [LogAction]
    [Authorize]
    public class MemberController : Controller
    {
        private MemberService ms = new MemberService();
        // GET: Member

        //kullanıcıların göreceği aktif üyeleri listeler
        public ActionResult Member()
        {
            var member = ms.GetAllMembers();
            var members = member.Where(x => x.MemberActive == true).ToList();
            return View(members);
        }
    }
}