using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    public class SetupPictureApiService
    {
        private static HiFiDBEntities _dbContext = new HiFiDBEntities();
        private EFUnitOfWork _uow = new EFUnitOfWork(_dbContext);

        //Bütün setupPicture tablosunu döndürür.
        public string GetAllSetupPictures()
        {
            var setupPictures = _uow.SetupPicturesTemplate.GetAll().ProjectTo<SetupPictureDto>().ToList();
            return JsonConvert.SerializeObject(setupPictures);
        }


        //Verilen id değerine sahip setupPicture verisini veritabanında bulur ve döndürür.
        public string GetSetupPictureById(int id)
        {
            var setupPicture = _uow.SetupPicturesTemplate.GetById(id).MapTo<SetupPictureDto>();
            return JsonConvert.SerializeObject(setupPicture);
        }

        //Verilen id değerine sahip setupPicture verisini veritabanından siler.
        public void DeleteSetupPicture(int id, string filePath)
        {
            var picture = _uow.SetupPicturesTemplate.GetById(id).MapTo<SetupPictureDto>();
            FileInfo file = new FileInfo(filePath + "/" + picture.SetupPicture);
            if (file.Exists)
            {
                file.Delete();
            }

            _uow.SetupPicturesTemplate.Delete(id);
            _uow.SaveChanges();
        }

        //Yeni setupPicture ekler.
        //public void AddSetupPicture(SetupPictureDto setupPicture)
        //{
        //    var mappedSetupPicture = setupPicture.MapTo<setupPictureTBL>();
        //    _uow.SetupPicturesTemplate.Add(mappedSetupPicture);
        //    _uow.SaveChanges();
        //} 
        public void AddSetupPicture(int id, string filePath)
        {
            SetupPictureDto newCompPicture = new SetupPictureDto();
            newCompPicture.SetupPicture = filePath;
            newCompPicture.SetupId = id;
            var mappedCompPicture = newCompPicture.MapTo<setupPictureTBL>();
            _uow.SetupPicturesTemplate.Add(mappedCompPicture);
            _uow.SaveChanges();
        }

        //Verilen id değerine sahip setupPicture verisini günceller.
        public void UpdateSetupPicture(int id, string filePath, string path)
        {
            var picture = _uow.SetupPicturesTemplate.GetById(id).MapTo<SetupPictureDto>();
            if (picture != null)
            {
                FileInfo file = new FileInfo(path + "/" + picture.SetupPicture);
                if (file.Exists)
                {
                    file.Delete();
                }
                picture.SetupPicture = filePath;
                var mapped = picture.MapTo<setupPictureTBL>();
                _uow.SetupPicturesTemplate.Update(mapped);
                _uow.SaveChanges();
            }
        }
        //Verilen setupId'ye sahip setupPicture verilerini döndürür.
        public string GetSetupPicBySetupId(int id)
        {
            var setupPictures = _uow.SetupPicturesTemplate.GetAll(x => x.setupId == id).ProjectTo<SetupPictureDto>()
                .ToList();
            return JsonConvert.SerializeObject(setupPictures);
        }
    }
}