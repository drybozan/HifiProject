using HiFi.Common.Helpers;
using HiFi.Dto;
using HiFi.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HiFi.MVC.ViewModels;
using HiFi.MVC.Filter;

namespace HiFi.MVC.Controllers
{
    [LogAction]
    [Authorize]
    public class ProfileSettingforAdminController : Controller
    {
        // GET: ProfileSettingforAdmin
        
        SetupService ss = new SetupService();
        SetupComponentService scs = new SetupComponentService();
        SystemCategoryService sc = new SystemCategoryService();
        
    

        //Setup sayfasını döndürür
        public ActionResult setupSetting(int id)
        {
            setups(id);
            components(id);
            return View();
        }

        //kullanıcnın tüm setuplarını listeler
        public PartialViewResult setups(int id)
        {
            var setups = ss.GetAllSetupByMemberId(id);
            return PartialView(setups);
        }


        // seçilen ilgili setup üzerinde değişiklik yapmak için modalda setupı gösterir
        [HttpGet]
        public PartialViewResult Singlesetup(int id)
        {
            var setups = ss.GetSingleSetup(id);
            return PartialView(setups);
        }

        //modal üzerinde setupa yapılan değişiklikleri database kaydeder.
        [HttpPost]
        public PartialViewResult Singlesetup(SetupDto setupDto)
        {
            int id = setupDto.SetupId;

            ss.UpdateSetup(id, setupDto);
            return PartialView();
        }
        // seçilen setupın id si ile kaydı siler
        public PartialViewResult DeleteSetup(int id)
        {
            ss.DeleteSetup(id);
            return PartialView("setupSetting");
        }

        //kullanıcnın tüm setupcomponentleri listeler
        public PartialViewResult components(int id)
        {

            var components = scs.GetAllComponentByMemberId(id);
            var asd = components.Select(x => x.SetupId).Distinct().ToList();
            var adsd = components.GroupBy(x => x.SetupId).Select(y => y.First()).ToList();
            return PartialView(components);
        }

        // seçilen ilgili component üzerinde değişiklik yapmak için modalda componenti gösterir
        [HttpGet]
        public PartialViewResult SingleComponent(int id)
        {
            var component = scs.GetSingleSetupComponent(id);
            return PartialView(component);
        }

        //modal üzerinde componente yapılan değişiklikleri database kaydeder.
        [HttpPost]
        public PartialViewResult SingleComponent(SetupComponentDto setupComponentDto)
        {
            int id = setupComponentDto.CompId;
            scs.UpdateSetupComponent(id, setupComponentDto);
            return PartialView();
        }

        // seçilen componentin id si ile kaydı siler
        public void DeleteSetupComponent(int id)
        {
            scs.DeleteSetupComponent(id);
        }

      

    }
}