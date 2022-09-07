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
    public class SetupComponentApiService
    {
        private static HiFiDBEntities _dbContext = new HiFiDBEntities();
        private EFUnitOfWork _uow = new EFUnitOfWork(_dbContext);

        //Bütün setupComponent tablosunu döndürür.
        public string GetAllSetupComps()
        {
            var setupComps = _uow.SetupComponentsTemplate.GetAll().ProjectTo<SetupComponentDto>().ToList();
            return JsonConvert.SerializeObject(setupComps);
        }

        //Verilen id değerine sahip setupComponent verisini veritabanında bulur ve döndürür.
        public string GetSetupCompById(int id)
        {
            var setupComp = _uow.SetupComponentsTemplate.GetById(id).MapTo<SetupComponentDto>();
            return JsonConvert.SerializeObject(setupComp);
        }

        //Verilen id değerine sahip setupComponent verisini veritabanından siler.
        public void DeleteSetupComp(int id)
        {
            _uow.SetupComponentsTemplate.Delete(id);
            _uow.SaveChanges();
        }

        //Yeni setupComponent ekler.
        public void AddSetupComp(SetupComponentDto newSetupComp)
        {
            var mappedSetupComp = newSetupComp.MapTo<setupComponentTBL>();
            _uow.SetupComponentsTemplate.Add(mappedSetupComp);
            _uow.SaveChanges();
        }

        //Verilen id değerine sahip setupPicture verisini günceller.
        public void UpdateSetupComp(int id, SetupComponentDto newSetupComp)
        {
            var setupComp = _uow.SetupComponentsTemplate.GetById(id).MapTo<SetupComponentDto>();
            if (setupComp != null)
            {
                var mappedSetupComp = newSetupComp.MapTo<setupComponentTBL>();
                _uow.SetupComponentsTemplate.Update(mappedSetupComp);
                _uow.SaveChanges();
            }
        }

        //Verilen memberId değerine sahip setupComponent verilerini döndürür.
        public string GetSetupCompByMemberId(int id)
        {
            var setupComp = _uow.SetupComponentsTemplate.GetAll(x => x.memberId == id).ProjectTo<SetupComponentDto>().ToList();
            return JsonConvert.SerializeObject(setupComp);
        }

        //Verilen setupId'ye sahip setupComponent verilerini döndürür.
        public string GetSetupCompBySetupId(int id)
        {
            var setupComp = _uow.SetupComponentsTemplate.GetAll(x => x.setupId == id).ProjectTo<SetupComponentDto>().ToList();
            return JsonConvert.SerializeObject(setupComp);
        }
    }
}