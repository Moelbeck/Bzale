using depross.Common;
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

    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private AccountWebService _accountService;

        public AccountController()
        {
            _accountService = new AccountWebService();
        }

        [HttpGet, Route("login")]
        public IHttpActionResult Login(string username, string pass)
        {
            if (ModelState.IsValid)
            {
                var login = _accountService.Login(username, pass);
                if (login != null)
                {
                    return Ok(login);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost, Route("logout")]
        public IHttpActionResult Logout(string email)
        {
            _accountService.Logout(email);
            return Ok();
        }

        [HttpPost, Route("create")]
        public IHttpActionResult CreateNewAccount([FromBody] AccountCreateDTO newaccount)
        {
            if (ModelState.IsValid)
            {
                var acc = _accountService.CreateNewAccount(newaccount);
                if (acc != null)
                {
                    return Ok(acc);
                }
                else
                    return BadRequest("Bruger blev ikke lavet. Enten fejl af input eller server fejl");
            }
            return BadRequest(ModelState);
        }

        [HttpPost, Route("{currentAccountId}/add")]
        public IHttpActionResult AddAccountToCompany(int currentAccountId, [FromBody]AccountCreateDTO newaccount)
        {
            if (ModelState.IsValid)
            {
                var acc = _accountService.AddAccountToCompany(currentAccountId, newaccount);
                if (acc != null)
                {
                    return Ok(acc);
                }
                else
                {
                    return BadRequest("Bruger blev ikke lavet");
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost, Route("{currentUserId}/company/add")]
        public IHttpActionResult AddCompanyToAccount(int currentuserId, [FromBody]CompanyDTO newcompany)
        {
            if (ModelState.IsValid)
            {
                var com = _accountService.AddCompanyToAccount(currentuserId, newcompany);
                if (com != null)
                {
                    return Ok(com);
                }
                else
                {
                    return BadRequest("Virksomhed blev ikke lavet!");
                }
            }
            return BadRequest(ModelState);
        }

        [HttpGet,Route("{email}/ismailindatabase")]        
        public IHttpActionResult IsEmailInDatabase(string email)
        {
            if (_accountService.IsEmailInDatabase(email))
            {
                return Ok(true);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet, Route("{id}/accountinfo")]
        public IHttpActionResult GetAccountInformation(int id)
        {

            var info = _accountService.GetAccountInformation(id);
            if (info != null)
            {
                return Ok(info);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPut, Route("updateaccountinformation")]        
        public IHttpActionResult UpdateAccountInformation([FromBody]AccountUpdateDTO viewmodel)
        {
            if (ModelState.IsValid)
            {
                var updated = _accountService.UpdateAccountInformation(viewmodel);
                if (updated != null)
                {
                    return Ok(updated);
                }
                else
                {
                    return BadRequest("Information blev ikke opdateret");
                }
            }
            return BadRequest(ModelState);
        }
        [HttpPut, Route("updatecompanyinformation")]
        public IHttpActionResult UpdateCompanyInformation([FromBody]CompanyUpdateRequest viewmodel)
        {
            if (ModelState.IsValid)
            {
                var updated = _accountService.UpdateCompanyInformation(viewmodel.AccountID, viewmodel.Company);
                if (updated != null)
                {
                    return Ok(updated);
                }
                else
                {
                    return BadRequest("Information blev ikke opdateret");
                }
            }
            return BadRequest(ModelState);

        }
        [HttpGet, Route("{vat}/isvatindatabase")]
        public IHttpActionResult IsVatInDatabase(string vat)
        {
            if (ModelState.IsValid)
            {
                if (_accountService.IsVatInDatabase(vat))
                {
                    return Ok(true);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest(ModelState);
        }

        [HttpGet, Route("{vat}/companyinfo")]
        public IHttpActionResult GetCompanyInformation(string vat)
        {
            var info = _accountService.GetCompanyInformation(vat);
            if (info != null)
            {
                return Ok(info);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet, Route("{email}/iscompanymailindatabase")]
        public IHttpActionResult IsCompanyEmailInDatabase(string email)
        {

            if (_accountService.IsCompanyEmailInDatabase(email))
            {
                return Ok(true);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost, Route("updatepassword")]
        public IHttpActionResult UpdatePassword([FromBody]AccountUpdatePasswordViewModel accountviewmodel)
        {
            if (ModelState.IsValid)
            {
                if (_accountService.UpdatePassword(accountviewmodel))
                {
                    return Ok(true);
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete, Route("delete")]
        public IHttpActionResult DeleteAccount(int id)
        {
            if (ModelState.IsValid)
            {
                if (_accountService.DeleteAccount(id))
                {
                    return Ok(true);
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }
    }
}
