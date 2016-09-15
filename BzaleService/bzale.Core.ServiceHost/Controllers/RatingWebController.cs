using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bzale.WebService;
using bzale.Common;
using bzale.Repository.DatabaseContext;
using bzale.ViewModel;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace bzale.Core.ServiceHost.Controllers
{
    [Route("api/[controller]")]
    [RequireHttps]
    public class RatingWebController : Controller
    {
        private RatingWebService _ratingService;

        public RatingWebController(IRatingRepository ratingrepo)
        {
            _ratingService = new RatingWebService(ratingrepo);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateRating([FromBody]RatingDTO viewmodel)
        {
            if (ModelState.IsValid)
            {
                if (_ratingService.CreateRating(viewmodel))
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest("Rating blev ikke lavet");
                }
            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        [Route("{companyID}/mostpositiverating")]
        public IActionResult GetMostPositiveRatingForCompany(int companyID)
        {
            if (ModelState.IsValid)
            {
                var positiverating = _ratingService.GetMostPositiveRatingForCompany(companyID);
                if (positiverating != null)
                {
                    return Ok(positiverating);
                }
                else
                {
                    return BadRequest("Kan ikke finde ratings for virksomheden");
                }
            }
            return BadRequest(ModelState);

        }

        [HttpGet]
        [Route("{companyID}/getratings")]
        public IActionResult GetRatingsForCompany(int companyID, int page, int size)
        {
            if (ModelState.IsValid)
            {
                var rratings = _ratingService.GetRatingsForCompany(companyID, page,size);
                if (rratings != null)
                {
                    return Ok(rratings);
                }
                else
                {
                    return BadRequest("Kan ikke finde ratings for virksomheden");
                }
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        [Route("{id}/remove")]
        public IActionResult RemoveRating(int id)
        {
            if (_ratingService.RemoveRating(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Kan ikke finde ratings for virksomheden");
            }
        }


        [HttpPut]
        [Route("update")]
        public IActionResult UpdateRating([FromBody]RatingDTO viewmodel)
        {
            if (_ratingService.UpdateRating(viewmodel))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Kan ikke finde ratings for virksomheden");
            }
        }
    }
}
