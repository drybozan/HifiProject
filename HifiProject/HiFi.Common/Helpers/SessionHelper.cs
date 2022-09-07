// ***********************************************************************
// Assembly         : aKare.IBYS
// Author           : MBB
// Created          : 14-01-2019
//
// Last Modified By : Sulhadin
// Last Modified On : 04-03-2019
// ***********************************************************************
// <copyright file="SessionHelper.cs" company="aKare Bilişim">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Web;
using HiFi.Dto;
using HiFi.Dto.Dtos;

/// <summary></summary>
namespace HiFi.Common.Helpers
{
    /// <summary>
    /// Session Yardımcı Nesnesi.
    /// </summary>
    public class SessionHelper
    {
        /// <summary>Veritabanı bağlantı bilgisi.</summary>
        //public static AKareSqlSettingsModel WorkConnectionString
        //{
        //    get => (AKareSqlSettingsModel)HttpContext.Current.Session["WorkConnectionString"] ?? new AKareSqlSettingsModel();
        //    set => HttpContext.Current.Session["WorkConnectionString"] = value;
        //}

        /// <summary>Giriş yapmış kullanıcı kimlik bilgisi</summary>
        public static MemberDto LoggedUserInfo
        {
            get => (MemberDto)HttpContext.Current.Session["UserInfo"] ?? new MemberDto();
            set => HttpContext.Current.Session["UserInfo"] = value;
        }

        /// <summary>Token bilgisi</summary>
        public static TokenDto TokenInfo
        {
            get => (TokenDto)HttpContext.Current.Session["TokenInfo"] ?? new TokenDto();
            set => HttpContext.Current.Session["TokenInfo"] = value;
        }

        /// <summary>Firma bilgisi</summary>
        //public static FirmDto FirmInfo
        //{
        //    get => (FirmDto)HttpContext.Current.Session["FirmInfo"] ?? new FirmDto();
        //    set => HttpContext.Current.Session["FirmInfo"] = value;
        //}

        /// <summary>Firma bilgisi</summary>
        //public static SubcontractorFirmDto SubcontractorFirmInfo
        //{
        //    get => (SubcontractorFirmDto)HttpContext.Current.Session["FirmInfo"] ?? new SubcontractorFirmDto();
        //    set => HttpContext.Current.Session["FirmInfo"] = value;
        //}

        /// <summary>Taşeron bilgisi</summary>
        //public static SubcontractorDto SubcontractorInfo
        //{
        //    get => (SubcontractorDto)HttpContext.Current.Session["SubcontractorInfo"] ?? new SubcontractorDto();
        //    set => HttpContext.Current.Session["SubcontractorInfo"] = value;
        //}


        /// <summary>Taşeron bilgisi</summary>
        //public static SubcontractorApplicationDto SubcontractorApplicationInfo
        //{
        //    get => (SubcontractorApplicationDto)HttpContext.Current.Session["SubcontractorApplicationInfo"] ?? new SubcontractorApplicationDto();
        //    set => HttpContext.Current.Session["SubcontractorApplicationInfo"] = value;
        //}

        public static Guid? SubcontractorGuid
        {
            get => (Guid?)HttpContext.Current.Session["Guid"];
            set => HttpContext.Current.Session["Guid"] = value;
        }

        public static bool? YardiPass
        {
            get => (bool?)HttpContext.Current.Session["YardiPass"];
            set => HttpContext.Current.Session["YardiPass"] = value;
        }

        /// <summary>Paket bilgisi</summary>
        //public static PacketVm PacketInfo
        //{
        //    get => (PacketVm)HttpContext.Current.Session["PacketInfo"] ?? new PacketVm();
        //    set => HttpContext.Current.Session["PacketInfo"] = value;
        //}

        /// <summary>Kontrol Birim bilgisi</summary>
        //public static ControlUnitVm ControlUnit
        //{
        //    get => (ControlUnitVm)HttpContext.Current.Session["ControlUnit"] ?? new ControlUnitVm();
        //    set => HttpContext.Current.Session["ControlUnit"] = value;
        //}


        /// <summary>Parametre bilgisi</summary>
        //public static ParameterVm Parameter
        //{
        //    get => (ParameterVm)HttpContext.Current.Session["Parameter"] ?? new ParameterVm();
        //    set => HttpContext.Current.Session["Parameter"] = value;
        //}
    }
}