using bzale.Web.Model;
using System.Web.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace bzale.Web.Controllers
{
    public class SaleListingController : Controller
    {
        // GET: /<controller>/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateSaleListing()
        {
            if (CurrentUser.CanSell)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
