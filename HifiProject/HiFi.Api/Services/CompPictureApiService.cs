using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using AutoMapper.QueryableExtensions;
using HiFi.Common;
using HiFi.Dto;
using HiFi.Dto.Dtos;
using HiFi.EF.Models;
using HiFi.Repository;
using Newtonsoft.Json;

namespace HiFi.Api.Services
{
    public class CompPictureApiService
    {
        private static HiFiDBEntities _dbContext = new HiFiDBEntities();
        private EFUnitOfWork _uow = new EFUnitOfWork(_dbContext);

        //Bütün compPicture tablosunu döndürür.
        public string GetAllCompPictures()
        {
            var compPictures = _uow.CompPicturesTemplate.GetAll().ProjectTo<CompPictureDto>().ToList();
            return JsonConvert.SerializeObject(compPictures);
        }

        //Verilen id değerine sahip compPicture verisini veritabanında bulur ve döndürür.
        public string GetCompPictureById(int id)
        {
            var compPicture = _uow.CompPicturesTemplate.GetById(id).MapTo<CompPictureDto>();
            return JsonConvert.SerializeObject(compPicture);
        }

        //Verilen id değerine sahip compPicture verisini veritabanından siler.
        public void DeleteCompPicture(int id)
        {
            _uow.CompPicturesTemplate.Delete(id);
            _uow.SaveChanges();
        }

        //Yeni compPicture ekler.
        //public void AddCompPicture(CompPictureDto newCompPicture)
        //{
        //    var mappedCompPicture = newCompPicture.MapTo<compPictureTBL>();
        //    _uow.CompPicturesTemplate.Add(mappedCompPicture);
        //    _uow.SaveChanges();
        //}

        //resim için
        public void AddCompPicture(int id, string filePath)
        {
            CompPictureDto newCompPicture = new CompPictureDto();
            newCompPicture.CompPicture = filePath;
            newCompPicture.CompId = id;
            var mappedCompPicture = newCompPicture.MapTo<compPictureTBL>();
            _uow.CompPicturesTemplate.Add(mappedCompPicture);
            _uow.SaveChanges();

        }

        //Verilen id değerine sahip compPicture verisini günceller.
        public void UpdateCompPicture(int id, string filePath, string path)
        {
            var picture = _uow.CompPicturesTemplate.GetById(id).MapTo<CompPictureDto>();
            if (picture != null)
            {
                FileInfo file = new FileInfo(path + picture.CompPicture);
                if (file.Exists)
                {
                    file.Delete();
                }
                picture.CompPicture = filePath;
                var mapped = picture.MapTo<compPictureTBL>();
                _uow.CompPicturesTemplate.Update(mapped);
                _uow.SaveChanges();
            }
        }

        //Verilen compId değerine sahip compPicture verilerini döndürür.
        public string GetCompPicturesByCompId(int id)
        {
            var compPictures = _uow.CompPicturesTemplate.GetAll(x => x.compId == id).ProjectTo<CompPictureDto>()
                .ToList();
            return JsonConvert.SerializeObject(compPictures);
        }
    }
}