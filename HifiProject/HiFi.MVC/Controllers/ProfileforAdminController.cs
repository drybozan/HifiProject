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
    public class ProfileforAdminController : Controller
    {
        MemberService ms = new MemberService();
        CompPictureService cp = new CompPictureService();
        SetupService ss = new SetupService();
        SetupComponentService sc = new SetupComponentService();
        // GET: Profile
        public ActionResult ProfileforAdmin(int id)
        {
            var x = ms.GetSingleMember(id);
            return View(x);
        }


        public PartialViewResult SetupPartial(int id)
        {
            var y = ss.GetAllSetupByMemberId(id);
            return PartialView(y);
        }


        public PartialViewResult SetupComponentPartial(int id)
        {
            var z = sc.GetAllComponentBySetupId(id);
            return PartialView(z);
        }

        public PartialViewResult ComponentPicturePartial(int id)
        {
            var v = cp.GetAllCompPicturesByCompId(id);
            return PartialView(v);
        }

      


    }
}
