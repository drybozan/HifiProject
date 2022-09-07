using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using HiFi.Common;
using HiFi.Dto;
using HiFi.EF.Models;
using HiFi.Repository;
using Newtonsoft.Json;

namespace HiFi.Api.Services
{
    public class TokenApiService
    {
        private static HiFiDBEntities _dbContext = new HiFiDBEntities();
        private EFUnitOfWork _uow = new EFUnitOfWork(_dbContext);

        //Girilen kullanıcı bilglerini veritabanı içerisinde kontrol eder.
        public MemberDto CheckLogin(string username, string password)
        {
            var login = _uow.MembersTemplate.Get(x => x.username == username && x.password == password)
                .MapTo<MemberDto>();
            return login;
        }

        //Token üzerindeki kimlik bilgilerini döndürür.
        public string TakeUserInfo(ClaimsIdentity idt)
        {
            MemberDto user = new MemberDto();
            var carry = idt.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
            user.UserType = (carry[0].Equals("admin")) ? 0 : (carry[0].Equals("user")) ? 1 : 2;
            user.Username = idt.Name;
            user.EntryDate = Convert.ToDateTime(idt.Claims.FirstOrDefault(c => c.Type == "LoggedOn").Value);
            user.MemberId = Convert.ToInt32(idt.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            return JsonConvert.SerializeObject(user);
        }
    }
}