using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using biz2biz.Service;
using biz2biz.ViewModel;
using biz2biz.ViewModel.AccountViewModels;
using biz2biz.ViewModel.CorporationViewModels;
using biz2biz.Web.Authorize;

namespace biz2biz.Web.Controllers
{
    /// <summary>
    /// This controller handles everything with accounts: creation, update, "my account" site, etc.
    /// </summary>
    public class AccountController : Controller
    {
        public readonly AccountService _accountService;
        public readonly CompanyService _companyService;
        public AccountController() : this(new AccountService(), new CompanyService())
        {
        }

        public AccountController(AccountService accountService, CompanyService companyService)
        {
            _accountService = accountService;
            _companyService = companyService;
        }

        public ActionResult Login()
        {
           return View(); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(AccountLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var accViewModel = _accountService.Login(model.UserName.ToLower(), model.Password);
                if (accViewModel != null)
                {

                        CurrentAccount.ID = accViewModel.ID;
                        CurrentAccount.FirstName = accViewModel.FirstName;
                        CurrentAccount.LastName = accViewModel.LastName;
                    
                    return RedirectToAction("Index","Home",model);
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            CurrentAccount.LogOff();
            CurrentAccount.HaveLoggedOut = true;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RegisterNewAccount()
        {
            CurrentAccount.LogOff();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult RegisterNewAccount(AccountCreateViewModel newaccount)
        {
            if (ModelState.IsValid)
            {
                CurrentAccount.LogOff();
                var account = _accountService.AddNewAccountAndCompany(newaccount);
                if (account != null)
                {
                    CurrentAccount.ID = account.ID;
                    CurrentAccount.FirstName = account.FirstName;
                    CurrentAccount.LastName = account.LastName;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Error","FEJL ved oprettelse af bruger!");
                    return View();
                }

            }
            return View();
        }

        #region My Account
        [HttpPost]
        [CustomAuthorize]
        public ActionResult UpdateAccount(AccountUpdateViewModel account)
        {
            if (ModelState.IsValid)
            {
                int currentaccountid = CurrentAccount.ID;
                var acc = _accountService.UpdateAccountInformation(currentaccountid,account);
                if (acc != null)
                {
                    CurrentAccount.ID = acc.ID;
                    CurrentAccount.FirstName = acc.FirstName;
                    CurrentAccount.LastName = acc.LastName;

                    return RedirectToAction("MyAccount", "Account");
                }

            }
            return View();
        }
        #endregion
        [CustomAuthorize]
        public ActionResult MyAccount()
        {
            return View();
        }
        [CustomAuthorize]
        public ActionResult UpdateAccount()
        {
            var account = _accountService.GetAccountInformation(CurrentAccount.ID);
            return View(account);
        }


        public string IsVatInDatabase(string vat)
        {
            return _companyService.IsVatInDatabase(vat.Trim()) ? "True" : "False";
        }
        public string IsEmailInDatabase(string email)
        {
            return _accountService.IsEmailInDatabase(email) ? "True" : "False";
        }

        public string IsAccountEmailInDatabase(string email)
        {
            int currentaccount = CurrentAccount.ID;
            bool val = _accountService.IsEmailInDatabase(currentaccount, email);
            if(val) ModelState.AddModelError("Email","Email eksistere i databasen");
            return  val? "True" : "False";
        }
        public string IsCompanyEmailInDatabase(string email)
        {
            var currentcompanyid = CurrentAccount.CompanyID;
            return _companyService.IsCompanyEmailInDatabase(currentcompanyid,email) ? "True" : "False";
        }
        public ActionResult ValidateVat(string countryCode,string vat)
        {
            countryCode = "DK";
            var res = _accountService.ValidateVAT(countryCode, vat.Trim());
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}