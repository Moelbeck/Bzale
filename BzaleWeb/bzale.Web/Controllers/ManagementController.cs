using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bzale.WebsiteService;
using bzale.Web.Model;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace bzale.Web.Controllers
{
    public class ManagementController : Controller
    {
        private AccountService _accountservice;

        public ManagementController()
        {
            _accountservice = new AccountService();
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public IActionResult CompanyManagement()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AccountManagement()
        {
            var accountinfo = _accountservice.GetAccountInformation(CurrentUser.ID).Result;
            return View(accountinfo);
        }

        [HttpGet]
        public IActionResult CompanySaleListings()
        {
            var companyinfo = _accountservice.GetCompanyInformation(CurrentUser.CompanyVAT);

            return View(companyinfo);
        }

        [HttpGet]
        public IActionResult SavedSaleListings()
        {
            return View();
        }
    }
}
