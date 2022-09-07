using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using AutoMapper.QueryableExtensions;
using HiFi.Api.paged;
using HiFi.Common;
using HiFi.Dto;
using HiFi.EF.Models;
using HiFi.Repository;
using Newtonsoft.Json;

namespace HiFi.Api.Services
{
    public class LogApiService
    {
        private static HiFiDBEntities _dbContext = new HiFiDBEntities();
        private EFUnitOfWork _uow = new EFUnitOfWork(_dbContext);

        //parçalı log tablosunu döndürür.
        public string GetAllLogs(int PageNumber,int PageSize)
        {
           
            var logs = _uow.LogsTemplate.GetAll()
                .OrderByDescending(x=>x.logId ) //en yeni datadan itibaren sıralar
                .Skip((PageNumber-1)*PageSize) //Sayfa numarası * sayfa boyutuna göre belirli bir kayıt kümesini atlar.
                .Take(PageSize) //Yalnızca sayfa boyutuna göre belirlenen gerekli miktarda veriyi alır.
                .ProjectTo<LogDto>().ToList();
            var totalRecords = _uow.LogsTemplate.GetAll().Count();
           var pagedReponse = PaginationHelper.CreatePagedReponse<LogDto>(logs, PageNumber, PageSize, totalRecords);
           
            return JsonConvert.SerializeObject(pagedReponse);

        }

        //Bütün log tablosunu döndürür.
        public string GetAllLogs()
        {

            var logs = _uow.LogsTemplate.GetAll()
              
                .ProjectTo<LogDto>().ToList();
          

            return JsonConvert.SerializeObject(logs);

        }

        //Verilen id değerine sahip log verisini veritabanında bulur ve döndürür.
        public string GetLogById(int id)
        {
            var log = _uow.LogsTemplate.GetById(id).MapTo<LogDto>();
            return JsonConvert.SerializeObject(log);
        }

        //Verilen id değerine sahip log verisini veritabanından siler.
        public void DeleteLog(int id)
        {
            _uow.LogsTemplate.Delete(id);
            _uow.SaveChanges();
        }

        //Yeni log ekler.
        public void AddLog(LogDto newLog)
        {
            var mappedLog = newLog.MapTo<logTBL>();
            _uow.LogsTemplate.Add(mappedLog);
            _uow.SaveChanges();
        }

        //Verilen id değerine sahip log verisini günceller.
        public void UpdateLog(int id, LogDto newLog)
        {
            var log = _uow.LogsTemplate.GetById(id).MapTo<MemberDto>();
            if (log != null)
            {
                var mapped = newLog.MapTo<logTBL>();
                _uow.LogsTemplate.Update(mapped);
                _uow.SaveChanges();
            }
        }

    }
}