using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper.QueryableExtensions;
using HiFi.Common;
using HiFi.Dto;
using HiFi.EF.Models;
using HiFi.Repository;
using Newtonsoft.Json;

namespace HiFi.Api.Services
{
    public class SetupService
    {
        private static HiFiDBEntities _dbContext = new HiFiDBEntities();
        private EFUnitOfWork _uow = new EFUnitOfWork(_dbContext);

        //Bütün setup tablosunu döndürür.
        public string GetAllSetups()
        {
            var setups = _uow.SetupsTemplate.GetAll().ProjectTo<SetupDto>().ToList();
            return JsonConvert.SerializeObject(setups);
        }

        //Verilen id değerine sahip setup verisini veritabanında bulur ve döndürür.
        public string GetSetupById(int id)
        {
            var setup = _uow.SetupsTemplate.GetById(id).MapTo<SetupDto>();
            return JsonConvert.SerializeObject(setup);
        }

        //Verilen id değerine sahip setup verisini veritabanından siler.
        public void DeleteSetup(int id)
        {
            _uow.SetupsTemplate.Delete(id);
            _uow.SaveChanges();
        }

        //Yeni setup ekler.
        public void AddSetup(SetupDto newSetup)
        {
            var mappedSetup = newSetup.MapTo<setupTBL>();
            _uow.SetupsTemplate.Add(mappedSetup);
            _uow.SaveChanges();
        }

        //Verilen id değerine sahip setup verisini günceller.
        public void UpdateSetup(int id, SetupDto newSetup)
        {
            var setup = _uow.SetupsTemplate.GetById(id).MapTo<SetupDto>();
            if (setup != null)
            {
                var mappedSetup = newSetup.MapTo<setupTBL>();
                _uow.SetupsTemplate.Update(mappedSetup);
                _uow.SaveChanges();
            }
        }

        //Verilen memberId'ye sahip setup verilerini döndürür.
        public string GetSetupByMemberId(int id)
        {
            var setup = _uow.SetupsTemplate.GetAll(x => x.memberId == id).ProjectTo<SetupDto>().ToList();
            return JsonConvert.SerializeObject(setup);
        }
    }
}