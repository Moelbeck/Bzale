using System.Linq;
using System.Text;
using biz2biz.Repository;
using biz2biz.Repository.context;
using AutoMapper;
using biz2biz.Enums;
using biz2biz.Extension;
using biz2biz.Model;
using biz2biz.Repository.Interfaces;
using biz2biz.ViewModel.AccountViewModels;
using VATChecker;
using biz2biz.ViewModel.Account;

namespace biz2biz.Service
{
    /// <summary>
    /// AccountService is handling login, creation etc for accounts
    /// </summary>
    public class AccountService
    {
        private readonly IAccountRepository<Account> _accountRepository;
        private readonly ICompanyRepository<Company> _companyRepository;
        private SecurityService _security;
        public AccountService()
        {
            var context = new Context();
            _accountRepository = new AccountRepository(context);
            _companyRepository = new CompanyRepository(context);
            _security = new SecurityService();
        }

        /// <summary>
        /// Username can both be email and VAT number
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public AccountViewModel Login(string userName, string password)
        {
            AccountViewModel accountViewModel = null;
            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
            {
                if (userName.Contains("@"))
                {
                    Account account = null;
                    var saltandpass = _accountRepository.ValidateLogin(userName);
                    var cryptedpass = saltandpass.Values.FirstOrDefault();
                    account = _accountRepository.GetAccount(userName, cryptedpass);
                    accountViewModel = Mapper.Map<Account, AccountViewModel>(account);
                }
                else //User logs in with VAT
                {
                    Account account = null;
                    var saltandpass = _accountRepository.ValidateLogin(userName);
                    foreach (var v in saltandpass.Values)
                    {
                        var cryptedpass = v;
                        account = _accountRepository.GetAccount(userName, cryptedpass);
                        if (account != null) break;
                    }
                    accountViewModel = Mapper.Map<Account, AccountViewModel>(account);
                }
            }
            return accountViewModel;
        }

        public AccountViewModel AddNewAccountAndCompany(AccountCreateViewModel newaccount)
        {
            if (newaccount.Email.IsValidEmail() && ValidateVAT("DK", newaccount.VAT).IsValid)
            {
                Account account = Mapper.Map<AccountCreateViewModel, Account>(newaccount);
                Company cs = account.Company;

                cs = _companyRepository.AddNewCompany(cs);
                var salt = _security.GenerateSalt();
                var saltasstring = Encoding.Default.GetString(salt);
                account.Company = cs;
                var pass = _security.GenerateCryptedPassword(newaccount.Password, saltasstring);
                account.PswSalt = saltasstring;
                account.CryptedPassword = pass;
                account = _accountRepository.AddNewAccount(account);
                var accountviewmodel = Mapper.Map<Account, AccountViewModel>(account);
                return accountviewmodel;
            }
            return null;
        }

        public AccountViewModel AddNewAccount_ToCompany()
        {
            return null;
        }

        public ViesVatCheck ValidateVAT(string countrycode,string vatnumber)
        {
            ViesVatCheck validateVat = new ViesVatCheck();
            validateVat.VATNumber = vatnumber;
            validateVat.CountryCode = countrycode;
            validateVat.CheckVat();
            return validateVat;
        }

        public bool IsEmailInDatabase(int currentaccount, string email)
        {
            return _accountRepository.IsMailInDatabase(currentaccount,email.Trim().ToLower());
        }

        public bool IsEmailInDatabase(string email)
        {
            return _accountRepository.IsMailInDatabase(email.Trim().ToLower());
        }

        public AccountUpdateViewModel GetAccountInformation(int id)
        {
            Account ac = _accountRepository.GetAccount(id);
            var accountviewmodel = Mapper.Map<Account, AccountUpdateViewModel>(ac);
            return accountviewmodel;
        }

        public AccountViewModel UpdateAccountInformation(int currentaccount,AccountUpdateViewModel account)
        {
            if (currentaccount>0)
            {
                var acc = _accountRepository.GetAccount(currentaccount);
                acc.FirstName = account.FirstName.Trim().Any()?account.FirstName:acc.FirstName;
                acc.LastName = account.LastName.Trim().Any() ? account.LastName : acc.LastName;
                acc.Address = account.Address.Trim().Any() ? account.Address : acc.Address;
                acc.Email = account.Email.Trim().Any() && account.Email.IsValidEmail() ? account.Email : account.Email;
                acc.Phone = account.Phone.Trim().Any() && account.Phone.IsValidPhoneNr() ? account.Phone : acc.Phone;
                if (account.PostalCode != null) acc.PostalCode = (int) account.PostalCode;
                if (account.Gender != null) acc.Gender = (eGender) account.Gender;

                if ( acc.Company.Email!=null &&!acc.Company.Email.Any())
                    acc.Company.Email = acc.Email;
                if (acc.Company.Phone != null && !acc.Company.Phone.Any())
                    acc.Company.Phone = acc.Phone;

                var com = _companyRepository.UpdateCompany(acc.Company);
                acc.Company = com;
                acc = _accountRepository.UpdateAccount(acc);
                var accountviewmodel = Mapper.Map<Account, AccountViewModel>(acc);

                return accountviewmodel;

            }
            return null;
        }


    }
}
