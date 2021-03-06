﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bzale.WebsiteService;
using bzale.Web.Model;
using bzale.Filter;
using bzale.ViewModel;
using bzale.Common;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace bzale.Web.Controllers
{
    public class ManagementController : Controller
    {
        private AccountService _accountservice;
        private VatValidationService _vatvalidationservice;

        public ManagementController()
        {
            _accountservice = new AccountService();
            _vatvalidationservice = new VatValidationService();
        }
        // GET: /<controller>/
        [EnsureUserLoggedIn]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CompanyManagement()
        {

            return View();
        }

        [ActionName("_CompanyPartial")]
        public IActionResult ValidateVat(eCountryCode countrycode, string vat)
        {
            var cc = EnumToString<eCountryCode>(countrycode);
            CompanyDTO dto = null;
            if (!string.IsNullOrEmpty(cc) && cc.Length < 3)
            {
                var vatvalidation = _vatvalidationservice.GetVatValidation(cc, vat).Result;
                if (vatvalidation.IsValid)
                {
                    dto = new CompanyDTO
                    {
                        VAT = vatvalidation.VATNumber,
                        Name = vatvalidation.Name,
                        Address = vatvalidation.Address,
                        Country = vatvalidation.CountryCode

                    };
                }
            }
            return PartialView( dto);
        }

        [HttpGet]
        [EnsureUserLoggedIn]
        public IActionResult AccountManagement()
        {
            var accountinfo = _accountservice.GetAccountInformation(CurrentUser.ID).Result;
            return View(accountinfo);
        }

        [HttpGet]
        [EnsureUserLoggedIn]
        [EnsureValidCompany]
        public IActionResult CompanySaleListings()
        {

            return View();
        }

        [HttpGet]
        [EnsureUserLoggedIn]
        public IActionResult SavedSaleListings()
        {
            return View();
        }


        private string EnumToString<T>(T enumtype) where T : struct, IConvertible
        {
            string value = Enum.GetName(typeof(T), enumtype).ToString();

            return value;
        }
    }
}
