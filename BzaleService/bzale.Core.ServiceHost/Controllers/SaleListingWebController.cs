using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bzale.WebService;
using bzale.ViewModel;
using bzale.Common;
using bzale.Repository.DatabaseContext;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace bzale.Core.ServiceHost.Controllers
{
    [Route("api/[controller]")]
    [RequireHttps]
    public class SaleListingWebController : Controller
    {
        private SaleListingWebService _salelistingService;

        public SaleListingWebController(BzaleDatabaseContext context)
        {
            _salelistingService = new SaleListingWebService(context);
        }
        // GET: api/values
        #region Salelisting
        [HttpPost]
        [Route("create")]
        public IActionResult CreateNewSaleListing([FromBody]SaleListingCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                if (_salelistingService.CreateNewSaleListing(model))
                {
                    return Ok();
                }
                return BadRequest("Annonce blev ikke lavet");
            }
            return BadRequest(ModelState);
        }
        [HttpGet("{id}")]
        public IActionResult GetSaleListingByID(int id)
        {
            if (ModelState.IsValid)
            {
                var salelisting = _salelistingService.GetSaleListingByID(id);
                if (salelisting != null)
                {
                    return Ok(salelisting);
                }
                return NotFound("Annonce blev ikke fundet");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("{saleID}/delete")]
        public IActionResult DeleteSaleListingByID(int saleID)
        {
            if (_salelistingService.DeleteSaleListingByID(saleID))
            {
                return Ok(true);
            }
            return BadRequest("Annonce blev ikke slettet");
        }


        [HttpPut]
        [Route("update")]
        public IActionResult UpdateSaleListing([FromBody]SaleListingUpdateDTO viewmodel)
        {
            if (ModelState.IsValid)
            {
                if (_salelistingService.UpdateSaleListing(viewmodel))
                {
                    return Ok(true);
                }
                return BadRequest("Annonce blev ikke opdateret");
            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        [Route("company/{companyID}")]

        public IActionResult GetSaleListingsForCompany(int companyID, int page, int size)
        {
            if (ModelState.IsValid)
            {
                var salelisting = _salelistingService.GetSaleListingsForCompany(companyID, page,size);
                if (salelisting != null)
                {
                    return Ok(salelisting);
                }
                return NotFound("Annonce blev ikke fundet");
            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        [Route("category/{categoryID}")]
        public IActionResult GetSaleListingsForCategory(int categoryID, int page, int size)
        {
            if (ModelState.IsValid)
            {
                var salelisting = _salelistingService.GetSaleListingsForCategory(categoryID, page,size);
                if (salelisting != null)
                {
                    return Ok(salelisting);
                }
                return NotFound("Ingen annoncer blev fundet");
            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        [Route("getBySearch/{search}")]
        public IActionResult GetSaleListingsBySearchString(string search, int page, int size, int userid)
        {
            if (ModelState.IsValid)
            {
                var salelisting = _salelistingService.GetSaleListingsBySearchString(search,page,size,userid);
                if (salelisting != null)
                {
                    return Ok(salelisting);
                }
                return NotFound("Ingen annoncer blev fundet");
            }
            return BadRequest(ModelState);
        }
        #endregion
        #region Images

        [HttpPost]
        [Route("addImage")]
        public IActionResult AddImageSaleListing([FromBody]ImageUploadRequest viewmodel)
        {
            if (ModelState.IsValid)
            {
                if (_salelistingService.AddImageSaleListing(viewmodel.SaleListing, viewmodel.Image))
                {
                    return CreatedAtRoute("GetSaleListingByID", new { controller = "SaleListing", id = viewmodel.SaleListing.ID }, viewmodel.SaleListing);
                }
                return NotFound("Billede blev ikke uploaded");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("{salelistingid}/removeimage/{id}")]
        public IActionResult RemoveImageSaleListing(int salelistingid, int imageid)
        {
            if (ModelState.IsValid)
            {
                if (_salelistingService.RemoveImageSaleListing(salelistingid,imageid))
                {
                    return Ok();
                }
                return NotFound("Billede blev ikke fjernet");
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("{salelistingid}/images")]
        public IActionResult GetImagesForSaleListing(int salelistingid)
        {
            if (ModelState.IsValid)
            {
                var images =_salelistingService.GetImagesForSaleListing(salelistingid);
                if(images != null)
                {
                    return Ok(images);
                }
                
                return NotFound("Billede blev ikke fjernet");
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("{salelistingid}/image")]
        public IActionResult GetImageForSaleListing(int salelistingid)
        {
            if (ModelState.IsValid)
            {
                var image = _salelistingService.GetImageForSaleListing(salelistingid);
                if (image != null)
                {
                    return Ok(image);
                }

                return NotFound("Billede blev ikke fjernet");
            }
            return BadRequest(ModelState);
        }
        #endregion

        #region Subscription
        [HttpPost]
        [Route("subscription/{sub}")]
        public IActionResult AddOrUpdateSubscription(eSubscription sub, [FromBody] SaleListingDTO salelistingviewmodel)
        {
            if (ModelState.IsValid)
            {
                if (_salelistingService.AddOrUpdateSubscription(sub, salelistingviewmodel))
                {
                    return Ok();
                }
                return NotFound("Subscription blev ikke uploaded");
            }
            return BadRequest(ModelState);
        }
        #endregion

        #region Comments
        [HttpPost]
        [Route("{salelistingid}/addcomment")]
        public IActionResult AddComment(int salelistingid, [FromBody]CommentDTO commentviewmodel)
        {
            if (ModelState.IsValid)
            {
                if (_salelistingService.AddComment(salelistingid, commentviewmodel))
                {
                    return Ok();
                }
                return NotFound("Kommentar blev ikke uploaded");
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        [Route("{salelistingid}/comments/{commentid}/AddAnswer")]
        public IActionResult AddAnswerForComment(int salelistingid, int commentid, [FromBody] CommentDTO answerviewmodel)
        {
            if (ModelState.IsValid)
            {
                if (_salelistingService.AddAnswerForComment(salelistingid, commentid, answerviewmodel))
                {
                    return Ok();
                }
                return NotFound("Kommentar blev ikke uploaded");
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        [Route("removeComment/{id}")]
        public IActionResult RemoveComment( int id, [FromBody]SaleListingDTO saleviewmodel)
        {
            if (ModelState.IsValid)
            {
                if (_salelistingService.RemoveComment(saleviewmodel, id))
                {
                    return Ok();
                }
                return NotFound("Kommentar blev ikke fjernet");
            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        [Route("comments/{salelistingID}")]
        public IActionResult GetCommentsForSaleListing(int salelistingID)
        {
            if (ModelState.IsValid)
            {
                var comments = _salelistingService.GetCommentsForSaleListing(salelistingID);

                if (comments !=null)
                {
                    return Ok(comments);
                }
                return NotFound("Kommentar blev ikke fundet");
            }
            return BadRequest(ModelState);
        }
        #endregion
    }
}
