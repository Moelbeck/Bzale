using System.Web.Http;
using VATChecker;

namespace depross.WebApi
{
    [RoutePrefix("api/VAT")]
    //[RequireHttps]
    public class VATController : ApiController
    {
     
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
