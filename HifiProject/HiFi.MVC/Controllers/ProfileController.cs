using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using HiFi.MVC.Filter;
using HiFi.Services.Services;

namespace HiFi.MVC.Views.Shared
{
    [LogAction]
    [Authorize]
    public class ProfileController : Controller
    {
        MemberService ms = new MemberService();
        CompPictureService cp = new CompPictureService();
        SetupService ss = new SetupService();
        SetupPictureService sps = new SetupPictureService();
        SetupComponentService sc = new SetupComponentService();

        // GET: Profile
        public ActionResult Profile(int id)
        {
            var x = ms.GetSingleMember(id);
            return View(x);
        }


        public PartialViewResult SetupPartial(int id)
        {
            var y = ss.GetAllSetupByMemberId(id);
            return PartialView(y);
        }

        public PartialViewResult SetupPicturePartial(int id)
        {
            var sp = sps.GetSetupPicturesBySetupId(id);
            return PartialView(sp);
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