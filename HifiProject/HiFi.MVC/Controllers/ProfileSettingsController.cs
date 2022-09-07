using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HiFi.Common.Helpers;
using HiFi.Dto;
using HiFi.MVC.Filter;
using HiFi.MVC.ViewModels;
using HiFi.Services.Services;

namespace HiFi.MVC.Controllers
{
    [LogAction]
    [Authorize]
    public class ProfileSettingsController : Controller
    {
        // GET: ProfileSettings
        public ActionResult Settings(int id)
        {
            profilSetting(id);
            setups(id);
            components(id);
            memberSetting(id);

            return View();
        }

        [HttpGet]
        public PartialViewResult profilSetting(int id)
        {
            MemberService ms = new MemberService();
            var profil = ms.GetSingleMember(id);
            ProfileSettingViewModel psvm = new ProfileSettingViewModel();
            psvm.MemberDtos = profil;
            return PartialView(psvm);
        }

        [HttpPost]
        public string profilSetting(ProfileSettingViewModel memberDto)
        {
            int id = SessionHelper.LoggedUserInfo.MemberId;
            MemberService ms = new MemberService();
            if (memberDto.ImageFile != null)
            {
                ms.UploadPicture(memberDto.ImageFile, id);
            }

            ms.UpdateMember(id, memberDto.MemberDtos);
            return "Bilgileriniz başarıyla kaydedilmiştir.";
        }

        //Setup sayfasını döndürür
        public PartialViewResult setupSetting()
        {
            return PartialView();
        }

        //kullanıcnın tüm setuplarını listeler
        public PartialViewResult setups(int id)
        {
            SetupService ss = new SetupService();
            var setups = ss.GetAllSetupByMemberId(id);
            return PartialView(setups);
        }


        // seçilen ilgili setup üzerinde değişiklik yapmak için modalda setupı gösterir
        [HttpGet]
        public PartialViewResult Singlesetup(int id)
        {
            SetupService ss = new SetupService();
            var setups = ss.GetSingleSetup(id);
            return PartialView(setups);
        }

        //modal üzerinde setupa yapılan değişiklikleri database kaydeder.
        [HttpPost]
        public string Singlesetup(SetupDto setupDto)
        {
            int id = setupDto.SetupId;
            SetupService ss = new SetupService();
            ss.UpdateSetup(id, setupDto);
            return "Bilgileriniz başarıyla kaydedilmiştir.";
        }

        [HttpGet]
        public PartialViewResult SetupPictures(int id)
        {
            SetupPictureService sps = new SetupPictureService();
            var setupPics = sps.GetSetupPicturesBySetupId(id);
            return PartialView(setupPics);
        }

        [HttpPost]
        public string SetupPictures(int id, HttpPostedFileBase setupPicFile)
        {
            if (setupPicFile != null)
            {
                SetupPictureService sps = new SetupPictureService();
                sps.UpdateSetupPicture(id, setupPicFile);
            }
            return "Bilgileriniz başarıyla kaydedilmiştir.";
        }

        public string DeleteSetupPicture(int id)
        {
            SetupPictureService sps = new SetupPictureService();
            sps.DeleteSetupPicture(id);
            return "Bilgileriniz başarıyla silinmiştir.";
        }

        [HttpGet]
        public PartialViewResult AddSetupPictures()
        {

            return PartialView();
        }

        [HttpPost]
        public string AddSetupPictures(int id, HttpPostedFileBase[] setupPictureFiles)
        {
            SetupPictureService sps = new SetupPictureService();
            sps.AddSetupPicture(setupPictureFiles, id);
            return "Bilgileriniz başarıyla kaydedilmiştir.";
        }

        [HttpGet]
        public PartialViewResult ComponentPictures(int id)
        {
            CompPictureService cps = new CompPictureService();
            var compPics = cps.GetAllCompPicturesByCompId(id);
            return PartialView(compPics);
        }

        [HttpPost]
        public string ComponentPictures(int id, HttpPostedFileBase compPicFile)
        {
            CompPictureService cps = new CompPictureService();
            cps.UpdateCompPicture(id, compPicFile);
            return "Bilgileriniz başarıyla kaydedilmiştir.";
        }

        [HttpGet]
        public PartialViewResult AddComponentPictures()
        {
            return PartialView();
        }

        [HttpPost]
        public string AddComponentPictures(int id, HttpPostedFileBase[] compPictureFiles)
        {
            CompPictureService cps = new CompPictureService();
            cps.AddCompPicture(compPictureFiles, id);
            return "Bilgileriniz başarıyla kaydedilmiştir.";
        }

