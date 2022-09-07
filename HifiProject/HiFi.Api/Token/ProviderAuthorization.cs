using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using HiFi.Api.Services;

namespace WebApi
{
    public class ProviderAuthorization : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            //Kullanıcı bilgilerinin boş olup olmadığını kontrol eder.
            if (context.UserName!= null && context.Password != null)
            {
                //Kullanıcı bilgileri servis üzerinden kontrol eder.
                TokenApiService ts = new TokenApiService();
                var loginData = ts.CheckLogin(context.UserName, context.Password);
                if (loginData != null)
                {
                    //Kullanıcı tipinin karşılığı ayarlar.
                    string userType="";
                    if (loginData.UserType == 0)
                    {
                        userType = "admin";

                    }
                    else if (loginData.UserType == 1)
                    {
                        userType = "user";
                    }
                    //Kullanıcı bilgilerine göre kimlik oluşturur.
                    ClaimsIdentity identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim(ClaimTypes.Role, userType));
                    identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                    identity.AddClaim(new Claim("UserId", loginData.MemberId.ToString()));
                    identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
                    context.Validated(identity);
                }
                else
                {
                    context.SetError("hata", "Kullanıcı adı veya şifre hatalı.");
                }
            }
            else
            {
                context.SetError("hata", "Kullanıcı adı veya şifre boş olamaz.");
            }

        }
    }
}