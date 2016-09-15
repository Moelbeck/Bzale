//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using bzale.WebService;
//using bzale.Repository.DatabaseContext;
//using bzale.ViewModel;
//using bzale.Common;

//// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

//namespace bzale.Core.ServiceHost.Controllers
//{
//    [Route("api/[controller]")]
//    //public class CreateAndUpdateController : Controller
//    {

//        private IAccountWebtService _accountservice;
//        private ICategoryWebService _categoryservice;
//        private ISaleListingWebService _salelistingservice;

//        public CreateAndUpdateController(BzaleDatabaseContext context)
//        {
//            _accountservice = new AccountWebService(context);
//            _categoryservice = new CategoryWebService(context);
//            _salelistingservice = new SaleListingWebService(context);

//        }
//        #region Create

//        [HttpPost]
//        [Route("category/createmain")]
//        public IActionResult CreateMainCategory([FromBody]CategoryDTO viewmodel)
//        {
//            _categoryservice.CreateMainCategory(viewmodel);
//            return Ok();
//        }
//        [HttpPost]

//        [Route("category/{main}/createsub")]
//        public void CreateSubCategory(int main, [FromBody]CategoryDTO viewmodel)
//        {
//            _categoryservice.CreateSubCategory(main, viewmodel);
//        }
//        [HttpPost]
//        [Route("/createmanufacturer")]
//        public void CreateManufacturer([FromBody]ManufacturerDTO viewmodel)
//        {
//            _categoryservice.CreateManufacturer(viewmodel);
//        }
//        [HttpPost]
//        [Route("/CreateProduct")]
//        public void CreateProduct([FromBody]ProductDTO viewmodel)
//        {
//            _categoryservice.CreateProduct(viewmodel);
//        }

//        [HttpPost]
//        [Route("/CreateAccount")]

//        public void CreateNewAccount(AccountCreateDTO viewmodel)
//        {
//            _accountservice.CreateNewAccount(viewmodel);
//        }

//        [HttpPost]
//        [Route("/CreateSaleListing")]

//        public void CreateNewSaleListing(SaleListingCreateDTO viewmodel)
//        {
//            _salelistingservice.CreateNewSaleListing(viewmodel);
//        }
//        [HttpPost]
//        [Route("/AddImageToSaleListing")]
//        public void AddImageToSaleListing([FromBody]ImageUploadRequest viewmodel)
//        {
//            _salelistingservice.AddImageSaleListing(viewmodel.SaleListing,viewmodel.Image);
//        }
//        #endregion

//        #region Get

//        #endregion
//    }
//}
