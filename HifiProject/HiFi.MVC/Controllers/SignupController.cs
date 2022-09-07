using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HiFi.Dto.Dtos;
using HiFi.MVC.Filter;
using HiFi.Services.Services;
namespace HiFi.MVC.Controllers
{

    public class SignupController : Controller
    {
        ApplicationService aps = new ApplicationService();
        // GET: Signup
        [HttpGet]
        public ActionResult Signup()
        {
            ViewBag.App2 = TempData["app2"];
            ViewBag.App1= TempData["app1"];
            return View();
        }
        [HttpPost]
        public ActionResult Signup(ApplicationDto app)
        {
            var feedBack = aps.SendMailApp(app.Mail);
            if (feedBack == "success")
            {
                aps.AddApplication(app);
                TempData["app2"] = feedBack;
            }
            else
            {
                TempData["app1"] = feedBack;
            }
            return RedirectToAction("Signup");
        }
    }
}