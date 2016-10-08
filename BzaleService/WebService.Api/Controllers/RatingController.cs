using depross.ViewModel;
using depross.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebService.Api.Controllers
{
    [RoutePrefix("api/Rating")]
    public class RatingController : ApiController
    {
        private RatingWebService _ratingService;

        public RatingController()
        {
            _ratingService = new RatingWebService();
        }

        [HttpPost, Route("create")]
        
        public IHttpActionResult CreateRating([FromBody]RatingDTO viewmodel)
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

        [HttpGet, Route("{companyID}/mostpositiverating")]        
        public IHttpActionResult GetMostPositiveRatingForCompany(int companyID)
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

        [HttpGet,Route("{companyID}/getratings")]
        public IHttpActionResult GetRatingsForCompany(int companyID, int page, int size)
        {
            if (ModelState.IsValid)
            {
                var rratings = _ratingService.GetRatingsForCompany(companyID, page, size);
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
        [HttpDelete,Route("{id}/remove")]
        public IHttpActionResult RemoveRating(int id)
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


        [HttpPut,Route("update")]
        public IHttpActionResult UpdateRating([FromBody]RatingDTO viewmodel)
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
