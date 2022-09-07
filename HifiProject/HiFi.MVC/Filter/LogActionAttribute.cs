using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HiFi.Common.Helpers;
using HiFi.Dto;
using HiFi.Services.Services;

namespace HiFi.MVC.Filter
{
    public class LogActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            //var controller = filterContext.RequestContext.RouteData.Values.ContainsKey("Controller") ? filterContext.RequestContext.RouteData.Values["Controller"].ToString() : null;
            //var action = filterContext.RequestContext.RouteData.Values.ContainsKey("Action") ? filterContext.RequestContext.RouteData.Values["Action"].ToString() : null;
            //var area = filterContext.RequestContext.RouteData.DataTokens.ContainsKey("Area") ? filterContext.RequestContext.RouteData.DataTokens["Area"].ToString() : null;
            //var user = filterContext.HttpContext.User.Identity.Name;

            LogDto newLog = new LogDto();
            newLog.IpAddress = HttpContext.Current.Request.UserHostAddress;
            newLog.LogActivity = filterContext.HttpContext.Request.RawUrl;
            newLog.LogDate = DateTime.Now;
            //newLog.LogUsername = filterContext.RequestContext.HttpContext.User.Identity.Name;
            if (SessionHelper.LoggedUserInfo!=null)
            {
                newLog.LogUsername = SessionHelper.LoggedUserInfo.Username;
                newLog.MemberId = SessionHelper.LoggedUserInfo.MemberId;
            }
            else
            {
                newLog.LogUsername = "Anonymous";
            }
            LogService ls = new LogService();
            ls.AddLog(newLog);
            base.OnActionExecuting(filterContext);
        }
    }
}