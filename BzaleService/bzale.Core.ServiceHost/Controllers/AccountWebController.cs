using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bzale.WebService;
using bzale.ViewModel;
using bzale.Repository.DatabaseContext;
using bzale.Common;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace bzale.Core.ServiceHost.Controllers
{
    [Route("api/[controller]")]
    [RequireHttps]
    public class AccountWebController : Controller
    {
        private AccountWebService _accountService;

        public AccountWebController(BzaleDatabaseContext context)
        {
            _accountService = new AccountWebService(context);
        }
        [HttpGet]
        [Route("login")]
        public IActionResult Login(string username, string pass)
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
                    return NotFound("Bruger var ikke fundet");
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("logout")]
        public IActionResult Logout(string email)
        {
            _accountService.Logout(email);
            return Ok();
        }
        [HttpPost]
        [Route("create")]
        public IActionResult CreateNewAccount([FromBody] AccountCreateDTO newaccount)
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
        [HttpPost]
        [Route("{currentAccountId}/add")]
        public IActionResult AddAccountToCompany(int currentAccountId, [FromBody]AccountCreateDTO newaccount)
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
        [RequireHttps]
        [HttpPost]
        [Route("{currentUserId}/company/add")]
        public IActionResult AddCompanyToAccount(int currentuserId, [FromBody]CompanyDTO newcompany)
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
        [HttpGet]
        [Route("{email}/ismailindatabase")]
        public IActionResult IsEmailInDatabase(string email)
        {
            if (_accountService.IsEmailInDatabase(email))
            {
                return Ok(true);
            }
            else
            {
                return NotFound(false);
            }
        }
        [HttpGet]
        [Route("{id}/accountinfo")]
        public IActionResult GetAccountInformation(int id)
        {

            var info = _accountService.GetAccountInformation(id);
            if (info != null)
            {
                return Ok(info);
            }
            else
            {
                return NotFound("Information blev ikke fundet");
            }

        }
        [HttpPost]
        [Route("updateaccountinformation")]
        public IActionResult UpdateAccountInformation([FromBody]AccountUpdateDTO viewmodel)
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
        [HttpPost]
        [Route("updatecompanyinformation")]
        public IActionResult UpdateCompanyInformation([FromBody]CompanyUpdateRequest viewmodel)
        {
            if (ModelState.IsValid)
            {
                var updated = _accountService.UpdateCompanyInformation(viewmodel.Account.ID, viewmodel.Company);
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
        [HttpGet]
        [Route("{vat}/isvatindatabase")]
        public IActionResult IsVatInDatabase(string vat)
        {
            if (ModelState.IsValid)
            {
                if (_accountService.IsVatInDatabase(vat))
                {
                    return Ok(true);
                }
                else
                {
                    return NotFound(false);
                }
            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        [Route("{vat}/companyinfo")]
        public IActionResult GetCompanyInformation(string vat)
        {
            var info = _accountService.GetCompanyInformation(vat);
            if (info != null)
            {
                return Ok(info);
            }
            else
            {
                return NotFound("Information blev ikke fundet");
            }
        }
        [HttpGet]
        [Route("{email}/iscompanymailindatabase")]
        public IActionResult IsCompanyEmailInDatabase(string email)
        {

            if (_accountService.IsCompanyEmailInDatabase(email))
            {
                return Ok(true);
            }
            else
            {
                return NotFound(false);
            }
        }
        [HttpPost]
        [Route("updatepassword")]
        public IActionResult UpdatePassword([FromBody]AccountUpdatePasswordViewModel accountviewmodel)
        {
            if (ModelState.IsValid)
            {
                if (_accountService.UpdatePassword(accountviewmodel))
                {
                    return Ok(true);
                }
                return NotFound(false);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteAccount(int id)
        {
            if (ModelState.IsValid)
            {
                if (_accountService.DeleteAccount(id))
                {
                    return Ok(true);
                }
                return NotFound(false);
            }
            return BadRequest(ModelState);
        }
    }
}
