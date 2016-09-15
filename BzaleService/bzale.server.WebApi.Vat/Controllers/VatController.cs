using bzale.server.WebApi.Vat.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VATChecker;

namespace bzale.server.WebApi.Vat.Controllers
{
    //[Route("api/[controller]")]
    //[RequireHttps]
    public class VATController : ApiController
    {

        public IHttpActionResult Get()
        {
            return Ok("VIRKER");
        }


        //[HttpGet("{countrycode}/{vatnumber}/validate")]
        //[Route("{countrycode}/{vatnumber}/validate")]

        //?cc={cc}&vatnr={vatnr}
        public IHttpActionResult GetValidateVAT(string cc, string vatnr)
        {
            ViesVatCheck validateVat = new ViesVatCheck();
            validateVat.VATNumber = vatnr;
            validateVat.CountryCode = cc;
            validateVat.CheckVat();

            return Ok(validateVat);
        }
    }
}
