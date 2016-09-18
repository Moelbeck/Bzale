using System;
using bzale.WebsiteService;
using bzale.Web.Model;
using bzale.Filter;
using System.Web.Mvc;
using depross.Common;
using depross.ViewModel;

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
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CompanyManagement()
        {

            return View();
        }

        [ActionName("_CompanyPartial")]
        public ActionResult ValidateVat(eCountryCode countrycode, string vat)
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


        private string EnumToString<T>(T enumtype) where T : struct, IConvertible
        {
            string value = Enum.GetName(typeof(T), enumtype).ToString();

            return value;
        }
    }
}
