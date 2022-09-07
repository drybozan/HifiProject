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
    public class SystemCategoryApiService
    {
        private static HiFiDBEntities _dbContext = new HiFiDBEntities();
        private EFUnitOfWork _uow = new EFUnitOfWork(_dbContext);

        //Bütün kategori tablosunu döndürür.
        public string GetAllCategories()
        {
            var categories = _uow.SystemCategoriesTemplate.GetAll().ProjectTo<SystemCategoryDto>().ToList();
            return JsonConvert.SerializeObject(categories);
        }

        //Verilen id değerine sahip kategoriyi veritabanında bulur ve döndürür.
        public string GetCategoriesById(int id)
        {
            var category = _uow.SystemCategoriesTemplate.GetById(id).MapTo<SystemCategoryDto>();
            return JsonConvert.SerializeObject(category);
        }

        //Verilen id değerine sahip kategoriyi veritabanından siler.
        public void DeleteCategories(int id)
        {
            _uow.SystemCategoriesTemplate.Delete(id);
            _uow.SaveChanges();
        }

        //Yeni kategori ekler.
        public void AddCategories(SystemCategoryDto newCategory)
        {
            var mappedCategory = newCategory.MapTo<systemCategoryTBL>();
            _uow.SystemCategoriesTemplate.Add(mappedCategory);
            _uow.SaveChanges();
        }

        //Verilen id değerine sahip kategoriyi günceller.
        public void UpdateCategories(int id, SystemCategoryDto newCategory)
        {
            var Category = _uow.SystemCategoriesTemplate.GetById(id).MapTo<SystemCategoryDto>();
            if (Category != null)
            {
                var mapped = newCategory.MapTo<systemCategoryTBL>();
                _uow.SystemCategoriesTemplate.Update(mapped);
                _uow.SaveChanges();
            }
        }
    }
}