        public string DeleteCompPicture(int id)
        {
            CompPictureService cps = new CompPictureService();
            cps.DeleteCompPicture(id);
            return "Bilgileriniz başarıyla silinmiştir.";
        }
        // seçilen setupın id si ile kaydı siler
        public string DeleteSetup(int id)
        {
            SetupService ss = new SetupService();
            //ss.DeleteSetup(id);
            return "Bilgileriniz başarıyla silinmiştir.";
        }

        [HttpGet]
        public PartialViewResult AddSetup()
        {
            return PartialView();
        }

        [HttpPost]
        public string AddSetup(SetupDto setupDto)
        {
            SetupService ss = new SetupService();
            setupDto.SetupActive = true;
            setupDto.MemberId = SessionHelper.LoggedUserInfo.MemberId;
            ss.AddSetup(setupDto);
            return "Bilgileriniz başarıyla kaydedilmiştir.";
        }

        //kullanıcnın tüm setupcomponentleri listeler
        public PartialViewResult components(int id)
        {
            SetupComponentService scs = new SetupComponentService();
            var components = scs.GetAllComponentByMemberId(id);
            return PartialView(components);
        }

        // seçilen ilgili component üzerinde değişiklik yapmak için modalda componenti gösterir
        [HttpGet]
        public PartialViewResult SingleComponent(int id)
        {
            SetupComponentService scs = new SetupComponentService();
            var component = scs.GetSingleSetupComponent(id);
            SetupService ss = new SetupService();
            ViewBag.Setups = ss.GetAllSetupByMemberId(SessionHelper.LoggedUserInfo.MemberId);


            SystemCategoryService scats = new SystemCategoryService();
            ViewBag.Categories = scats.GetAllSystemCategory();
            return PartialView(component);
        }

        //modal üzerinde componente yapılan değişiklikleri database kaydeder.
        [HttpPost]
        public string SingleComponent(SetupComponentDto setupComponentDto)
        {
            SetupComponentService scs = new SetupComponentService();
            int id = setupComponentDto.CompId;
            scs.UpdateSetupComponent(id, setupComponentDto);
            return "Bilgileriniz başarıyla kaydedilmiştir.";
        }

        // seçilen componentin id si ile kaydı siler
        public string DeleteSetupComponent(int id)
        {
            SetupComponentService scs = new SetupComponentService();
            scs.DeleteSetupComponent(id);
            CompPictureService cps = new CompPictureService();
            return "Bilgileriniz başarıyla silinmiştir.";
        }

        [HttpGet]
        public PartialViewResult AddSetupComponent()
        {
            SetupService ss = new SetupService();
            ViewBag.Setups = ss.GetAllSetupByMemberId(SessionHelper.LoggedUserInfo.MemberId);


            SystemCategoryService scs = new SystemCategoryService();
            ViewBag.Categories = scs.GetAllSystemCategory();

            return PartialView();
        }

        [HttpPost]
        public string AddSetupComponent(SetupComponentDto setupComponentDto)
        {
            SetupComponentService scs = new SetupComponentService();
            setupComponentDto.MemberId = SessionHelper.LoggedUserInfo.MemberId;
            scs.AddSetupComponent(setupComponentDto);
            return "Bilgileriniz başarıyla kaydedilmiştir.";
        }

        [HttpGet]
        public PartialViewResult memberSetting(int id)
        {
            MemberService ms = new MemberService();
            ProfileSettingsMemberSettingVievModel psmsv = new ProfileSettingsMemberSettingVievModel();
            var profil = ms.GetSingleMember(id);
            psmsv.memberdtos = profil;
            return PartialView(psmsv);
        }

        [HttpPost]
        public string memberSetting(ProfileSettingsMemberSettingVievModel memberSet)
        {

            int id = SessionHelper.LoggedUserInfo.MemberId;
            MemberService ms = new MemberService();
            if (memberSet.oldPassword == memberSet.memberdtos.Password)
            {
                if (memberSet.newPassword1 != null && memberSet.newPassword2 != null)
                {

                    memberSet.memberdtos.Password = memberSet.newPassword1;

                }
                //ms.UpdateMember(id, memberSet.memberdtos);
                return "Bilgileriniz başarıyla kaydedilmiştir.";
            }
            else
            {

                return "Girdiğiniz şifre yanlış!!";

            }
        }
    }
}