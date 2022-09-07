using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HiFi.Dto;
using HiFi.Dto.Dtos;
using HiFi.MVC.Filter;
using HiFi.Services.Services;

namespace HiFi.MVC.Controllers
{
    [LogAction]
    public class apidenemeController : Controller
    {
        CompPictureService cps=new CompPictureService();
        // GET: apideneme
        [HttpGet]
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Index(MemberDto compPictureDto)
        {
            
            return View();
        }
    }
}