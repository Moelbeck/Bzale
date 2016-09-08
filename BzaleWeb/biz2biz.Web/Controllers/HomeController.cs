using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using biz2biz.Service;
using biz2biz.ViewModel;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace biz2biz.Web.Controllers
{
    /// <summary>
    /// This controller will contain everything else (for now)
    /// </summary>
    public class HomeController : Controller
    {
        public readonly CategoryService _categoryService;

        private List<CategoryViewModel> jobCategoryViewModels;
        private List<CategoryViewModel> productCategoryViewModels;
        private AccountService _accountService;
        public HomeController()
            : this(new CategoryService())
        {
        }

        public HomeController(CategoryService categoryService)
        {
            _categoryService = categoryService;
            _accountService = new AccountService();
            bool isdebugging = true;
            if (isdebugging && !CurrentAccount.HaveLoggedOut)
            {
                var accViewModel = _accountService.Login("Chrismoelbeck@gmail.com", "Chris1989");
                if (accViewModel != null)
                {

                    CurrentAccount.ID = accViewModel.ID;
                    CurrentAccount.FirstName = accViewModel.FirstName;
                    CurrentAccount.LastName = accViewModel.LastName;
                }
            }
        }
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult JobCategories()
        {
            return View();
        }

        public ActionResult ProductCategories(int selectedViewModel)
        {
            TempData["SelectedJobCategory"] = selectedViewModel;
            return View();
        }

        public ActionResult ProductView(int selectedproductcategory)
        {
            return View();
        }
        #region Kendo calls

        public ActionResult GetAllJobCategories([DataSourceRequest] DataSourceRequest request)
        {
            jobCategoryViewModels = _categoryService.GetJobCategories();
            return Json(jobCategoryViewModels.ToDataSourceResult(request));
        }
        public ActionResult GetProductCategories_ForJob([DataSourceRequest] DataSourceRequest request)
        {
            int id = (int)TempData["SelectedJobCategory"];
            if (id <= 0) { return RedirectToAction("JobCategories","Home");}
            productCategoryViewModels = _categoryService.GetProductCategorisByJob(id);
            return Json(productCategoryViewModels.ToDataSourceResult(request));
        }
        #endregion
    }
}