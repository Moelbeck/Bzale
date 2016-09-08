using AutoMapper;
using bzale.Common;
using bzale.Extension;
using bzale.Model;
using bzale.Repository;
using bzale.Repository.DatabaseContext;
using bzale.service;
using bzale.Service;
using bzale.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;


namespace bzale.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    /// <summary>
    /// AccountService is handling login, creation etc for accounts
    /// </summary>
    public class AccountWebService : IAccountWebtService
    {
        readonly AccountRepository _accountRepository;
        readonly CompanyRepository _companyRepository;
        readonly CreateAndUpdateService _createAndUpdateService;

        public AccountWebService(BzaleDatabaseContext context)
        {
            _accountRepository = new AccountRepository(context);
            _companyRepository = new CompanyRepository(context);
            _createAndUpdateService = new CreateAndUpdateService();
        }

        public AccountDTO Login(string username, string pass)
        {
            AccountDTO accountViewModel = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(username))
                {
                    Account account = _accountRepository.GetAccount(username);
                    if (PasswordValidationService.GetInstance().ValidatePassword(pass, account.Password, account.Salt))
                    {
                        //_log.LogLoginLogout(account.ID, eLoginType.Login);
                        accountViewModel = Mapper.Map<Account, AccountDTO>(account);
                    }

                }
            }
            catch(Exception ex)
            {
                return null;
            }
            return accountViewModel;
        }
        public void Logout(string usermail)
        {
            try
            {
                //_log.LogLoginLogout(account.ID, eLoginType.Logout);
            }
            catch(Exception ex)
            {
                throw;
            }

        }
        public AccountDTO CreateNewAccount(AccountCreateDTO newaccount)
        {
            try { 
            if (newaccount.Email.IsValidEmail() && !IsEmailInDatabase(newaccount.Email))
            {
                Account account = Mapper.Map<AccountCreateDTO, Account>(newaccount);
                    if (account.Company != null && !string.IsNullOrEmpty(account.Company.VAT) && !IsVatInDatabase(account.Company.VAT))
                    {
                        account.Company = _createAndUpdateService.CreateCompanyObject(newaccount.VAT, newaccount.CompanyName, newaccount.CompanyAddress); ;
                    }
                    string salt = PasswordValidationService.GetInstance().GenerateSalt();
                account.Password = PasswordValidationService.GetInstance().GenerateCryptedPassword(newaccount.Password, salt);
                account.Salt = salt;
                account = _accountRepository.AddNewAccount(account);
                var accountviewmodel = Mapper.Map<Account, AccountDTO>(account);
                //_log.LogLoginLogout(account.ID, eLoginType.Created);
                return accountviewmodel;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public AccountDTO AddAccountToCompany(int currentAccountId, AccountCreateDTO newaccount)
        {
            try { 
            var current = _accountRepository.GetAccount(currentAccountId);
            if ((current.Type == eAccountType.Owner || current.Type == eAccountType.Administrator) && IsVatInDatabase(newaccount.VAT) && !IsEmailInDatabase(newaccount.Email))
            {
                Account account = Mapper.Map<AccountCreateDTO, Account>(newaccount);
                Company company = _companyRepository.GetCompany(newaccount.VAT);
                string salt = PasswordValidationService.GetInstance().GenerateSalt();
                account.Password = PasswordValidationService.GetInstance().GenerateCryptedPassword(newaccount.Password, salt);
                account.Salt = salt;
                account.Company = _companyRepository.AddNewCompany(company);
                account = _accountRepository.AddNewAccount(account);
                var accountviewmodel = Mapper.Map<Account, AccountDTO>(account);
                return Mapper.Map<Account,AccountDTO>(current);
            }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public CompanyDTO AddCompanyToAccount(int currentuserID, CompanyDTO newCompany)
        {
            try { 
            var current = _accountRepository.GetAccount(currentuserID);
            if (!_companyRepository.IsVatInDatabase(newCompany.VAT))
            {
                var newcompany = _createAndUpdateService.CreateCompanyObject(newCompany);
                current.Company = newcompany;
                _accountRepository.UpdateAccount(current);
                var viewmodel = Mapper.Map<Company, CompanyDTO>(newcompany);

                return viewmodel;
            }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
        public bool IsEmailInDatabase(string email)
        {
            try
            {
                return _accountRepository.IsMailInDatabase(email.Trim().ToLower());

            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public bool UpdatePassword(AccountUpdatePasswordViewModel accountviewmodel)
        {
            try
            {
                var account = _accountRepository.GetAccount(accountviewmodel.ID);
                string salt = PasswordValidationService.GetInstance().GenerateSalt();
                string oldpass = PasswordValidationService.GetInstance().GenerateCryptedPassword(accountviewmodel.OldPassword, account.Salt);
                if (oldpass.Equals(account.Password) && accountviewmodel.NewPassword.Equals(accountviewmodel.ConfirmedPassword))
                {
                    account.Password = PasswordValidationService.GetInstance().GenerateCryptedPassword(accountviewmodel.NewPassword, salt);
                    account.Salt = salt;
                    _accountRepository.UpdateAccount(account);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool IsUserVerifiedToSell(AccountDTO viewmodel)
        {
            try
            {
                Account acc = _accountRepository.GetAccount(viewmodel.ID);
                return (acc.Company != null && acc.Company.ID > 0 && !string.IsNullOrWhiteSpace(acc.Company.VAT) && acc.Company.IsVerified);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public AccountUpdateDTO GetAccountInformation(int id)
        {
            try
            {

                Account ac = _accountRepository.GetAccount(id);
                var accountviewmodel = Mapper.Map<Account, AccountUpdateDTO>(ac);
                return accountviewmodel;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public AccountDTO UpdateAccountInformation(AccountUpdateDTO viewmodel)
        {
            try
            {
                if (viewmodel.ID > 0)
                {
                    Account updatedacc = Mapper.Map<AccountUpdateDTO, Account>(viewmodel);

                    var currentaccount = _accountRepository.GetAccount(viewmodel.ID);
                    var updated = _createAndUpdateService.UpdateAccountFields(currentaccount, updatedacc);
                    updated = _accountRepository.UpdateAccount(updated);
                    var accountviewmodel = Mapper.Map<Account, AccountDTO>(updated);

                    return accountviewmodel;

                }
                return null;

            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public bool DeleteAccount(int id)
        {
            try
            {
                _accountRepository.DeleteAccount(id);
                return true;
            }
            catch ( Exception ex)
            {

                return false;
            }
        }

        public bool IsVatInDatabase(string vat)
        {
            try
            {
                return _companyRepository.IsVatInDatabase(vat);

            }
            catch (Exception ex)
            {

                throw;
            }        }

        public CompanyDTO GetCompanyInformation(string vat)
        {
            try
            {
                var company = _companyRepository.GetCompany(vat);
                CompanyDTO viewmodel = Mapper.Map<Company, CompanyDTO>(company);
                return viewmodel;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool IsCompanyEmailInDatabase(string email)
        {
            try
            {
                return _companyRepository.IsEmailInDatabase(email);
            }
            catch ( Exception ex)
            {

                throw;
            }
        }

        public CompanyDTO UpdateCompanyInformation(int currentuserId, CompanyDTO viewmodel)
        {
            try
            {
                var acccount = _accountRepository.GetAccount(currentuserId);
                if ((acccount.Type == eAccountType.Owner || acccount.Type == eAccountType.Administrator) && viewmodel.ID > 0)
                {
                    Company updatedcompany = Mapper.Map<CompanyDTO, Company>(viewmodel);
                    var currentaccount = _companyRepository.GetCompany(viewmodel.ID);
                    var updated = _createAndUpdateService.UpdateCompanyFields(currentaccount, updatedcompany);
                    updated = _companyRepository.UpdateCompany(updated);
                    var accountviewmodel = Mapper.Map<Company, CompanyDTO>(updated);
                    return accountviewmodel;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
