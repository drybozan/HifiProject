using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using HiFi.Dto;
using HiFi.Dto.Dtos;

namespace HiFi.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            GlobalConfiguration.Configure(WebApiConfig.Register);

            //Tabloları profilleriyle eşleştirir.
            AutoMapper.Mapper.Initialize(cfg =>
            {
                //mapping tables

                cfg.AddProfile<CompPictureProfile>();
                cfg.AddProfile<LogProfile>();
                cfg.AddProfile<MemberProfile>();
                cfg.AddProfile<SetupComponentProfile>();
                cfg.AddProfile<SetupProfile>();
                cfg.AddProfile<SetupPictureProfile>();
                cfg.AddProfile<SystemCategoryProfile>();
                cfg.AddProfile<ApplicationProfile>();
            });
        }
    }
}
