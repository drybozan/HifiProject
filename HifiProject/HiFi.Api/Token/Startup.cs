﻿using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using WebApi;

[assembly: OwinStartup(typeof(HiFi.Api.Token.Startup))]

namespace HiFi.Api.Token
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            ConfigureOAuth(app);
            WebApiConfig.Register(httpConfiguration);
            app.UseWebApi(httpConfiguration);
        }

        void ConfigureOAuth(IAppBuilder app)
        {
            //Token üretimi için authorization ayarlarını belirliyoruz.
            OAuthAuthorizationServerOptions oAuthAuthorizationServerOptions = new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new PathString("/token"), //Token talebini yapacağımız dizin.
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(4), //Oluşturulacak tokenin geçerlilik zamanını ayarlıyoruz.
                AllowInsecureHttp = true, //Güvensiz http portuna izin veriyoruz.
                Provider = new ProviderAuthorization() //Sağlayıcı sınıfını belirtiyoruz.
            };

            //Yukarıda belirlemiş olduğumuz authorization ayarlarında çalışması için server'a ilgili OAuthAuthorizationServerOptions
            //tipindeki nesneyi gönderiyoruz.
            app.UseOAuthAuthorizationServer(oAuthAuthorizationServerOptions);

            //Authentication Type olarak Bearer Authentication'ı kullanacağımızı belirtiyoruz.
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}
