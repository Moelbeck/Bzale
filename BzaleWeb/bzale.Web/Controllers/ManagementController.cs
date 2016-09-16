using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bzale.WebsiteService;
using bzale.Web.Model;
using bzale.Filter;

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

            var vatvalidation = _vatvalidationservice.GetVatValidation("DK", "78161418");
            return View();
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
    }
}
