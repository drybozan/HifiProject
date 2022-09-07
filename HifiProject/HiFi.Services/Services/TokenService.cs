using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiFi.Dto;
using HiFi.Dto.Dtos;
using Newtonsoft.Json;

namespace HiFi.Services.Services
{
    
    public class TokenService
    {
        //Gelen bilgileri token almak için gönderir ve tokeni döndürür.
        public TokenDto CheckToken(string username, string password)
        {
            WebApiService<TokenDto> was = new WebApiService<TokenDto>();
            TokenDto token = was.GetToken(username, password);
            return token;
        }

        //Tokeni alan kullanıcı bilgilerini döndürür.
        public MemberDto GetLoggedUser()
        {
            WebApiService<MemberDto> was = new WebApiService<MemberDto>();
            return was.GetSingle("loginapi/get");
        }
    }
}
