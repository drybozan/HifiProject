using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HiFi.Common.Helpers;
using HiFi.Dto;
using HiFi.MVC.Filter;
using HiFi.Services.Services;

namespace HiFi.MVC.Controllers
{

    public class SigninController : Controller
    {
        // GET: Signin
        [HttpGet]
        public ActionResult Signin()
        {
            ViewBag.Msg = TempData["msg"];
       
            return View();
        }

        [HttpPost]
        public ActionResult Signin(MemberDto model)
        {
            TokenService ts = new TokenService();
            var token = ts.CheckToken(model.Username, model.Password);
            if (token.access_token != null && token.expires_in != null && token.token_type != null)
            {
                SessionHelper.TokenInfo = token;
                SessionHelper.LoggedUserInfo = ts.GetLoggedUser();
              
                FormsAuthentication.SetAuthCookie(SessionHelper.LoggedUserInfo.MemberName, false);
                return RedirectToAction("Member", "Member");
                
            }
            else
            {
                TempData["sign"] = "Kullanıcı adı veya şifre yanlış !!";
                return RedirectToAction("Signin");
            }
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            ViewBag.Mail = TempData["mail"];
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(MemberDto member)
        {
            MemberService ms = new MemberService();
            TempData["mail"] = ms.SendMailPassword(member.Mail);
            return RedirectToAction("ForgotPassword");
        }

        [LogAction]
        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return View("Signin");
        }
    }
}