﻿using System;
using bzale.WebsiteService;
using bzale.Web.Model;
using bzale.Filter;
using System.Web.Mvc;
using depross.Common;
using depross.ViewModel;
using Common.Extension;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace bzale.Web.Controllers
{
    [EnsureLoggedInAuthorize]
    public class ManagementController : Controller
    {
        private AccountService _accountservice;
        private VatValidationService _vatvalidationservice;
        private CategoryService _categoryService;
        public ManagementController()
        {
            _accountservice = new AccountService();
            _vatvalidationservice = new VatValidationService();
            _categoryService = new CategoryService();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> CompanyManagement()
        {
            CompanyDTO company = null;
            if (CurrentUser.IsCompanyValidated)
            {
               company = await _accountservice.GetCompanyInformation(CurrentUser.VAT);
                ViewBag.IsValidated = true;
            }
            else
            {
                ViewBag.IsValidated = false;
            }
            return View(company);
        }

        [HttpGet]
        public ActionResult AccountManagement()
        {
            var accountinfo = _accountservice.GetAccountInformation(CurrentUser.ID).Result;
            return View(accountinfo);
        }

        [HttpGet]

        public ActionResult CompanySaleListings()
        {

            return View();
        }

        [HttpGet]
        public ActionResult SavedSaleListings()
        {
            return View();
        }

        #region Create Sale listing

        [HttpGet]
        [EnsureCanSellAuthorize]
        public async Task<ActionResult> CreateSaleListing()
        {
            CurrentSalelistingCreate.SaleListingViewModel = null;

            CurrentSalelistingCreate.SaleListingViewModel.MainCategories = await _categoryService.GetAllMainCategories(1, int.MaxValue);
            return View(CurrentSalelistingCreate.SaleListingViewModel);
        }


        public async Task<ActionResult> SetSelectedMainCategory(int categoryid)
        {
            if (categoryid > 0)
            {
                CurrentSalelistingCreate.SaleListingViewModel.SelectedMainCategory 
                    = CurrentSalelistingCreate.SaleListingViewModel.MainCategories.FirstOrDefault(e => e.ID == categoryid);
                List<CategoryDTO> subcategories = await _categoryService.GetSubCategoriesForMain(categoryid);
                CurrentSalelistingCreate.SaleListingViewModel.SubCategories = subcategories;
            } 
            return PartialView("CreateSalelisting", CurrentSalelistingCreate.SaleListingViewModel);

        }

        public async Task<ActionResult> SetSelectedSubCategory(int categoryid)
        {
            if (categoryid > 0)
            {
                CurrentSalelistingCreate.SaleListingViewModel.SelectedSubCategory
                    = CurrentSalelistingCreate.SaleListingViewModel.SubCategories.FirstOrDefault(e => e.ID == categoryid);
                CurrentSalelistingCreate.SaleListingViewModel.ProductTypes = await _categoryService.GetProductTypesForCategory(categoryid, 1);
            }
            return PartialView("CreateSalelisting", CurrentSalelistingCreate.SaleListingViewModel);

        }

        public ActionResult SetSelectedProductType(int producttypeid)
        {
            if (producttypeid > 0)
            {
                CurrentSalelistingCreate.SaleListingViewModel.SelectedProductType
                    = CurrentSalelistingCreate.SaleListingViewModel.ProductTypes.FirstOrDefault(e => e.ID == producttypeid);
                CurrentSalelistingCreate.SaleListingViewModel.SaleListing = new SaleListingDTO();
            }
            return PartialView("CreateSalelisting", CurrentSalelistingCreate.SaleListingViewModel);

        }

        #endregion


        #region Account and company posts
        [HttpPost]
        public async Task<ActionResult> ValidateVat(eCountryCode countrycode, string vat)
        {
            var cc = countrycode.EnumToString();
            CompanyDTO dto = null;
            if (!string.IsNullOrEmpty(cc) && cc.Length < 3)
            {
                var vatvalidation = await _vatvalidationservice.GetVatValidation(cc, vat);
                if (vatvalidation.IsValid)
                {
                    ViewBag.IsValidated = true;
                    dto = CreateCompanyFromVatValidation(vatvalidation);
                }
            }
            return PartialView("CompanyManagement", dto);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateAccountInformation(AccountUpdateDTO updatedto)
        {
            AccountUpdateDTO updated = null;
            if (ModelState.IsValid)
            {
                updated = await _accountservice.UpdateAccountInformation(updatedto);
                return PartialView("AccountManagement", updated);

            }

            return PartialView("AccountManagement", ModelState);
        }
        [HttpPost]
        public async Task<ActionResult> AddOrUpdateCompany(CompanyDTO company)
        {
            if (ModelState.IsValid)
            {
                CompanyDTO savedOrUpdatedDTO = null;
                //Antager, at brugeren ikke har en virksomhed koblet op til sig her.
                if (!CurrentUser.IsCompanyValidated)
                {
                    savedOrUpdatedDTO = await _accountservice.AddCompanyToAccount(CurrentUser.ID, company);
                }
                else
                {
                    CompanyUpdateRequest request = new CompanyUpdateRequest
                    {
                        Company = company,
                        AccountID = CurrentUser.ID
                    };
                    savedOrUpdatedDTO = await _accountservice.UpdateCompanyInformation(request);
                }
                ViewBag.IsValidated = true;
                CurrentUser.AddCompanyInformation(savedOrUpdatedDTO);
                return PartialView("CompanyManagement", savedOrUpdatedDTO);
            }
            return PartialView("CompanyManagement", ModelState);
        }
        #endregion
        private CompanyDTO CreateCompanyFromVatValidation(VatValidationDTO dto)
        {
            CompanyDTO company = null;
            //1:Adresse, 2: postnummer, 3: by
            string[] adressinfo = dto.Address.Split('\n');
            var postalcodeandCity = adressinfo[1].Split(new string[] { @" " }, StringSplitOptions.None);
            company = new CompanyDTO
            {
                VAT = dto.VATNumber,
                Name = dto.Name,
                Address = adressinfo[0],
                PostalCode = int.Parse(postalcodeandCity[0]),
                City = postalcodeandCity[1],
                CountryCode = dto.CountryCode.StringToEnum<eCountryCode>()
            };
            return company;
        }

    }
}
