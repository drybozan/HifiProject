using HiFi.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HiFi.MVC.Controllers
{
    [Authorize]
    public class LogController : Controller
    {
        LogService logService = new LogService();

        static int  pageNumber =1;
        static int pageSize = 10;

        [HttpGet]
        public ActionResult Log()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetLog()
        {
            var logs = logService.GetAllLogs(pageNumber, pageSize);
            return Json(logs, JsonRequestBehavior.AllowGet);
        }


        public void DeleteLog(int id)
        {
            logService.DeleteLog(id);
        }

        [HttpPost]
        public void SetPageNumber(int id)
        {
            pageNumber = id;
           
        }
        [HttpPost]
        public void SetPageSize(int id)
        {
            pageSize = id;

        }

    }
}