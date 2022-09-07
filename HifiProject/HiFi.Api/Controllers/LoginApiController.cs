using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using HiFi.Api.Services;

namespace HiFi.Api.Controllers
{
    public class LoginApiController : ApiController
    {
        private TokenApiService ts = new TokenApiService();

        //Giriş yapan kullanıcının token kimlik bilgilerini listeler.
        // GET api/<controller>
        public string Get()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return ts.TakeUserInfo(identity);
        }
    }
}
