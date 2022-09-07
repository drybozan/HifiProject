using HiFi.Dto;
using HiFi.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HiFi.MVC.Filter;

namespace HiFi.MVC.Controllers
{
    [LogAction]
    public class SystemCategoryController : Controller
    {
        private SystemCategoryService systemCategoryService = new SystemCategoryService();
        // GET: SystemCategory

        [HttpGet]
        public ActionResult Category()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllCategories()
        {
            var categories = systemCategoryService.GetAllSystemCategory();

            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        //kategori eklemek için bir modal döndürür.
        [HttpGet]
        public PartialViewResult AddCategory()
        {
            return PartialView();
        }

        //Admin, eklediği kategoriyi modal üzerinden datayı buraya gönderir ve tabloya kaydedilir.
        [HttpPost]
        public PartialViewResult AddCategory(SystemCategoryDto categoryDto)
        {
            systemCategoryService.AddSystemCategory( categoryDto);
            return PartialView("Category");
        }

        // Admin, üye bilgilerini düzenlemek istediği sistem kategoriyi seçer id ile tüm bilgileri modal üzerine aktarılır.
        [HttpGet]
        public PartialViewResult UpdateCategory(int id)
        {
            SystemCategoryDto category = systemCategoryService.GetSingleSystemCategory(id);
            return PartialView(category);
        }

        //Admin, düzenlediği bilgileri modal üzerinden datayı buraya gönderir ve tabloya kaydedilir.
        [HttpPost]
        public PartialViewResult UpdateCategory(SystemCategoryDto categoryDto)
        {
            int id = categoryDto.CtgId;
            systemCategoryService.UpdateSystemCategory(id, categoryDto);
            return PartialView("Category");
        }

        // Silinecek üyeler id ile gönderilir ve tablodan silinir.
        public void DeleteCategory(int id)
        {
            systemCategoryService.DeleteSystemCategory(id);
        }
    }
}